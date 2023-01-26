using App.Application.Enums;
using App.Application.Models;
using App.Application.Services.UsuarioPerfil.DTOs.Usuario;
using App.Application.Services.UsuarioPerfil.Queries;
using Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Services.UsuarioPerfil.QueryHandlers;

internal class GetByIdPerfilUsuarioHandler :
    IRequestHandler<GetByIdProdutos, OperationResult<PerfilUsuarioDto>>
{
    private readonly DataContext _ctx;

    public GetByIdPerfilUsuarioHandler(DataContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<OperationResult<PerfilUsuarioDto>> Handle(GetByIdProdutos request,
                                                    CancellationToken cancellationToken)
    {
        OperationResult<PerfilUsuarioDto> result = new();

        var perfil = await _ctx.PerfilUsuario
                               .Where(up => up.UsuarioPerfilId == request.UsuarioPerfilId)
                               .FirstOrDefaultAsync(cancellationToken: cancellationToken);


        if (perfil is null)
        {
            result.AddError(ErroCode.NotFound,
                               string.Format(ProdutosErroMessage.UsuarioPerfilNotFound,
                                             request.UsuarioPerfilId));
            return result;
        }

        result.Payload = PerfilUsuarioDto.FromPerfilUsuario(perfil);
        return result;
    }
}
