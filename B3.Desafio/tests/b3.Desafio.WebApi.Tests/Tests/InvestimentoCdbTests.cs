using b3.Desafio.WebApi.Domain.Entities;
using b3.Desafio.WebApi.Domain.Entities.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static b3.Desafio.WebApi.Domain.Entities.Investimento;

namespace b3.Desafio.WebApi.Tests.Tests
{
    public class InvestimentoCdbTests
    {
        public InvestimentoCdbTests()
        {
        
        }

        [Fact]
        public void DeveRetornarInvestimentoTipoCdb()
        {
            //Arrange e Act
            var testeTipo = InvestimentoFactory.New(Decimal.Zero, 0, TipoInvestimento.CDB);

            //Assert
            Assert.IsType<InvestimentoCdb>(testeTipo);
        }

        [Theory]
        [InlineData(1200, 12, 1347.70, 118.16)]
        public void DeveCalcularOsValoresInvestidos(decimal valorInicial, int prazo, decimal valorFinalTotalEsperado, decimal valorLiquidoEsperado)
        {
            //Arrange
            var alvo = InvestimentoFactory.New(valorInicial, prazo, TipoInvestimento.CDB);

            //act
            alvo.CalcularInvestimento();


            //Assert
            Assert.True(valorFinalTotalEsperado.ToString("C2").Equals(alvo.ValorFinalInvestimento.ToString("C2")));
            Assert.True(valorLiquidoEsperado.ToString("C2").Equals(alvo.ValorFinalLiquidoInvestimento.ToString("C2")));

        }
    }
}

