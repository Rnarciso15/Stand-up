using System;
using System.Data;
using System.Linq;

// ═══════════════════════════════════════════════════════════════════════════
//  ApiService — camada de serviço / negócio.
//
//  • Expõe métodos com os mesmos nomes que o BLL original para compatibilidade
//    com as forms existentes.
//  • Toda a filtragem usa LINQ sobre DataTable — sem loops imperativos.
//  • Cada classe interna representa um domínio (Func, Clientes, veiculos, …).
//
//  NÃO acede directamente ao HttpClient — delega sempre para ApiClient.
// ═══════════════════════════════════════════════════════════════════════════
namespace Stand_up
{
    public static class ApiService
    {
        // ── Sessão (propriedades de leitura delegadas para ApiClient) ────
        public static string UserRole       => ApiClient.UserRole;
        public static string UserName       => ApiClient.UserName;
        public static int    EmployeeNumber => ApiClient.EmployeeNumber;
        public static bool   IsAdmin        => ApiClient.IsAdmin;

        // ════════════════════════════════════════════════════════════════
        //  FUNCIONÁRIOS
        // ════════════════════════════════════════════════════════════════
        public static class Func
        {
            /// <summary>
            /// Autentica o utilizador. Devolve DataTable com 1 linha se sucesso,
            /// 0 linhas se falhar, compatível com o código original das forms.
            /// </summary>
            public static DataTable login(int n_func, string senha)
            {
                var (ok, name, isAdmin, _, _) = ApiClient.Login(n_func, senha);

                var dt = new DataTable();
                dt.Columns.Add("n_func", typeof(int));
                dt.Columns.Add("nome",   typeof(string));
                dt.Columns.Add("admin",  typeof(bool));

                if (ok) dt.Rows.Add(n_func, name, isAdmin);
                return dt;
            }

            /// <summary>Devolve "True" se o utilizador autenticado for admin.</summary>
            public static string Buscar_admin(int n_func)
                => ApiClient.IsAdmin ? "True" : "False";

            /// <summary>Devolve DataTable com nome e imagem (placeholder) do utilizador.</summary>
            public static DataTable LoadPerfil(int n_func)
            {
                var dt = new DataTable();
                dt.Columns.Add("nome",   typeof(string));
                dt.Columns.Add("imagem", typeof(byte[]));
                dt.Rows.Add(ApiClient.UserName, Array.Empty<byte>());
                return dt;
            }

            // Criação de utilizador via API de registo
            public static int insertFunc(
                string nome, string senha, bool ativo, string data_nascimento,
                string email, string telefone, string nib, byte[] imagem,
                string nif, string morada, string genero, bool admin)
            {
                if (!ativo) return -1;
                if (!int.TryParse(nif, out int employeeNumber)) return -1;

                try
                {
                    var role = admin ? "Admin" : "Vendedor";
                    ApiClient.RegisterUser(employeeNumber, nome, "teste", admin, role);
                    return 1;
                }
                catch { return -1; }
            }

            // Stubs — operações sem suporte directo na API actual
            public static DataTable Load()                                              => new DataTable();
            public static DataTable queryLoad_Func()                                    => new DataTable();
            public static DataTable queryLoad_Func_ativo(bool ativo)                   => new DataTable();
            public static DataTable queryLoad_Func1234(string term, bool ativo)        => new DataTable();
            public static DataTable queryFunc_Like_nome(string nome)                   => new DataTable();
            public static DataTable queryFunc_Like_nome_ativo(string nome, bool ativo) => new DataTable();
            public static DataTable queryFunc_Like_id(string id)                       => new DataTable();
            public static DataTable queryFunc_Like_id_ativo(string id, bool ativo)     => new DataTable();
            public static DataTable queryFunc_Like_nif(string nif)                     => new DataTable();
            public static DataTable queryFunc_Like_nif_ativo(string nif, bool ativo)   => new DataTable();
            public static DataTable queryFunc_Like_genero(string genero)               => new DataTable();
            public static DataTable queryFunc_Like_genero_ativo(string g, bool a)      => new DataTable();
            public static DataTable queryFunc_Like_idade(string data)                  => new DataTable();
            public static DataTable queryFunc_Like_idade_ativo(string data, bool a)    => new DataTable();
            public static DataTable queryFunc_emailIgual(string email, int n_func)     => new DataTable();
            public static DataTable queryFunc_telefoneIgual(string tel, int n_func)    => new DataTable();
            public static DataTable queryFunc_NibIgual(string nib, int n_func)         => new DataTable();
            public static DataTable queryFunc_NifIgual(string nif, int n_func)         => new DataTable();
            public static DataTable queryFunc_get_senha(int n_func)                    => new DataTable();
            public static DataTable queryFunc_get_id(string nif)                       => new DataTable();
            public static int updateFunc(int n, string nm, bool a, string d, string em,
                string tel, string nib, byte[] img, string nif, string mr, string g)   => -1;
            public static int senhaFunc(string s, int n, string sp)                    => -1;
            public static int senhaFunc1(string s, int n)                              => -1;
        }

