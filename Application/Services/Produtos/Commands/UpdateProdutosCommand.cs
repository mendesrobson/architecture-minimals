using Application.Models;
using MediatR;

namespace Application.Services.Produtos.Commands
{
    public  sealed record UpdateProdutosCommand:
        IRequest<OperationResult<Domain.Aggregates.ProdutosAggregate.Produtos>>
    {
        public Guid IdProduto { get; set; }
    }
}
