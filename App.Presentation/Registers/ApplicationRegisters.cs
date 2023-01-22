using Microsoft.Extensions.DependencyInjection;

namespace WebApiMinimal.Registers
{
    public class ApplicationRegisters : IWebAppBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IdentityService>();
            //builder.Services.AddScoped<IApiVersionDescriptionProvider>();
        }
    }
}
