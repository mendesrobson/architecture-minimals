namespace WebApiMinimal.EndpointDefinitions
{
    public class ProdutoEndpoints : EndpointDefinition
    {
        public override void RegisterEndpoints(WebApplication app)
        {
            var paramentros = ProdutoRoute.ById;

            var userProfileGroup = app.MapGroup(ProdutoRoute.NameBase);
                                      //.RequireAuthorization();

            userProfileGroup.MapGet(ProdutoRoute.NameBase, GetAll)
                            .WithName(ProdutoRoute.NameBase)
                            .WithOpenApi();


            userProfileGroup.MapGet($"/{ProdutoRoute.NameBase}/{paramentros}", GetById)
                            .AddEndpointFilter<GuidValidationFilter>()
                            .WithName(ProdutoRoute.NameBase)
                            .WithOpenApi();
        }


        private async Task<IResult> GetAll(IMediator mediator,
                                           IMapper mapper,
                                           CancellationToken token)
        {
            var query = new GetAllProdutos();
            var response = await mediator.Send(query, token);
            var profiles = mapper.Map<List<Produtos>>(response.Payload);
            return TypedResults.Ok(profiles);
        }


        private async Task<IResult> GetById(IMediator mediator,
                                            IMapper mapper, 
                                            string idProduto,
                                            CancellationToken token)
        {
            var query = new GetByIdProdutos { IdProduto = Guid.Parse(idProduto) };
            var response = await mediator.Send(query, token);

            if (response.IsError)
                return HandleErrorResponse(response.Erros);

            var userProfile = mapper.Map<Produtos>(response.Payload);
            return TypedResults.Ok(userProfile);
        }
    }
}
