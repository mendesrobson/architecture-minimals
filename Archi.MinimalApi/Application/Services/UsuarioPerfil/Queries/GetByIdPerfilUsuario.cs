using Application.Models;
using Application.Services.UsuarioPerfil.DTOs.Usuario;
using MediatR;

namespace Application.Services.UsuarioPerfil.Queries
{
    public class GetByIdPerfilUsuario:
        IRequest<OperationResult<PerfilUsuarioDto>>
    {
        public Guid UsuarioPerfilId { get; set; }
    }
}
