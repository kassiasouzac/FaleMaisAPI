using FaleMaisAPI.Interfaces;
using FaleMaisAPI.Models;
using System.Numerics;
using System.Text.RegularExpressions;

namespace FaleMaisAPI.Services
{
    public class CalculoService : ICalculoService
    {
        private readonly ITarifaRepository _tarifaRepository;
        private readonly IPlanoRepository _planoRepository;

        public CalculoService(ITarifaRepository tarifaRepository, IPlanoRepository planoRepository)
        {
            _tarifaRepository = tarifaRepository;
            _planoRepository = planoRepository;
        }


        public List<string> GetDDD()
        => _tarifaRepository.GetDDD();

        public List<PlanoModel> GetPlanos()
        => _planoRepository.Get();

        public  double Calcular(string dddOrigem, string dddDestino, int minutos)
        {
            var tarifa =  _tarifaRepository.Get(dddOrigem, dddDestino) ?? throw new ArgumentException("Tarifa não encontrada para as cidades de origem e destino informadas.");

            var valor =  Math.Round(tarifa.ValorPorMinuto * minutos, 2);
            return valor;
        }

        public double CalcularComPlano(string dddOrigem, string dddDestino, int minutos, int planoId)
        {
            var tarifa = _tarifaRepository.Get(dddOrigem, dddDestino) ?? throw new ArgumentException("Tarifa não encontrada para as cidades de origem e destino informadas.");
            var planoFaleMais = _planoRepository.Get(planoId) ?? throw new ArgumentException("Plano FaleMais não encontrado.");
            var minutosExcedentes = minutos - planoFaleMais.MinutosIncluidos;
            var valorComPlano = Math.Round(minutosExcedentes <= 0 ? 0 : (minutosExcedentes * tarifa.ValorPorMinuto * 1.1), 2);

            return valorComPlano;
        }
    }
}
