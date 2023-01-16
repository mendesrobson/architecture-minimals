using Application.Services.UsuarioPerfil.Queries;
using MediatR;
using WebApiMinimal.Abstractions.EndpointDefinitions.Interfaces;

namespace WebApiMinimal.Registers;

public class UtilRegisters : IRegister
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllPerfilUsuario));
        builder.Services.AddMediatR(typeof(GetAllPerfilUsuario));
    }
}
