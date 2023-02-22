using b3.Desafio.WebApi.Domain.Entities.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3.Desafio.WebApi.Tests.Tests
{
    public class TipoInvestimentoTests
    {

        [Theory]
        [InlineData("CDA")]
        [InlineData("ABD")]
        public void DeveRetornarEnumInvalidoDeAcordoComOTipoInformado(string tipo)
        {
            //Arrange Act Arrange
            object? tipoEnum;
            
            Assert.False(Enum.TryParse(typeof(TipoInvestimento), tipo, true, out tipoEnum));
        }
    }
}
