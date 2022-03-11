using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oponeo.Domain;
using Oponeo.Infrastructure.Builders;

namespace Oponeo.Infrastructure;

public class OponeoContext : DbContext
{
    public OponeoContext(DbContextOptions<OponeoContext> options)
        : base(options)
    {
    }

    public DbSet<ExampleObject> ExampleObjects { get; set; }

    public DbSet<Offer> Offers { get; set; }

    public DbSet<Parameter> Parameters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ExampleObject>().Configure();
        modelBuilder.Entity<SubExampleObject>().Configure();

        modelBuilder.Entity<Offer>().Configure();
        modelBuilder.Entity<Parameter>().Configure();
    }
}