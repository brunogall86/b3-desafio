using System.Runtime.CompilerServices;

namespace b3.Desafio.WebApi.Extensions
{
    public static class DecimalExtensions
    {

        public static string FormatTwoDigits(this Decimal valor) => valor.ToString("C2");

    }
}
