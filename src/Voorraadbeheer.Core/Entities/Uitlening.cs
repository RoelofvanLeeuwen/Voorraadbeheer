namespace Voorraadbeheer.Core.Entities;

/// <summary>
/// Registratie van een uitgeleend artikel.
/// </summary>
public class Uitlening : EntityBase
{
    /// <summary>Artikel-id.</summary>
    public int ArtikelId { get; set; }

    /// <summary>Navigatie naar het uitgeleende artikel.</summary>
    public Artikel Artikel { get; set; } = null!;

    /// <summary>Naam van de persoon aan wie uitgeleend is.</summary>
    public string AanWie { get; set; } = string.Empty;

    /// <summary>Datum van uitlening.</summary>
    public DateTime UitleendatumUtc { get; set; }

    /// <summary>Verwachte terugkeerdatum. Null wanneer onbekend.</summary>
    public DateTime? VerwachteTeruggaveDatumUtc { get; set; }

    /// <summary>Werkelijke teruggavedatum. Null zolang nog niet teruggegeven.</summary>
    public DateTime? TeruggegavenOpUtc { get; set; }

    /// <summary>Uitgeleende hoeveelheid.</summary>
    public decimal Hoeveelheid { get; set; }

    /// <summary>Geeft aan of dit item al is teruggegeven.</summary>
    public bool IsTeruggegeven => TeruggegavenOpUtc.HasValue;
}
