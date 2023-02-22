using b3.Desafio.WebApi.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3.Desafio.WebApi.Tests.Tests
{
    public class ModelRequestTests
    {
        [Fact]
        public void InvestimentoModelRequest_DeveRetornarValido()
        {
            //Arrange
            var request = new InvestimentoModelRequest();
            request.ValorInicial = 1200;
            request.Prazo = 12;

            //Act 
            var result = request.EhValido();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void InvestimentoModelRequest_DeveRetornarInvalido()
        { 
            //Arrange
            var request = new InvestimentoModelRequest();
            request.ValorInicial = 0;
            request.Prazo = 0;

            //Act 
            var result = request.EhValido();

            //Assert
            Assert.False(result);

        }
    }
}
