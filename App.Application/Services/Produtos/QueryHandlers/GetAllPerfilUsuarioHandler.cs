using App.Application.Models;
using App.Application.Services.UsuarioPerfil.Queries;
using Domain.Aggregates.PerfilUsuarioAggregate;
using Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Services.UsuarioPerfil.QueryHandlers
{
    internal class GetAllPerfilUsuarioHandler :
        IRequestHandler<GetAllPerfilUsuario, OperationResult<IEnumerable<PerfisUsuarios>>>
    {
        private readonly DataContext _ctx;

        public GetAllPerfilUsuarioHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<IEnumerable<PerfisUsuarios>>> Handle(GetAllPerfilUsuario request,
                                                                        CancellationToken cancellationToken)
        {
            OperationResult<IEnumerable<PerfisUsuarios>> result = new();

            result.Payload = await _ctx.PerfilUsuario.ToListAsync(cancellationToken);
            return result;

        }
    }
}
