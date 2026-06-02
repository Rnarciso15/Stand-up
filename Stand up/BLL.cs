using System;
using System.Data;

// ═══════════════════════════════════════════════════════════════════════════
//  BLL — camada de compatibilidade (shim).
//
//  As forms mais antigas usam BLL.Func / BLL.veiculos / etc.
//  Este ficheiro delega TODAS as chamadas para ApiService, que é a camada
//  de serviço actual. Não contém lógica própria.
//
//  ⚠  Não adicionar lógica aqui. Para novas funcionalidades, usar ApiService.
// ═══════════════════════════════════════════════════════════════════════════
namespace BusinessLogicLayer
{
    public static class BLL
    {
        public static class Func
        {
            public static DataTable login(int n_func, string senha)
                => Stand_up.ApiService.Func.login(n_func, senha);

            public static string Buscar_admin(int n_func)
                => Stand_up.ApiService.Func.Buscar_admin(n_func);

            public static DataTable LoadPerfil(int n_func)
                => Stand_up.ApiService.Func.LoadPerfil(n_func);

            public static int insertFunc(string nome, string senha, bool ativo, string data,
                string email, string tel, string nib, byte[] img, string nif, string mr, string g, bool admin)
                => Stand_up.ApiService.Func.insertFunc(nome, senha, ativo, data, email, tel, nib, img, nif, mr, g, admin);

            public static DataTable Load()                                          => Stand_up.ApiService.Func.Load();
            public static DataTable queryLoad_Func()                                => Stand_up.ApiService.Func.queryLoad_Func();
            public static DataTable queryLoad_Func_ativo(bool a)                    => Stand_up.ApiService.Func.queryLoad_Func_ativo(a);
            public static DataTable queryLoad_Func1234(string t, bool a)            => Stand_up.ApiService.Func.queryLoad_Func1234(t, a);
            public static DataTable queryFunc_Like_nome(string n)                   => Stand_up.ApiService.Func.queryFunc_Like_nome(n);
            public static DataTable queryFunc_Like_nome_ativo(string n, bool a)     => Stand_up.ApiService.Func.queryFunc_Like_nome_ativo(n, a);
            public static DataTable queryFunc_Like_id(string id)                    => Stand_up.ApiService.Func.queryFunc_Like_id(id);
            public static DataTable queryFunc_Like_id_ativo(string id, bool a)      => Stand_up.ApiService.Func.queryFunc_Like_id_ativo(id, a);
            public static DataTable queryFunc_Like_nif(string nif)                  => Stand_up.ApiService.Func.queryFunc_Like_nif(nif);
            public static DataTable queryFunc_Like_nif_ativo(string n, bool a)      => Stand_up.ApiService.Func.queryFunc_Like_nif_ativo(n, a);
            public static DataTable queryFunc_Like_genero(string g)                 => Stand_up.ApiService.Func.queryFunc_Like_genero(g);
            public static DataTable queryFunc_Like_genero_ativo(string g, bool a)   => Stand_up.ApiService.Func.queryFunc_Like_genero_ativo(g, a);
            public static DataTable queryFunc_Like_idade(string d)                  => Stand_up.ApiService.Func.queryFunc_Like_idade(d);
            public static DataTable queryFunc_Like_idade_ativo(string d, bool a)    => Stand_up.ApiService.Func.queryFunc_Like_idade_ativo(d, a);
            public static DataTable queryFunc_emailIgual(string e, int n)           => Stand_up.ApiService.Func.queryFunc_emailIgual(e, n);
            public static DataTable queryFunc_telefoneIgual(string t, int n)        => Stand_up.ApiService.Func.queryFunc_telefoneIgual(t, n);
            public static DataTable queryFunc_NibIgual(string nb, int n)            => Stand_up.ApiService.Func.queryFunc_NibIgual(nb, n);
            public static DataTable queryFunc_NifIgual(string nf, int n)            => Stand_up.ApiService.Func.queryFunc_NifIgual(nf, n);
            public static DataTable queryFunc_get_senha(int n)                      => Stand_up.ApiService.Func.queryFunc_get_senha(n);
            public static DataTable queryFunc_get_id(string nif)                    => Stand_up.ApiService.Func.queryFunc_get_id(nif);
            public static int updateFunc(int n, string nm, bool a, string d, string em,
                string tel, string nib, byte[] img, string nif, string mr, string g)
                => Stand_up.ApiService.Func.updateFunc(n, nm, a, d, em, tel, nib, img, nif, mr, g);
            public static int senhaFunc(string s, int n, string sp)                 => Stand_up.ApiService.Func.senhaFunc(s, n, sp);
            public static int senhaFunc1(string s, int n)                           => Stand_up.ApiService.Func.senhaFunc1(s, n);
        }

