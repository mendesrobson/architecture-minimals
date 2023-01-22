namespace App.Presentation.Registers;

public class ValidateRegisters : IWebAppBuilderRegister
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
    }
}
