using Application.Enums;
using Application.Models;
using Application.Services.UsuarioPerfil.DTOs.Usuario;
using Application.Services.UsuarioPerfil.Queries;
using AutoMapper;
using Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UsuarioPerfil.QueryHandlers;

internal class GetByIdPerfilUsuarioHandler :
    IRequestHandler<GetByIdPerfilUsuario, OperationResult<UsuarioDto>>
{
    private readonly DataContext _ctx;

    public GetByIdPerfilUsuarioHandler(DataContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<OperationResult<UsuarioDto>> Handle(GetByIdPerfilUsuario request, 
                                                    CancellationToken cancellationToken)
    {
        OperationResult<UsuarioDto> result = new();

        var perfil = await _ctx.PerfilUsuario
                               .Where(up => up.UsuarioPerfilId == request.UsuarioPerfilId)
                               .FirstOrDefaultAsync(cancellationToken: cancellationToken);


        if(perfil is null)
        {
            result.AddError(ErroCode.NotFound,
                               string.Format(UsuarioPerfilErroMessage.UsuarioPerfilNotFound, 
                                             request.UsuarioPerfilId));
            return result;
        }

        result.Payload = UsuarioDto.FromUsuario(perfil);
        return result;
    }
}
