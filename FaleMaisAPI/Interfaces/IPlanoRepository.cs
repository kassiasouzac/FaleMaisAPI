using FaleMaisAPI.Models;

namespace FaleMaisAPI.Interfaces
{
    public interface IPlanoRepository
    {
        List<PlanoModel> Get();
        PlanoModel Get(int id);
        void NovoPlano(PlanoModel plano);
        void RemoverPlano(PlanoModel plano);
    }
}
