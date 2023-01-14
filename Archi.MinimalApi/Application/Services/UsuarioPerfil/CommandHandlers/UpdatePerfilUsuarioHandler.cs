using Application.Models;
using Application.Services.UsuarioPerfil.Commands;
using Domain.Aggregates.PerfilUsuarioAggregate;
using Infra;
using MediatR;
using Domain.Exceptions;
using Application.Enums;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.UsuarioPerfil.CommandHandlers
{
    internal class UpdatePerfilUsuarioHandler
        : IRequestHandler<UpdateUsuarioPerfil, OperationResult<PerfilUsuario>>
    {
        private readonly DataContext _ctx;

        public UpdatePerfilUsuarioHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<PerfilUsuario>> Handle(UpdateUsuarioPerfil request,
                                                           CancellationToken cancellationToken)
        {
            OperationResult<PerfilUsuario> result = new();

            try
            {
                var perfilUsuario = await _ctx.PerfilUsuario
                                          .Where(_ => _.UsuarioPerfilId == request.PerfilUsuarioId)
                                          .FirstOrDefaultAsync(cancellationToken);

                if (perfilUsuario is null)
                {
                    result.AddError(ErroCode.NotFound,
                        string.Format(UsuarioPerfilErroMessage.UsuarioPerfilNotFound, request.PerfilUsuarioId));
                    return result;
                }

                var usuarioInfo = UsuariosInfo.CreateUsuarioInfo(request.Nome, request.SobreNome,
                   request.Email, request.Teefone);

                perfilUsuario.UpdateUsuario(usuarioInfo);

                _ctx.PerfilUsuario.Update(perfilUsuario);

                await _ctx.SaveChangesAsync(cancellationToken);

                result.Payload = perfilUsuario;
            }
            catch (UsuarioPerfilNotifException ex)
            {
                ex.ValidationErrors.ForEach(e => 
                             result.AddError(ErroCode.ValidationError, e));
            }
            catch (Exception e)
            {
                result.AddUnknownError(e.Message);
            }

            return result;
        }
    }
}
