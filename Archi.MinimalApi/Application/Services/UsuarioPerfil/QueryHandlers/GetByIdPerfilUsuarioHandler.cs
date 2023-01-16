using Application.Enums;
using Application.Models;
using Application.Services.UsuarioPerfil.DTOs.Usuario;
using Application.Services.UsuarioPerfil.Queries;
using Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.UsuarioPerfil.QueryHandlers;

internal class GetByIdPerfilUsuarioHandler :
    IRequestHandler<GetByIdPerfilUsuario, OperationResult<PerfilUsuarioDto>>
{
    private readonly DataContext _ctx;

    public GetByIdPerfilUsuarioHandler(DataContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<OperationResult<PerfilUsuarioDto>> Handle(GetByIdPerfilUsuario request,
                                                    CancellationToken cancellationToken)
    {
        OperationResult<PerfilUsuarioDto> result = new();

        var perfil = await _ctx.PerfilUsuario
                               .Where(up => up.UsuarioPerfilId == request.UsuarioPerfilId)
                               .FirstOrDefaultAsync(cancellationToken: cancellationToken);


        if (perfil is null)
        {
            result.AddError(ErroCode.NotFound,
                               string.Format(UsuarioPerfilErroMessage.UsuarioPerfilNotFound,
                                             request.UsuarioPerfilId));
            return result;
        }

        result.Payload = PerfilUsuarioDto.FromPerfilUsuario(perfil);
        return result;
    }
}
