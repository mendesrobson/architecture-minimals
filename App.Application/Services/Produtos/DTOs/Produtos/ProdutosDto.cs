namespace Application.Services.UsuarioPerfil.DTOs.Usuario;

public class ProdutosDto
{
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public List<string> Tags { get; private set; }

    public static ProdutosDto FromUsuario(string nome,
                                          decimal Preco, 
                                          List<string> tags)
    {
        return new ProdutosDto
        {
            Nome = nome,
            Preco = Preco,
            Tags = tags
        };
    }
}
