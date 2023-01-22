using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    internal class PerfilUsuarioConfig : IEntityTypeConfiguration<PerfisUsuarios>
    {
        public void Configure(EntityTypeBuilder<PerfisUsuarios> builder)
        {
            builder.OwnsOne(up => up.Usuario);
        }
    }
}