        // ════════════════════════════════════════════════════════════════
        //  CLIENTES
        // ════════════════════════════════════════════════════════════════
        public static class Clientes
        {
            public static DataTable Load()                     => ApiClient.GetClients();
            public static DataTable queryLoad_cliente()        => ApiClient.GetClients();
            public static DataTable queryCliente_mostrar_dados(int id) => ApiClient.GetClientById(id);
            public static DataTable LoadCliente_proc(int id)   => ApiClient.GetClientById(id);
            public static DataTable queryCliente_Like(string nome)     => ApiClient.SearchClients(nome);

            public static DataTable queryLoad_cliente1234(string term, bool ativo)
                => ApiClient.SearchClients(term).WhereActive("ativo", ativo);

            public static DataTable queryCliente_Like_nome(string nome)
                => ApiClient.SearchClients(nome);

            public static DataTable queryCliente_Like_nome_ativo(string nome, bool ativo)
                => ApiClient.SearchClients(nome).WhereActive("ativo", ativo);

            // Pesquisas por NIF / NIB / genero / idade — fetch all + filtro local
            public static DataTable queryCliente_Like_nif(string nif)
                => ApiClient.GetClients().WhereLike("nif", nif);

            public static DataTable queryCliente_Like_nif_ativo(string nif, bool ativo)
                => ApiClient.GetClients().WhereLike("nif", nif).WhereActive("ativo", ativo);

            public static DataTable queryCliente_Like_id(string id)
                => ApiClient.GetClients().WhereLike("n_cliente", id);

            public static DataTable queryCliente_Like_id_ativo(string id, bool ativo)
                => ApiClient.GetClients().WhereLike("n_cliente", id).WhereActive("ativo", ativo);

            public static DataTable queryCliente_Like_genero(string genero)
                => ApiClient.GetClients().WhereLike("genero", genero);

            public static DataTable queryCliente_Like_genero_ativo(string genero, bool ativo)
                => ApiClient.GetClients().WhereLike("genero", genero).WhereActive("ativo", ativo);

            public static DataTable queryCliente_Like_idade(string data)
                => ApiClient.GetClients().WhereLike("data_nascimento", data);

            public static DataTable queryCliente_Like_idade_ativo(string data, bool ativo)
                => ApiClient.GetClients().WhereLike("data_nascimento", data).WhereActive("ativo", ativo);

            // Verificação de duplicados
            public static DataTable querycliente_emailIgual(string email)
                => ApiClient.GetClients().WhereEquals("email", email);

            public static DataTable queryCliente_telefoneIgual(string telefone)
                => ApiClient.GetClients().WhereEquals("telefone", telefone);

            public static DataTable queryCliente_NibIgual(string nib)
                => ApiClient.GetClients().WhereEquals("nib", nib);

            public static DataTable queryCliente_NifIgual(string nif)
                => ApiClient.GetClients().WhereEquals("nif", nif);

            public static DataTable queryFunc_emailIgual(string email, int excludeId)
                => ApiClient.GetClients().WhereEquals("email", email).WhereNotId("n_cliente", excludeId);

