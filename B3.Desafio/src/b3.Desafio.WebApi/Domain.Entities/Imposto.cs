namespace b3.Desafio.WebApi.Domain.Entities
{
    public class Imposto
    {

        public static decimal ImpostoAPagar(int prazoEmMeses)
        {
            if (prazoEmMeses > 0 && prazoEmMeses <= 6)
                return 0.225m;

            if (prazoEmMeses > 6 && prazoEmMeses <= 12)
                return 0.20m;

            if (prazoEmMeses > 12 && prazoEmMeses <= 24)
                return 0.175m;

            if (prazoEmMeses > 24)
                return 0.15m;

            return -1;
        }
    }
}
