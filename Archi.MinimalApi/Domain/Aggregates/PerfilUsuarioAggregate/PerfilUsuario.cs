using System;

namespace Domain.Aggregates.PerfilUsuarioAggregate;

public class PerfilUsuario
{
    private PerfilUsuario() { }

    public Guid UsuarioPerfilId { get; private set; }
    public string UsuarioIdentity { get; private set; }
    public UsuariosInfo Usuario { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime DataModificacao { get; private set; }

    // factory
    public static PerfilUsuario CreateUsuarioPerfil(string usuarioPerfilId, UsuariosInfo usuario)
    {
        return new PerfilUsuario
        {
            UsuarioIdentity = usuarioPerfilId,
            Usuario = usuario,
            DataCriacao = DateTime.UtcNow,
            DataModificacao = DateTime.UtcNow
        };
    }

    public void UpdateUsuario(UsuariosInfo usuario)
    {
        Usuario = usuario;
        DataModificacao = DateTime.UtcNow;
    }
}
