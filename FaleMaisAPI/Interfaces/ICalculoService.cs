using FaleMaisAPI.Models;

namespace FaleMaisAPI.Interfaces
{
    public interface ICalculoService
    {
        List<string> GetDDD();
        List<PlanoModel> GetPlanos();

        double Calcular(string dddOrigem, string dddDestino, int minutos);
        double CalcularComPlano(string dddOrigem, string dddDestino, int minutos, int planoId);
    }
}
