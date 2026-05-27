using Microsoft.EntityFrameworkCore;
using Voorraadbeheer.Core.Entities;
using Voorraadbeheer.Core.Interfaces;

namespace Voorraadbeheer.Infrastructure.Persistence;

/// <summary>
/// EF Core database-context voor de Voorraadbeheer-applicatie.
/// </summary>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>Artikelen in de schuur.</summary>
    public DbSet<Artikel> Artikelen => Set<Artikel>();

    /// <summary>Categorieën voor artikelen.</summary>
    public DbSet<Categorie> Categorieën => Set<Categorie>();

    /// <summary>Klusprojecten.</summary>
    public DbSet<Project> Projecten => Set<Project>();

    /// <summary>Projectregels (benodigde artikelen per project).</summary>
    public DbSet<ProjectRegel> ProjectRegels => Set<ProjectRegel>();

    /// <summary>Uitleningen.</summary>
    public DbSet<Uitlening> Uitleningen => Set<Uitlening>();

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    /// <inheritdoc/>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetAuditFields()
    {
        var now = DateTime.UtcNow;
        foreach (var entry in ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAtUtc = now;
                entry.Entity.UpdatedAtUtc = now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAtUtc = now;
            }
        }
    }
}
