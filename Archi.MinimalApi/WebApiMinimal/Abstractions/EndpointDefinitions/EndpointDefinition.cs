using Application.Enums;
using Application.Models;
using WebApiMinimal.Abstractions.EndpointDefinitions.Interfaces;
using WebApiMinimal.Contracts.Common;

namespace WebApiMinimal.Abstractions.EndpointDefinitions;

public abstract class EndpointDefinition : IEndpointDefinition
{
    public abstract void RegisterEndpoints(WebApplication app);

    protected IResult HandleErrorResponse(List<Error> errors)
    {
        var apiError = new ErroResponse();

        if (errors.Any(e => e.Code == ErroCode.NotFound))
        {
            var error = errors.FirstOrDefault(e => e.Code == ErroCode.NotFound);

            apiError.StatusCode = 404;
            apiError.StatusMessage = "Not Found";
            apiError.Timestamp = DateTime.Now;
            apiError.Erros.Add(error.Message);

            return Results.BadRequest(apiError);
        }

        apiError.StatusCode = 400;
        apiError.StatusMessage = "Bad request";
        apiError.Timestamp = DateTime.Now;
        errors.ForEach(e => apiError.Erros.Add(e.Message));
        return Results.BadRequest(apiError);
    }
}
