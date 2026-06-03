using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Persistence;

public static class DbInitializer
{
    public static async Task InitializeAsync(StandUpDbContext dbContext, CancellationToken cancellationToken = default)
    {
        await dbContext.Database.MigrateAsync(cancellationToken);
        await SeedDemoDataAsync(dbContext, cancellationToken);
    }

    private static async Task SeedDemoDataAsync(StandUpDbContext dbContext, CancellationToken cancellationToken)
    {
        // ── CLIENTES (60) ────────────────────────────────────────────────────
        if (!await dbContext.Clients.AnyAsync(cancellationToken))
        {
            dbContext.Clients.AddRange(SeedClients());
        }

        // ── VEÍCULOS (120) ───────────────────────────────────────────────────
        if (!await dbContext.Vehicles.AnyAsync(cancellationToken))
        {
            dbContext.Vehicles.AddRange(SeedVehicles());
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        // ── MARCAÇÕES (100) ──────────────────────────────────────────────────
        if (!await dbContext.Appointments.AnyAsync(cancellationToken))
        {
            var clients  = await dbContext.Clients.ToListAsync(cancellationToken);
            var vehicles = await dbContext.Vehicles.Where(v => !v.IsSold).ToListAsync(cancellationToken);
            if (clients.Count > 0 && vehicles.Count > 0)
                dbContext.Appointments.AddRange(SeedAppointments(clients, vehicles));
        }

        // ── VENDAS (80) ──────────────────────────────────────────────────────
        if (!await dbContext.SaleTransactions.AnyAsync(cancellationToken))
        {
            var clients  = await dbContext.Clients.ToListAsync(cancellationToken);
            var soldVehicles = await dbContext.Vehicles.Where(v => v.IsSold).ToListAsync(cancellationToken);
            if (clients.Count > 0 && soldVehicles.Count > 0)
                dbContext.SaleTransactions.AddRange(SeedSales(clients, soldVehicles));
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        // ── IMAGENS DE VEÍCULOS (120 × até 6 via Wikimedia Commons) ────────
        if (!await dbContext.VehicleImages.AnyAsync(cancellationToken))
        {
            Console.WriteLine("[Seed] A iniciar download de imagens via Wikimedia Commons...");
            try
            {
                var vehicles = await dbContext.Vehicles
                    .Select(v => new { v.LicensePlate, v.Brand, v.Model, v.IsMotorcycle })
                    .ToListAsync(cancellationToken);

                using var http = new System.Net.Http.HttpClient { Timeout = TimeSpan.FromSeconds(25) };
                http.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "StandUpDealerApp/1.0");

                var toSave = new List<VehicleImage>();
                int done   = 0;

                // Processamento sequencial + delay para respeitar rate limits da Wikipedia
                foreach (var v in vehicles)
                {
                    var urls = await FindWikipediaImageUrlsAsync(http, v.Brand, v.Model, v.IsMotorcycle, cancellationToken);
                    int saved = 0;
                    foreach (var url in urls)
                    {
                        try
                        {
                            var data = await http.GetByteArrayAsync(url, cancellationToken);
                            if (data.Length < 8_000) continue;
                            toSave.Add(new VehicleImage
                            {
                                VehicleLicensePlate = v.LicensePlate,
                                Data                = data,
                                CreatedAt           = DateTime.UtcNow
                            });
                            saved++;
                        }
                        catch { }
                    }
                    done++;
                    Console.WriteLine($"[Seed] {done}/{vehicles.Count} - {v.Brand} {v.Model}: {saved} imagem(ns)");
                    await Task.Delay(350, cancellationToken);
                }

                if (toSave.Count > 0)
                {
                    Console.WriteLine($"[Seed] A guardar {toSave.Count} imagens na BD...");
                    dbContext.VehicleImages.AddRange(toSave);
                    await dbContext.SaveChangesAsync(cancellationToken);
                    Console.WriteLine("[Seed] Imagens guardadas com sucesso.");
                }
                else
                {
                    Console.WriteLine("[Seed] AVISO: Nenhuma imagem descarregada (sem rede?).");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Seed] ERRO no seed de imagens: {ex.Message}");
            }
        }
    }

    private static async Task<List<string>> FindWikipediaImageUrlsAsync(
        System.Net.Http.HttpClient http, string brand, string model, bool isMoto, CancellationToken ct)
    {
        var urls = new List<string>();

        // Algumas marcas têm nomes diferentes na Wikipedia
        var wBrand = brand switch
        {
            "Mercedes"        => "Mercedes-Benz",
            "Land Rover"      => "Land Rover",
            "Range Rover"     => "Range Rover",
            "Alfa Romeo"      => "Alfa Romeo",
            "Harley-Davidson" => "Harley-Davidson",
            _                 => brand
        };

        // Variantes de título, da mais específica para a mais geral
        // ex: "BMW M3 Competition" → "BMW M3" → "BMW" (último recurso)
        var words  = model.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var titles = new List<string>();
        titles.Add($"{wBrand} {model}");                                    // completo
        if (words.Length > 2) titles.Add($"{wBrand} {words[0]} {words[1]}"); // 2 palavras
        if (words.Length > 1) titles.Add($"{wBrand} {words[0]}");            // 1 palavra
        titles.Add(wBrand);                                                 // só a marca

        foreach (var rawTitle in titles)
        {
            if (urls.Count >= 4) break;
            var enc = Uri.EscapeDataString(rawTitle.Replace(' ', '_'));

            // Tentar media-list: devolve várias imagens do artigo (pode dar 404 → exception)
            try
            {
                var json = await http.GetStringAsync(
                    $"https://en.wikipedia.org/api/rest_v1/page/media-list/{enc}", ct);
                using var doc = System.Text.Json.JsonDocument.Parse(json);

                if (doc.RootElement.TryGetProperty("items", out var items))
                {
                    foreach (var item in items.EnumerateArray())
                    {
                        if (urls.Count >= 4) break;
                        if (!item.TryGetProperty("type",   out var tEl) || tEl.GetString() != "image") continue;
                        if (!item.TryGetProperty("srcset", out var ss)) continue;

                        string? best = null;
                        foreach (var s in ss.EnumerateArray())
                        {
                            if (!s.TryGetProperty("src", out var srcEl)) continue;
                            var raw = srcEl.GetString() ?? "";
                            if (!raw.EndsWith(".jpg",  StringComparison.OrdinalIgnoreCase) &&
                                !raw.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)) continue;
                            best = raw.StartsWith("//") ? "https:" + raw : raw;
                        }
                        if (best is not null) urls.Add(best);
                    }
                }
            }
            catch { }

            // Tentar summary: segue redirects automaticamente (BMW_M3_Competition → BMW_M3)
            // Garante pelo menos 1 imagem mesmo para variantes sem artigo próprio
            if (urls.Count == 0)
            {
                try
                {
                    var json = await http.GetStringAsync(
                        $"https://en.wikipedia.org/api/rest_v1/page/summary/{enc}", ct);
                    using var doc = System.Text.Json.JsonDocument.Parse(json);

                    var imgUrl =
                        (doc.RootElement.TryGetProperty("originalimage", out var orig) &&
                         orig.TryGetProperty("source", out var s1) ? s1.GetString() : null) ??
                        (doc.RootElement.TryGetProperty("thumbnail",     out var tn)   &&
                         tn.TryGetProperty("source",   out var s2) ? s2.GetString() : null);

                    if (!string.IsNullOrEmpty(imgUrl)) urls.Add(imgUrl!);
                }
                catch { }
            }

            // Se já temos imagens desta variante, não precisamos da próxima
            if (urls.Count > 0) break;
        }

        return urls;
    }

