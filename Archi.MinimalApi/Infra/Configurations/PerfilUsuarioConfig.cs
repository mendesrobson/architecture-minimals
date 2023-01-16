using Domain.Aggregates.PerfilUsuarioAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    internal class PerfilUsuarioConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.OwnsOne(up => up.Usuario);
        }
    }
}
