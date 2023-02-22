using b3.Desafio.WebApi.Domain.Service;
using b3.Desafio.WebApi.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3.Desafio.WebApi.Tests.Tests
{
    public class ResponseMessageTests
    {

        [Fact]
        public void InvestimentoCalculadoResponse_DeveRetornarStatusCode200()
        {
            //Arrange
            var investimento = new InvestimentoService().CalcularInvestimento(1200, 12, Domain.Entities.Enumeradores.TipoInvestimento.CDB);

            //Act
            var response = InvestimentoCalculadoResponse.ModelToResponse(investimento.Result);

            //Assert
            Assert.True(!string.IsNullOrEmpty(response.ValorFinal));
            Assert.True(response.Rendimentos.Count > 0);
        }
    }
}

