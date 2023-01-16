using WebApiMinimal.Abstractions.EndpointDefinitions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infra;

namespace WebApiMinimal.Registers;

public class DbRegisters : IRegister
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
