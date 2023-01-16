using AutoMapper;
using Domain.Aggregates.PerfilUsuarioAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services.UsuarioPerfil.DTOs.Usuario
{
    public class PerfilUsuarioDto
    {
        public Guid PerfilUsuarioId { get; set; }
        public UsuarioDto Usuarios { get; set; }

        public static PerfilUsuarioDto FromPerfilUsuario(UserProfile perfil)
        {
            var usarioPerfil = new PerfilUsuarioDto { PerfilUsuarioId = perfil.UsuarioPerfilId };
            usarioPerfil.Usuarios = UsuarioDto.FromUsuario(perfil.Usuario);

            return usarioPerfil;
        }
    }
}
