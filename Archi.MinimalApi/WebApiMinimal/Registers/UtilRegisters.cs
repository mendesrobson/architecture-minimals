namespace WebApiMinimal.Registers;

public class UtilRegisters : IWebAppBuilderRegister
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllPerfilUsuario));
        builder.Services.AddMediatR(typeof(GetAllPerfilUsuario));
    }
}
