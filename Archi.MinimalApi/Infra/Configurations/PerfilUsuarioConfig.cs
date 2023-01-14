using Domain.Aggregates.PerfilUsuarioAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    internal class PerfilUsuarioConfig : IEntityTypeConfiguration<PerfilUsuario>
    {
        public void Configure(EntityTypeBuilder<PerfilUsuario> builder)
        {
            builder.OwnsOne(up => up.Usuario);
        }
    }
}
