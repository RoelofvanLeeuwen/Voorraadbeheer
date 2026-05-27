namespace Voorraadbeheer.Core.Entities;

/// <summary>
/// Een item in de schuur: materiaal, bevestigingsmiddel, gereedschap of machine.
/// </summary>
public class Artikel : EntityBase
{
    /// <summary>Naam van het artikel.</summary>
    public string Naam { get; set; } = string.Empty;

    /// <summary>Optionele aanvullende omschrijving of locatie in de schuur.</summary>
    public string? Notitie { get; set; }

    /// <summary>Huidige hoeveelheid op voorraad.</summary>
    public decimal Hoeveelheid { get; set; }

    /// <summary>Maateenheid (bijv. stuks, kg, meter, m²).</summary>
    public string Eenheid { get; set; } = string.Empty;

    /// <summary>Minimumdrempel; bij onderschrijding verschijnt het artikel in het tekortoverzicht.</summary>
    public decimal? Minimumdrempel { get; set; }

    /// <summary>Categorie-id.</summary>
    public int CategorieId { get; set; }

    /// <summary>Navigatie naar de categorie.</summary>
    public Categorie Categorie { get; set; } = null!;

    /// <summary>Openstaande uitleningen voor dit artikel.</summary>
    public ICollection<Uitlening> Uitleningen { get; set; } = [];

    /// <summary>Projectregels die dit artikel benoemen.</summary>
    public ICollection<ProjectRegel> ProjectRegels { get; set; } = [];
}
