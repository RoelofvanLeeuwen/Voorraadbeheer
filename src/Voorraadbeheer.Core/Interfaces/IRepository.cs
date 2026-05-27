namespace Voorraadbeheer.Core.Interfaces;

/// <summary>
/// Generieke opslagfunctionaliteit voor domeinentities.
/// </summary>
/// <typeparam name="T">Het entity-type.</typeparam>
public interface IRepository<T> where T : class, IEntity
{
    /// <summary>Haalt alle niet-verwijderde entities op.</summary>
    Task<IReadOnlyList<T>> ListAsync();

    /// <summary>Haalt een entity op basis van het id op.</summary>
    Task<T?> GetByIdAsync(int id);

    /// <summary>Voegt een nieuwe entity toe.</summary>
    Task AddAsync(T entity);

    /// <summary>Werkt een bestaande entity bij.</summary>
    Task UpdateAsync(T entity);

    /// <summary>Verwijdert een entity (soft delete).</summary>
    Task DeleteAsync(T entity);
}
