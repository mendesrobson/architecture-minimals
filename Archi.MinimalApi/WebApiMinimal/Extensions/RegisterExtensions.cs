using WebApiMinimal.Abstractions.EndpointDefinitions.Interfaces;

namespace WebApiMinimal.Extensions;

public static class RegisterExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        var registrars = GetRegisters();

        foreach (var registrar in registrars)
        {
            registrar.RegisterServices(builder);
        }
    }

    public static void RegisterEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (var endpointDef in endpointDefinitions)
        {
            endpointDef.RegisterEndpoints(app);
        }
    }

    private static IEnumerable<IRegister> GetRegisters()
    {
        var scanningType = typeof(Program);
        return scanningType.Assembly.GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IRegister)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IRegister>();
    }
}
