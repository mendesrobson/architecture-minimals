using Application.Enums;
using Application.Models;
using Application.Services.Produtos.Queries;
using Application.Services.UsuarioPerfil.DTOs.Usuario;
using Application.Services.UsuarioPerfil;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
using Application.Services.Produtos.DTO;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Produtos.QueryHandlers
{
    public sealed class GetByIdProdutosQueryHandler :
         IRequestHandler<GetByIdProdutosQuery, OperationResult<ProdutosDtos>>
    {
        private readonly DataContext _ctx;

        public GetByIdProdutosQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<ProdutosDtos>> Handle(GetByIdProdutosQuery request, 
                                                                CancellationToken cancellationToken)
        {
            OperationResult<ProdutosDtos> result = new();

            var perfil = await _ctx.Produtos
                                   .Where(up => up.IdProduto == request.IdProduto)
                                   .FirstOrDefaultAsync(cancellationToken: cancellationToken);


            if (perfil is null)
            {
                result.AddError(ErroCode.NotFound,
                                   string.Format(ProdutoslErroMessage.ProdutoNotFound,
                                                 request.IdProduto));
                return result;
            }

            result.Payload = ProdutosDtos.FromProdutos(perfil);
            return result;
        }
    }
}
