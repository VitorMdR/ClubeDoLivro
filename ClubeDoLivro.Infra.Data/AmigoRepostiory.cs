using ClubeDoLivro.Domain;
using ClubeDoLivro.Domain.Repositories;
using ClubeDoLivro.Infra.Data.DAO;
using System;
using System.Collections.Generic;

namespace ClubeDoLivro.Infra.Data
{
    public class AmigoRepostiory : IAmigoRepository
    {
        private readonly AmigoDAO _amigoDao;

        public AmigoRepostiory()
        {
            _amigoDao = new AmigoDAO();
        }

        public List<Amigo> BuscarTodos()
        {
            return _amigoDao.BuscarTodos();
        }

        public void Cadastrar(Amigo amigo)
        {
            _amigoDao.InserirAmigo(amigo);
        }
    }
}
