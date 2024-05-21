using System.Collections.Generic;

namespace ClubeDoLivro.Domain.Repositories
{
    public interface IRevistaRepository
    {
        List<Revista> BuscarTodas();
        void CadastrarRevista(Revista revista);
    }
}
