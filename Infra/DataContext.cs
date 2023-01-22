using Domain.Aggregates.PerfilUsuarioAggregate;
using Domain.Aggregates.ProdutosAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra;

public class DataContext : IdentityDbContext
{
    public DataContext(DbContextOptions options)
        : base(options) { }

    public DbSet<PerfisUsuarios> PerfilUsuario { get; set; }

    public DbSet<Produtos> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<InfoUsuarios>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
