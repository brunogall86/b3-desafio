using b3.Desafio.WebApi.Domain.Entities.Enumeradores;
using b3.Desafio.WebApi.Extensions;
using System.ComponentModel.DataAnnotations;

namespace b3.Desafio.WebApi.Models.Requests
{
    public class InvestimentoModelRequest : RequestModelBase
    {
        public decimal ValorInicial { get; set; }

        public int Prazo { get; set; }

        protected override void Validar()
        {
            if (ValorInicial <= decimal.Zero)
                errors.Add("Valor de investimento deve ser maior que 0.");
            if (Prazo <= decimal.Zero)
                errors.Add("O prazo deve ser maior que 0.");
        }
    }
}
