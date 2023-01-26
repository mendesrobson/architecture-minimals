using App.Application.Models;
using Application.Services.UsuarioPerfil.DTOs.Usuario;
using MediatR;

namespace App.Application.Services.UsuarioPerfil.Queries;

public class GetByIdProdutos :
    IRequest<OperationResult<ProdutosDto>>
{
    public Guid IdProduto { get; set; }
}
