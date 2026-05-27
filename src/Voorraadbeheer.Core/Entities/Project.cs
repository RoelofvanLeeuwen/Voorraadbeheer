namespace Voorraadbeheer.Core.Entities;

/// <summary>
/// Een klusproject met een lijst van benodigde materialen.
/// </summary>
public class Project : EntityBase
{
    /// <summary>Naam van het project.</summary>
    public string Naam { get; set; } = string.Empty;

    /// <summary>Optionele omschrijving van het project.</summary>
    public string? Omschrijving { get; set; }

    /// <summary>Benodigde artikelen en hoeveelheden voor dit project.</summary>
    public ICollection<ProjectRegel> Regels { get; set; } = [];
}
