using Microsoft.EntityFrameworkCore;
using Voorraadbeheer.Core.Interfaces;
using Voorraadbeheer.Infrastructure.Persistence;

namespace Voorraadbeheer.Infrastructure.Repositories;

/// <summary>
/// Generieke EF Core repository-implementatie voor entities die <see cref="IEntity"/> implementeren.
/// </summary>
/// <typeparam name="T">Het entity-type.</typeparam>
public class Repository<T>(AppDbContext context) : IRepository<T> where T : class, IEntity
{
    private readonly DbSet<T> _set = context.Set<T>();

    /// <inheritdoc/>
    public async Task<IReadOnlyList<T>> ListAsync()
        => await _set.Where(e => e.DeletedAtUtc == null).ToListAsync();

    /// <inheritdoc/>
    public async Task<T?> GetByIdAsync(int id)
        => await _set.FirstOrDefaultAsync(e => e.Id == id && e.DeletedAtUtc == null);

    /// <inheritdoc/>
    public async Task AddAsync(T entity)
    {
        await _set.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(T entity)
    {
        _set.Update(entity);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(T entity)
    {
        entity.DeletedAtUtc = DateTime.UtcNow;
        _set.Update(entity);
        await context.SaveChangesAsync();
    }
}
