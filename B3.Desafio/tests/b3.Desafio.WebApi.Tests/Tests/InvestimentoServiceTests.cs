using b3.Desafio.WebApi.Domain.Entities;
using b3.Desafio.WebApi.Domain.Service;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static b3.Desafio.WebApi.Domain.Entities.Investimento;

namespace b3.Desafio.WebApi.Tests.Tests
{
    public class InvestimentoServiceTests
    {

        public InvestimentoServiceTests()
        {

        }

        [Fact(DisplayName = "Calcular Investimento")]

        public async Task DeveRetornarInvestimentoCalculado()
        {
            //Arrange
            var mocker = new AutoMocker();

            var investimentoService = mocker.CreateInstance<InvestimentoService>();

            //Act
            var investimento = await investimentoService.CalcularInvestimento(1200, 12, Domain.Entities.Enumeradores.TipoInvestimento.CDB);

            //Assert
            Assert.True(investimento.ValorFinalInvestimento > investimento.ValorInicialInvestimento);
        }
    }
}