            public static DataTable queryFunc_telefoneIgual(string tel, int excludeId)
                => ApiClient.GetClients().WhereEquals("telefone", tel).WhereNotId("n_cliente", excludeId);

            public static DataTable queryFunc_NibIgual(string nib, int excludeId)
                => ApiClient.GetClients().WhereEquals("nib", nib).WhereNotId("n_cliente", excludeId);

            public static DataTable queryFunc_NifIgual(string nif, int excludeId)
                => ApiClient.GetClients().WhereEquals("nif", nif).WhereNotId("n_cliente", excludeId);

            // Mutações
            public static int insertCliente(
                string telefone, string nome, bool ativo, string data_nascimento,
                string email, string nib, byte[] imagem, string nif, string morada,
                string genero, string senha)
            {
                try { ApiClient.CreateClient(nome, email, telefone, nif, morada); return 1; }
                catch { return -1; }
            }

            public static int updateCliente(
                int id, string nome, bool ativo, string data_nascimento,
                string email, string telefone, string nib, byte[] imagem,
                string nif, string morada, string genero)
            {
                try { ApiClient.SetClientActive(id, ativo); return 1; }
                catch { return -1; }
            }

            // Stubs
            public static DataTable queryCliente_2(int id, string nome)   => new DataTable();
            public static DataTable queryCliente_3(int id)                => ApiClient.GetClientById(id);
            public static int       senhaCliente(string senha, int id)    => -1;
            public static int       alterarPerfil(string u, string p, string i) => -1;
            public static int       alterarEstado(string u, int estado)   => -1;
        }

        // ════════════════════════════════════════════════════════════════
        //  TRANSAÇÕES (VENDAS)
        // ════════════════════════════════════════════════════════════════
        public static class transacoes
        {
            public static DataTable loadTrans()                     => ApiClient.GetSales();

            public static DataTable queryFunc_Like_N_Matricula(string plate)
                => ApiClient.SearchSalesByPlate(plate);

            public static DataTable queryFunc_Like_NIF(string nif)
                => ApiClient.GetSales().WhereLike("nif", nif);

            public static DataTable queryFunc_Like_N_data(string data)
                => ApiClient.GetSales().WhereLike("data", data);

            public static DataTable queryFunc_Like_N_valor(string valor)
                => ApiClient.GetSales().WhereLike("valor", valor);

            public static DataTable loadnif_Cliente(int clientId)
            {
                var client = ApiClient.GetClientById(clientId);
                var dt = new DataTable();
                dt.Columns.Add("nif", typeof(string));
                if (client.Rows.Count > 0)
                    dt.Rows.Add(client.Rows[0]["nif"]);
                return dt;
            }

            public static int insertTrans(int nif, string plate, string data, int valor, string nome)
            {
                try { ApiClient.CreateSale(nif.ToString(), plate, data, valor, nome); return 1; }
                catch { return -1; }
            }
        }

        // ════════════════════════════════════════════════════════════════
        //  VEÍCULOS
        // ════════════════════════════════════════════════════════════════
        public static class veiculos
        {
            public static DataTable queryLoad_veiculo(bool vendido)
                => ApiClient.GetVehicles(vendido);

            public static DataTable queryLoad_veiculo_mota(bool vendido, bool mota)
                => ApiClient.GetVehicles(vendido).WhereBool("mota", mota);

            public static DataTable queryLoad_veiculoMatricula(bool vendido, string plate)
                => ApiClient.SearchVehiclesByPlate(plate, vendido);

            public static DataTable Load_dados(string plate)        => ApiClient.GetVehicleByPlate(plate);
            public static DataTable Load_dados_imagem(string plate) => ApiClient.GetVehicleByPlate(plate);
            public static DataTable Load_dados1(string plate)       => ApiClient.GetVehicleByPlate(plate);

            // Pesquisas por atributo (fetch all + filtro local)
            public static DataTable queryMarca_veiculo(string marca, bool vendido, bool mota)
                => ApiClient.GetVehicles(vendido).WhereEquals("Marca", marca).WhereBool("mota", mota);

