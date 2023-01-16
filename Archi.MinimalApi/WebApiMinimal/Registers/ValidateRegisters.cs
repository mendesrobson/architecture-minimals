using FluentValidation;
using WebApiMinimal.Abstractions.EndpointDefinitions.Interfaces;

namespace WebApiMinimal.Registers;

public class ValidateRegisters : IRegister
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
    }
}
