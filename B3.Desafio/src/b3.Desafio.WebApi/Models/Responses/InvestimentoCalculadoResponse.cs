using b3.Desafio.WebApi.Domain.Entities;
using b3.Desafio.WebApi.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace b3.Desafio.WebApi.Models.Responses
{
    public class InvestimentoCalculadoResponse
    {
        public string TipoInvestimento { get; set; }
        public int Prazo { get; set; }
        public string ValorInvestido { get; set; }
        public string ValorFinal { get; set; }
        public string ValorLiquido { get; set; }
        public IList<RendimentosCalculadosResponse> Rendimentos { get; set; }
       

        public static InvestimentoCalculadoResponse ModelToResponse(Investimento investimento)
        {
            return new InvestimentoCalculadoResponse
            {
                TipoInvestimento = investimento.TipoInvestimento.ToString(),
                Prazo = investimento.PrazoInvestimento,
                ValorInvestido = investimento.ValorInicialInvestimento.FormatTwoDigits(),
                ValorFinal = investimento.ValorFinalInvestimento.FormatTwoDigits(),
                ValorLiquido = investimento.ValorFinalLiquidoInvestimento.FormatTwoDigits(),
                Rendimentos = RendimentosCalculadosResponse.ModelToResponse(investimento.TotalRendimentos.ToList())
            };
        }

    }
    public class RendimentosCalculadosResponse
    {
        public string ValorInicialInvestido { get; set; }

        public int MesCalculado { get; set; }
        public string ValorFinalCalculado { get; set; }

        public static IList<RendimentosCalculadosResponse> ModelToResponse(IList<Rendimento> rendimentos)
        {
            var l = new List<RendimentosCalculadosResponse>();
            foreach (var rendimento in rendimentos)
            {
                l.Add(new RendimentosCalculadosResponse()
                {
                    ValorInicialInvestido = rendimento.ValorInicialInvestido.FormatTwoDigits(),
                    ValorFinalCalculado = rendimento.ValorFinalCalculado.FormatTwoDigits(),
                    MesCalculado = rendimento.MesCalculado
                });
            }

            return l;
        }
    }

}
