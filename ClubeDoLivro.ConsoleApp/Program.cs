using System;
using ClubeDoLivro.Infra.Data.DAO;
using ClubeDoLivro.Domain;
using ClubeDoLivro.Infra.Data;

namespace ClubeDoLivro.ConsoleApp
{
    internal class Program
    {
        private static RevistaRepository _revistaRepository = new RevistaRepository();
        private static AmigoRepostiory _amigoRepository = new AmigoRepostiory();
        private static EmprestimoRepository _emprestimoRepostiory = new EmprestimoRepository();
        
        static void Main(string[] args)
        {
            Console.WriteLine("============= MENU =============");
            Console.WriteLine("1 > Cadastrar Revista");
            Console.WriteLine("2 > Visualizar revistas");
            Console.WriteLine("3 > Cadastrar empréstimo");
            Console.WriteLine("4 > Visualizar empréstimos");
            Console.WriteLine("5 > Cadastrar amigo");
            Console.WriteLine("6 > Visualizar amigos");
            Console.Write("=>");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarRevista();
                    break;
                case "2":
                    VisualizarRevistas();
                    break;
                case "3":
                    CadastrarEmprestimo();
                    break;
                case "4":
                    VisualizarEmprestimos();
                    break;
                case "5":
                    CadastrarAmigo();
                    break;
                case "6":
                    VisualizarAmigos();
                    break;
                default:
                    break;
            }
        }

        private static void VisualizarEmprestimos()
        {
            var emprestimos = _emprestimoRepostiory.BuscarTodos();

            foreach (var item in emprestimos)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void CadastrarEmprestimo()
        {
            Console.WriteLine("Nome do amigo: ");
            var nomeAmigo = Console.ReadLine();

            Console.WriteLine("Coleção da revista: ");
            var colecao = Console.ReadLine();

            Console.WriteLine("Número da edição: ");
            var numeroEdicao = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ano: ");
            var ano = Convert.ToInt32(Console.ReadLine());

            _emprestimoRepostiory.Cadastrar(nomeAmigo, colecao, ano, numeroEdicao);
        }
      

        private static void CadastrarRevista()
        {
            Console.WriteLine("Tipo da coleção: ");
            var colecao = Console.ReadLine();

            Console.WriteLine("Número da edição: ");
            var numeroEdicao = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ano: ");
            var ano = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Cor da caixa: ");
            var corCaixa = Console.ReadLine();

            var revista = new Revista(colecao, corCaixa, ano, numeroEdicao);
            _revistaRepository.CadastrarRevista(revista);
        }


        private static void VisualizarRevistas()
        {
            var revistas = _revistaRepository.BuscarTodas();

            foreach (var item in revistas)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void CadastrarAmigo()
        {
            Console.WriteLine("Nome: ");
            var nome = Console.ReadLine();

            Console.WriteLine("Nome da Mãe: ");
            var nomeMae = Console.ReadLine();

            Console.WriteLine("Telefone: ");
            var telefone = Console.ReadLine();

            Console.WriteLine("Digite 0 se o amigo é do prédio e 1 se é da escola: ");
            var origem = Convert.ToInt32(Console.ReadLine());

            var amigo = new Amigo(nome, nomeMae, telefone, (OrigemAmigo)origem);

            _amigoRepository.Cadastrar(amigo);
        }

        private static void VisualizarAmigos()
        {
            var amigos = _amigoRepository.BuscarTodos();

            foreach (var item in amigos)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
