using Application.Models;
using Domain.Aggregates.PerfilUsuarioAggregate;
using MediatR;

namespace Application.Services.UsuarioPerfil.Queries;

public class GetAllPerfilUsuario :
    IRequest<OperationResult<IEnumerable<PerfisUsuarios>>>
{
}
