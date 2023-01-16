namespace WebApiMinimal.Extensions;

public static class RegisterExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        var registrars = GetRegistrars<IWebAppBuilderRegister>();

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

    public static void RegisterPipelineComponents(this WebApplication app)
    {
        var registrars = GetRegistrars<IWebAppRegisters>();
        foreach (var registrar in registrars)
        {
            registrar.RegisterServices(app);
        }
    }

    private static IEnumerable<T> GetRegistrars<T>() where T : IRegister
    {
        var scanningType = typeof(Program);
        return scanningType.Assembly.GetTypes()
            .Where(t => t.IsAssignableTo(typeof(T)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<T>();
    }
}
