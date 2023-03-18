using FaleMaisAPI.Interfaces;
using FaleMaisAPI.Models;

namespace FaleMaisAPI.Repositories
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly List<TarifaModel> _dbContext = new List<TarifaModel>
            {
                new TarifaModel("011", "016", 1.90),
                new TarifaModel("016", "011", 2.90),
                new TarifaModel("011", "017", 1.70),
                new TarifaModel("017", "011", 2.70),
                new TarifaModel("011", "018", 0.90),
                new TarifaModel("018", "011", 1.90)
            };

        public List<TarifaModel> Get()
        => _dbContext.ToList();

        public TarifaModel Get(int id)
        => _dbContext.FirstOrDefault(t => t.Id == id);

        public TarifaModel Get(string dddOrigem, string dddDestino)
        => _dbContext.FirstOrDefault(t => t.DDDOrigem.Equals(dddOrigem) && t.DDDDestino.Equals(dddDestino));

        public List<string> GetDDD()
        => _dbContext.Select(t => t.DDDOrigem).Distinct().ToList();

        public void NovaTarifa(TarifaModel tarifa)
        =>  _dbContext.Add(tarifa);

        public void RemoverTarifa(TarifaModel tarifa)
       => _dbContext.Remove(tarifa);


    }
}
