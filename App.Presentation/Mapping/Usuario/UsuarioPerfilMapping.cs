namespace WebApiMinimal.Mapping.Usuario
{
    public class UsuarioPerfilMapping : Profile
    {
        public UsuarioPerfilMapping()
        {
            //========================================== Mapping de Commands ==========================================
            CreateMap<UsuarioPerfilCreateUpdate, UpdateUsuarioPerfil>();

            //========================================== Aggregations & Response ======================================
            CreateMap<PerfisUsuarios, UsuarioPerfilResponse>();
            CreateMap<InfoUsuarios, UsuarioInform>();
        }
    }
}
