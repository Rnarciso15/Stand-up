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

            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from Clientes", null);
            }
            static public int insertCliente(string nome, string morada, string telefone)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@nome", nome),
                new SqlParameter("@morada", morada),
                new SqlParameter("@telefone", telefone)
           };

                return dal.executarNonQuery("INSERT into Clientes (Nome,Morada,Telefone) VALUES(@nome,@morada,@telefone)", sqlParams);
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
            static public int updateCliente(string id, string nome, string morada, string telefone)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@id", id),
                new SqlParameter("@nome", nome),
                new SqlParameter("@morada", morada),
                new SqlParameter("@telefone", telefone)
            };
                return dal.executarNonQuery("update [Clientes] set [nome]=@nome, [morada]=@morada, [telefone]=@telefone where [id]=@id", sqlParams);
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
            static public DataTable Load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from funcionario", null);
            }
            static public int updateFunc(string Matricula, int Quilometros, string Data, string Marca, string Modelo, string Descricao, string Combustivel, byte[] Imagem, int Valor, string Cor, string tipo_de_caixa, int N_Portas, string Traccao, string Matricula1)
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
            static public int insertFunc(string nome, string senha, bool ativo, string data_nascimento, string email, string telefone, string nib, byte[] imagem, string nif,string morada, string genero)
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

           };

                return dal.executarNonQuery("INSERT into funcionario (nome,senha,ativo,data_nascimento,email,telefone,nib,imagem,nif,genero,morada) VALUES(@nome,@senha,@ativo,@data_nascimento,@email,@telefone,@nib,@imagem,@nif,@genero,@morada)", sqlParams);
            }



        }
    }
   

                     
}