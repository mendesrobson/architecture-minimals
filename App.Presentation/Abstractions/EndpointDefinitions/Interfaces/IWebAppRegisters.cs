namespace App.Presentation.Abstractions.EndpointDefinitions.Interfaces
{
    public interface IWebAppRegisters : IRegister
    {
        void RegisterServices(WebApplication builder);
    }
}