    // ════════════════════════════════════════════════════════════════════════
    //  CLIENTES — 60 registos
    // ════════════════════════════════════════════════════════════════════════
    private static IEnumerable<Client> SeedClients() =>
    [
        new() { Name="João Silva",          Email="joao.silva@email.pt",          Phone="+351910001001", Nif="123456001", Address="Rua Augusta 12, Lisboa",             IsActive=true  },
        new() { Name="Maria Santos",        Email="maria.santos@email.pt",        Phone="+351910001002", Nif="123456002", Address="Av. Aliados 88, Porto",               IsActive=true  },
        new() { Name="Carlos Ferreira",     Email="carlos.ferreira@email.pt",     Phone="+351920001003", Nif="123456003", Address="Rua de Coimbra 5, Coimbra",           IsActive=true  },
        new() { Name="Ana Pereira",         Email="ana.pereira@email.pt",         Phone="+351930001004", Nif="123456004", Address="Largo do Toural 3, Guimarães",        IsActive=true  },
        new() { Name="Rui Costa",           Email="rui.costa@email.pt",           Phone="+351960001005", Nif="123456005", Address="Av. da Liberdade 200, Lisboa",        IsActive=true  },
        new() { Name="Sofia Rodrigues",     Email="sofia.rodrigues@email.pt",     Phone="+351910001006", Nif="123456006", Address="Rua do Ouro 45, Lisboa",              IsActive=true  },
        new() { Name="Pedro Oliveira",      Email="pedro.oliveira@email.pt",      Phone="+351920001007", Nif="123456007", Address="Travessa da Bainharia 9, Porto",      IsActive=true  },
        new() { Name="Marta Gonçalves",     Email="marta.goncalves@email.pt",     Phone="+351930001008", Nif="123456008", Address="Rua da Palma 67, Lisboa",             IsActive=true  },
        new() { Name="Tiago Martins",       Email="tiago.martins@email.pt",       Phone="+351960001009", Nif="123456009", Address="Rua de Santa Catarina 120, Porto",    IsActive=true  },
        new() { Name="Beatriz Alves",       Email="beatriz.alves@email.pt",       Phone="+351910001010", Nif="123456010", Address="Alameda Dom Afonso Henriques, Lisboa",IsActive=true  },
        new() { Name="Miguel Sousa",        Email="miguel.sousa@email.pt",        Phone="+351920001011", Nif="123456011", Address="Praça da República 15, Braga",        IsActive=true  },
        new() { Name="Catarina Nunes",      Email="catarina.nunes@email.pt",      Phone="+351930001012", Nif="123456012", Address="Rua do Carmo 33, Lisboa",             IsActive=true  },
        new() { Name="André Carvalho",      Email="andre.carvalho@email.pt",      Phone="+351960001013", Nif="123456013", Address="Rua Direita 77, Évora",               IsActive=true  },
        new() { Name="Inês Ribeiro",        Email="ines.ribeiro@email.pt",        Phone="+351910001014", Nif="123456014", Address="Av. dos Aliados 22, Porto",           IsActive=true  },
        new() { Name="Luís Mendes",         Email="luis.mendes@email.pt",         Phone="+351920001015", Nif="123456015", Address="Rua da Graça 8, Lisboa",              IsActive=true  },
        new() { Name="Filipa Lopes",        Email="filipa.lopes@email.pt",        Phone="+351930001016", Nif="123456016", Address="Rua de Cedofeita 55, Porto",          IsActive=true  },
        new() { Name="Nuno Araújo",         Email="nuno.araujo@email.pt",         Phone="+351960001017", Nif="123456017", Address="Av. da Boavista 300, Porto",          IsActive=true  },
        new() { Name="Patrícia Vieira",     Email="patricia.vieira@email.pt",     Phone="+351910001018", Nif="123456018", Address="Rua do Almada 90, Porto",             IsActive=true  },
        new() { Name="Ricardo Monteiro",    Email="ricardo.monteiro@email.pt",    Phone="+351920001019", Nif="123456019", Address="Rua do Norte 14, Faro",               IsActive=true  },
        new() { Name="Susana Fernandes",    Email="susana.fernandes@email.pt",    Phone="+351930001020", Nif="123456020", Address="Largo de São Domingos 7, Lisboa",     IsActive=true  },
        new() { Name="Diogo Teixeira",      Email="diogo.teixeira@email.pt",      Phone="+351960001021", Nif="123456021", Address="Rua da Madalena 38, Lisboa",          IsActive=true  },
        new() { Name="Vera Pinto",          Email="vera.pinto@email.pt",          Phone="+351910001022", Nif="123456022", Address="Av. Central 11, Braga",               IsActive=true  },
        new() { Name="Henrique Correia",    Email="henrique.correia@email.pt",    Phone="+351920001023", Nif="123456023", Address="Rua de Santo António 66, Setúbal",    IsActive=true  },
        new() { Name="Margarida Castro",    Email="margarida.castro@email.pt",    Phone="+351930001024", Nif="123456024", Address="Travessa do Fala-Só 2, Lisboa",       IsActive=true  },
        new() { Name="Francisco Lima",      Email="francisco.lima@email.pt",      Phone="+351960001025", Nif="123456025", Address="Rua Nova 44, Setúbal",                IsActive=true  },
        new() { Name="Alexandra Morais",    Email="alexandra.morais@email.pt",    Phone="+351910001026", Nif="123456026", Address="Rua das Flores 19, Porto",            IsActive=true  },
        new() { Name="Gonçalo Reis",        Email="goncalo.reis@email.pt",        Phone="+351920001027", Nif="123456027", Address="Av. Engenheiro Duarte Pacheco, Lisboa",IsActive=true  },
        new() { Name="Daniela Melo",        Email="daniela.melo@email.pt",        Phone="+351930001028", Nif="123456028", Address="Rua de Azurara 5, Vila do Conde",     IsActive=true  },
        new() { Name="Paulo Nogueira",      Email="paulo.nogueira@email.pt",      Phone="+351960001029", Nif="123456029", Address="Rua da Junqueira 120, Lisboa",        IsActive=true  },
        new() { Name="Joana Cardoso",       Email="joana.cardoso@email.pt",       Phone="+351910001030", Nif="123456030", Address="Praça do Município 1, Cascais",       IsActive=true  },
        new() { Name="Marcos Duarte",       Email="marcos.duarte@email.pt",       Phone="+351920001031", Nif="123456031", Address="Rua de Entrecampos 88, Lisboa",       IsActive=true  },
        new() { Name="Cristina Barros",     Email="cristina.barros@email.pt",     Phone="+351930001032", Nif="123456032", Address="Av. de Roma 55, Lisboa",              IsActive=true  },
        new() { Name="Sérgio Simões",       Email="sergio.simoes@email.pt",       Phone="+351960001033", Nif="123456033", Address="Rua da Boavista 7, Coimbra",          IsActive=true  },
        new() { Name="Carla Fonseca",       Email="carla.fonseca@email.pt",       Phone="+351910001034", Nif="123456034", Address="Rua de Fernão de Magalhães 41, Porto",IsActive=true  },
        new() { Name="Bruno Azevedo",       Email="bruno.azevedo@email.pt",       Phone="+351920001035", Nif="123456035", Address="Rua da Alegria 3, Lisboa",            IsActive=true  },
        new() { Name="Léa Domingues",       Email="lea.domingues@email.pt",       Phone="+351930001036", Nif="123456036", Address="Largo do Rato 12, Lisboa",            IsActive=true  },
        new() { Name="Tomás Baptista",      Email="tomas.baptista@email.pt",      Phone="+351960001037", Nif="123456037", Address="Rua da Praia 88, Setúbal",            IsActive=true  },
        new() { Name="Raquel Esteves",      Email="raquel.esteves@email.pt",      Phone="+351910001038", Nif="123456038", Address="Rua de Passos Manuel 30, Porto",      IsActive=true  },
        new() { Name="Eduardo Branco",      Email="eduardo.branco@email.pt",      Phone="+351920001039", Nif="123456039", Address="Av. 5 de Outubro 150, Lisboa",        IsActive=true  },
        new() { Name="Liliana Cunha",       Email="liliana.cunha@email.pt",       Phone="+351930001040", Nif="123456040", Address="Rua da Palma 33, Braga",              IsActive=true  },
        new() { Name="Hugo Borges",         Email="hugo.borges@email.pt",         Phone="+351960001041", Nif="123456041", Address="Rua de Miguel Bombarda 9, Porto",     IsActive=true  },
        new() { Name="Elisa Pacheco",       Email="elisa.pacheco@email.pt",       Phone="+351910001042", Nif="123456042", Address="Av. António Augusto de Aguiar 44, Lisboa", IsActive=true },
        new() { Name="Samuel Macedo",       Email="samuel.macedo@email.pt",       Phone="+351920001043", Nif="123456043", Address="Rua de Belém 22, Lisboa",             IsActive=true  },
        new() { Name="Mónica Queirós",      Email="monica.queiros@email.pt",      Phone="+351930001044", Nif="123456044", Address="Praça da Batalha 6, Porto",           IsActive=true  },
        new() { Name="Afonso Peixoto",      Email="afonso.peixoto@email.pt",      Phone="+351960001045", Nif="123456045", Address="Rua das Taipas 17, Guimarães",        IsActive=true  },
        new() { Name="Bárbara Magalhães",   Email="barbara.magalhaes@email.pt",   Phone="+351910001046", Nif="123456046", Address="Rua da Escola Politécnica 58, Lisboa",IsActive=true  },
        new() { Name="Cláudio Torres",      Email="claudio.torres@email.pt",      Phone="+351920001047", Nif="123456047", Address="Rua da Bandeirinha 3, Leiria",        IsActive=true  },
        new() { Name="Diana Rocha",         Email="diana.rocha@email.pt",         Phone="+351930001048", Nif="123456048", Address="Travessa do Carvalho 8, Viseu",       IsActive=true  },
        new() { Name="Emanuel Marques",     Email="emanuel.marques@email.pt",     Phone="+351960001049", Nif="123456049", Address="Rua do Almada 77, Porto",             IsActive=true  },
        new() { Name="Filomena Gomes",      Email="filomena.gomes@email.pt",      Phone="+351910001050", Nif="123456050", Address="Rua Direita 14, Viana do Castelo",    IsActive=true  },
        new() { Name="Gustavo Freitas",     Email="gustavo.freitas@email.pt",     Phone="+351920001051", Nif="123456051", Address="Av. Brasil 200, Lisboa",              IsActive=true  },
        new() { Name="Helena Xavier",       Email="helena.xavier@email.pt",       Phone="+351930001052", Nif="123456052", Address="Rua do Campo Alegre 90, Porto",       IsActive=true  },
        new() { Name="Igor Neves",          Email="igor.neves@email.pt",          Phone="+351960001053", Nif="123456053", Address="Rua Dr. Sousa Martins 4, Lisboa",     IsActive=true  },
        new() { Name="Juliana Leite",       Email="juliana.leite@email.pt",       Phone="+351910001054", Nif="123456054", Address="Rua da Torrinha 19, Porto",           IsActive=true  },
        new() { Name="Kevin Andrade",       Email="kevin.andrade@email.pt",       Phone="+351920001055", Nif="123456055", Address="Travessa do Jordão 11, Lisboa",       IsActive=true  },
        new() { Name="Laura Conceição",     Email="laura.conceicao@email.pt",     Phone="+351930001056", Nif="123456056", Address="Av. Infante Santo 35, Lisboa",        IsActive=true  },
        new() { Name="Manuel Valente",      Email="manuel.valente@email.pt",      Phone="+351960001057", Nif="123456057", Address="Rua da Vitória 8, Lisboa",            IsActive=true  },
        new() { Name="Natália Couto",       Email="natalia.couto@email.pt",       Phone="+351910001058", Nif="123456058", Address="Rua do Breiner 55, Porto",            IsActive=true  },
        new() { Name="Otávio Mendonça",     Email="otavio.mendonca@email.pt",     Phone="+351920001059", Nif="123456059", Address="Rua da Cruz dos Poiais 7, Lisboa",    IsActive=true  },
        new() { Name="Priya Sharma",        Email="priya.sharma@email.pt",        Phone="+351930001060", Nif="123456060", Address="Rua Marquês de Fronteira 40, Lisboa", IsActive=true  },
    ];

