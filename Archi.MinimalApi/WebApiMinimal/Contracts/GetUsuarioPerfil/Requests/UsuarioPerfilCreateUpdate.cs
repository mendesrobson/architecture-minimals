namespace WebApiMinimal.Contracts.UsuarioPerfil.Requests;

public class UsuarioPerfilCreateUpdate
{
    public int Nome { get; set; }
    public int SobreNome { get; set; }
    public int Email { get; set; }
    public int Telefone { get; set; }
}
