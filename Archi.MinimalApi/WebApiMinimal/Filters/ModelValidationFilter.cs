using FluentValidation;
using WebApiMinimal.Contracts.Common;

namespace WebApiMinimal.Filters;

public class ModelValidationFilter<T>: ErrorGenerate, IEndpointFilter where T : class
{
    private readonly IValidator<T> _validator;

    public ModelValidationFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, 
                                               EndpointFilterDelegate next)
    {
        var model = context.Arguments
                           .FirstOrDefault(a => a.GetType() == typeof(T)) as T;

        if (model is null)
        {
            var errorResponse = GenerateErrorResponse();
            errorResponse.Erros.Add("A solicação não esta no formato correto.");
            return Results.Json(errorResponse, statusCode: errorResponse.StatusCode);
        }

        var validationResult = await _validator.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            var errorResponse = GenerateErrorResponse();
            validationResult.Errors.ForEach(e => errorResponse.Erros.Add(e.ErrorMessage));
            return Results.Json(errorResponse, statusCode: errorResponse.StatusCode);
        }
        return await next(context);
    }
}
