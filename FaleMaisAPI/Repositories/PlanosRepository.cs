using FaleMaisAPI.Interfaces;
using FaleMaisAPI.Models;
using System.Numerics;

namespace FaleMaisAPI.Repositories
{
   
        public class PlanoRepository : IPlanoRepository
        {
        private readonly List<PlanoModel> _dbContext = new List<PlanoModel>
            {
                new PlanoModel(1, "FaleMais 30",  30),
                new PlanoModel(2, "FaleMais 60", 60),
                new PlanoModel(3,"FaleMais 120", 120)
            };
        public List<PlanoModel> Get()
                => _dbContext.ToList();

            public PlanoModel Get(int id)
                => _dbContext.FirstOrDefault(p => p.Id == id);

            public void NovoPlano(PlanoModel plano)
            {
                _dbContext.Add(plano);
            }

            public void RemoverPlano(PlanoModel plano)
            {
                _dbContext.Remove(plano);
            }

       
    }
    }

