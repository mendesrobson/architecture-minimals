using App.Application.Models;
using Domain.Aggregates.PerfilUsuarioAggregate;
using MediatR;

namespace App.Application.Services.UsuarioPerfil.Queries;

public class GetAllPerfilUsuario :
    IRequest<OperationResult<IEnumerable<PerfisUsuarios>>>
{
}
