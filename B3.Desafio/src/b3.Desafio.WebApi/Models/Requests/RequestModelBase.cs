namespace b3.Desafio.WebApi.Models.Requests
{
    public abstract class RequestModelBase
    {
        protected List<string> errors { get; set; }
        
        public IReadOnlyList<string> Errors { get { return errors; }}

        protected RequestModelBase()
        {
            errors = new List<string>();
        }

        public bool EhValido()
        {
            Validar();
            return Errors.Count == 0;
        }
        protected abstract void Validar();

        
    }
}
