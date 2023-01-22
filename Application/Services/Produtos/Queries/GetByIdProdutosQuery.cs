using Application.Models;
using Application.Services.Produtos.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Produtos.Queries
{
    public sealed record GetByIdProdutosQuery:
         IRequest<OperationResult<ProdutosDtos>>
    {
        public Guid IdProduto { get; set; }
    }
}
