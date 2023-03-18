namespace FaleMaisAPI.Models
{
    public class PlanoModel
    {
        public int Id { get; set; }

        public string Nome {get; set;}

        public int MinutosIncluidos { get; set;}

        public PlanoModel(int id, string nome, int minutosIncluidos)
        {
            Id = id;
            Nome = nome;
            MinutosIncluidos = minutosIncluidos;
        }
    }
}
