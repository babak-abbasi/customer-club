using Domain.Write.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Write.EFContext;

public class EFDBContext : DbContext
{
    public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
    {
        
    }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDBContext).Assembly);
    }
}