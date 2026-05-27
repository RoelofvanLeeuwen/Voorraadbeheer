namespace Voorraadbeheer.Core.Interfaces;

/// <summary>
/// Basisinterface voor alle persistente domeinentities.
/// </summary>
public interface IEntity
{
    /// <summary>Unieke sleutel.</summary>
    int Id { get; set; }

    /// <summary>Aanmaakdatum in UTC.</summary>
    DateTime CreatedAtUtc { get; set; }

    /// <summary>Laatste wijzigingsdatum in UTC.</summary>
    DateTime UpdatedAtUtc { get; set; }

    /// <summary>Verwijderdatum in UTC. Null wanneer niet verwijderd.</summary>
    DateTime? DeletedAtUtc { get; set; }
}
