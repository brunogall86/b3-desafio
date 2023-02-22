using b3.Desafio.WebApi.Domain.Entities;
using b3.Desafio.WebApi.Domain.Entities.Enumeradores;
using static b3.Desafio.WebApi.Domain.Entities.Investimento;

namespace b3.Desafio.WebApi.Domain.Service
{
    public class InvestimentoService : IInvestimentoService
    {

        public InvestimentoService()
        {
         
        }

        public async Task<Investimento> CalcularInvestimento(decimal valorInicial, int prazo, TipoInvestimento tipoInvestimento)
        {
            var investimento = InvestimentoFactory.New(valorInicial, prazo, tipoInvestimento);
            investimento.CalcularInvestimento();

            return await Task.FromResult<Investimento>(investimento);
        }
    }
}
