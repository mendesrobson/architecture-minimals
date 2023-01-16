using Domain.Aggregates.PerfilUsuarioAggregate;

namespace Application.Services.UsuarioPerfil.DTOs.Usuario
{
    public class PerfilUsuarioDto
    {
        public Guid PerfilUsuarioId { get; set; }
        public UsuarioDto Usuarios { get; set; }

        public static PerfilUsuarioDto FromPerfilUsuario(PerfisUsuarios perfil)
        {
            var usarioPerfil = new PerfilUsuarioDto { PerfilUsuarioId = perfil.UsuarioPerfilId };
            usarioPerfil.Usuarios = UsuarioDto.FromUsuario(perfil.Usuario);

            return usarioPerfil;
        }
    }
}