    // ════════════════════════════════════════════════════════════════════════
    //  VEÍCULOS — 120 registos
    // ════════════════════════════════════════════════════════════════════════
    private static IEnumerable<Vehicle> SeedVehicles()
    {
        var list = new List<Vehicle>
        {
            // ── BMW ────────────────────────────────────────────────────────
            V("AA-01-BB", "BMW","M3 Competition",    "Gasolina",18000, 82500, Y(2), "Azul Tanzanit","Auto",   4,"Traseira",false,false),
            V("AA-02-BB", "BMW","M5 CS",             "Gasolina", 9000,118000, Y(1), "Cinzento Frozen","Auto", 4,"Traseira",false,false),
            V("AA-03-BB", "BMW","320d xDrive",       "Diesel",  65000, 24500, Y(4), "Preto","Auto",           4,"4WD",     false,false),
            V("AA-04-BB", "BMW","X5 xDrive40d",      "Diesel",  42000, 58000, Y(3), "Branco","Auto",          5,"4WD",     false,false),
            V("AA-05-BB", "BMW","i4 M50",            "Elétrico",12000, 79000, Y(1), "Verde Frozen","Auto",    4,"4WD",     false,false),
            V("AA-06-BB", "BMW","Z4 M40i",           "Gasolina",22000, 54000, Y(2), "Azul San Marino","Auto",2,"Traseira",false,false),
            V("AA-07-BB", "BMW","M2 Competition",    "Gasolina",31000, 61000, Y(3), "Preto","Manual",         2,"Traseira",false,false),
            V("AA-08-BB", "BMW","X3 M Competition",  "Gasolina",19000, 74000, Y(2), "Cinzento","Auto",        5,"4WD",     false,false),
            V("AA-09-BB", "BMW","Serie 1 118i",      "Gasolina",48000, 19500, Y(5), "Branco","Auto",          5,"Dianteira",false,false),
            V("AA-10-BB", "BMW","330e M Sport",      "Híbrido", 27000, 38500, Y(3), "Azul","Auto",            4,"Traseira",false,false),

            // ── Mercedes-Benz ─────────────────────────────────────────────
            V("BB-01-CC", "Mercedes","AMG C63 S",    "Gasolina",28000, 76000, Y(3), "Branco","Auto",          4,"Traseira",false,false),
            V("BB-02-CC", "Mercedes","GLE 400d 4M",  "Diesel",  35000, 68000, Y(3), "Prata","Auto",           5,"4WD",     false,false),
            V("BB-03-CC", "Mercedes","A200 d",       "Diesel",  52000, 22000, Y(5), "Preto","Auto",           5,"Dianteira",false,false),
            V("BB-04-CC", "Mercedes","EQS 450+",     "Elétrico",14000, 98000, Y(1), "Branco","Auto",          4,"Traseira",false,false),
            V("BB-05-CC", "Mercedes","CLA 250 4M",   "Gasolina",38000, 36000, Y(4), "Vermelho","Auto",        4,"4WD",     false,false),
            V("BB-06-CC", "Mercedes","G 63 AMG",     "Gasolina", 8000,198000, Y(1), "Preto","Auto",           5,"4WD",     false,false),
            V("BB-07-CC", "Mercedes","C220d Coupé",  "Diesel",  44000, 32500, Y(4), "Cinzento","Auto",        2,"Traseira",false,false),
            V("BB-08-CC", "Mercedes","E 53 AMG",     "Híbrido", 21000, 82000, Y(2), "Azul","Auto",            4,"4WD",     false,false),

            // ── Audi ──────────────────────────────────────────────────────
            V("CC-01-DD", "Audi","RS6 Avant",        "Gasolina",22000, 98000, Y(2), "Nardo Grey","Auto",      5,"4WD",     false,false),
            V("CC-02-DD", "Audi","RS3 Sedan",        "Gasolina",16000, 62000, Y(2), "Kemora Grey","Auto",     4,"4WD",     false,false),
            V("CC-03-DD", "Audi","Q7 55 TFSI",       "Gasolina",39000, 55000, Y(3), "Branco","Auto",          5,"4WD",     false,false),
            V("CC-04-DD", "Audi","A4 Avant 35 TDI",  "Diesel",  71000, 21000, Y(6), "Prata","Auto",           5,"Dianteira",false,false),
            V("CC-05-DD", "Audi","e-tron GT RS",     "Elétrico",11000,138000, Y(1), "Preto","Auto",           4,"4WD",     false,false),
            V("CC-06-DD", "Audi","TT RS Coupé",      "Gasolina",33000, 48000, Y(4), "Vermelho","Manual",      2,"4WD",     false,false),
            V("CC-07-DD", "Audi","Q5 40 TDI",        "Diesel",  47000, 38000, Y(4), "Cinzento","Auto",        5,"4WD",     false,false),

            // ── Porsche ────────────────────────────────────────────────────
            V("DD-01-EE", "Porsche","911 Carrera S", "Gasolina", 9500,138000, Y(1), "Preto","PDK",            2,"Traseira",false,false),
            V("DD-02-EE", "Porsche","Cayenne GTS",   "Gasolina",18000, 98000, Y(2), "Azul Gentia","Auto",     5,"4WD",     false,false),
            V("DD-03-EE", "Porsche","718 Boxster GTS","Gasolina",24000, 76000, Y(3), "Amarelo","PDK",         2,"Traseira",false,false),
            V("DD-04-EE", "Porsche","Taycan Turbo",  "Elétrico",17000,172000, Y(2), "Gelo Branco","Auto",     4,"4WD",     false,false),
            V("DD-05-EE", "Porsche","Macan S",       "Gasolina",44000, 48000, Y(4), "Azul Safira","PDK",      5,"4WD",     false,false),

            // ── Volkswagen ────────────────────────────────────────────────
            V("EE-01-FF", "Volkswagen","Golf R Mk8", "Gasolina",42000, 38500, Y(3), "Azul Lapiz","Auto",      5,"4WD",     false,false),
            V("EE-02-FF", "Volkswagen","Touareg R",  "Híbrido", 31000, 72000, Y(3), "Preto","Auto",           5,"4WD",     false,false),
            V("EE-03-FF", "Volkswagen","Polo GTI",   "Gasolina",28000, 24500, Y(3), "Vermelho","Manual",      5,"Dianteira",false,false),
            V("EE-04-FF", "Volkswagen","ID.4 Pro",   "Elétrico",21000, 44000, Y(2), "Branco","Auto",          5,"Traseira",false,false),
            V("EE-05-FF", "Volkswagen","Golf GTD",   "Diesel",  55000, 26500, Y(5), "Cinzento","Manual",      5,"Dianteira",false,false),
            V("EE-06-FF", "Volkswagen","Arteon R",   "Gasolina",19000, 52000, Y(2), "Prata","Auto",           5,"4WD",     false,false),

            // ── Toyota ────────────────────────────────────────────────────
            V("FF-01-GG", "Toyota","GR Supra",       "Gasolina", 7800, 62000, Y(1), "Amarelo","Auto",         2,"Traseira",false,false),
            V("FF-02-GG", "Toyota","GR86",           "Gasolina",14000, 34000, Y(2), "Vermelho","Manual",      2,"Traseira",false,false),
            V("FF-03-GG", "Toyota","RAV4 Hybrid",    "Híbrido", 38000, 38500, Y(3), "Branco","Auto",          5,"4WD",     false,false),
            V("FF-04-GG", "Toyota","bZ4X",           "Elétrico",18000, 46000, Y(2), "Azul","Auto",            5,"4WD",     false,false),
            V("FF-05-GG", "Toyota","Yaris GR",       "Gasolina",11000, 38000, Y(2), "Branco","Manual",        5,"4WD",     false,false),

            // ── Ford ──────────────────────────────────────────────────────
            V("GG-01-HH", "Ford","Mustang GT",       "Gasolina",54000, 44000, Y(5), "Vermelho","Manual",      2,"Traseira",false,false),
            V("GG-02-HH", "Ford","Mustang Mach-E GT","Elétrico",22000, 68000, Y(2), "Preto","Auto",           5,"4WD",     false,false),
            V("GG-03-HH", "Ford","Focus ST",         "Gasolina",49000, 26500, Y(5), "Laranja","Manual",       5,"Dianteira",false,false),
            V("GG-04-HH", "Ford","Puma ST",          "Gasolina",35000, 29500, Y(3), "Azul","Manual",          5,"Dianteira",false,false),

            // ── Renault ───────────────────────────────────────────────────
            V("HH-01-II", "Renault","Mégane RS Trophy","Gasolina",28000,29500, Y(3), "Laranja","Manual",      5,"Dianteira",false,false),
            V("HH-02-II", "Renault","Clio RS Line",  "Gasolina",41000, 16500, Y(5), "Amarelo","Auto",         5,"Dianteira",false,false),
            V("HH-03-II", "Renault","Arkana E-Tech", "Híbrido", 29000, 31000, Y(3), "Azul","Auto",            5,"Dianteira",false,false),
            V("HH-04-II", "Renault","Zoe R135",      "Elétrico",33000, 24000, Y(4), "Branco","Auto",          5,"Dianteira",false,false),

            // ── Tesla ─────────────────────────────────────────────────────
            V("II-01-JJ", "Tesla","Model 3 LR AWD",  "Elétrico",35000, 48000, Y(2), "Branco Pérola","Auto",  4,"4WD",     false,false),
            V("II-02-JJ", "Tesla","Model S Plaid",   "Elétrico",19000,118000, Y(2), "Preto","Auto",           4,"4WD",     false,false),
            V("II-03-JJ", "Tesla","Model Y LR",      "Elétrico",28000, 54000, Y(2), "Azul","Auto",            5,"4WD",     false,false),
            V("II-04-JJ", "Tesla","Model X Plaid",   "Elétrico",14000,138000, Y(1), "Branco","Auto",          7,"4WD",     false,false),

            // ── Honda ─────────────────────────────────────────────────────
            V("JJ-01-KK", "Honda","Civic Type R",    "Gasolina",61000, 27000, Y(6), "Vermelho Rallye","Manual",5,"Dianteira",false,false),
            V("JJ-02-KK", "Honda","NSX Type S",      "Híbrido",  4000,188000, Y(1), "Vermelho","Auto",        2,"4WD",     false,false),
            V("JJ-03-KK", "Honda","Jazz e:HEV",      "Híbrido", 22000, 22500, Y(3), "Azul","Auto",            5,"Dianteira",false,false),
            V("JJ-04-KK", "Honda","CR-V e:HEV",      "Híbrido", 31000, 38000, Y(3), "Branco","Auto",          5,"4WD",     false,false),

            // ── SEAT / Cupra ──────────────────────────────────────────────
            V("KK-01-LL", "SEAT","Leon Cupra R",     "Gasolina",48000, 23500, Y(5), "Cinzento","Auto",        5,"4WD",     false,false),
            V("KK-02-LL", "Cupra","Formentor VZ5",   "Gasolina",16000, 62000, Y(2), "Petrol Blue","Auto",     5,"4WD",     false,false),
            V("KK-03-LL", "Cupra","Born",            "Elétrico",24000, 38000, Y(2), "Preto","Auto",           5,"Traseira",false,false),

            // ── Peugeot ────────────────────────────────────────────────────
            V("LL-01-MM", "Peugeot","308 GTi",       "Gasolina",55000, 21000, Y(6), "Cinzento","Manual",      5,"Dianteira",false,false),
            V("LL-02-MM", "Peugeot","3008 GT Hybrid","Híbrido", 37000, 35000, Y(3), "Pearl White","Auto",     5,"4WD",     false,false),
            V("LL-03-MM", "Peugeot","508 PSE",       "Híbrido", 19000, 54000, Y(2), "Selenium Grey","Auto",   5,"4WD",     false,false),
            V("LL-04-MM", "Peugeot","e-208",         "Elétrico",27000, 31000, Y(3), "Azul","Auto",            5,"Dianteira",false,false),

            // ── Volvo ──────────────────────────────────────────────────────
            V("MM-01-NN", "Volvo","XC60 Recharge",   "Híbrido", 19000, 56000, Y(2), "Prata","Auto",           5,"4WD",     false,false),
            V("MM-02-NN", "Volvo","V60 Polestar",    "Gasolina",44000, 38500, Y(5), "Azul","Manual",          5,"4WD",     false,false),
            V("MM-03-NN", "Volvo","C40 Recharge",    "Elétrico",16000, 52000, Y(2), "Preto","Auto",           5,"4WD",     false,false),
            V("MM-04-NN", "Volvo","XC90 T8",         "Híbrido", 28000, 72000, Y(3), "Crystal White","Auto",   7,"4WD",     false,false),

            // ── Alfa Romeo / Outros premium ───────────────────────────────
            V("NN-01-OO", "Alfa Romeo","Giulia GTA",  "Gasolina", 3000,142000, Y(1), "Vermelho","Auto",       4,"Traseira",false,false),
            V("NN-02-OO", "Alfa Romeo","Stelvio QV",  "Gasolina",26000, 74000, Y(3), "Branco","Auto",         5,"4WD",     false,false),
            V("NN-03-OO", "Lamborghini","Urus S",     "Gasolina", 6000,288000, Y(1), "Amarelo","Auto",        5,"4WD",     false,false),
            V("NN-04-OO", "Ferrari","SF90 Stradale",  "Híbrido",  2000,498000, Y(1), "Vermelho","Auto",       2,"4WD",     false,false),
            V("NN-05-OO", "Maserati","Ghibli Trofeo", "Gasolina",14000, 98000, Y(2), "Azul Emozione","Auto", 4,"Traseira",false,false),
            V("NN-06-OO", "Land Rover","Defender 110","Diesel",  32000, 72000, Y(3), "Verde Pangea","Auto",   5,"4WD",     false,false),
            V("NN-07-OO", "Range Rover","Sport HSE",  "Híbrido", 22000,112000, Y(2), "Preto","Auto",          5,"4WD",     false,false),

            // ── MOTAS ─────────────────────────────────────────────────────
            V("11-AA-22", "Ducati","Panigale V4 S",   "Gasolina", 4200, 28000, Y(2), "Vermelho","Manual",    0,"Traseira",false,true ),
            V("11-BB-22", "Ducati","Monster SP",      "Gasolina", 8800, 15500, Y(3), "Preto","Manual",       0,"Traseira",false,true ),
            V("11-CC-22", "Ducati","Multistrada V4 S","Gasolina",11000, 22500, Y(2), "Cinzento","Manual",    0,"Traseira",false,true ),
            V("11-DD-22", "Yamaha","MT-09 SP",        "Gasolina",11000, 11500, Y(3), "Preto","Manual",       0,"Traseira",false,true ),
            V("11-EE-22", "Yamaha","R1M",             "Gasolina", 3200, 26500, Y(2), "Azul","Manual",        0,"Traseira",false,true ),
            V("11-FF-22", "Yamaha","Tracer 9 GT",     "Gasolina",18000, 12500, Y(3), "Cinzento","Manual",    0,"Traseira",false,true ),
            V("11-GG-22", "KTM","Duke 890 R",         "Gasolina", 6700, 13200, Y(2), "Laranja","Manual",     0,"Traseira",false,true ),
            V("11-HH-22", "KTM","1290 Super Duke R",  "Gasolina", 9100, 19500, Y(2), "Preto","Manual",       0,"Traseira",false,true ),
            V("11-II-22", "BMW","S1000RR",            "Gasolina", 7800, 22000, Y(2), "Azul","Manual",        0,"Traseira",false,true ),
            V("11-JJ-22", "BMW","R1250 GS Adventure", "Gasolina",24000, 17500, Y(3), "Castanho","Manual",    0,"4WD",     false,true ),
            V("11-KK-22", "Kawasaki","ZX-10RR",       "Gasolina", 5500, 24000, Y(2), "Verde","Manual",       0,"Traseira",false,true ),
            V("11-LL-22", "Honda","CBR1000RR-R SP",   "Gasolina", 6200, 26500, Y(2), "Vermelho","Manual",    0,"Traseira",false,true ),
            V("11-MM-22", "Aprilia","RSV4 Factory",   "Gasolina", 4400, 24500, Y(2), "Preto","Manual",       0,"Traseira",false,true ),
            V("11-NN-22", "Triumph","Street Triple RS","Gasolina",14000, 13500, Y(3), "Branco","Manual",     0,"Traseira",false,true ),
            V("11-OO-22", "Harley-Davidson","Fat Bob","Gasolina",19000, 22000, Y(3), "Cinzento","Manual",    0,"Traseira",false,true ),

            // ── VENDIDOS — histórico ─────────────────────────────────────
            V("ZZ-01-AA", "Audi","A4 Avant TDI",     "Diesel",  97000, 19500, Y(7), "Prata","Auto",          5,"Dianteira",true, false),
            V("ZZ-02-AA", "Mercedes","GLA 200d",      "Diesel",  82000, 24000, Y(6), "Preto","Auto",          5,"Dianteira",true, false),
            V("ZZ-03-AA", "BMW","118d",               "Diesel",  88000, 16500, Y(7), "Azul","Manual",         5,"Dianteira",true, false),
            V("ZZ-04-AA", "Volkswagen","Golf VII TDI","Diesel",  91000, 14000, Y(7), "Cinzento","Manual",     5,"Dianteira",true, false),
            V("ZZ-05-AA", "Toyota","Yaris Hybrid",    "Híbrido", 74000, 15000, Y(6), "Branco","Auto",         5,"Dianteira",true, false),
            V("ZZ-06-AA", "Ford","Fiesta ST",         "Gasolina",68000, 13500, Y(6), "Vermelho","Manual",     5,"Dianteira",true, false),
            V("ZZ-07-AA", "Renault","Clio IV dCi",    "Diesel",  81000, 10500, Y(7), "Cinzento","Manual",     5,"Dianteira",true, false),
            V("ZZ-08-AA", "Peugeot","2008 1.6 HDi",   "Diesel",  95000, 11000, Y(8), "Castanho","Manual",    5,"Dianteira",true, false),
            V("ZZ-09-AA", "Honda","Civic 1.5 VTEC",   "Gasolina",78000, 17500, Y(6), "Azul","Auto",           5,"Dianteira",true, false),
            V("ZZ-10-AA", "SEAT","Ibiza 1.0 TSI",     "Gasolina",62000,  9500, Y(5), "Branco","Manual",       5,"Dianteira",true, false),
            V("ZZ-11-AA", "Mazda","6 Skyactiv-D",     "Diesel",  84000, 18500, Y(7), "Vermelho","Auto",       4,"Dianteira",true, false),
            V("ZZ-12-AA", "Nissan","Qashqai 1.5 dCi", "Diesel",  88000, 14500, Y(7), "Prata","Auto",          5,"4WD",     true, false),
            V("ZZ-13-AA", "Kia","Sportage GT-Line",   "Diesel",  76000, 16000, Y(6), "Cinzento","Auto",       5,"4WD",     true, false),
            V("ZZ-14-AA", "Hyundai","Tucson Hybrid",  "Híbrido", 58000, 22000, Y(5), "Preto","Auto",          5,"4WD",     true, false),
            V("ZZ-15-AA", "Opel","Astra OPC",         "Gasolina",71000, 13000, Y(7), "Vermelho","Manual",     5,"Dianteira",true, false),
            V("ZZ-16-AA", "Skoda","Octavia RS",       "Diesel",  66000, 21000, Y(6), "Prata","Manual",        5,"Dianteira",true, false),
            V("ZZ-17-AA", "Yamaha","MT-07",           "Gasolina",28000,  7200, Y(4), "Cinzento","Manual",     0,"Traseira",true, true ),
            V("ZZ-18-AA", "Kawasaki","Z900",          "Gasolina",31000,  8500, Y(5), "Preto","Manual",        0,"Traseira",true, true ),
            V("ZZ-19-AA", "Ducati","Monster 821",     "Gasolina",22000, 11500, Y(5), "Vermelho","Manual",     0,"Traseira",true, true ),
            V("ZZ-20-AA", "Honda","CB650R",           "Gasolina",19000,  8800, Y(4), "Cinzento","Manual",     0,"Traseira",true, true ),
        };
        return list;
    }

