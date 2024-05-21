using System.Collections.Generic;

namespace ClubeDoLivro.Domain.Repositories
{
    public interface IEmprestimoRepository
    {
        List<Emprestimo> BuscarTodos();
        void Cadastrar(string nomeAmigo, string colecaoRevista, int anoRevista, int edicaoRevista);
    }
}
