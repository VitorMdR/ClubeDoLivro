using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClubeDoLivro.Domain;

namespace ClubeDoLivro.Infra.Data.DAO
{
    public class AmigoDAO
    {
        private string _connectionString = @"data source=.\SQLEXPRESS;initial catalog=ClubeDoLivroDB;uid=sa;pwd=bocaum24;";

        public void InserirAmigo(Amigo amigo)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conexao;

                    var insertCommand = @"INSERT INTO AMIGO VALUES (@NOME,@NOME_MAE,@LOCAL,@TELEFONE)";

                    ConverterObjetoParaParametrosSQL(amigo, command);

                    command.CommandText = insertCommand;

                    command.ExecuteNonQuery();
                }

            }
        }


        public List<Amigo> BuscarTodos()
        {
            var listaAmigos = new List<Amigo>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM AMIGO;";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Amigo amigoBuscado = ConverterSqlParaObjeto(leitor);
                        listaAmigos.Add(amigoBuscado);
                    }
                }

                return listaAmigos;
            }
        }

        public Amigo BuscaPorNome(string nome)
        {

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT TOP(1) * FROM AMIGO WHERE NOME LIKE @NOME"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@NOME", $"%{nome}%");

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI CLIENTE BUSCADO
                        return ConverterSqlParaObjeto(leitor);
                    }
                }
            }

            return null;
        }

        private Amigo ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var id = int.Parse(leitor["ID_AMIGO"].ToString());
            var nome = leitor["NOME"].ToString();
            var nomeMae = leitor["NOME_MAE"].ToString();
            var origem = int.Parse(leitor["LOCAL"].ToString());
            var telefone = leitor["TELEFONE"].ToString();

            return new Amigo(id, nome, nomeMae, origem, telefone);
        }


        private void ConverterObjetoParaParametrosSQL(Amigo amigo, SqlCommand command)
        {
            command.Parameters.AddWithValue("@NOME", amigo.Nome);
            command.Parameters.AddWithValue("@NOME_MAE", amigo.NomeMae);
            command.Parameters.AddWithValue("@LOCAL", amigo.Origem);
            command.Parameters.AddWithValue("@TELEFONE", amigo.Telefone);
        }
    }
}