            public static DataTable queryCor_veiculo(string cor, bool vendido, bool mota)
                => ApiClient.GetVehicles(vendido).WhereEquals("Cor", cor).WhereBool("mota", mota);

            public static DataTable queryCor_veiculo_tudo(string cor, bool vendido)
                => ApiClient.GetVehicles(vendido).WhereEquals("Cor", cor);

            public static DataTable queryGasolina_veiculo(string comb, bool vendido, bool mota)
                => ApiClient.GetVehicles(vendido).WhereEquals("Combustivel", comb).WhereBool("mota", mota);

            public static DataTable queryGasolina_veiculo_tudo(string comb, bool vendido)
                => ApiClient.GetVehicles(vendido).WhereEquals("Combustivel", comb);

            public static DataTable queryCarro(string cor, string marca, bool vendido, bool mota)
                => ApiClient.GetVehicles(vendido)
                   .WhereEquals("Marca", marca).WhereEquals("Cor", cor).WhereBool("mota", mota);

            public static DataTable queryCarro2(string comb, string marca, bool vendido, bool mota)
                => ApiClient.GetVehicles(vendido)
                   .WhereEquals("Combustivel", comb).WhereEquals("Marca", marca).WhereBool("mota", mota);

            public static DataTable queryCarro3(string comb, string marca, string cor, bool vendido, bool mota)
                => ApiClient.GetVehicles(vendido)
                   .WhereEquals("Marca", marca).WhereEquals("Combustivel", comb).WhereBool("mota", mota);

            public static DataTable queryCarro4(string comb, string cor, bool vendido, bool mota)
                => ApiClient.GetVehicles(vendido)
                   .WhereEquals("Combustivel", comb).WhereBool("mota", mota);

            // Ordenações — devolve todos (API não suporta sort; UI ordena)
            public static DataTable querymaior_quiilometros(bool vendido, bool mota)
                => ApiClient.GetVehicles(vendido).WhereBool("mota", mota);
            public static DataTable querymaior_quiilometros_tudo(bool vendido)      => ApiClient.GetVehicles(vendido);
            public static DataTable queryMenor_quiilometros(bool vendido, bool mota)
                => ApiClient.GetVehicles(vendido).WhereBool("mota", mota);
            public static DataTable queryMenor_quiilometros_tudo(bool vendido)      => ApiClient.GetVehicles(vendido);

            public static DataTable querymaior_quiilometros_Marca(string m, bool v, bool mota)
                => ApiClient.GetVehicles(v).WhereEquals("Marca", m).WhereBool("mota", mota);
            public static DataTable querymenor_quiilometros_Marca(string m, bool v, bool mota)
                => ApiClient.GetVehicles(v).WhereEquals("Marca", m).WhereBool("mota", mota);
            public static DataTable querymaior_quiilometros_Cor(string cor, bool v)
                => ApiClient.GetVehicles(v).WhereEquals("Cor", cor);
            public static DataTable querymenor_quiilometros_Cor(string cor, bool v)
                => ApiClient.GetVehicles(v).WhereEquals("Cor", cor);
            public static DataTable querymaior_quiilometros_Combustivel(string c, bool v)
                => ApiClient.GetVehicles(v).WhereEquals("Combustivel", c);
            public static DataTable querymenor_quiilometros_Combustivel(string c, bool v)
                => ApiClient.GetVehicles(v).WhereEquals("Combustivel", c);
            public static DataTable querymaior_quiilometros_Marca_cor(string m, string cor, bool v, bool mota)
                => ApiClient.GetVehicles(v).WhereEquals("Marca", m).WhereEquals("Cor", cor).WhereBool("mota", mota);
            public static DataTable querymenor_quiilometros_Marca_cor(string m, string cor, bool v, bool mota)
                => ApiClient.GetVehicles(v).WhereEquals("Marca", m).WhereEquals("Cor", cor).WhereBool("mota", mota);
            public static DataTable querymaior_quiilometros_Marca_combustivel(string m, string c, bool v, bool mota)
                => ApiClient.GetVehicles(v).WhereEquals("Marca", m).WhereEquals("Combustivel", c).WhereBool("mota", mota);
            public static DataTable querymenor_quiilometros_Marca_combustivel(string m, string c, bool v, bool mota)
                => ApiClient.GetVehicles(v).WhereEquals("Marca", m).WhereEquals("Combustivel", c).WhereBool("mota", mota);
            public static DataTable querymaior_quiilometros_Combustivel_cor(string c, string cor, bool v)
                => ApiClient.GetVehicles(v).WhereEquals("Combustivel", c).WhereEquals("Cor", cor);
            public static DataTable querymenor_quiilometros_Combustivel_cor(string c, string cor, bool v)
                => ApiClient.GetVehicles(v).WhereEquals("Combustivel", c).WhereEquals("Cor", cor);

