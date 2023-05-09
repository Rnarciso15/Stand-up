using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class BLL
    {
        public class Imagem
        {
            static public object loadpic()
            {
                DAL dal = new DAL();
                 SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", 1),
             };
                return dal.executarScalar("select Img from Imagem where id=1", sqlParams);
            
            }
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Imagem", null);
            }

            static public int insertImagem(byte [] img )
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@img", img),
                
           };

                return dal.executarNonQuery("INSERT into Imagem (Img) VALUES(@img)", sqlParams);
            }
        }
        public class Clientes
        {  
            static public DataTable queryCliente_Like_nome(string nome)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome + "%")
                };
                return dal.executarReader("select * from cliente where nome like @nome", sqlParams);
            }

            static public DataTable queryCliente_Like_nome_ativo(string nome, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome + "%"),
                 new SqlParameter("@Ativo", Ativo ),
                };
                return dal.executarReader("select * from cliente where nome like @nome and Ativo = @Ativo", sqlParams);
            }
            static public DataTable queryCliente_Like_id(string n_cliente)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@n_cliente", n_cliente + "%")
                };
                return dal.executarReader("select * from cliente where n_cliente like @n_cliente", sqlParams);
            }

            static public DataTable queryCliente_Like_id_ativo(string n_cliente, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@n_cliente", n_cliente + "%"),
                 new SqlParameter("@Ativo", Ativo ),
                };
                return dal.executarReader("select * from cliente where n_cliente like @n_cliente and Ativo = @Ativo", sqlParams);
            }

            static public DataTable queryCliente_Like_nif(string nif)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nif", nif + "%")
                };
                return dal.executarReader("select * from cliente where nif like @nif", sqlParams);
            }

            static public DataTable queryCliente_Like_nif_ativo(string nif, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nif", nif + "%"),
                 new SqlParameter("@Ativo", Ativo ),
                };
                return dal.executarReader("select * from cliente where nif like @nif and Ativo = @Ativo", sqlParams);
            }

            static public DataTable queryCliente_Like_genero(string genero)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@genero", genero + "%")
                };
                return dal.executarReader("select * from cliente where genero like @genero", sqlParams);
            }
            static public DataTable queryCliente_Like_genero_ativo(string genero, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@genero", genero + "%"),
                 new SqlParameter("@Ativo", Ativo ),
                };
                return dal.executarReader("select * from cliente where genero like @genero and Ativo = @Ativo", sqlParams);
            }
            static public DataTable queryCliente_Like_idade(string data_nascimento)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@data_nascimento", data_nascimento + "%")
                };
                return dal.executarReader("select * from cliente where data_nascimento like @data_nascimento", sqlParams);
            }
            static public DataTable queryCliente_Like_idade_ativo(string data_nascimento, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@data_nascimento", data_nascimento + "%"),
                 new SqlParameter("@Ativo", Ativo ),
                };
                return dal.executarReader("select * from Cliente where data_nascimento like @data_nascimento and Ativo = @Ativo", sqlParams);

            }
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select  n_cliente,nome,data_nascimento,genero,email,telefone,nib,nif,morada,Ativo,imagem from cliente", null);
            }
        
            static public DataTable queryCliente_Like(String nome)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome + "%")
                };
                return dal.executarReader("select * from Clientes where Nome like @nome", sqlParams);
            }
            static public DataTable queryCliente(int id) {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }
            static public DataTable queryCliente_2(int id, string nome)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                 new SqlParameter("@Nome", nome)
                };
                return dal.executarReader("select * from Clientes where ID=@id and Nome=@nome", sqlParams);
            }
            static public DataTable queryCliente_3(int id)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id)
                };
                return dal.executarReader("select * from Clientes where ID=@id", sqlParams);
            }
            static public int insertCliente(string telefone, string nome, bool Ativo, string data_nascimento, string email, string nib, byte[] imagem, string nif, string morada, string genero,string senha)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome),
                new SqlParameter("@Ativo", Ativo),
                new SqlParameter("@data_nascimento", data_nascimento),
                new SqlParameter("@email", email),
                new SqlParameter("@telefone", telefone),
                new SqlParameter("@nib", nib),
                new SqlParameter("@imagem", imagem),
                new SqlParameter("@nif", nif),
                new SqlParameter("@genero", genero),
                new SqlParameter("@morada", morada),
                new SqlParameter("@senha", senha),

           };

                return dal.executarNonQuery("INSERT into cliente (nome,senha,Ativo,data_nascimento,email,telefone,nib,imagem,nif,genero,morada) VALUES(@nome,@senha,@Ativo,@data_nascimento,@email,@telefone,@nib,@imagem,@nif,@genero,@morada)", sqlParams);
            }


            static public int updateCliente(int n_cliente, string nome, bool Ativo, string data_nascimento, string email, string telefone, string nib, byte[] imagem, string nif, string morada, string genero)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@n_cliente", n_cliente),
                new SqlParameter("@nome", nome),
                new SqlParameter("@Ativo", Ativo),
                new SqlParameter("@data_nascimento", data_nascimento),
                new SqlParameter("@email", email),
                new SqlParameter("@telefone", telefone),
                new SqlParameter("@nib", nib),
                new SqlParameter("@imagem", imagem),
                new SqlParameter("@nif", nif),
                new SqlParameter("@morada", morada),
                new SqlParameter("@genero", genero),
            };
                return dal.executarNonQuery("update [cliente] set  [nome]=@nome, [Ativo]=@Ativo , [data_nascimento]=@data_nascimento, [email]=@email, [telefone]=@telefone, [nib]=@nib, [imagem]=@imagem, [nif]=@nif, [morada]=@morada, [genero]=@genero where n_cliente  = @n_cliente", sqlParams);
            }


            static public int alterarPerfil(string utilizador, String password, string imagem)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@password", password),
                    new SqlParameter("@imagem", imagem)};

                return dal.executarNonQuery("update [utilizadores] set [password]=@password, [imagem]=@imagem where [utilizador]=@utilizador", sqlparams);
            }

            static public int alterarEstado(string utilizador, int estado)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@utilizador", utilizador),
                    new SqlParameter("@estado", estado)};

                return dal.executarNonQuery("update utilizadores set estado=@estado where utilizador=@utilizador", sqlparams);
            }


            static public int senhaCliente(string senha, int n_cliente)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@senha", senha),
                 new SqlParameter("@n_cliente", n_cliente)
           };

                return dal.executarNonQuery("update [cliente] set [senha]=@senha where [n_cliente]=@n_cliente", sqlParams);

            }
        }


        public class veiculos
        {
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select Modelo from Modelos", null);
            }
            static public DataTable Load_dados(string Matricula)
            {

                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Matricula", Matricula),
              
           };
                return dal.executarReader("select * from Veiculo where Matricula = @Matricula", sqlParams);
            }
            static public DataTable Load_dados1(string Matricula)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Matricula", Matricula),

           };
                return dal.executarReader("select Matricula from Veiculo where Matricula = @Matricula", sqlParams);
            }
            static public int updateVeiculo(string Matricula, int Quilometros, string Data, string Marca, string Modelo, string Descricao, string Combustivel, byte[] Imagem, int Valor, string Cor, string tipo_de_caixa, int N_Portas, string Traccao, string Matricula1)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Matricula", Matricula),
                new SqlParameter("@Quilometros", Quilometros),
                new SqlParameter("@Data", Data),
                new SqlParameter("@Marca", Marca),
                new SqlParameter("@Modelo", Modelo),
                new SqlParameter("@Descricao", Descricao),
                 new SqlParameter("@Imagem", Imagem),
                  new SqlParameter("@Combustivel", Combustivel),
                     new SqlParameter("@Valor", Valor),
                       new SqlParameter("@Cor", Cor),
                         new SqlParameter("@tipo_de_caixa", tipo_de_caixa),
                           new SqlParameter("@N_Portas", N_Portas),
                           new SqlParameter("@Matricula1", Matricula1),
                             new SqlParameter("@Traccao", Traccao)
            };
                return dal.executarNonQuery("update [Veiculo] set [Matricula]=@Matricula, [Quilometros]=@Quilometros, [Data]=@Data , [Marca]=@Marca, [Modelo]=@Modelo, [Descricao]=@Descricao, [Combustivel]=@Combustivel, [Imagem]=@Imagem, [Valor]=@Valor, [Cor]=@Cor, [tipo_de_caixa]=@tipo_de_caixa, [Traccao]=@Traccao where [Matricula]=@Matricula1", sqlParams);
            }
            static public int insertVeiculo(string Matricula, int Quilometros, string Data, string Marca, string Modelo, string Descricao, string Combustivel, byte[] Imagem,int Valor,string Cor, string tipo_de_caixa, int N_Portas, string Traccao)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Matricula", Matricula),
                new SqlParameter("@Quilometros", Quilometros),
                new SqlParameter("@Data", Data),
                new SqlParameter("@Marca", Marca),
                new SqlParameter("@Modelo", Modelo),
                new SqlParameter("@Descricao", Descricao),
                 new SqlParameter("@Imagem", Imagem),
                  new SqlParameter("@Combustivel", Combustivel),
                     new SqlParameter("@Valor", Valor),
                       new SqlParameter("@Cor", Cor),
                         new SqlParameter("@tipo_de_caixa", tipo_de_caixa),
                           new SqlParameter("@N_Portas", N_Portas),
                             new SqlParameter("@Traccao", Traccao)
                              
           };

                return dal.executarNonQuery("INSERT into Veiculo (Matricula,Quilometros,Data,Marca,Modelo,Descricao,Combustivel,Imagem,Valor,Cor,tipo_de_caixa,N_Portas,Traccao) VALUES(@Matricula,@Quilometros,@Data,@Marca,@Modelo,@Descricao,@Combustivel,@Imagem,@Valor,@Cor,@tipo_de_caixa,@N_Portas,@Traccao)", sqlParams);
            }
            static public int insert_modelo(string marca , string modelo, int inicio_producao,  int fim_producao)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                           
                new SqlParameter("@marca", marca),
                new SqlParameter("@modelo", modelo),
                new SqlParameter("@inicio_producao", inicio_producao),
                new SqlParameter("@fim_producao", fim_producao),

           };

                return dal.executarNonQuery("INSERT into marcas (marca,modelo,inicio_producao,fim_producao) VALUES(@marca,@modelo,@inicio_producao,@fim_producao)", sqlParams);
            }

            static public int deleteveiculo()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
            

            };
                return dal.executarNonQuery("Delete From marcas", sqlParams);
            }

            static public DataTable queryMarca_veiculo()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
           
                };
                return dal.executarReader("select Nome from Marcas", sqlParams);
            }
            static public DataTable queryLoad_veiculo()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
           
                };
                return dal.executarReader("select * from Veiculo  ", sqlParams);
            }
            static public DataTable queryModelos_veiculo(int id_marca) {  
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                        new SqlParameter("@id_marca", id_marca),
                };
                return dal.executarReader("select Modelo from Modelos Where id_marca = @id_marca ", sqlParams);
            }
            static public DataTable queryGasolina_veiculo(string Combustivel)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                        new SqlParameter("@Combustivel", Combustivel),
                };
                return dal.executarReader("select * from Veiculo Where Combustivel = @Combustivel ", sqlParams);
            }

            static public DataTable queryCor_veiculo(string Cor)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                        new SqlParameter("@Cor", Cor),
                };
                return dal.executarReader("select * from Veiculo Where Cor = @Cor ", sqlParams);
            }

            static public DataTable queryMarca_veiculo(string Marca)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                        new SqlParameter("@Marca", Marca),
                };
                return dal.executarReader("select * from Veiculo Where Marca = @Marca ", sqlParams);
            }
            static public DataTable querymaior_quiilometros()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                
                };
                return dal.executarReader("select * from Veiculo  ORDER BY Quilometros DESC ", null);
            }
            static public DataTable queryMenor_quiilometros()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{

                };
                return dal.executarReader("select * from Veiculo  ORDER BY Quilometros ASC ", null);
            }
            static public DataTable queryData_Modelos_veiculo(string Marca, string Modelo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                      new SqlParameter("@Marca", Marca),
                        new SqlParameter("@Modelo", Modelo),
                };
                return dal.executarReader("select * from marcas Where Marca = @Marca And Modelo = @Modelo", sqlParams);
            }


            static public object queryBuscar_id_marca(string Nome)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                     new SqlParameter("@Nome", Nome),
                };
                return dal.executarScalar("select Id from Marcas where Nome = @Nome", sqlParams);
            }
            static public DataTable queryBuscar_Inicio_fim_producao(string Modelo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                     new SqlParameter("@Modelo", Modelo),
                };
                return dal.executarReader("select inicio_producao,fim_producao from Modelos where Modelo = @Modelo", sqlParams);
            }

            static public DataTable queryModelos_veiculo1234(int id_marca,int inicio_producao,int fim_producao, int ano)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                        new SqlParameter("@id_marca", id_marca),
                         new SqlParameter("@inicio_producao", inicio_producao),
                          new SqlParameter("@fim_producao", fim_producao),
                          new SqlParameter("@ano", ano),
                };
                return dal.executarReader("select Modelo from Modelos Where id_marca = @id_marca and  inicio_producao <= @ano   and  fim_producao >= @ano", sqlParams);
            }

        }

        public class Func
        {

            static public string Buscar_admin(int n_func)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{

                new SqlParameter("@n_func", n_func) };

                return Convert.ToString(dal.executarScalar("select admin from funcionario where n_func = @n_func", sqlParams));
            }
            static public DataTable Load(bool admin)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
              
                new SqlParameter("@admin", admin) };

                return dal.executarReader("select n_func,nome,data_nascimento,genero,email,telefone,nib,nif,morada,ativo,imagem  from funcionario where admin = @admin", sqlParams);
            }

            static public DataTable queryLoad_Func()
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{

                };
                return dal.executarReader("select * from funcionario", sqlParams);
            }

            

            static public DataTable LoadPerfil(int n_func)
            {
                DAL dal = new DAL();            
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@n_func", n_func),
                };
                return dal.executarReader("select nome,imagem from funcionario where n_func = @n_func", sqlParams);
            }

            static public DataTable login(int n_func, string senha)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@n_func", n_func),
                 new SqlParameter("@senha", senha)
                };
                return dal.executarReader("select * from funcionario where n_func=@n_func and senha=@senha", sqlParams);
            }

            static public DataTable queryFunc_Like_nome(string nome)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome + "%")
                };
                return dal.executarReader("select * from funcionario where Nome like @nome", sqlParams);
            }

            static public DataTable queryFunc_Like_nome_ativo(string nome, bool ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome + "%"),
                 new SqlParameter("@ativo", ativo ),
                };
                return dal.executarReader("select * from funcionario where nome like @nome and ativo = @ativo", sqlParams);
            }
            static public DataTable queryFunc_Like_id(string n_func)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@n_func", n_func + "%")
                };
                return dal.executarReader("select * from funcionario where n_func like @n_func", sqlParams);
            }

            static public DataTable queryFunc_Like_id_ativo(string n_func, bool ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@n_func", n_func + "%"),
                 new SqlParameter("@ativo", ativo ),
                };
                return dal.executarReader("select * from funcionario where n_func like @n_func and ativo = @ativo", sqlParams);
            }

            static public DataTable queryFunc_Like_nif(string nif)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nif", nif + "%")
                };
                return dal.executarReader("select * from funcionario where nif like @nif", sqlParams);
            }

            static public DataTable queryFunc_Like_nif_ativo(string nif, bool ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nif", nif + "%"),
                 new SqlParameter("@ativo", ativo ),
                };
                return dal.executarReader("select * from funcionario where nif like @nif and ativo = @ativo", sqlParams);
            }

            static public DataTable queryFunc_Like_genero(string genero)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@genero", genero + "%")
                };
                return dal.executarReader("select * from funcionario where genero like @genero", sqlParams);
            }
            static public DataTable queryFunc_Like_genero_ativo(string genero, bool ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@genero", genero + "%"),
                 new SqlParameter("@ativo", ativo ),
                };
                return dal.executarReader("select * from funcionario where genero like @genero and ativo = @ativo", sqlParams);
            }
            static public DataTable queryFunc_Like_idade(string data_nascimento)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@data_nascimento", data_nascimento + "%")
                };
                return dal.executarReader("select * from funcionario where data_nascimento like @data_nascimento", sqlParams);
            }
            static public DataTable queryFunc_Like_idade_ativo(string data_nascimento, bool ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@data_nascimento", data_nascimento + "%"),
                 new SqlParameter("@ativo", ativo ),
                };
                return dal.executarReader("select * from funcionario where data_nascimento like @data_nascimento and ativo = @ativo", sqlParams);

            }
            static public int insertFunc(string nome, string senha, bool ativo, string data_nascimento, string email, string telefone, string nib, byte[] imagem, string nif,string morada, string genero,bool admin)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome),
                new SqlParameter("@senha", senha),
                new SqlParameter("@ativo", ativo),
                new SqlParameter("@data_nascimento", data_nascimento),
                new SqlParameter("@email", email),
                new SqlParameter("@telefone", telefone),
                new SqlParameter("@nib", nib),
                new SqlParameter("@imagem", imagem),
                new SqlParameter("@nif", nif),
                new SqlParameter("@genero", genero),
                new SqlParameter("@morada", morada),
                new SqlParameter("@admin", admin),

           };

                return dal.executarNonQuery("INSERT into funcionario (nome,senha,ativo,data_nascimento,email,telefone,nib,imagem,nif,genero,morada,admin) VALUES(@nome,@senha,@ativo,@data_nascimento,@email,@telefone,@nib,@imagem,@nif,@genero,@morada,@admin)", sqlParams);
            }


            static public int updateFunc(int n_func, string nome, bool ativo, string data_nascimento, string email, string telefone, string nib, byte[] imagem, string nif, string morada, string genero)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@n_func", n_func),
                new SqlParameter("@nome", nome),
                new SqlParameter("@ativo", ativo),
                new SqlParameter("@data_nascimento", data_nascimento),
                new SqlParameter("@email", email),
                new SqlParameter("@telefone", telefone),
                 new SqlParameter("@nib", nib),
                  new SqlParameter("@imagem", imagem),
                     new SqlParameter("@nif", nif),
                       new SqlParameter("@morada", morada),
                         new SqlParameter("@genero", genero),
            };
                return dal.executarNonQuery("update [funcionario] set  [nome]=@nome, [ativo]=@ativo , [data_nascimento]=@data_nascimento, [email]=@email, [telefone]=@telefone, [nib]=@nib, [imagem]=@imagem, [nif]=@nif, [morada]=@morada, [genero]=@genero where n_func  = @n_func", sqlParams);
            }

            static public int senhaFunc(string senha, int n_func)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@senha", senha),
                 new SqlParameter("@n_func", n_func)
           };

                return dal.executarNonQuery("update [funcionario] set [senha]=@senha where [n_func]=@n_func", sqlParams);

            }



        }
    }
   

                     
}