using Application.Models;
using Domain.Aggregates.PerfilUsuarioAggregate;
using MediatR;

namespace Application.Services.UsuarioPerfil.Commands
{
    public class UpdateUsuarioPerfil:
        IRequest<OperationResult<UserProfile>>
    {
        public Guid PerfilUsuarioId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Teefone { get; set; }
    }
}
