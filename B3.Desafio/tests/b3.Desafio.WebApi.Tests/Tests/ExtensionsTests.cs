using b3.Desafio.WebApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3.Desafio.WebApi.Tests.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void DecimalExtensions_DeveRetornarDecimalFormatadoComDuasCasas()
        {
            //Arrange
            var valor = 1800.1234m;

            //Act
            var result = valor.FormatTwoDigits();

            //Assert
            Assert.True(result.Equals("R$ 1.800,12"));
        }

        [Fact]
        public void ValidationExtensions_DeveRetornarValidacaoDeEntidadeValida()
        {
            //Arrange Act Assert
            Assert.True(ValidationExtensions.ValorMaiorQueZero(10));
        }

        [Fact]
        public void ValidationExtensions_DeveRetornarValidacaoDeEntidadeInvalida()
        {
            //Arrange Act Assert
            Assert.False(ValidationExtensions.ValorMaiorQueZero(0));
            Assert.False(ValidationExtensions.ValorMaiorQueZero(-10));
        }
    }
}