    private static Vehicle V(string plate, string brand, string model, string fuel, int km, int price,
        DateTime reg, string color, string gearbox, int doors, string traction, bool sold, bool moto) => new()
    {
        LicensePlate = plate, Brand = brand, Model = model, Fuel = fuel,
        Kilometers = km, Price = price, RegistrationDate = reg, Color = color,
        GearboxType = gearbox, Doors = doors > 0 ? doors : null, Traction = traction,
        IsSold = sold, IsMotorcycle = moto
    };

    private static DateTime Y(int years) => DateTime.UtcNow.AddYears(-years);

    // ════════════════════════════════════════════════════════════════════════
    //  MARCAÇÕES — 100 registos
    // ════════════════════════════════════════════════════════════════════════
    private static IEnumerable<Appointment> SeedAppointments(List<Client> clients, List<Vehicle> vehicles)
    {
        var appointments = new List<Appointment>();
        var rng = new Random(42);

        for (int i = 0; i < 100; i++)
        {
            var daysOffset = rng.Next(-60, 30);
            var hour = 9 + rng.Next(0, 8);
            var minute = rng.Next(0, 4) * 15;
            var slot = DateTime.Today.AddDays(daysOffset).AddHours(hour).AddMinutes(minute);
            var client = clients[i % clients.Count];
            var vehicle = vehicles[i % vehicles.Count];

            appointments.Add(new Appointment
            {
                DateOnly        = slot.Date,
                DateTimeSlot    = slot,
                EmployeeNumber  = 1000,
                EmployeeName    = "Administrador",
                ClientId        = client.Id,
                ClientName      = client.Name,
                ClientPhone     = client.Phone ?? "",
                SmsConsentGranted = !string.IsNullOrWhiteSpace(client.Phone),
                VehicleBrand    = vehicle.Brand,
                VehicleModel    = vehicle.Model,
                VehicleLicensePlate = vehicle.LicensePlate,
            });
        }
        return appointments;
    }

    // ════════════════════════════════════════════════════════════════════════
    //  VENDAS — 80 registos (apenas veículos marcados como vendidos)
    // ════════════════════════════════════════════════════════════════════════
    private static IEnumerable<SaleTransaction> SeedSales(List<Client> clients, List<Vehicle> soldVehicles)
    {
        var sales = new List<SaleTransaction>();
        var rng = new Random(42);

        for (int i = 0; i < Math.Min(80, soldVehicles.Count); i++)
        {
            var client = clients[i % clients.Count];
            var vehicle = soldVehicles[i];
            var daysAgo = rng.Next(1, 365);

            sales.Add(new SaleTransaction
            {
                ClientNif           = client.Nif ?? "000000000",
                ClientName          = client.Name,
                VehicleLicensePlate = vehicle.LicensePlate,
                TransactionDate     = DateTime.UtcNow.AddDays(-daysAgo),
                Value               = vehicle.Price,
            });
        }
        return sales;
    }
}
