namespace App.Presentation.Filters
{
    public class GuidValidationFilter : ErrorGenerate, IEndpointFilter
    {
        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            foreach (var keyValuePair in context.HttpContext.Request.RouteValues)
            {
                if (keyValuePair.Key.EndsWith("Id") || keyValuePair.Key == "id")
                {
                    var isValid = IsValidGuid(keyValuePair.Value.ToString());
                    if (!isValid)
                    {
                        var errorResponse = GenerateErrorResponse();
                        errorResponse.Erros.Add("O Id não está no formato correto 'GUID'.");
                        return Results.Json(errorResponse, statusCode: errorResponse.StatusCode);
                    }
                }
            }

            return await next(context);
        }

        private bool IsValidGuid(string id)
        {
            return Guid.TryParse(id, out var value);
        }
    }
}
