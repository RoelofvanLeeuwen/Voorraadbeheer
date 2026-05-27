using Voorraadbeheer.Core.Interfaces;

namespace Voorraadbeheer.Core.Entities;

/// <summary>
/// Basisklasse voor alle persistente domeinentities.
/// </summary>
public abstract class EntityBase : IEntity
{
    /// <inheritdoc/>
    public int Id { get; set; }

    /// <inheritdoc/>
    public DateTime CreatedAtUtc { get; set; }

    /// <inheritdoc/>
    public DateTime UpdatedAtUtc { get; set; }

    /// <inheritdoc/>
    public DateTime? DeletedAtUtc { get; set; }
}
