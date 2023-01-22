using Application.Models;
using Application.Services.Produtos.Commands;
using Infra;
using MediatR;

namespace Application.Services.Produtos.CommandHandlers;

public sealed class CreateProdutosCommandHandlers
      : IRequestHandler<CreateProdutosCommand,
        OperationResult<Domain.Aggregates.ProdutosAggregate.Produtos>>
{
    private readonly DataContext _ctx;

    public CreateProdutosCommandHandlers(DataContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<OperationResult<Domain.Aggregates.ProdutosAggregate.Produtos>> Handle(CreateProdutosCommand request, 
                                                                                            CancellationToken cancellationToken)
    {
        var result = new OperationResult<Domain.Aggregates.ProdutosAggregate.Produtos>();

        var produt = Domain.Aggregates.ProdutosAggregate.Produtos.CreateProdutos(request.Nome, 
                                                                                 request.Preco, 
                                                                                 request.Tags);
        _ctx.Produtos.Add(produt);
        await _ctx.SaveChangesAsync(cancellationToken);

        result.Payload = produt;

        return result;
    }
}
