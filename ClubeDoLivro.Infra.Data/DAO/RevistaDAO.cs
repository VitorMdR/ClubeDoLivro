using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClubeDoLivro.Domain;

namespace ClubeDoLivro.Infra.Data.DAO
{
    public class RevistaDAO
    {
        private string _connectionString = @"data source=.\SQLEXPRESS;initial catalog=ClubeDoLivroDB;uid=sa;pwd=bocaum24;";

        public void InserirRevista(Revista revista)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conexao;

                    var insertCommand = @"INSERT INTO REVISTA VALUES (@colecao,@ano,@edicao,@caixa, @locada)";

                    ConverterObjetoParaParametrosSQL(revista, command);

                    command.CommandText = insertCommand;

                    command.ExecuteNonQuery();
                }

            }
        }

        public void AtualizarRevista(Revista revista)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conexao;

                    var updateCommand = @"UPDATE REVISTA SET LOCADA = @locada, TIPO_COLECAO = '@colecao', ANO = @ano, COR_CAIXA = '@caixa', NUMERO = @edicao WHERE ID_REVISTA = @ID";
                    

                    ConverterObjetoParaParametrosSQL(revista, command);

                    command.CommandText = updateCommand;

                    command.ExecuteNonQuery();
                }

            }
        }

        public Revista BuscarPorParametros(string colecao, int ano, int edicao)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID_REVISTA, TIPO_COLECAO, ANO, NUMERO, COR_CAIXA, LOCADA
                                  FROM REVISTA WHERE TIPO_COLECAO = @TIPO_COLECAO
                                  AND NUMERO = @EDICAO
                                  AND ANO = @ANO;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@TIPO_COLECAO", colecao);
                    comando.Parameters.AddWithValue("@ANO", ano);
                    comando.Parameters.AddWithValue("@EDICAO", edicao);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var revista = ConverterSqlParaObjeto(leitor);

                        return revista;
                    }
                }
            }

            return null;
        }

        public List<Revista> BuscarTodas()
        {
            var listaRevistas = new List<Revista>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM REVISTA;";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Revista revistaBuscada = ConverterSqlParaObjeto(leitor);
                        listaRevistas.Add(revistaBuscada);
                    }
                }

                return listaRevistas;
            }
        }

        private Revista ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var id = int.Parse(leitor["ID_REVISTA"].ToString());
            var edicao = int.Parse(leitor["NUMERO"].ToString());
            var ano = int.Parse(leitor["ANO"].ToString());
            var colecao = leitor["TIPO_COLECAO"].ToString();
            var corCaixa = leitor["COR_CAIXA"].ToString();
            var locada = Convert.ToBoolean(leitor["locada"]);

            return new Revista(id, colecao, corCaixa, ano, edicao, locada);
        }


        private void ConverterObjetoParaParametrosSQL(Revista revista, SqlCommand command)
        {
            command.Parameters.AddWithValue("@colecao", revista.TipoColecao);
            command.Parameters.AddWithValue("@ano", revista.Ano);
            command.Parameters.AddWithValue("@edicao", revista.Edicao);
            command.Parameters.AddWithValue("@caixa", revista.CorDaCaixa);
            command.Parameters.AddWithValue("@Locada", revista.Locada);
            command.Parameters.AddWithValue("@ID", revista.Id);
        }
    }
}