using System;

namespace ClubeDoLivro.Domain
{
    public class Revista
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public int Edicao { get; set; }
        public string TipoColecao { get; set; }
        public string CorDaCaixa { get; set; }
        public bool Locada { get; set; }

        public Revista(string tipoColecao, string corCaixa, int ano, int edicao)
        {
            TipoColecao = tipoColecao;
            CorDaCaixa = corCaixa;
            Ano = ano;
            Edicao = edicao;
            Locada = false;
        }

        public Revista(int id, string tipoColecao, string corCaixa, int ano, int edicao, bool locada)
        {
            Id = id;
            TipoColecao = tipoColecao;
            CorDaCaixa = corCaixa;
            Ano = ano;
            Edicao = edicao;
            Locada = false;
        }

        internal void Locar()
        {
            if (Locada)
            {
                throw new RevistaLocadaNaoDisponivelException();
            }
            Locada = true;
        }

        public override string ToString()
        {
            return $"ID: {Id} // Tipo da Coleção: {TipoColecao} //Ano: {Ano} // Edição: {Edicao} // Caixa: {CorDaCaixa}";
        }

    }
}
