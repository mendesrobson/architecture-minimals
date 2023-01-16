using Domain.Aggregates.PerfilUsuarioAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra;

public  class DataContext: IdentityDbContext
{
    public DataContext(DbContextOptions options) 
        : base(options){}

    public DbSet<PerfisUsuarios> PerfilUsuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<InfoUsuarios>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