        public static class Clientes
        {
            public static DataTable Load()                                                      => Stand_up.ApiService.Clientes.Load();
            public static DataTable queryLoad_cliente()                                         => Stand_up.ApiService.Clientes.queryLoad_cliente();
            public static DataTable queryLoad_cliente1234(string t, bool a)                    => Stand_up.ApiService.Clientes.queryLoad_cliente1234(t, a);
            public static DataTable queryCliente_mostrar_dados(int id)                          => Stand_up.ApiService.Clientes.queryCliente_mostrar_dados(id);
            public static DataTable LoadCliente_proc(int id)                                    => Stand_up.ApiService.Clientes.LoadCliente_proc(id);
            public static DataTable queryCliente_Like(string n)                                 => Stand_up.ApiService.Clientes.queryCliente_Like(n);
            public static DataTable queryCliente_Like_nome(string n)                            => Stand_up.ApiService.Clientes.queryCliente_Like_nome(n);
            public static DataTable queryCliente_Like_nome_ativo(string n, bool a)              => Stand_up.ApiService.Clientes.queryCliente_Like_nome_ativo(n, a);
            public static DataTable queryCliente_Like_nif(string n)                             => Stand_up.ApiService.Clientes.queryCliente_Like_nif(n);
            public static DataTable queryCliente_Like_nif_ativo(string n, bool a)               => Stand_up.ApiService.Clientes.queryCliente_Like_nif_ativo(n, a);
            public static DataTable queryCliente_Like_id(string id)                             => Stand_up.ApiService.Clientes.queryCliente_Like_id(id);
            public static DataTable queryCliente_Like_id_ativo(string id, bool a)               => Stand_up.ApiService.Clientes.queryCliente_Like_id_ativo(id, a);
            public static DataTable queryCliente_Like_genero(string g)                          => Stand_up.ApiService.Clientes.queryCliente_Like_genero(g);
            public static DataTable queryCliente_Like_genero_ativo(string g, bool a)            => Stand_up.ApiService.Clientes.queryCliente_Like_genero_ativo(g, a);
            public static DataTable queryCliente_Like_idade(string d)                           => Stand_up.ApiService.Clientes.queryCliente_Like_idade(d);
            public static DataTable queryCliente_Like_idade_ativo(string d, bool a)             => Stand_up.ApiService.Clientes.queryCliente_Like_idade_ativo(d, a);
            public static DataTable querycliente_emailIgual(string e)                           => Stand_up.ApiService.Clientes.querycliente_emailIgual(e);
            public static DataTable queryCliente_telefoneIgual(string t)                        => Stand_up.ApiService.Clientes.queryCliente_telefoneIgual(t);
            public static DataTable queryCliente_NibIgual(string n)                             => Stand_up.ApiService.Clientes.queryCliente_NibIgual(n);
            public static DataTable queryCliente_NifIgual(string n)                             => Stand_up.ApiService.Clientes.queryCliente_NifIgual(n);
            public static DataTable queryFunc_emailIgual(string e, int id)                      => Stand_up.ApiService.Clientes.queryFunc_emailIgual(e, id);
            public static DataTable queryFunc_telefoneIgual(string t, int id)                   => Stand_up.ApiService.Clientes.queryFunc_telefoneIgual(t, id);
            public static DataTable queryFunc_NibIgual(string n, int id)                        => Stand_up.ApiService.Clientes.queryFunc_NibIgual(n, id);
            public static DataTable queryFunc_NifIgual(string n, int id)                        => Stand_up.ApiService.Clientes.queryFunc_NifIgual(n, id);
            public static DataTable queryCliente_2(int id, string n)                            => Stand_up.ApiService.Clientes.queryCliente_2(id, n);
            public static DataTable queryCliente_3(int id)                                      => Stand_up.ApiService.Clientes.queryCliente_3(id);
            public static int insertCliente(string tel, string nome, bool a, string d,
                string em, string nib, byte[] img, string nif, string mr, string g, string s)
                => Stand_up.ApiService.Clientes.insertCliente(tel, nome, a, d, em, nib, img, nif, mr, g, s);
            public static int updateCliente(int id, string nome, bool a, string d,
                string em, string tel, string nib, byte[] img, string nif, string mr, string g)
                => Stand_up.ApiService.Clientes.updateCliente(id, nome, a, d, em, tel, nib, img, nif, mr, g);
            public static int senhaCliente(string s, int id)                                    => Stand_up.ApiService.Clientes.senhaCliente(s, id);
            public static int alterarPerfil(string u, string p, string i)                       => Stand_up.ApiService.Clientes.alterarPerfil(u, p, i);
            public static int alterarEstado(string u, int e)                                    => Stand_up.ApiService.Clientes.alterarEstado(u, e);
        }

