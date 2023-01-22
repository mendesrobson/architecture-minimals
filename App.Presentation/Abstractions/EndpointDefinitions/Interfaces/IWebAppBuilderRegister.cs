namespace App.Presentation.Abstractions.EndpointDefinitions.Interfaces
{
    public interface IWebAppBuilderRegister : IRegister
    {
        void RegisterServices(WebApplicationBuilder builder);
    }
}
