using System.Collections.Generic;

namespace ClubeDoLivro.Domain.Repositories
{
    public interface IAmigoRepository
    {
        List<Amigo> BuscarTodos();
        void Cadastrar(Amigo amigo);
    }
}
