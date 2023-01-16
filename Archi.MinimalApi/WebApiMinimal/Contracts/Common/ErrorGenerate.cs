namespace WebApiMinimal.Contracts.Common
{
    public abstract class ErrorGenerate
    {
        protected ErroResponse GenerateErrorResponse()
        {
            var apiError = new ErroResponse();
            apiError.StatusCode = 400;
            apiError.StatusMessage = "Bad request";
            apiError.Timestamp = DateTime.Now;

            return apiError;
        }
    }
}
