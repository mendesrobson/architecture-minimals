using Application.Models;
using Application.Services.Produtos.Queries;
using Application.Services.UsuarioPerfil.Queries.PerfilUsuario;
using Domain.Aggregates.PerfilUsuarioAggregate;
using Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Produtos.QueryHandlers
{
    public sealed class GetAllProdutosQueryHandlers:
         IRequestHandler<GetAllProdutosQuery, OperationResult<IEnumerable<Domain.Aggregates.ProdutosAggregate.Produtos>>> 
    {
        private readonly DataContext _ctx;

        public GetAllProdutosQueryHandlers(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<IEnumerable<Domain.Aggregates.ProdutosAggregate.Produtos>>> Handle(GetAllProdutosQuery request, 
                                                                                                             CancellationToken cancellationToken)
        {
            OperationResult<IEnumerable<Domain.Aggregates.ProdutosAggregate.Produtos>> result = new();

            result.Payload = await _ctx.Produtos.ToListAsync(cancellationToken);
            return result;
        }
    }
}
