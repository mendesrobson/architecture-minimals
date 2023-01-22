using Application.Services.UsuarioPerfil.DTOs.Usuario;
using Domain.Aggregates.PerfilUsuarioAggregate;

namespace Application.Services.Produtos.DTO;

public class ProdutosDtos
{
    public string IdProduto { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public List<string> Tags { get; set; } = new();

    public static ProdutosDtos FromProdutos(Domain.Aggregates.ProdutosAggregate.Produtos produtos)
    {
        return new ProdutosDtos
        {
            IdProduto = produtos.IdProduto.ToString(),
            Nome = produtos.Nome,
            Preco = produtos.Preco,
            Tags = produtos.Tags
        };
    }
}
