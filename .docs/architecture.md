# Architecture

## Doel van de applicatie

Persoonlijke voorraadbeheerapplicatie voor een hobbyschuur. Beheer van artikelen, categorieën, projecten en uitleningen. Zie `specification.md` voor de volledige scope.

## Huidige solution-structuur

_(Nog niet aangemaakt — volgt na initialisatie van de technische basis.)_

Geplande structuur:

```
Voorraadbeheer.slnx
│
├── src/
│   ├── Voorraadbeheer.Core/
│   ├── Voorraadbeheer.Application/
│   ├── Voorraadbeheer.Infrastructure/
│   └── Voorraadbeheer.Web/
│
├── tests/
│   ├── Voorraadbeheer.Core.Tests/
│   ├── Voorraadbeheer.Application.Tests/
│   └── Voorraadbeheer.Infrastructure.Tests/
│
└── .docs/
```

## Projectlagen

### Core

Domeinentities, interfaces, enums en domeinexceptions. Geen afhankelijkheden naar andere lagen.

Geplande inhoud:
- `Entities/` — Artikel, Categorie, Eenheid, Project, ProjectRegel, Uitlening
- `Interfaces/` — IRepository<T>, IEntity
- `Enums/` — (domeinspecifieke enums)
- `Exceptions/` — domeinexceptions

### Application

Applicatielogica: services, DTO's, mapping en validatie.

Geplande inhoud:
- `DTOs/` — per feature gegroepeerd
- `Enums/` — Application-niveau enums (geen directe Core-enums in DTO's)
- `Interfaces/` — service-interfaces
- `Services/` — ArtikelService, ProjectService, UitleningService, CategorieService
- `Mapping/` — extension methods voor entity ↔ DTO

### Infrastructure

EF Core, repositories, SQLite-persistentie.

Geplande inhoud:
- `Persistence/AppDbContext.cs`
- `Persistence/Configurations/`
- `Persistence/Migrations/`
- `Repositories/`
- `DependencyInjection.cs`

### Web

Server-side Blazor UI. Responsief ontwerp gebaseerd op `.docs/DefaultTemplate.zip`.

Geplande inhoud:
- `Components/Layout/` — MainLayout.razor, NavMenu.razor
- `Components/Pages/` — pagina's per feature
- `wwwroot/css/` — vertaalde CSS uit DefaultTemplate.zip
- `Program.cs` — met InteractiveServer rendering

## Dependency rules

```
Web → Application → Core
Infrastructure → Application, Core
Web → Infrastructure (DI-registratie)
```

Core kent geen andere lagen. Application kent Infrastructure niet.

## Belangrijkste domeinconcepten

- **Artikel** — een item in de schuur met naam, categorie, hoeveelheid, eenheid en minimumdrempel
- **Categorie** — door gebruiker gedefinieerde groepering van artikelen
- **Eenheid** — flexibele maateenheid (stuks, kg, meter, m², etc.)
- **Project** — een klusproject met een lijst van benodigde artikelen en hoeveelheden
- **ProjectRegel** — één benodigde artikel+hoeveelheid binnen een project
- **Uitlening** — registratie van een uitgeleend artikel: aan wie, wanneer, verwachte terugkeer

## Belangrijkste datastromen

_(Wordt uitgewerkt in `.docs/flow.md` na technische basis.)_

## Externe koppelingen

Geen in fase 1.

## Database en persistence

- SQLite via EF Core
- Lokaal opgeslagen op de host-machine
- Migraties via EF Core Migrations

## Security en autorisatie

Geen authenticatie in fase 1. Lokale applicatie, één gebruiker.

## Deploymentarchitectuur

Lokaal gehost op Windows. Bereikbaar via browser op pc en mobiel (zelfde netwerk).
Zie `.docs/deployment.md` voor details na inrichting.

## Bekende technische beperkingen

_(Nog geen bekende beperkingen.)_

## Open architectuurvragen

- Welke .NET-versie is geïnstalleerd op de ontwikkelmachine? (wordt bepaald via `dotnet --list-sdks`)
