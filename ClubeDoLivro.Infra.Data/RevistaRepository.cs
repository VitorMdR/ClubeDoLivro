using ClubeDoLivro.Domain;
using ClubeDoLivro.Domain.Repositories;
using ClubeDoLivro.Infra.Data.DAO;
using System.Collections.Generic;

namespace ClubeDoLivro.Infra.Data
{
    public class RevistaRepository : IRevistaRepository
    {
        private readonly RevistaDAO _revistaDAO;

        public RevistaRepository()
        {
            _revistaDAO = new RevistaDAO();
        }

        public List<Revista> BuscarTodas()
        {
            return _revistaDAO.BuscarTodas();
        }

        public void CadastrarRevista(Revista revista)
        {
            _revistaDAO.InserirRevista(revista);
        }
    }
}
