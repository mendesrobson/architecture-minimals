namespace App.Presentation.Registers;

public class DbRegisters : IWebAppBuilderRegister
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        var cs = builder.Configuration.GetConnectionString("SqlConnection");
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(cs);
        });
    }
}
