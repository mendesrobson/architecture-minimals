using App.Application.Models;
using App.Domain.Aggregates.Produtos;
using MediatR;

namespace App.Application.Services.UsuarioPerfil.Queries;

public sealed record GetAllProdutos :
    IRequest<OperationResult<IEnumerable<ProdutoAggregate>>>
{
}
