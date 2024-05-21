using System;

namespace ClubeDoLivro.Domain
{
    public class Emprestimo
    {
        public int Id { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime? DataDevolucao { get; set; }

        public Revista Revista { get; set; }
        public Amigo Amigo { get; set; }
        public bool Devolvida { get => DataDevolucao != null; }

        public Emprestimo(Revista revista, Amigo amigo)
        {

            DataEmprestimo = DateTime.Now;
            this.Amigo = amigo;

            if (revista.Id > 0)
            {
                Revista = revista;
                Revista.Locar();
            }
        }

        public Emprestimo(int id, DateTime dataEmprestimo, DateTime? dataDevolucao, Revista revista, Amigo amigo)
        {
            Id = id;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            Revista = revista;
            Amigo = amigo;
        }

        public override string ToString()
        {
            return $"Id: {Id} // DataEmprestimo: {DataEmprestimo} // Devolvida: {Devolvida} //Devolução: {DataDevolucao} //  Revista: {Revista.TipoColecao}/{Revista.Ano}/{Revista.Edicao} // Amigo: {Amigo.Nome}";
        }
    }
}