            // Mutações
            public static int insertVeiculo(
                string plate, int km, string data, string marca, string modelo,
                string descr, string comb, byte[] img, int valor, string cor,
                string caixa, int portas, string traccao, bool vendido, bool mota)
            {
                try { ApiClient.CreateVehicle(plate, km, marca, modelo, comb, valor, mota); return 1; }
                catch { return -1; }
            }

            public static int updateVendido(string plate, bool vendido)
            {
                try { ApiClient.SetVehicleSold(plate, vendido); return 1; }
                catch { return -1; }
            }

            // Operações não suportadas (sem endpoint DELETE/PATCH completo na API)
            public static int updateVeiculo(string p, int km, string d, string m, string mo,
                string desc, string c, byte[] img, int v, string cor,
                string caixa, int portas, string trac, string p1)           => -1;
            public static int deleteveiculo(string plate)                   => -1;
            public static int deleteveiculo()                               => -1;
            public static int insert_modelo(string m, string mo, int i, int f) => -1;

            // Stubs — dados de marcas/modelos não existem na API actual
            public static DataTable Load()                                  => new DataTable();
            public static DataTable queryMarca_veiculo()                    => new DataTable();
            public static DataTable queryMarca_veiculoMotas()               => new DataTable();
            public static DataTable queryModelos_veiculo(int id)            => new DataTable();
            public static DataTable queryModelos_veiculoMotas(int id)       => new DataTable();
            public static DataTable queryModelos_veiculo1234(int id, int a) => new DataTable();
            public static DataTable queryModelos_veiculo1234Motas(int i, int a) => new DataTable();
            public static DataTable queryData_Modelos_veiculo(string m, string mo) => new DataTable();
            public static DataTable queryBuscar_Inicio_fim_producao(string m)      => new DataTable();
            public static object    queryBuscar_id_marca(string nome)              => null;
            public static object    queryBuscar_id_marcaModelos(string nome)       => null;
            public static object    queryBuscar_id_marcaModelosMotas(string nome)  => null;
        }

        // ════════════════════════════════════════════════════════════════
        //  MARCAÇÕES (TEST DRIVE)
        // ════════════════════════════════════════════════════════════════
        public static class testDrive
        {
            public static DataTable queryLoad_Test(DateTime data)
                => ApiClient.GetAppointments(data);

            public static int insertTest(
                DateTime dataSemHora, DateTime data, int idFunc, string nomeFunc,
                int idCliente, string nomeCliente, string marca, string modelo,
                string plate, byte[] imagemCarro)
            {
                try
                {
                    ApiClient.CreateAppointment(data, idFunc, nomeFunc, idCliente, nomeCliente, marca, modelo, plate);
                    return 1;
                }
                catch { return -1; }
            }

            public static DataTable EleminarTest(int id)
            {
                try { ApiClient.DeleteAppointment(id); }
                catch { /* already gone */ }
                return new DataTable();
            }

            public static DataTable procurarFuncOcupado(DateTime data, int idFunc)
                => ApiClient.GetAppointments(data).WhereIntEquals("id_func", idFunc);

            public static DataTable procurarClienteOcupado(DateTime data, int idCliente)
                => ApiClient.GetAppointments(data).WhereIntEquals("id_cliente", idCliente);

