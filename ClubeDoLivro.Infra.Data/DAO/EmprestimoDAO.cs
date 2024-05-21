using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClubeDoLivro.Domain;

namespace ClubeDoLivro.Infra.Data.DAO
{
    public class EmprestimoDAO
    {
        private string _connectionString = @"data source=.\SQLEXPRESS;initial catalog=ClubeDoLivroDB;uid=sa;pwd=bocaum24;";

        public void InserirEmprestimo(Emprestimo emprestimo)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conexao;

                    var insertCommand = @"INSERT INTO EMPRESTIMO (REVISTA_ID, DATA_EMPRESTIMO, AMIGO_ID) VALUES (@REVISTAID,@DATAEMPRESTIMO, @AMIGO_ID)";

                    ConverterObjetoParaParametrosSQL(emprestimo, command);

                    command.CommandText = insertCommand;

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Emprestimo> BuscarTodos()
        {
            var listaEmprestimos = new List<Emprestimo>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT ID_EMPRESTIMO, DATA_EMPRESTIMO, DATA_DEVOLUCAO, REVISTA_ID,
                                    R.TIPO_COLECAO AS REVISTA_COLECAO,
                                    R.ANO AS REVISTA_ANO,
                                    R.NUMERO AS REVISTA_NUMERO,
                                    AMIGO_ID,
                                    A.NOME AS AMIGO_NOME
                                FROM Emprestimo
                                INNER JOIN REVISTA R ON R.ID_REVISTA = REVISTA_ID
                                INNER JOIN AMIGO A ON A.ID_AMIGO = AMIGO_ID";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Emprestimo EmprestimoBuscado = ConverterSqlParaObjeto(leitor);
                        listaEmprestimos.Add(EmprestimoBuscado);
                    }
                }

                return listaEmprestimos;
            }
        }

        private Emprestimo ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var id = int.Parse(leitor["ID_Emprestimo"].ToString());
            var dataEmprestimo = Convert.ToDateTime(leitor["DATA_EMPRESTIMO"].ToString());
            var dataDevolucao = leitor["DATA_DEVOLUCAO"] as DateTime?;
            var colecaoRevista = leitor["REVISTA_COLECAO"].ToString();
            var edicaoRevista = int.Parse(leitor["REVISTA_NUMERO"].ToString());
            var idRevista = int.Parse(leitor["REVISTA_ID"].ToString());
            var anoRevista = int.Parse(leitor["REVISTA_ANO"].ToString());
            var amigoId = int.Parse(leitor["AMIGO_ID"].ToString());
            var amigoNome = leitor["AMIGO_NOME"].ToString();

            var revista = new Revista(idRevista, colecaoRevista, "", anoRevista, edicaoRevista, false);

            var amigo = new Amigo(amigoId, amigoNome);

            return new Emprestimo(id, dataEmprestimo,dataDevolucao, revista, amigo);
        }

        public void ConverterObjetoParaParametrosSQL(Emprestimo emprestimo, SqlCommand command)
        {
            command.Parameters.AddWithValue("@REVISTAID", emprestimo.Revista.Id);
            command.Parameters.AddWithValue("@AMIGO_ID", emprestimo.Amigo.Id);
            command.Parameters.AddWithValue("@DATAEMPRESTIMO", emprestimo.DataEmprestimo);
        }
    }
}