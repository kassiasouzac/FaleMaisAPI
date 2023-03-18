namespace FaleMaisAPI.Models
{
    public class TarifaModel
    {
        public int Id { get; set; }
        public string DDDOrigem { get; set; }
        public string DDDDestino { get; set; }
        public double ValorPorMinuto { get; set; }

        public TarifaModel(string dddOrigem, string dddDestino, double valorPorMinuto)
        {
            DDDOrigem = dddOrigem; 
            DDDDestino = dddDestino;
            ValorPorMinuto = valorPorMinuto;
        }

        

    }
}
