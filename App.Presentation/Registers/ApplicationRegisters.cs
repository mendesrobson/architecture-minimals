namespace App.Presentation.Registers
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
