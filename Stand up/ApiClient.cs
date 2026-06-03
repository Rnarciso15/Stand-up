using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace Stand_up
{
    // ═══════════════════════════════════════════════════════════════════════
    //  ApiClient — camada de acesso HTTP à REST API.
    //  Responsabilidades: autenticação, transporte HTTP, serialização JSON
    //  e mapeamento de respostas para DataTable.
    //
    //  NÃO deve conter lógica de negócio — essa pertence ao ApiService.
    // ═══════════════════════════════════════════════════════════════════════
    internal static class ApiClient
    {
        // ── Configuração ─────────────────────────────────────────────────
        private static readonly string BaseUrl =
            (ConfigurationManager.AppSettings["ApiBaseUrl"] ?? "http://localhost:5196/")
            .TrimEnd('/') + "/";

        private static readonly HttpClient Http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        private static readonly JavaScriptSerializer Json = new JavaScriptSerializer
        {
            MaxJsonLength = int.MaxValue
        };

        // ── Sessão do utilizador autenticado ─────────────────────────────
        public static string UserRole       { get; private set; } = "";
        public static string UserName       { get; private set; } = "";
        public static int    EmployeeNumber { get; private set; }
        public static bool   IsAdmin        { get; private set; }
        public static string LastError      { get; private set; } = "";

        // ── Endpoints ────────────────────────────────────────────────────
        private static class Endpoints
        {
            public const string Login        = "api/auth/login";
            public const string Register     = "api/auth/register";
            public const string Vehicles     = "api/vehicles";
            public const string VehicleSearch= "api/vehicles/search";
            public const string Clients      = "api/clients";
            public const string ClientSearch = "api/clients/search";
            public const string Sales        = "api/sales";
            public const string SalesSearch  = "api/sales/search";
            public const string Appointments = "api/appointments";
            public const string VehicleImages= "api/images/vehicles";
        }

        // ════════════════════════════════════════════════════════════════
        //  AUTH
        // ════════════════════════════════════════════════════════════════

        public static (bool Ok, string Name, bool IsAdmin, string Role, string Message) Login(
            int employeeNumber, string password)
        {
            LastError = "";
            try
            {
                var body = Jb.Object(
                    Jb.Prop("employeeNumber", employeeNumber),
                    Jb.Prop("password", password));

                var resp = PostRaw(Endpoints.Login, body);
                var obj  = ParseObj(resp.Body);

                // 401 = credenciais inválidas (a API devolve a mensagem no body)
                if (resp.StatusCode == HttpStatusCode.Unauthorized)
                    return (false, "", false, "", Str(obj, "message"));

                ThrowIfNotSuccess(resp, "Login");

                bool ok = Bool(obj, "isAuthenticated");
                if (ok)
                {
                    UserRole       = Str(obj, "role");
                    UserName       = Str(obj, "name");
                    EmployeeNumber = employeeNumber;
                    IsAdmin        = Bool(obj, "isAdmin");
                    SetRoleHeader();
                }

                return (ok, Str(obj, "name"), Bool(obj, "isAdmin"), Str(obj, "role"), Str(obj, "message"));
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return (false, "", false, "", ex.Message);
            }
        }

        public static void RegisterUser(int employeeNumber, string name, string password, bool isAdmin, string role)
        {
            var body = Jb.Object(
                Jb.Prop("employeeNumber", employeeNumber),
                Jb.Prop("name",           name),
                Jb.Prop("password",       password),
                Jb.Prop("isAdmin",        isAdmin),
                Jb.Prop("role",           role));

            Post(Endpoints.Register, body);
        }

        // ════════════════════════════════════════════════════════════════
        //  VEÍCULOS
        // ════════════════════════════════════════════════════════════════

        public static DataTable GetVehicles(bool sold)
            => MapToVehicleTable(GetArray($"{Endpoints.Vehicles}?isSold={Bstr(sold)}"));

        public static DataTable SearchVehiclesByPlate(string plate, bool sold)
            => MapToVehicleTable(GetArray(
                $"{Endpoints.VehicleSearch}?licensePlate={Uri.EscapeDataString(plate)}&isSold={Bstr(sold)}"));

        public static DataTable GetVehicleByPlate(string plate)
        {
            var result = SearchVehiclesByPlate(plate, false);
            return result.Rows.Count > 0 ? result : SearchVehiclesByPlate(plate, true);
        }

        public static void CreateVehicle(string plate, int km, string brand, string model, string fuel, int price, bool isMoto)
        {
            var body = Jb.Object(
                Jb.Prop("licensePlate",  plate),
                Jb.Prop("kilometers",    km),
                Jb.Prop("brand",         brand),
                Jb.Prop("model",         model),
                Jb.Prop("fuel",          fuel),
                Jb.Prop("price",         price),
                Jb.Prop("isMotorcycle",  isMoto));

            Post(Endpoints.Vehicles, body);
        }

        public static void SetVehicleSold(string plate, bool sold)
            => Patch($"{Endpoints.Vehicles}/{Uri.EscapeDataString(plate)}/sold?isSold={Bstr(sold)}", "{}");

        // ════════════════════════════════════════════════════════════════
        //  CLIENTES
        // ════════════════════════════════════════════════════════════════

        public static DataTable GetClients()
            => MapToClientTable(GetArray(Endpoints.Clients));

        public static DataTable SearchClients(string name)
            => MapToClientTable(GetArray($"{Endpoints.ClientSearch}?name={Uri.EscapeDataString(name)}"));

        public static DataTable GetClientById(int id)
        {
            var all = GetArray(Endpoints.Clients);
            var filtered = new ArrayList();
            foreach (var item in all)
                if (item is Dictionary<string, object> c && Int(c, "id") == id)
                    filtered.Add(c);
            return MapToClientTable(filtered);
        }

        public static void CreateClient(string name, string email, string phone, string nif, string address)
        {
            var body = Jb.Object(
                Jb.Prop("name",    name),
                Jb.Prop("email",   email),
                Jb.Prop("phone",   phone),
                Jb.Prop("nif",     nif),
                Jb.Prop("address", address));

            Post(Endpoints.Clients, body);
        }

        public static void SetClientActive(int id, bool active)
            => Patch($"{Endpoints.Clients}/{id}/active?isActive={Bstr(active)}", "{}");

        // ════════════════════════════════════════════════════════════════
        //  VENDAS
        // ════════════════════════════════════════════════════════════════

        public static DataTable GetSales()
            => MapToSaleTable(GetArray(Endpoints.Sales));

        public static DataTable SearchSalesByPlate(string plate)
            => MapToSaleTable(GetArray($"{Endpoints.SalesSearch}?licensePlate={Uri.EscapeDataString(plate)}"));

        public static void CreateSale(string clientNif, string plate, string date, int value, string clientName)
        {
            var body = Jb.Object(
                Jb.Prop("clientNif",           clientNif),
                Jb.Prop("vehicleLicensePlate", plate),
                Jb.Prop("transactionDate",     date),
                Jb.Prop("value",               value),
                Jb.Prop("clientName",          clientName));

            Post(Endpoints.Sales, body);
        }

        // ════════════════════════════════════════════════════════════════
        //  MARCAÇÕES
        // ════════════════════════════════════════════════════════════════

        public static DataTable GetAppointments(DateTime date)
            => MapToAppointmentTable(GetArray($"{Endpoints.Appointments}?date={date:yyyy-MM-dd}"));

        public static void CreateAppointment(
            DateTime slot, int employeeNumber, string employeeName,
            int clientId, string clientName, string brand, string model, string plate)
        {
            // Obtém o telefone do cliente para SMS consent
            var clientRow = GetClientById(clientId);
            var phone = clientRow.Rows.Count > 0 ? clientRow.Rows[0]["telefone"]?.ToString() ?? "" : "";

            var body = Jb.Object(
                Jb.Prop("dateTimeSlot",         slot.ToString("yyyy-MM-ddTHH:mm:ss")),
                Jb.Prop("employeeNumber",        employeeNumber),
                Jb.Prop("employeeName",          employeeName),
                Jb.Prop("clientId",              clientId),
                Jb.Prop("clientName",            clientName),
                Jb.Prop("vehicleBrand",          brand),
                Jb.Prop("vehicleModel",          model),
                Jb.Prop("vehicleLicensePlate",   plate),
                Jb.Prop("clientPhone",           phone),
                Jb.Prop("smsConsentGranted",     !string.IsNullOrWhiteSpace(phone)));

            Post(Endpoints.Appointments, body);
        }

        public static void DeleteAppointment(int id)
            => Delete($"{Endpoints.Appointments}/{id}");

        // ════════════════════════════════════════════════════════════════
        //  IMAGENS
        // ════════════════════════════════════════════════════════════════

        public static DataTable GetVehicleImages(string plate)
        {
            var dt = new DataTable();
            dt.Columns.Add("Image", typeof(byte[]));
            // API devolve apenas metadata; bytes seriam devolvidos separadamente
            return dt;
        }

        public static void AddVehicleImage(byte[] image, string plate)
        {
            var base64 = Convert.ToBase64String(image ?? Array.Empty<byte>());
            Post($"{Endpoints.VehicleImages}/{Uri.EscapeDataString(plate)}", $"\"{base64}\"");
        }

        // ════════════════════════════════════════════════════════════════
        //  UTILITÁRIO PÚBLICO
        // ════════════════════════════════════════════════════════════════

        /// <summary>Marca operação sem suporte pela API atual (log + throw).</summary>
        public static void MarkNotSupported(string operation)
        {
            LastError = $"Operação não suportada pela API: {operation}";
            throw new NotSupportedException(LastError);
        }

        // ════════════════════════════════════════════════════════════════
        //  HTTP — métodos internos
        // ════════════════════════════════════════════════════════════════

        private static void SetRoleHeader()
        {
            Http.DefaultRequestHeaders.Remove("X-User-Role");
            Http.DefaultRequestHeaders.Add("X-User-Role", UserRole);
        }

        private static string Get(string path)
        {
            var response = Http.GetAsync(BaseUrl + path).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        private static (HttpStatusCode StatusCode, string Body) PostRaw(string path, string json)
        {
            var content  = new StringContent(json, Encoding.UTF8, "application/json");
            var response = Http.PostAsync(BaseUrl + path, content).Result;
            return (response.StatusCode, response.Content.ReadAsStringAsync().Result);
        }

        private static string Post(string path, string json)
        {
            var (statusCode, body) = PostRaw(path, json);
            ThrowIfNotSuccess((statusCode, body), path);
            return body;
        }

        private static string Patch(string path, string json)
        {
            var request  = new HttpRequestMessage(new HttpMethod("PATCH"), BaseUrl + path)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            var response = Http.SendAsync(request).Result;
            var body     = response.Content.ReadAsStringAsync().Result;
            ThrowIfNotSuccess((response.StatusCode, body), path);
            return body;
        }

        private static string Delete(string path)
        {
            var response = Http.DeleteAsync(BaseUrl + path).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        private static void ThrowIfNotSuccess((HttpStatusCode StatusCode, string Body) resp, string operation)
        {
            int code = (int)resp.StatusCode;
            if (code < 200 || code > 299)
            {
                LastError = $"{operation} falhou ({code}): {resp.Body}";
                throw new InvalidOperationException(LastError);
            }
        }

        // ════════════════════════════════════════════════════════════════
        //  JSON — parse
        // ════════════════════════════════════════════════════════════════

        private static Dictionary<string, object> ParseObj(string json)
        {
            var raw = Json.DeserializeObject(string.IsNullOrWhiteSpace(json) ? "{}" : json);
            return raw as Dictionary<string, object> ?? new Dictionary<string, object>();
        }

        /// <summary>Desserializa JSON array; compatível com object[] e ArrayList.</summary>
        private static ArrayList GetArray(string path)
        {
            var body = Get(path);
            var raw  = Json.DeserializeObject(string.IsNullOrWhiteSpace(body) ? "[]" : body);
            if (raw is ArrayList al)   return al;
            if (raw is object[] arr)   return new ArrayList(arr);
            return new ArrayList();
        }

        private static string Str(Dictionary<string, object> d, string key)
            => d != null && d.TryGetValue(key, out var v) && v != null ? v.ToString() : "";

        private static bool Bool(Dictionary<string, object> d, string key)
            => d != null && d.TryGetValue(key, out var v) && v is bool b && b;

        private static int Int(Dictionary<string, object> d, string key)
            => d != null && d.TryGetValue(key, out var v) && v != null
               ? Convert.ToInt32(v) : 0;

        private static string Bstr(bool value) => value ? "true" : "false";

        // ════════════════════════════════════════════════════════════════
        //  DataTable mappers
        // ════════════════════════════════════════════════════════════════

        private static DataTable MapToVehicleTable(ArrayList rows)
        {
            var dt = CreateVehicleSchema();
            foreach (var item in rows)
            {
                if (!(item is Dictionary<string, object> v)) continue;
                dt.Rows.Add(
                    Str(v, "licensePlate"), Int(v, "kilometers"), Str(v, "registrationDate"),
                    Str(v, "brand"),        Str(v, "model"),      "",
                    Str(v, "fuel"),         Array.Empty<byte>(),  Int(v, "price"),
                    "",                     "",                   0,
                    "",                     Bool(v, "isSold"),    Bool(v, "isMotorcycle"));
            }
            return dt;
        }

        private static DataTable MapToClientTable(ArrayList rows)
        {
            var dt = CreateClientSchema();
            foreach (var item in rows)
            {
                if (!(item is Dictionary<string, object> c)) continue;
                dt.Rows.Add(
                    Int(c,  "id"),       Str(c, "name"),     Str(c, "birthDate"),
                    Str(c,  "gender"),   Str(c, "email"),    Str(c, "phone"),
                    Str(c,  "nib"),      Str(c, "address"),  Str(c, "nif"),
                    Array.Empty<byte>(), Bool(c, "isActive"));
            }
            return dt;
        }

        private static DataTable MapToSaleTable(ArrayList rows)
        {
            var dt = CreateSaleSchema();
            foreach (var item in rows)
            {
                if (!(item is Dictionary<string, object> s)) continue;
                dt.Rows.Add(
                    Int(s, "id"),             Str(s, "clientNif"),
                    Str(s, "vehicleLicensePlate"), Str(s, "transactionDate"),
                    Int(s, "value"),          Str(s, "clientName"));
            }
            return dt;
        }

        private static DataTable MapToAppointmentTable(ArrayList rows)
        {
            var dt = CreateAppointmentSchema();
            foreach (var item in rows)
            {
                if (!(item is Dictionary<string, object> a)) continue;
                dt.Rows.Add(
                    Int(a, "id"),             Str(a, "dateTimeSlot"),
                    Int(a, "employeeNumber"), Str(a, "employeeName"),
                    Int(a, "clientId"),       Str(a, "clientName"),
                    Str(a, "vehicleBrand"),   Str(a, "vehicleModel"),
                    Str(a, "vehicleLicensePlate"), Array.Empty<byte>());
            }
            return dt;
        }

        // ════════════════════════════════════════════════════════════════
        //  DataTable schemas (colunas com nomes compatíveis com as forms)
        // ════════════════════════════════════════════════════════════════

        private static DataTable CreateVehicleSchema()
        {
            var dt = new DataTable();
            dt.Columns.Add("Matricula",    typeof(string));
            dt.Columns.Add("Quilometros",  typeof(int));
            dt.Columns.Add("Data",         typeof(string));
            dt.Columns.Add("Marca",        typeof(string));
            dt.Columns.Add("Modelo",       typeof(string));
            dt.Columns.Add("Descricao",    typeof(string));
            dt.Columns.Add("Combustivel",  typeof(string));
            dt.Columns.Add("Imagem",       typeof(object));
            dt.Columns.Add("Valor",        typeof(int));
            dt.Columns.Add("Cor",          typeof(string));
            dt.Columns.Add("tipo_de_caixa",typeof(string));
            dt.Columns.Add("N_Portas",     typeof(int));
            dt.Columns.Add("Traccao",      typeof(string));
            dt.Columns.Add("vendido",      typeof(bool));
            dt.Columns.Add("mota",         typeof(bool));
            return dt;
        }

        private static DataTable CreateClientSchema()
        {
            var dt = new DataTable();
            dt.Columns.Add("n_cliente",       typeof(int));
            dt.Columns.Add("nome",            typeof(string));
            dt.Columns.Add("data_nascimento", typeof(string));
            dt.Columns.Add("genero",          typeof(string));
            dt.Columns.Add("email",           typeof(string));
            dt.Columns.Add("telefone",        typeof(string));
            dt.Columns.Add("nib",             typeof(string));
            dt.Columns.Add("morada",          typeof(string));
            dt.Columns.Add("nif",             typeof(string));
            dt.Columns.Add("imagem",          typeof(object));
            dt.Columns.Add("ativo",           typeof(bool));
            return dt;
        }

        private static DataTable CreateSaleSchema()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id",        typeof(int));
            dt.Columns.Add("nif",       typeof(string));
            dt.Columns.Add("Matricula", typeof(string));
            dt.Columns.Add("data",      typeof(string));
            dt.Columns.Add("valor",     typeof(int));
            dt.Columns.Add("nome",      typeof(string));
            return dt;
        }

        private static DataTable CreateAppointmentSchema()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id",          typeof(int));
            dt.Columns.Add("data",        typeof(string));
            dt.Columns.Add("id_func",     typeof(int));
            dt.Columns.Add("nomefunc",    typeof(string));
            dt.Columns.Add("id_cliente",  typeof(int));
            dt.Columns.Add("nomecliente", typeof(string));
            dt.Columns.Add("marca",       typeof(string));
            dt.Columns.Add("modelo",      typeof(string));
            dt.Columns.Add("matricula",   typeof(string));
            dt.Columns.Add("imagemcarro", typeof(byte[]));
            return dt;
        }
    }

    // ═══════════════════════════════════════════════════════════════════════
    //  Jb (JsonBuilder) — constrói JSON de forma segura sem concatenação
    //  manual de strings.  Simples, sem dependências externas.
    // ═══════════════════════════════════════════════════════════════════════
    internal static class Jb
    {
        /// <summary>Cria objeto JSON a partir dos pares chave-valor fornecidos.</summary>
        public static string Object(params string[] properties)
            => "{" + string.Join(",", properties) + "}";

        /// <summary>Par chave:valor — trata string, int, bool e DateTime.</summary>
        public static string Prop(string key, object value)
        {
            string jsonValue;
            switch (value)
            {
                case null:
                    jsonValue = "null";
                    break;
                case bool b:
                    jsonValue = b ? "true" : "false";
                    break;
                case int i:
                    jsonValue = i.ToString();
                    break;
                case long l:
                    jsonValue = l.ToString();
                    break;
                case double d:
                    jsonValue = d.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    break;
                default:
                    jsonValue = "\"" + Escape(value.ToString()) + "\"";
                    break;
            }
            return $"\"{Escape(key)}\":{jsonValue}";
        }

        private static string Escape(string s)
            => (s ?? "")
               .Replace("\\", "\\\\")
               .Replace("\"", "\\\"")
               .Replace("\n", "\\n")
               .Replace("\r", "\\r")
               .Replace("\t", "\\t");
    }
}
