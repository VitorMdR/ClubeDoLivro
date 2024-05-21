namespace ClubeDoLivro.Domain
{
    public class Amigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeMae { get; set; }
        public string Telefone { get; set; }
        public OrigemAmigo Origem { get; set; }

        public Amigo(string nome, string nomeMae, string telefone, OrigemAmigo origem)
        {
            Nome = nome;
            NomeMae = nomeMae;
            Telefone = telefone;
            Origem = origem;
        }

        public Amigo(int id, string nome, string nomeMae, int orgiem, string telefone) : this(nome, nomeMae, telefone, (OrigemAmigo)orgiem)
        {
            Id = id;
        }

        public Amigo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Id: {Id} // Nome: {Nome} // Mãe: {NomeMae} // Telefone: {Telefone} // Origem: {(Origem == OrigemAmigo.Escola ? "Escola" : "Prédio")}";
        }

    }
}
