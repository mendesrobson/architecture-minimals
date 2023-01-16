namespace WebApiMinimal.Abstractions.EndpointDefinitions.Interfaces;

public interface IEndpointDefinition
{
    void RegisterEndpoints(WebApplication app);
}
