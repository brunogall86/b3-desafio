namespace b3.Desafio.WebApi.Domain.Entities
{
    public class Rendimento
    {
        public decimal ValorInicialInvestido { get; set; }
        public int MesCalculado { get; set; }
        public decimal ValorFinalCalculado { get; set; }

        public Rendimento(decimal valorInvestido, int mesCalculado, decimal valorFinal)
        {
            ValorInicialInvestido = valorInvestido;
            MesCalculado = mesCalculado;
            ValorFinalCalculado = valorFinal;
        }
    }
}