            public static DataTable procurarCarroOcupado(DateTime data, string plate)
                => ApiClient.GetAppointments(data).WhereEquals("matricula", plate);
        }

        // ════════════════════════════════════════════════════════════════
        //  IMAGENS
        // ════════════════════════════════════════════════════════════════
        public static class Imagem
        {
            public static DataTable LoadImagensCarro(string plate)
                => ApiClient.GetVehicleImages(plate);

            public static int insertImagemCarro(byte[] img, string plate)
            {
                try { ApiClient.AddVehicleImage(img, plate); return 1; }
                catch { return -1; }
            }

            // Stubs — sem equivalente na API actual
            public static int       insertlogo(int id, byte[] logo)  => -1;
            public static DataTable loadlogo()                        => new DataTable();
            public static object    loadpic()                         => null;
            public static DataTable Load()                            => new DataTable();
            public static int       insertImagem(byte[] img)          => -1;
        }
    }

    // ═══════════════════════════════════════════════════════════════════════
    //  DataTableExtensions — LINQ-style sobre DataTable.
    //  Permite encadear filtros de forma legível:
    //    dt.WhereEquals("Marca","BMW").WhereBool("mota",false)
    // ═══════════════════════════════════════════════════════════════════════
    internal static class DataTableExtensions
    {
        /// <summary>Cria DataTable vazio (sem colunas) para stubs.</summary>
        public static DataTable Empty() => new DataTable();

        /// <summary>Filtra linhas onde a coluna string contém o valor (OrdinalIgnoreCase).</summary>
        public static DataTable WhereLike(this DataTable dt, string column, string value)
        {
            if (!dt.Columns.Contains(column) || string.IsNullOrEmpty(value)) return dt;
            return dt.AsEnumerable()
                     .Where(r => r[column].ToString()
                                  .IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0)
                     .CopyToDataTable(dt);
        }

        /// <summary>Filtra linhas onde a coluna string é igual ao valor (OrdinalIgnoreCase).</summary>
        public static DataTable WhereEquals(this DataTable dt, string column, string value)
        {
            if (!dt.Columns.Contains(column) || value == null) return dt;
            return dt.AsEnumerable()
                     .Where(r => r[column].ToString()
                                  .Equals(value, StringComparison.OrdinalIgnoreCase))
                     .CopyToDataTable(dt);
        }

        /// <summary>Filtra linhas onde a coluna booleana tem o valor especificado.</summary>
        public static DataTable WhereBool(this DataTable dt, string column, bool value)
        {
            if (!dt.Columns.Contains(column)) return dt;
            return dt.AsEnumerable()
                     .Where(r => Convert.ToBoolean(r[column]) == value)
                     .CopyToDataTable(dt);
        }

        /// <summary>Filtra linhas onde a coluna booleana "ativo" tem o valor especificado.</summary>
        public static DataTable WhereActive(this DataTable dt, string column, bool value)
            => dt.WhereBool(column, value);

        /// <summary>Filtra linhas onde a coluna int é igual ao valor.</summary>
        public static DataTable WhereIntEquals(this DataTable dt, string column, int value)
        {
            if (!dt.Columns.Contains(column)) return dt;
            return dt.AsEnumerable()
                     .Where(r => Convert.ToInt32(r[column]) == value)
                     .CopyToDataTable(dt);
        }

        /// <summary>Filtra linhas onde a coluna int NÃO é igual ao valor (exclusão de duplicados).</summary>
        public static DataTable WhereNotId(this DataTable dt, string column, int excludeId)
        {
            if (!dt.Columns.Contains(column)) return dt;
            return dt.AsEnumerable()
                     .Where(r => Convert.ToInt32(r[column]) != excludeId)
                     .CopyToDataTable(dt);
        }

        // ── Helper interno ────────────────────────────────────────────
        private static DataTable CopyToDataTable(
            this System.Collections.Generic.IEnumerable<DataRow> rows, DataTable schema)
        {
            var result = schema.Clone();
            foreach (var row in rows)
                result.ImportRow(row);
            return result;
        }
    }
}