        public static class transacoes
        {
            public static DataTable loadTrans()                                     => Stand_up.ApiService.transacoes.loadTrans();
            public static DataTable queryFunc_Like_N_Matricula(string p)            => Stand_up.ApiService.transacoes.queryFunc_Like_N_Matricula(p);
            public static DataTable queryFunc_Like_NIF(string n)                    => Stand_up.ApiService.transacoes.queryFunc_Like_NIF(n);
            public static DataTable queryFunc_Like_N_data(string d)                 => Stand_up.ApiService.transacoes.queryFunc_Like_N_data(d);
            public static DataTable queryFunc_Like_N_valor(string v)                => Stand_up.ApiService.transacoes.queryFunc_Like_N_valor(v);
            public static DataTable loadnif_Cliente(int id)                         => Stand_up.ApiService.transacoes.loadnif_Cliente(id);
            public static int insertTrans(int nif, string p, string d, int v, string n)
                => Stand_up.ApiService.transacoes.insertTrans(nif, p, d, v, n);
        }

        public static class veiculos
        {
            public static DataTable queryLoad_veiculo(bool v)                                   => Stand_up.ApiService.veiculos.queryLoad_veiculo(v);
            public static DataTable queryLoad_veiculo_mota(bool v, bool m)                      => Stand_up.ApiService.veiculos.queryLoad_veiculo_mota(v, m);
            public static DataTable queryLoad_veiculoMatricula(bool v, string p)                => Stand_up.ApiService.veiculos.queryLoad_veiculoMatricula(v, p);
            public static DataTable Load_dados(string p)                                        => Stand_up.ApiService.veiculos.Load_dados(p);
            public static DataTable Load_dados_imagem(string p)                                 => Stand_up.ApiService.veiculos.Load_dados_imagem(p);
            public static DataTable Load_dados1(string p)                                       => Stand_up.ApiService.veiculos.Load_dados1(p);
            public static DataTable Load()                                                       => Stand_up.ApiService.veiculos.Load();
            public static DataTable queryMarca_veiculo()                                        => Stand_up.ApiService.veiculos.queryMarca_veiculo();
            public static DataTable queryMarca_veiculoMotas()                                   => Stand_up.ApiService.veiculos.queryMarca_veiculoMotas();
            public static DataTable queryMarca_veiculo(string m, bool v, bool mo)               => Stand_up.ApiService.veiculos.queryMarca_veiculo(m, v, mo);
            public static DataTable queryCor_veiculo(string c, bool v, bool m)                  => Stand_up.ApiService.veiculos.queryCor_veiculo(c, v, m);
            public static DataTable queryCor_veiculo_tudo(string c, bool v)                     => Stand_up.ApiService.veiculos.queryCor_veiculo_tudo(c, v);
            public static DataTable queryGasolina_veiculo(string c, bool v, bool m)             => Stand_up.ApiService.veiculos.queryGasolina_veiculo(c, v, m);
            public static DataTable queryGasolina_veiculo_tudo(string c, bool v)                => Stand_up.ApiService.veiculos.queryGasolina_veiculo_tudo(c, v);
            public static DataTable queryCarro(string c, string m, bool v, bool mo)             => Stand_up.ApiService.veiculos.queryCarro(c, m, v, mo);
            public static DataTable queryCarro2(string c, string m, bool v, bool mo)            => Stand_up.ApiService.veiculos.queryCarro2(c, m, v, mo);
            public static DataTable queryCarro3(string c, string m, string cor, bool v, bool mo)=> Stand_up.ApiService.veiculos.queryCarro3(c, m, cor, v, mo);
            public static DataTable queryCarro4(string c, string cor, bool v, bool mo)          => Stand_up.ApiService.veiculos.queryCarro4(c, cor, v, mo);
            public static DataTable querymaior_quiilometros(bool v, bool m)                     => Stand_up.ApiService.veiculos.querymaior_quiilometros(v, m);
            public static DataTable querymaior_quiilometros_tudo(bool v)                        => Stand_up.ApiService.veiculos.querymaior_quiilometros_tudo(v);
            public static DataTable queryMenor_quiilometros(bool v, bool m)                     => Stand_up.ApiService.veiculos.queryMenor_quiilometros(v, m);
            public static DataTable queryMenor_quiilometros_tudo(bool v)                        => Stand_up.ApiService.veiculos.queryMenor_quiilometros_tudo(v);
            public static DataTable querymaior_quiilometros_Marca(string m, bool v, bool mo)    => Stand_up.ApiService.veiculos.querymaior_quiilometros_Marca(m, v, mo);
            public static DataTable querymenor_quiilometros_Marca(string m, bool v, bool mo)    => Stand_up.ApiService.veiculos.querymenor_quiilometros_Marca(m, v, mo);
            public static DataTable querymaior_quiilometros_Cor(string c, bool v)               => Stand_up.ApiService.veiculos.querymaior_quiilometros_Cor(c, v);
            public static DataTable querymenor_quiilometros_Cor(string c, bool v)               => Stand_up.ApiService.veiculos.querymenor_quiilometros_Cor(c, v);
            public static DataTable querymaior_quiilometros_Combustivel(string c, bool v)       => Stand_up.ApiService.veiculos.querymaior_quiilometros_Combustivel(c, v);
            public static DataTable querymenor_quiilometros_Combustivel(string c, bool v)       => Stand_up.ApiService.veiculos.querymenor_quiilometros_Combustivel(c, v);
            public static DataTable querymaior_quiilometros_Marca_cor(string m,string c,bool v,bool mo) => Stand_up.ApiService.veiculos.querymaior_quiilometros_Marca_cor(m,c,v,mo);
            public static DataTable querymenor_quiilometros_Marca_cor(string m,string c,bool v,bool mo) => Stand_up.ApiService.veiculos.querymenor_quiilometros_Marca_cor(m,c,v,mo);
            public static DataTable querymaior_quiilometros_Marca_combustivel(string m,string c,bool v,bool mo) => Stand_up.ApiService.veiculos.querymaior_quiilometros_Marca_combustivel(m,c,v,mo);
            public static DataTable querymenor_quiilometros_Marca_combustivel(string m,string c,bool v,bool mo) => Stand_up.ApiService.veiculos.querymenor_quiilometros_Marca_combustivel(m,c,v,mo);
            public static DataTable querymaior_quiilometros_Combustivel_cor(string c,string cor,bool v) => Stand_up.ApiService.veiculos.querymaior_quiilometros_Combustivel_cor(c,cor,v);
            public static DataTable querymenor_quiilometros_Combustivel_cor(string c,string cor,bool v) => Stand_up.ApiService.veiculos.querymenor_quiilometros_Combustivel_cor(c,cor,v);
            public static DataTable queryModelos_veiculo(int id)                                => Stand_up.ApiService.veiculos.queryModelos_veiculo(id);
            public static DataTable queryModelos_veiculoMotas(int id)                           => Stand_up.ApiService.veiculos.queryModelos_veiculoMotas(id);
            public static DataTable queryModelos_veiculo1234(int id, int a)                     => Stand_up.ApiService.veiculos.queryModelos_veiculo1234(id, a);
            public static DataTable queryModelos_veiculo1234Motas(int id, int a)                => Stand_up.ApiService.veiculos.queryModelos_veiculo1234Motas(id, a);
            public static DataTable queryData_Modelos_veiculo(string m, string mo)              => Stand_up.ApiService.veiculos.queryData_Modelos_veiculo(m, mo);
            public static DataTable queryBuscar_Inicio_fim_producao(string m)                   => Stand_up.ApiService.veiculos.queryBuscar_Inicio_fim_producao(m);
            public static object    queryBuscar_id_marca(string n)                              => Stand_up.ApiService.veiculos.queryBuscar_id_marca(n);
            public static object    queryBuscar_id_marcaModelos(string n)                       => Stand_up.ApiService.veiculos.queryBuscar_id_marcaModelos(n);
            public static object    queryBuscar_id_marcaModelosMotas(string n)                  => Stand_up.ApiService.veiculos.queryBuscar_id_marcaModelosMotas(n);
            public static int insertVeiculo(string p, int km, string d, string m, string mo,
                string desc, string c, byte[] img, int v, string cor,
                string caixa, int portas, string tr, bool vendido, bool mota)
                => Stand_up.ApiService.veiculos.insertVeiculo(p,km,d,m,mo,desc,c,img,v,cor,caixa,portas,tr,vendido,mota);
            public static int updateVendido(string p, bool v)                                   => Stand_up.ApiService.veiculos.updateVendido(p, v);
            public static int updateVeiculo(string p,int km,string d,string m,string mo,
                string desc,string c,byte[] img,int v,string cor,string caixa,int portas,string tr,string p1)
                => Stand_up.ApiService.veiculos.updateVeiculo(p,km,d,m,mo,desc,c,img,v,cor,caixa,portas,tr,p1);
            public static int deleteveiculo(string p)                                           => Stand_up.ApiService.veiculos.deleteveiculo(p);
            public static int deleteveiculo()                                                    => Stand_up.ApiService.veiculos.deleteveiculo();
            public static int insert_modelo(string m, string mo, int i, int f)                  => Stand_up.ApiService.veiculos.insert_modelo(m,mo,i,f);
        }

