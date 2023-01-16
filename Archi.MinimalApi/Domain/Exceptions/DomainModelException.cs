namespace Domain.Exceptions
{
    public abstract class DomainModelException : Exception
    {
        public List<string> ValidationErrors { get; }

        internal DomainModelException()
        {
            ValidationErrors = new();
        }

        internal DomainModelException(string message)
            : base(message)
        {
            ValidationErrors = new();
        }

        internal DomainModelException(string message, Exception exception)
            : base(message, exception)
        {
            ValidationErrors = new();
        }
    }
}
