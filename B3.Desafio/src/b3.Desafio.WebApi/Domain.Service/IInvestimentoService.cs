using b3.Desafio.WebApi.Domain.Entities;
using b3.Desafio.WebApi.Domain.Entities.Enumeradores;

namespace b3.Desafio.WebApi.Domain.Service
{
    public interface IInvestimentoService
    {
        Task<Investimento> CalcularInvestimento(decimal valorInicial, int prazo, TipoInvestimento tipoInvestimento);
    }
}
