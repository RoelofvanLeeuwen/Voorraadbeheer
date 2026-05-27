# Specification

## Applicatiebeschrijving

Persoonlijke voorraadbeheerapplicatie voor een hobbyschuur. De app houdt bij welke materialen, bevestigingsmiddelen en machines/gereedschappen er zijn, in welke hoeveelheid, en of iets is uitgeleend. Via projecten kan de gebruiker vooraf zien wat er ontbreekt.

## Doel van de applicatie

Voorkomen dat de gebruiker midden in een project ontdekt dat materiaal op is of gereedschap uitgeleend is.

## Doelgroep en gebruikers

Eén gebruiker (de eigenaar van de schuur). De app wordt gebruikt op pc en mobiel (responsieve webapplicatie). Geen login vereist.

## Probleem dat wordt opgelost

Bij het starten van een project ontbreekt soms materiaal of is gereedschap uitgeleend. Dit wordt pas ontdekt tijdens het project, wat tijd en ergernis kost.

## Belangrijkste processen

1. **Voorraadbeheer** — artikelen toevoegen, bewerken, verwijderen en hoeveelheid bijwerken
2. **Projectplanning** — project aanmaken met lijst van benodigde materialen en hoeveelheden; tekortoverzicht bekijken
3. **Uitleenbeheer** — vastleggen aan wie iets is uitgeleend en wanneer het terugverwacht wordt; uitlening terugboeken
4. **Signalering** — overzicht van artikelen onder minimumdrempel en openstaande uitleningen

## Grove scope

### Must haves

- Artikelen beheren (naam, categorie, hoeveelheid, eenheid, minimumvoorraad)
- Flexibele eenheden: stuks, kg, meter, m², afmetingen, etc.
- Categorieën beheren (zelf aanmaken en bewerken)
- Minimumdrempel per artikel instellen
- Overzicht artikelen onder minimumdrempel
- Projecten aanmaken met lijst van benodigde materialen en hoeveelheden
- Per project: tekortoverzicht (wat ontbreekt op basis van huidige voorraad)
- Uitleningen registreren: artikel, aan wie, datum, verwachte terugkeerdatum
- Overzicht openstaande uitleningen
- Responsieve UI (werkt op desktop én mobiel)

### Should haves

- Snel zoeken en filteren op artikelen
- Notitieveld per artikel (bijv. afmeting, locatie in schuur, merk)
- Uitlening terugboeken (voorraad hersteld, uitlening afgesloten)
- Dashboard met samenvatting: tekorten, openstaande uitleningen, actieve projecten

### Could haves

- Foto per artikel
- Inkoop/aanvulhistorie per artikel
- Exporteren naar PDF of Excel
- Kosten bijhouden per artikel

### Won't haves voor deze fase

- Meerdere gebruikers of rollen
- Cloud-synchronisatie
- Barcode-scanner
- Automatisch bestellen of webshop-koppeling

## Rollen / actoren

- **Eigenaar** — enige gebruiker, volledige toegang, geen login vereist

## Randvoorwaarden

- Werkt op Windows (lokaal gehost), bereikbaar via browser op pc en telefoon
- Geen internettoegang vereist voor gebruik
- Eén gebruiker; geen authenticatie vereist in fase 1

## Externe koppelingen

Geen in fase 1.

## Security, privacy en autorisatie

Lokale applicatie zonder login. Geen gevoelige persoonsgegevens van derden. Geen aanvullende beveiligingseisen in fase 1.

## Definitie van succes voor de eerste versie

De gebruiker kan vóór een project checken of alle benodigde materialen op voorraad zijn en of alle gereedschappen beschikbaar zijn (niet uitgeleend).

## User stories

_(Worden uitgewerkt na akkoord op de initiële technische basis.)_

## Niet-functionele eisen

- Responsief ontwerp: bruikbaar op desktop (1024px+) en mobiel (320px+)
- Lokale persistentie via SQLite
- Snelle laadtijden voor eenvoudig gebruik in de schuur

## Open vragen

_(Geen op dit moment.)_

## Wijzigingshistorie

| Datum | Wijziging |
|-------|-----------|
| 2026-05-27 | Initiële scope vastgelegd op basis van gebruikersbeschrijving |