        public static class testDrive
        {
            public static DataTable queryLoad_Test(DateTime d)                                  => Stand_up.ApiService.testDrive.queryLoad_Test(d);
            public static DataTable EleminarTest(int id)                                        => Stand_up.ApiService.testDrive.EleminarTest(id);
            public static DataTable procurarFuncOcupado(DateTime d, int id)                     => Stand_up.ApiService.testDrive.procurarFuncOcupado(d, id);
            public static DataTable procurarClienteOcupado(DateTime d, int id)                  => Stand_up.ApiService.testDrive.procurarClienteOcupado(d, id);
            public static DataTable procurarCarroOcupado(DateTime d, string p)                  => Stand_up.ApiService.testDrive.procurarCarroOcupado(d, p);
            public static int insertTest(DateTime ds, DateTime d, int idF, string nF,
                int idC, string nC, string m, string mo, string p, byte[] img)
                => Stand_up.ApiService.testDrive.insertTest(ds,d,idF,nF,idC,nC,m,mo,p,img);
        }

        public static class Imagem
        {
            public static DataTable LoadImagensCarro(string p)              => Stand_up.ApiService.Imagem.LoadImagensCarro(p);
            public static int insertImagemCarro(byte[] img, string p)       => Stand_up.ApiService.Imagem.insertImagemCarro(img, p);
            public static int insertlogo(int id, byte[] logo)               => Stand_up.ApiService.Imagem.insertlogo(id, logo);
            public static DataTable loadlogo()                               => Stand_up.ApiService.Imagem.loadlogo();
            public static object loadpic()                                   => Stand_up.ApiService.Imagem.loadpic();
            public static DataTable Load()                                   => Stand_up.ApiService.Imagem.Load();
            public static int insertImagem(byte[] img)                       => Stand_up.ApiService.Imagem.insertImagem(img);
        }
    }
}
