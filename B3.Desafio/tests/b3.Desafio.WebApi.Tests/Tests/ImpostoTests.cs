using b3.Desafio.WebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace b3.Desafio.WebApi.Tests.Tests
{
    public class ImpostoTests
    {
       
        [Theory]
        [InlineData(5, 0.225)]
        [InlineData(8, 0.20)]
        [InlineData(13, 0.175)]
        [InlineData(25, 0.15)]
        [InlineData(-1, -1)]
        public void DeveRetornarAliquotaConformeEsperado(int prazo, decimal aliquotaEsperada)
        {
            //Arrange e Act
            var impostoAPagar = Imposto.ImpostoAPagar(prazo);

            
            Assert.Equal(aliquotaEsperada, impostoAPagar);
            
        }
    }
}
