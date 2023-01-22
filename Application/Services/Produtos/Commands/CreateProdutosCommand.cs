using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Produtos.Commands;

public sealed record CreateProdutosCommand :
IRequest<OperationResult<Domain.Aggregates.ProdutosAggregate.Produtos>>
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public List<string> Tags { get; set; }
}

