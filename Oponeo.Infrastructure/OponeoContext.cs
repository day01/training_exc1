using Microsoft.EntityFrameworkCore;
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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var auditEntity in ChangeTracker.Entries<Entity>())
        {
            if (auditEntity.State is EntityState.Added or EntityState.Modified or EntityState.Deleted)
            {
                auditEntity.Entity.ModifiedDate = DateTime.Now;

                if (auditEntity.State is EntityState.Added)
                {
                    auditEntity.Entity.CreatedDate = DateTime.Now;
                }
                else if (auditEntity.State is EntityState.Deleted)
                {
                    auditEntity.Entity.DeletedDate = DateTime.Now;
                }
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }
}