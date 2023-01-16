using Domain.Aggregates.PerfilUsuarioAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra;

public  class DataContext: IdentityDbContext
{
    public DataContext(DbContextOptions options) 
        : base(options){}

    public DbSet<UserProfile> PerfilUsuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<BasicInfo>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
