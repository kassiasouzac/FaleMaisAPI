using FaleMaisAPI.Models;

namespace FaleMaisAPI.Interfaces
{
    public interface ITarifaRepository
    {
        List<TarifaModel> Get();
        TarifaModel Get(int id);

        TarifaModel Get(string dddOrigem, string dddDestino);

        List<string> GetDDD();

        void NovaTarifa(TarifaModel tarifa);
        void RemoverTarifa(TarifaModel tarifa);
    }
}
