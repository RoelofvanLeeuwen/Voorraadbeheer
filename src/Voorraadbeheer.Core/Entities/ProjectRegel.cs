namespace Voorraadbeheer.Core.Entities;

/// <summary>
/// Één benodigde artikel en hoeveelheid binnen een project.
/// </summary>
public class ProjectRegel : EntityBase
{
    /// <summary>Project-id.</summary>
    public int ProjectId { get; set; }

    /// <summary>Navigatie naar het project.</summary>
    public Project Project { get; set; } = null!;

    /// <summary>Artikel-id.</summary>
    public int ArtikelId { get; set; }

    /// <summary>Navigatie naar het benodigde artikel.</summary>
    public Artikel Artikel { get; set; } = null!;

    /// <summary>Benodigde hoeveelheid.</summary>
    public decimal BenodigdeHoeveelheid { get; set; }
}
