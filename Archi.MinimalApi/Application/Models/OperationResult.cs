using Application.Enums;

namespace Application.Models
{
    public class OperationResult<T>
    {
        public T Payload { get; set; }
        public bool IsError { get; private set; }
        public List<Error> Erros { get; } = new();

        public void AddError(ErroCode code, string message)
        {
            HandleError(code, message);
        }

        public void AddUnknownError(string message)
        {
            HandleError(ErroCode.UnknownError, message);
        }

        public void ResetIsError()
        {
            IsError = false;
        }

        private void HandleError(ErroCode code, string message)
        {
            Erros.Add(new Error { Code = code, Message = message });
            IsError = true;
        }
    }
}
