using AutoMapper;
using Domain.Aggregates.PerfilUsuarioAggregate;

namespace Application.Services.UsuarioPerfil.DTOs.Usuario;

public class UsuarioDto
{
    public Guid UsuarioPerfilId { get; set; }
    public PerfilUsuario UsuarioPerdil { get; set; }

    public static UsuarioDto FromUsuario(PerfilUsuario usuarios)
    {
        var usuarioDto = new UsuarioDto { UsuarioPerfilId = usuarios.UsuarioPerfilId };

        return usuarioDto;


    }
}
