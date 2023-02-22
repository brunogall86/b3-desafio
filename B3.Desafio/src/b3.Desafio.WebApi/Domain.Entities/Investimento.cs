using b3.Desafio.WebApi.Domain.Entities.Enumeradores;

namespace b3.Desafio.WebApi.Domain.Entities
{
    public abstract class Investimento
    {
        protected const decimal TB = 1.08m;
        protected const decimal CDI = 0.009m;


        public decimal ValorInicialInvestimento { get; private set; }
        public int PrazoInvestimento { get; private set; }
        public decimal ValorFinalInvestimento { get; protected set; }
        public decimal ValorFinalLiquidoInvestimento { get; protected set; }

        public TipoInvestimento TipoInvestimento { get; private set; }

        private List<Rendimento> Rendimentos { get; set; }

        public IReadOnlyList<Rendimento> TotalRendimentos { get { return Rendimentos; } }

        protected Investimento(decimal valorInicialInvestimento, int prazoInvestimento, TipoInvestimento tipoInvestimento)
        {
            ValorInicialInvestimento = valorInicialInvestimento;
            PrazoInvestimento = prazoInvestimento;
            TipoInvestimento = tipoInvestimento;

            Rendimentos = new List<Rendimento>();
        }


        public virtual void CalcularInvestimento()
        {
            CalcularRendimentos();
            CalcularValorFinal();
            CalcularValorLiquido();

        }
        protected abstract decimal CalcularRendimento(decimal valorInicial);
        protected abstract void CalcularValorLiquido();
        protected abstract void CalcularValorFinal();

        protected virtual void CalcularRendimentos()
        {
            decimal valorInicial = ValorInicialInvestimento;
            decimal valorFinal = 0;
            for (int i = 1; i <= PrazoInvestimento; i++)
            {
                valorFinal = CalcularRendimento(valorInicial);
                Rendimentos.Add(new Rendimento(valorInicial, i, valorFinal));
                valorInicial = valorFinal;
            }
        }

        public class InvestimentoFactory { 
            public static Investimento New(decimal valorInicialInvestimento, int prazoInvestimento, TipoInvestimento tipoInvestimento)
            {
                switch (tipoInvestimento)
                {
                    case TipoInvestimento.CDB:
                        return new InvestimentoCdb(valorInicialInvestimento, prazoInvestimento);
                    default:
                        return null;
                }
            }
        }
    }

    public class InvestimentoCdb : Investimento
    {
        
        public InvestimentoCdb(decimal valorInicialInvestimento, int prazoInvestimento) : base(valorInicialInvestimento, prazoInvestimento, TipoInvestimento.CDB)
        {
            
        }


        protected override decimal CalcularRendimento(decimal valorInicial)
        {
            return valorInicial * (1 + (CDI * TB));
        }

        protected override void CalcularValorFinal()
        {
            ValorFinalInvestimento = ValorInicialInvestimento + TotalRendimentos.Sum(p => p.ValorFinalCalculado - p.ValorInicialInvestido);
                
        }

        protected override void CalcularValorLiquido()
        {
            var aliquotaImposto = Imposto.ImpostoAPagar(PrazoInvestimento);
            var somaValorFinal = TotalRendimentos.Sum(p => p.ValorFinalCalculado - p.ValorInicialInvestido);
            ValorFinalLiquidoInvestimento = somaValorFinal - (somaValorFinal * aliquotaImposto);
        }

        
    }
}
