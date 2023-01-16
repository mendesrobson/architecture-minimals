using Application.Services.UsuarioPerfil.Commands;
using AutoMapper;
using Domain.Aggregates.PerfilUsuarioAggregate;
using WebApiMinimal.Contracts.UsuarioPerfil.Requests;
using WebApiMinimal.Contracts.UsuarioPerfil.Responses;

namespace WebApiMinimal.Mapping.Usuario
{
    public class UsuarioPerfilMapping: Profile
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
