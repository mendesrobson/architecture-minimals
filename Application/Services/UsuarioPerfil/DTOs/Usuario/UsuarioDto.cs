using Domain.Aggregates.PerfilUsuarioAggregate;

namespace Application.Services.UsuarioPerfil.DTOs.Usuario;

public class UsuarioDto
{
    public string Nome { get; private set; }
    public string SobreNome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }

    public static UsuarioDto FromUsuario(InfoUsuarios basicInfo)
    {
        return new UsuarioDto
        {
            Nome = basicInfo.Nome,
            SobreNome = basicInfo.SobreNome,
            Email = basicInfo.Email,
            Telefone = basicInfo.Telefone
        };
    }
}
