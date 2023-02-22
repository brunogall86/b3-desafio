using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace b3.Desafio.WebApi.Extensions
{
    public class ValidationExtensions
    {   
        public static bool ValorMaiorQueZero(decimal value)
        {
            bool ehValido = true;

            if (value <= decimal.Zero)
                ehValido = false;

            return ehValido;
        }

    }
}
