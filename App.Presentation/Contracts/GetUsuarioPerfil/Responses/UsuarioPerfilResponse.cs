namespace App.Presentation.Contracts.UsuarioPerfil.Responses;

public class UsuarioPerfilResponse
{
    public Guid PerfilUsuarioId { get; set; }
    public UsuarioInform Usuarios { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataModificacao { get; set; }
}
