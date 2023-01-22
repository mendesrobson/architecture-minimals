using Application.Enums;
using Application.Models;
using Application.Services.Produtos.Commands;
using Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Produtos.CommandHandlers
{
    public sealed class UpdateProdutosCommandHandlers
        : IRequestHandler<UpdateProdutosCommand, 
          OperationResult<Domain.Aggregates.ProdutosAggregate.Produtos>>
    {
        private readonly DataContext _ctx;

        public UpdateProdutosCommandHandlers(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<Domain.Aggregates.ProdutosAggregate.Produtos>> Handle(UpdateProdutosCommand request, 
                                           CancellationToken cancellationToken)
        {
            OperationResult<Domain.Aggregates.ProdutosAggregate.Produtos> result = new();


            var produtosUp = await _ctx.Produtos
                                        .Where(_ => _.IdProduto == request.IdProduto)
                                        .FirstOrDefaultAsync(cancellationToken);

            if (produtosUp is null)
            {
                result.AddError(ErroCode.NotFound,
                    string.Format(ProdutoslErroMessage.ProdutoNotFound, request.IdProduto));
                return result;
            }

            produtosUp.UpdateProduto(produtosUp);

            _ctx.Produtos.Update(produtosUp);

            await _ctx.SaveChangesAsync(cancellationToken);

            result.Payload = produtosUp;

            return result;
        }
    }
}
