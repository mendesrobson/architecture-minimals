namespace Domain.Aggregates.PerfilUsuarioAggregate;

public class PerfisUsuarios
{
    private PerfisUsuarios() { }

    public Guid UsuarioPerfilId { get; private set; }
    public string UsuarioIdentity { get; private set; }
    public InfoUsuarios Usuario { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime DataModificacao { get; private set; }

    public static PerfisUsuarios CreateUsuarioPerfil(string usuarioPerfilId, InfoUsuarios usuario)
    {
        return new PerfisUsuarios
        {
            UsuarioIdentity = usuarioPerfilId,
            Usuario = usuario,
            DataCriacao = DateTime.UtcNow,
            DataModificacao = DateTime.UtcNow
        };
    }

    public void UpdateUsuario(InfoUsuarios usuario)
    {
        Usuario = usuario;
        DataModificacao = DateTime.UtcNow;
    }
}
