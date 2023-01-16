namespace WebApiMinimal.EndpointDefinitions
{
    public class UsuarioPerfilEndpoints : EndpointDefinition
    {
        public override void RegisterEndpoints(WebApplication app)
        {
            var userProfileGroup = app.MapGroup(ApiRoutes.UsuarioPerfil.UserProfileBase)
                                      .RequireAuthorization();

            userProfileGroup.MapGet("/", GetAllUserProfiles);
            //.WithName("GetWeatherForecast")
            //.WithOpenApi(); 

            userProfileGroup.MapGet(ApiRoutes.UsuarioPerfil.IdRoute, GetByIdPerfilUsuario)
                            .AddEndpointFilter<GuidValidationFilter>();
        }


        private async Task<IResult> GetAllUserProfiles(IMediator mediator,
                                                       IMapper mapper,
                                                       CancellationToken token)
        {
            var query = new GetAllPerfilUsuario();
            var response = await mediator.Send(query, token);
            var profiles = mapper.Map<List<UsuarioPerfilResponse>>(response.Payload);
            return TypedResults.Ok(profiles);
        }


        private async Task<IResult> GetByIdPerfilUsuario(IMediator mediator,
                                                       IMapper mapper, string id,
                                                       CancellationToken token)
        {
            var query = new GetByIdPerfilUsuario { UsuarioPerfilId = Guid.Parse(id) };
            var response = await mediator.Send(query, token);

            if (response.IsError)
                return HandleErrorResponse(response.Erros);

            var userProfile = mapper.Map<UsuarioPerfilResponse>(response.Payload);
            return TypedResults.Ok(userProfile);
        }
    }
}
