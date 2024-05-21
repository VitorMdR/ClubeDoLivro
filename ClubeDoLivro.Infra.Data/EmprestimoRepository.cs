using ClubeDoLivro.Domain;
using ClubeDoLivro.Domain.Repositories;
using ClubeDoLivro.Infra.Data.DAO;
using System.Collections.Generic;

namespace ClubeDoLivro.Infra.Data
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly EmprestimoDAO _emprestimoDAO;
        private readonly AmigoDAO _amigoDAO;
        private readonly RevistaDAO _revistaDAO;

        public EmprestimoRepository()
        {
            _emprestimoDAO = new EmprestimoDAO();
            _amigoDAO = new AmigoDAO();
            _revistaDAO = new RevistaDAO();
        }

        public List<Emprestimo> BuscarTodos()
        {
            return _emprestimoDAO.BuscarTodos();    
        }

        public void Cadastrar(string nomeAmigo, string colecaoRevista, int anoRevista, int edicaoRevista)
        {
            var amigo = _amigoDAO.BuscaPorNome(nomeAmigo);

            if (amigo == null)
                throw new AmigoNotFoundException();

            var revista = _revistaDAO.BuscarPorParametros(colecaoRevista, anoRevista, edicaoRevista);

            if (revista == null)
                throw new RevistaNotFoundException();

            var emprestimo = new Emprestimo(revista,amigo);

            _emprestimoDAO.InserirEmprestimo(emprestimo);
            _revistaDAO.AtualizarRevista(revista);
        }
    }
}
