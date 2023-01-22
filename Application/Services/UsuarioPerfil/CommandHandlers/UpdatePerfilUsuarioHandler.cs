using Application.Enums;
using Application.Models;
using Application.Services.UsuarioPerfil.Commands;
using Domain.Aggregates.PerfilUsuarioAggregate;
using Domain.Exceptions;
using Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.UsuarioPerfil.CommandHandlers
{
    internal class UpdatePerfilUsuarioHandler
        : IRequestHandler<UpdateUsuarioPerfil, OperationResult<PerfisUsuarios>>
    {
        private readonly DataContext _ctx;

        public UpdatePerfilUsuarioHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<PerfisUsuarios>> Handle(UpdateUsuarioPerfil request,
                                                           CancellationToken cancellationToken)
        {
            OperationResult<PerfisUsuarios> result = new();

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

                var usuarioInfo = InfoUsuarios.CreateUsuarioInfo(request.Nome, request.SobreNome,
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
