using System;

namespace Domain.Aggregates.PerfilUsuarioAggregate;

public class PerfilUsuario
{
    private PerfilUsuario() { }

    public Guid UsuarioPerfilId { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime DataModificacao { get; private set; }

    // factory
    public static PerfilUsuario CreateUsuarioPerfil()
    {
        return new PerfilUsuario
        {
            DataCriacao = DateTime.UtcNow,
            DataModificacao = DateTime.UtcNow
        };
    }
}
