using System;

namespace Domain.Aggregates.PerfilUsuarioAggregate;

public class UserProfile
{
    private UserProfile() { }

    public Guid UsuarioPerfilId { get; private set; }
    public string UsuarioIdentity { get; private set; }
    public BasicInfo Usuario { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime DataModificacao { get; private set; }

    // factory
    public static UserProfile CreateUsuarioPerfil(string usuarioPerfilId, BasicInfo usuario)
    {
        return new UserProfile
        {
            UsuarioIdentity = usuarioPerfilId,
            Usuario = usuario,
            DataCriacao = DateTime.UtcNow,
            DataModificacao = DateTime.UtcNow
        };
    }

    public void UpdateUsuario(BasicInfo usuario)
    {
        Usuario = usuario;
        DataModificacao = DateTime.UtcNow;
    }
}
