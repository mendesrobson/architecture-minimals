using Application.Models;
using Domain.Aggregates.PerfilUsuarioAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Produtos.Queries
{
    public sealed record GetAllProdutosQuery:
        IRequest<OperationResult<IEnumerable<Domain.Aggregates.ProdutosAggregate.Produtos>>>
    {
        public Guid IdProduto { get; set; }
    }
}
