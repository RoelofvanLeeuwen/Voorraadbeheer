# Decisions

## Actieve keuzes

| Datum | Keuze | Reden | Impact | Status |
|-------|-------|-------|--------|--------|
| 2026-05-27 | Geen authenticatie in fase 1 | Eén gebruiker, lokale applicatie, geen gevoelige persoonsgegevens van derden | Geen login-flow, geen gebruikersbeheer | Actief |
| 2026-05-27 | SQLite als database | Lokale applicatie zonder serverinfrastructuur, eenvoudig te beheren | Geen aparte databaseserver nodig | Actief |
| 2026-05-27 | Server-side Blazor (.Web) als UI | Eenvoudige stack, geen JavaScript-framework nodig, goede mobiele ondersteuning via browser | Alles draait server-side, geen aparte API vereist in fase 1 | Actief |
| 2026-05-27 | Geen apart .Api-project in fase 1 | Blazor Web praat direct met Application services; WebAPI pas als externe koppelingen nodig zijn | Eenvoudigere structuur voor fase 1 | Actief |
| 2026-05-27 | DefaultTemplate.zip als verplichte designbasis voor Blazor shell | Consistente visuele basis conform projectrichtlijnen | Standaard Blazor-uiterlijk wordt vervangen door native Blazor-vertaling van het template | Actief |
| 2026-05-27 | .slnx solution-formaat | Modernere, compactere solution-definitie conform projectrichtlijnen | Vereist Visual Studio 2022 17.x+ of dotnet SDK met slnx-ondersteuning | Actief |
| 2026-05-27 | Handmatige mapping via extension methods | Maakt dataflow zichtbaar, geen AutoMapper-magie, beter leesbaar | Iets meer boilerplate, maar volledige controle | Actief |

## Vervangen of achterhaalde keuzes

| Datum | Oude keuze | Nieuwe keuze | Reden | Impact |
|-------|------------|--------------|-------|--------|

## Open beslispunten

| Vraag | Context | Mogelijke opties | Benodigde actie |
|-------|---------|------------------|-----------------|
| Welke .NET-versie gebruiken? | Afhankelijk van geïnstalleerde SDK op de machine | Hoogste stabiele versie op de machine | `dotnet --list-sdks` uitvoeren bij technische setup |
