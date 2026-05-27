namespace Voorraadbeheer.Core.Entities;

/// <summary>
/// Een door de gebruiker gedefinieerde groepering van artikelen.
/// </summary>
public class Categorie : EntityBase
{
    /// <summary>Naam van de categorie.</summary>
    public string Naam { get; set; } = string.Empty;

    /// <summary>Optionele omschrijving.</summary>
    public string? Omschrijving { get; set; }

    /// <summary>Artikelen in deze categorie.</summary>
    public ICollection<Artikel> Artikelen { get; set; } = [];
}
