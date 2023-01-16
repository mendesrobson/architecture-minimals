using WebApiMinimal.Abstractions.EndpointDefinitions.Interfaces;
using Application.Services;

namespace WebApiMinimal.Registers
{
    public class ApplicationRegisters : IRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IdentityService>();
        }
    }
}
