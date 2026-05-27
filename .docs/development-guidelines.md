# Ontwikkelrichtlijnen voor .NET-projecten met Clean Architecture

Versie: 1.23  
Doel: dit document beschrijft de vaste ontwikkelstijl voor nieuwe en bestaande .NET/C#-projecten. Het is bedoeld als herbruikbare projectinstructie voor AI-assistenten zoals GitHub Copilot, Claude, Codex CLI, ChatGPT, Cursor, Windsurf of vergelijkbare AI-codeomgevingen.

Plaats dit bestand voortaan altijd in de repository als:

```text
.docs/development-guidelines.md
```

Plaats het designbestand voortaan altijd in:

```text
.docs/DefaultTemplate.zip
```

Optioneel mag daarnaast een AI-tool-specifiek instructiebestand worden toegevoegd, bijvoorbeeld:

```text
.github/copilot-instructions.md
```

Dat bestand mag kort verwijzen naar `.docs/development-guidelines.md`, maar de volledige richtlijnen staan in `.docs`. Deze richtlijnen zijn tool-onafhankelijk en gelden dus voor GitHub Copilot, Claude, Codex CLI, ChatGPT, Cursor, Windsurf en vergelijkbare AI-codeomgevingen.

---


---

## 0. Universele startprompt voor AI-codegeneratie

Gebruik deze prompt aan het begin van een nieuwe AI-sessie, ongeacht of je werkt met GitHub Copilot, Claude, Codex, ChatGPT, Cursor, Windsurf of een andere AI-codeomgeving.

Plak deze prompt letterlijk in de AI-omgeving nadat de repository is geopend:

```text
Je werkt in deze repository als mijn AI-ontwikkelassistent.

Lees eerst de projectinstructies en documentatie voordat je iets wijzigt.

Verplichte bronnen:
- AGENTS.md
- CLAUDE.md, wanneer je met Claude Code werkt
- .docs/development-guidelines.md
- .docs/DefaultTemplate.zip, wanneer aanwezig
- .docs/architecture.md
- .docs/decisions.md
- .docs/progress.md
- .docs/specification.md
- .docs/flow.md, wanneer aanwezig
- .docs/deployment.md, wanneer relevant
- .docs/troubleshooting.md, wanneer aanwezig
- README.md, wanneer aanwezig

Belangrijke regels:
1. Deze guidelines gelden voor iedere AI-omgeving. Ga er niet vanuit dat dit specifiek voor Copilot, Claude, Codex of een andere tool is.
2. Gebruik .docs/development-guidelines.md als leidende instructie.
3. Gebruik .docs/DefaultTemplate.zip als verplichte designbasis voor de initiële Blazor .Web-app-shell wanneer dit bestand aanwezig is.
4. Zet React/JSX uit het designbestand nooit letterlijk over.
5. Gebruik geen React, Babel, npm, Vite of Webpack voor de Blazor-app.
6. Vertaal het design direct bij de initiële .Web-opzet naar native Blazor/Razor-componenten en gewone CSS. Een neutrale of standaard Blazor-shell is niet toegestaan wanneer .docs/DefaultTemplate.zip aanwezig is.
7. Controleer vóór nieuwe codewijzigingen of architecture.md, progress.md, decisions.md en specification.md consistent zijn.
8. Los documentatie-inconsistenties eerst op voordat je verder bouwt.
9. Controleer vóór iedere user story de Git-status en branch.
10. Een user story mag nooit rechtstreeks op development worden geïmplementeerd.
11. Maak vóór iedere user story verplicht een nieuwe featurebranch vanaf development. Let op: de initiële projectbasis zelf hoort eerst op development te staan en gepusht te zijn; US-001 mag pas daarna op een featurebranch starten.
12. Gebruik branchnaamgeving zoals feature/US-001-korte-omschrijving.
13. Als je op development staat en een user story wilt starten, stop dan en maak eerst de featurebranch.
14. Werk pas aan code nadat de juiste featurebranch actief is.
15. Lever bij iedere user story concrete acceptatiescenario's op.
16. Bij testfouten of bugs: maak eerst een analyse- en herstelplan en pas pas code aan na expliciete akkoordvraag of opdracht.
17. Houd .docs/architecture.md, .docs/decisions.md, .docs/progress.md, .docs/specification.md en waar nodig .docs/flow.md actueel.
18. Na een volledig geteste user story wordt een pull request naar development voorbereid.
19. Voor deployment gaat development via pull request naar main.
20. Deployment gebeurt altijd vanaf main.
21. Gebruik voor nieuwe solutions standaard .slnx wanneer de tooling dit ondersteunt; gebruik .sln alleen als .slnx niet beschikbaar of passend is.
22. Gebruik C# voor alle applicatiecode. Voeg geen andere taal of runtime toe tenzij expliciet gevraagd.
23. De initiële setup mag geen functionele user stories implementeren.
24. De initiële setup bestaat alleen uit documentatie, Clean Architecture-baseline, technische basis, Git/GitHub/branches en de Blazor UI/designbaseline.
25. Na de initiële setup moet je stoppen en melden: “Het systeem is klaar voor de eerste user story.”
26. US-001 mag pas worden voorgesteld en verfijnd na akkoord van de gebruiker.
27. Maak de featurebranch voor US-001 pas nadat US-001 inhoudelijk is besproken, verfijnd en goedgekeurd.
28. Harde fasepoort: na het aanmaken/pushen van main mag je geen functionele code of user story bouwen.
29. Eerst moet je naar development, daar de volledige Blazor-basis en template-UI/designbaseline afmaken, committen en pushen naar origin/development.
30. Daarna moet je stoppen en expliciet vragen: “Wil je dat ik US-001 voorstel en samen met je verfijn?”
31. Maak pas een featurebranch nadat de gebruiker akkoord heeft gegeven op de voorgestelde/verfijnde US-001 én het implementatieplan.
32. Als je tijdens de initiële setup merkt dat je functionele code aan het schrijven bent, stop direct en corrigeer het plan.

Voer nu eerst deze controles uit en rapporteer de uitkomst:

A. Documentatiecontrole
- Bestaat .docs/development-guidelines.md?
- Bestaat .docs/DefaultTemplate.zip?
- Bestaan architecture.md, decisions.md, progress.md en specification.md?
- Zijn deze documenten consistent met elkaar?

B. Git- en branchcontrole
- Wat is de huidige branch?
- Bestaat main?
- Bestaat development?
- Bestaat origin/main?
- Bestaat origin/development?
- Is de werkmap clean?
- Zijn er openstaande wijzigingen?
- Is er een open pull request dat eerst afgerond moet worden?

C. Projectstatus
- In welke fase bevindt het project zich?
- Is de initiële basis klaar?
- Is de applicatiescope al vastgelegd?
- Zijn er al user stories?
- Zijn er per ongeluk al functionele user stories geïmplementeerd tijdens de initiële setup?
- Is de initiële setup beperkt gebleven tot technische baseline, documentatie en UI/designbaseline?
- Wat is de eerstvolgende logische stap?
- Staat de technische basis én UI/designbaseline al op development en origin/development?
- Is het verplichte stopmoment na de initiële setup al bereikt?
- Heeft de gebruiker al akkoord gegeven om US-001 te bespreken?
D. Designbaselinecontrole
- Bestaat .docs/DefaultTemplate.zip?
- Is de initiële .Web-shell direct vertaald uit dit template?
- Zijn app-shell, navigatie, appbar/header, drawer/sidebar en contentindeling overgenomen op shell-niveau?
- Is de shell native Blazor/Razor zonder React/npm/Babel/Vite/Webpack?
- Werkt interactive server rendering voor de shell?
- Werkt het hamburgermenu/drawer-menu?
- Als dit nog niet zo is: beschouw de initiële basis als niet klaar en stel eerst een plan voor om de template-shell toe te passen.


Als de eerstvolgende stap een user story is:
- Maak nog geen codewijzigingen.
- Controleer eerst dat de initiële projectbasis op development staat en naar origin/development is gepusht.
- Controleer dat development actueel is.
- Maak daarna verplicht een featurebranch vanaf development.
- Rapporteer de gekozen branchnaam.
- Ga pas daarna verder met analyse of implementatie.

Als GitHub, main of development nog ontbreekt:
- Vraag de gebruiker eerst om een GitHub repository-URL of help met het aanmaken van een lege repository op GitHub.
- Koppel daarna zelf de remote, push main, maak development aan en push development wanneer je toegang hebt.
- Als je geen toegang hebt, geef exacte commando's en stop met user-story werk totdat dit is opgelost.

Geef eerst alleen je analyse, controles en voorgestelde volgende stap. Pas nog geen code aan.
```

### 0.1 Verplichte plaatsing van guidelines en designbestand

In ieder project moeten de guidelines en het designbestand in `.docs` staan. Daarnaast staan `AGENTS.md` en `CLAUDE.md` in de root:

```text
.docs/
├── development-guidelines.md
├── DefaultTemplate.zip
├── architecture.md
├── decisions.md
├── progress.md
├── specification.md
├── flow.md
├── deployment.md
└── troubleshooting.md
```

Regels:

- `development-guidelines.md` is de tool-onafhankelijke bron voor werkwijze, architectuur en proces.
- `.docs/DefaultTemplate.zip` is de standaard designbasis voor het Blazor `.Web`-project wanneer aanwezig.
- Een AI-agent moet deze bestanden lezen vóórdat zij projectstructuur, UI, user stories of code wijzigt.
- Plaats het designbestand niet alleen buiten de repository of alleen in een chatbijlage; zet het in `.docs/DefaultTemplate.zip`.
- Als `.docs/DefaultTemplate.zip` ontbreekt, moet de AI dit melden en vragen of het template alsnog moet worden toegevoegd.
- Als het project geen Blazor UI heeft, wordt `.docs/DefaultTemplate.zip` niet toegepast, maar blijft het wel als referentie beschikbaar.

### 0.2 Harde stop voor featurebranches

Voor iedere user story geldt zonder uitzondering:

```text
Eerst initiële basis op development pushen.
Daarna pas user-story branch maken.
Nooit direct op development implementeren.
Altijd eerst een featurebranch vanaf development maken.
```

Verplichte commando's of equivalente toolacties vóór implementatie:

```bash
git checkout development
git pull
git checkout -b feature/US-xxx-korte-omschrijving
git branch --show-current
```

De actieve branch moet daarna lijken op:

```text
feature/US-xxx-korte-omschrijving
```

Als de actieve branch nog steeds `development` is, mag de AI geen user-story code schrijven.

---


## 1. AGENTS.md en CLAUDE.md als AI-ingangen

Naast `.docs/development-guidelines.md` gebruikt iedere repository een compacte AI-ingang in de root van de repository.

Standaardbestanden:

```text
AGENTS.md
CLAUDE.md
.docs/development-guidelines.md
.docs/DefaultTemplate.zip
```

### 1.1 Rol van AGENTS.md

`AGENTS.md` is de tool-onafhankelijke instructie voor AI-codeagents.

Gebruik dit bestand voor:

- GitHub Copilot coding agent;
- Codex CLI;
- Claude;
- ChatGPT;
- Cursor;
- Windsurf;
- andere AI-codeomgevingen.

`AGENTS.md` bevat niet het volledige richtlijnendocument. Het is een compacte router naar de echte projectdocumentatie.

`AGENTS.md` verwijst minimaal naar:

```text
.docs/development-guidelines.md
.docs/architecture.md
.docs/decisions.md
.docs/progress.md
.docs/specification.md
.docs/DefaultTemplate.zip
```

### 1.2 Rol van CLAUDE.md

`CLAUDE.md` is specifiek bedoeld voor Claude Code.

Ook dit bestand blijft kort. Het verwijst naar:

```text
AGENTS.md
.docs/development-guidelines.md
.docs/architecture.md
.docs/decisions.md
.docs/progress.md
.docs/specification.md
.docs/DefaultTemplate.zip
```

`CLAUDE.md` bevat geen volledige kopie van de guidelines. De volledige bron blijft:

```text
.docs/development-guidelines.md
```

### 1.3 Waarom niet alles in AGENTS.md of CLAUDE.md?

De volledige richtlijnen zijn groot en projectbreed. Als alles wordt gekopieerd naar meerdere bestanden, ontstaan snel verschillen.

Daarom geldt:

```text
.docs/development-guidelines.md = volledige bron
AGENTS.md = compacte tool-onafhankelijke ingang
CLAUDE.md = compacte Claude-specifieke ingang
```

Als regels worden aangepast, wordt eerst `.docs/development-guidelines.md` bijgewerkt. Daarna worden `AGENTS.md` en `CLAUDE.md` alleen bijgewerkt wanneer de korte startinstructie zelf verandert.

### 1.4 Verplichte rootstructuur voor AI-projecten

Bij ieder nieuw project wordt minimaal deze structuur geplaatst:

```text
AGENTS.md
CLAUDE.md
README.md
.docs/
├── development-guidelines.md
├── DefaultTemplate.zip
├── architecture.md
├── decisions.md
├── progress.md
├── specification.md
├── flow.md
├── deployment.md
└── troubleshooting.md
```

### 1.5 Harde regel

Een AI-agent mag niet starten met codewijzigingen voordat zij minimaal heeft gelezen of gecontroleerd:

```text
AGENTS.md
.docs/development-guidelines.md
.docs/architecture.md
.docs/decisions.md
.docs/progress.md
.docs/specification.md
```

Voor Claude Code geldt aanvullend:

```text
CLAUDE.md
```

Als één van deze bestanden ontbreekt, moet de AI dit melden en eerst helpen om de ontbrekende projectdocumentatie aan te maken.

---

## 2. Algemene uitgangspunten

De software moet begrijpelijk, onderhoudbaar, testbaar en uitbreidbaar zijn. Code wordt niet alleen geschreven om vandaag te werken, maar ook om later veilig aangepast te kunnen worden door andere ontwikkelaars, docenten, studenten of AI-assistenten.

Belangrijke uitgangspunten:

- Gebruik C# als primaire programmeertaal.
- Gebruik C# voor alle applicatiecode; voeg geen andere programmeertaal of runtime toe tenzij dit expliciet is afgesproken.
- Gebruik voor nieuwe solutions standaard het Visual Studio `.slnx`-formaat wanneer de gebruikte tooling dit ondersteunt; gebruik `.sln` alleen als `.slnx` niet beschikbaar of niet passend is.
- Gebruik standaard de hoogste geïnstalleerde stabiele .NET SDK/target framework-versie, tenzij het project expliciet op een bepaalde versie moet blijven.
- Controleer de beschikbare SDK's met `dotnet --list-sdks`.
- Controleer de actieve SDK met `dotnet --version`.
- Bouw volgens Clean Architecture-principes.
- Gebruik standaard een volledig server-side Blazor `.Web`-project met de normale Visual Studio template-opbouw.
- Gebruik bij de initiële Blazor UI-opzet standaard `.docs/DefaultTemplate.zip` als visuele en structurele designreferentie wanneer dit bestand naast de instructies of in de projectmap beschikbaar is.
- Gebruik niet het standaard Blazor template-uiterlijk als definitieve applicatieshell wanneer `.docs/DefaultTemplate.zip` beschikbaar is; vertaal het aangeleverde design direct bij de initiële basis naar native Blazor/Razor-componenten. Een neutrale of standaard Blazor shell is dan niet toegestaan.
- Configureer Blazor standaard met server-side interactivity, zodat pagina's en componenten interactief renderen.
- Gebruik voor WebAPI-functionaliteit standaard een apart `.Api`-project; plaats API-controllers niet in `.Web`, tenzij dit expliciet als afwijking is vastgelegd.
- Houd domeinlogica gescheiden van infrastructuur, UI en externe systemen.
- Domain enums uit Core mogen niet rechtstreeks gebruikt worden in DTO’s, Razor components, API responses of UI-code.
- Als DTO’s, API-contracten of UI een enum nodig hebben, maak dan een aparte enum in de Application-laag en map expliciet via extension methods.
- Werk in kleine, testbare verticale slices.
- Gebruik per user story een aparte branch, gebaseerd op de actuele `development` branch.
- Harde stop: implementeer een user story nooit rechtstreeks op `development`; maak altijd eerst een aparte user-story branch vanaf `development`.
- Lever bij iedere user story concrete acceptatiescenario's op die de gebruiker handmatig kan uitvoeren.
- Een user story is pas klaar voor pull request als de acceptatiescenario's zijn uitgevoerd en de resultaten zijn vastgelegd.
- Maak na een volledig geteste user story een pull request terug naar `development`.
- Start geen nieuwe user-story branch zolang er nog een open pull request staat.
- Maak na de initiële basis een GitHub-repository aan en richt daarna een `development` branch in als basis voor verdere ontwikkeling.
- De AI-omgeving moet deze Git/GitHub/branch-stappen zelf uitvoeren wanneer zij toegang heeft tot de lokale Git-omgeving en GitHub tooling.
- Harde stop: werk geen user story uit zolang Git, GitHub, de initiële commit op `main` en de `development` branch niet correct zijn ingericht.
- Maak voor releases/deployment een pull request van `development` naar `main`.
- Deployments vinden altijd plaats vanaf `main`, niet vanaf `development` of feature branches.
- Maak wijzigingen stap voor stap.
- Laat controllers, UI-componenten en tools zo dun mogelijk.
- Plaats businesslogica in services.
- Plaats opslagdetails in repositories en infrastructuur.
- Gebruik dependency injection consequent.
- Registreer services per project via een eigen static dependency injection extension class; `Program.cs` roept alleen projectbrede extension methods aan.
- Gebruik voor persistente domeinentities standaard een `IEntity`-interface met `Id`, `CreatedAtUtc`, `UpdatedAtUtc` en `DeletedAtUtc`.
- Gebruik een generic repository voor standaard opslaggedrag voor types die `IEntity` implementeren.
- Gebruik extension methods voor mapping en eenvoudige herbruikbare bewerkingen op entities, DTO's of eenvoudige types.
- Gebruik duidelijke Engelse naamgeving in code.
- Voeg Nederlandse XML-documentatie toe aan nieuwe of aangepaste publieke types, interfaces en belangrijke methods.
- Schrijf geen onnodige inline comments.
- Maak code die compileert en direct testbaar is.
- Bij testfouten of bugs maakt de AI eerst een analyse- en herstelplan; zij implementeert de oplossing pas na expliciete akkoordvraag of opdracht.
- Houd architectuur, keuzes, specificaties, user stories en voortgang actief bij in Markdown-documentatie.
- Vraag na het initieel aanmaken van solution, projecten en documentatie altijd om een heldere en uitgebreide applicatiebeschrijving voordat user stories worden uitgewerkt.
- Leg de applicatiebeschrijving, doelgroep, doel, grove scope en MoSCoW-indeling vast in de documentatie en gebruik dit als basis voor user stories.
- Een AI-assistent die code genereert moet relevante documentatie automatisch aanvullen of bijwerken bij iedere betekenisvolle wijziging.
- Voer vóór nieuwe codewijzigingen een documentatieconsistentiecontrole uit wanneer `architecture.md`, `progress.md`, `decisions.md` of `specification.md` elkaar kunnen tegenspreken.
- Los documentatie-inconsistenties eerst op voordat nieuwe user stories of codewijzigingen worden uitgewerkt.

---

## 3. .NET-versie bepalen

Voor nieuwe projecten wordt niet blind een vaste .NET-versie gekozen. De standaardregel is:

```text
Gebruik de hoogste geïnstalleerde stabiele .NET SDK en target framework-versie.
```

Controleer dit op de ontwikkelmachine met:

```bash
dotnet --list-sdks
dotnet --version
dotnet --list-runtimes
```

Richtlijn:

- Voor een nieuw project: gebruik de hoogste geïnstalleerde stabiele .NET-versie.
- Voor een bestaand project: respecteer de bestaande `TargetFramework`, tenzij expliciet wordt besloten om te upgraden.
- Voor onderwijsprojecten: kies een versie die ook op de machines van studenten beschikbaar is.
- Voor productieprojecten: kies bij voorkeur een LTS-versie, tenzij bewust voor een Current/STF-versie wordt gekozen.
- Leg een bewuste afwijking vast in de documentatie.

Voorbeeld in een `.csproj`:

```xml
<TargetFramework>net9.0</TargetFramework>
```

Dit voorbeeld is geen harde standaard. De daadwerkelijke waarde hangt af van de geïnstalleerde SDK en de projectafspraken.

---

## 4. Gebruik met Visual Studio en GitHub Copilot

Wanneer je in Visual Studio een nieuw project aanmaakt, kun je dit bestand in de repository zetten en AI-agent expliciet vragen het toe te passen.

Aanbevolen werkwijze:

1. Maak in Visual Studio een lege solution of basisproject aan.
2. Voeg dit document toe aan de repository.
3. Plaats het bij voorkeur als `.github/copilot-instructions.md`.
4. Maak ook direct de documentatiestructuur onder `.docs/`.
5. Commit de instructie- en documentatiebestanden vroeg in het project.
6. Maak of koppel een GitHub-repository zodra de initiële basis staat.
7. Maak daarna een `development` branch vanaf de initiële stabiele basis.
8. Vraag AI-agent daarna expliciet om volgens deze richtlijnen te werken.

Voorbeeldprompt:

```text
Lees eerst het bestand .github/copilot-instructions.md.
Pas alle relevante richtlijnen uit dat document toe op dit project.

Ik wil dat je bij alle voorstellen rekening houdt met:
- Clean Architecture
- hoogste geïnstalleerde stabiele .NET-versie
- duidelijke projectstructuur
- repository pattern waar zinvol
- services als applicatielaag
- DTO's voor API/UI
- EF Core in Infrastructure
- dunne controllers
- async/await
- Nederlandse XML-documentatie
- kleine verticale slices
- acceptatietesten na iedere stap
- actief bijhouden van .docs/architecture.md
- actief bijhouden van .docs/decisions.md
- actief bijhouden van .docs/progress.md
- verwerken van user stories in .docs/specification.md

Doe nu nog geen grote wijzigingen. Geef eerst een voorstel voor de solution-structuur en de benodigde documentatiestructuur.
```

Een Markdown-bestand in de repository is geen garantie dat AI-agent altijd alles perfect toepast. Blijf in prompts expliciet verwijzen naar het bestand, zeker bij grotere wijzigingen.

---

## 5. Verplichte documentatiestructuur

Elke repository bevat een `.docs` map waarin de actuele situatie van het project wordt bijgehouden.

Minimale structuur:

```text
.docs/
├── development-guidelines.md
├── DefaultTemplate.zip
├── architecture.md
├── decisions.md
├── progress.md
├── specification.md
├── flow.md
├── deployment.md
└── troubleshooting.md
```

Daarnaast staat in de root een `README.md`.

Optioneel kan voor AI-agent ook deze map/bestand worden gebruikt:

```text
.github/
└── copilot-instructions.md
```

### 4.1 architecture.md

`architecture.md` beschrijft de actuele architectuur van de applicatie. Dit bestand moet gedurende de ontwikkeling worden bijgewerkt wanneer de structuur, lagen, afhankelijkheden, datastromen of technische keuzes veranderen.

Minimale inhoud:

```text
# Architecture

## Doel van de applicatie

## Huidige solution-structuur

## Projectlagen

### Core
### Application
### Infrastructure
### Web
### Blazor of UI
### Tools

## Dependency rules

## Belangrijkste domeinconcepten

## Belangrijkste datastromen

## Externe koppelingen

## Database en persistence

## Security en autorisatie

## Deploymentarchitectuur

## Bekende technische beperkingen

## Open architectuurvragen
```

Regels:

- Dit bestand beschrijft de actuele werkelijke situatie, niet alleen de gewenste situatie.
- Als code afwijkt van de architectuur, wordt dat expliciet benoemd.
- Bij iedere nieuwe verticale slice wordt gecontroleerd of dit bestand moet worden aangepast.
- Grote technische keuzes worden niet alleen hier genoemd, maar ook vastgelegd in `decisions.md`.

### 4.2 decisions.md

`decisions.md` houdt technische en functionele keuzes bij. Dit is bedoeld als eenvoudig Architecture Decision Record-bestand, zonder zware formele ADR-structuur.

Minimale inhoud:

```text
# Decisions

## Actieve keuzes

| Datum | Keuze | Reden | Impact | Status |
|------|-------|-------|--------|--------|

## Vervangen of achterhaalde keuzes

| Datum | Oude keuze | Nieuwe keuze | Reden | Impact |
|------|------------|--------------|-------|--------|

## Open beslispunten

| Vraag | Context | Mogelijke opties | Benodigde actie |
|------|---------|------------------|-----------------|
```

Voorbeelden van keuzes die hierin thuishoren:

- gekozen .NET-versie;
- gekozen database;
- keuze voor SQLite, SQL Server of PostgreSQL;
- keuze voor repository pattern;
- keuze voor handmatige mapping in plaats van AutoMapper;
- keuze voor controllers in plaats van Minimal APIs;
- keuze voor JWT-authenticatie;
- keuze om tools via WebAPI te laten schrijven in plaats van rechtstreeks naar de database;
- keuze voor Docker, Raspberry Pi, VPS of andere deploymentvorm;
- bewuste afwijkingen van Clean Architecture.

Regels:

- Nieuwe belangrijke keuzes worden direct toegevoegd.
- Oude keuzes worden niet stilzwijgend verwijderd, maar verplaatst of gemarkeerd als vervangen.
- De status kan bijvoorbeeld zijn: `Actief`, `Voorgesteld`, `Vervangen`, `Afgewezen`, `Nog te besluiten`.

### 4.3 progress.md

`progress.md` houdt de actieve ontwikkelstatus bij. Dit bestand moet na iedere betekenisvolle wijziging worden bijgewerkt.

Minimale inhoud:

```text
# Progress

## Huidige status

Korte samenvatting van de actuele stand van het project.

## Actieve branch

## Laatste werkende situatie

## Afgeronde onderdelen

| Datum | Onderdeel | Resultaat | Teststatus |
|------|-----------|-----------|------------|

## Lopende onderdelen

| Onderdeel | Status | Volgende stap | Blokkades |
|----------|--------|---------------|-----------|

## Nog te doen

| Prioriteit | Onderdeel | Reden |
|-----------|-----------|-------|

## Bekende problemen

| Probleem | Impact | Mogelijke oplossing |
|---------|--------|---------------------|

## Laatste acceptatietesten

| Datum | Test | Resultaat |
|------|------|-----------|

## Volgende logische stap

Beschrijf concreet wat de volgende kleine stap is.
```

Regels:

- Dit bestand is leidend voor de actieve ontwikkelstatus.
- Als een nieuwe chat of AI-sessie start, moet dit bestand worden gelezen.
- Na een werkende wijziging wordt de laatste werkende situatie bijgewerkt.
- Na acceptatietesten wordt de teststatus bijgewerkt.
- Als iets half af is, wordt dat expliciet vermeld.
- De volgende logische stap moet concreet zijn, niet vaag.

### 4.4 specification.md

`specification.md` bevat de applicatiebeschrijving, grove scope, MoSCoW-indeling, functionele specificatie, user stories en acceptatiecriteria.

Minimale inhoud:

```text
# Specification

## Applicatiebeschrijving

## Doel van de applicatie

## Doelgroep en gebruikers

## Probleem dat wordt opgelost

## Belangrijkste processen

## Grove scope

### Must haves

### Should haves

### Could haves

### Won't haves voor deze fase

## Rollen / actoren

## Randvoorwaarden

## Externe koppelingen

## Security, privacy en autorisatie

## Definitie van succes voor de eerste versie

## User stories

### US-001 - Titel

Als [rol]  
wil ik [functionaliteit]  
zodat [waarde/resultaat].

#### Acceptatiecriteria

- [ ] Gegeven ...
- [ ] Wanneer ...
- [ ] Dan ...

#### Technische notities

#### Status

Voorgesteld / In ontwikkeling / Gereed / Vervallen

## Niet-functionele eisen

## Open vragen

## Wijzigingshistorie
```

Regels:

- De initiële applicatiebeschrijving en grove scope worden eerst hier vastgelegd.
- Nieuwe user stories worden daarna eerst hier vastgelegd of bijgewerkt.
- Een user story krijgt acceptatiecriteria voordat er code wordt gegenereerd.
- Als tijdens ontwikkeling blijkt dat de story wijzigt, wordt dit bestand aangepast.
- Technische implementatiedetails horen beperkt in dit bestand; diepere technische keuzes horen in `architecture.md` of `decisions.md`.
- Afgeronde user stories worden niet verwijderd, maar op `Gereed` gezet.

### 4.5 flow.md

`flow.md` beschrijft belangrijke proces- en datastromen.

Voorbeelden:

- request-flow van UI naar API naar database;
- ingest-flow van externe bron naar opslag;
- authenticatie-flow;
- deployment-flow;
- import/export-flow;
- simulator-flow.

### 4.6 deployment.md

`deployment.md` beschrijft hoe de applicatie wordt gedraaid, gedeployed en beheerd.

Minimale inhoud:

- benodigde SDK/runtime;
- database;
- connection strings;
- environment variables;
- Docker-instructies;
- poorten;
- startvolgorde;
- logcontrole;
- updateproces;
- rollbackproces.

### 4.7 troubleshooting.md

`troubleshooting.md` bevat bekende fouten, symptomen en oplossingen.

Voorbeeld:

```text
## Probleem: EF Core PendingModelChangesWarning

### Symptoom

### Oorzaak

### Oplossing

### Controle
```

---

## 6. Initiële applicatiebeschrijving en grove scope

Nadat initieel de solution, projecten en documentatiestructuur zijn aangemaakt, mag de AI niet direct beginnen met het uitwerken van user stories of bouwen van functionaliteit.

Eerst moet de AI de gebruiker vragen om de applicatie helder en uitgebreid te beschrijven.

Doel van deze stap:

- begrijpen wat de applicatie moet doen;
- begrijpen voor wie de applicatie bedoeld is;
- begrijpen welk probleem wordt opgelost;
- bepalen wat de grove scope is;
- bepalen wat voorlopig buiten scope valt;
- de basis leggen voor goede user stories;
- voorkomen dat de AI te vroeg technische aannames doet.

### 5.1 Verplichte vraag aan de gebruiker

De AI stelt na het initieel aanmaken van solution, projecten en documentatie minimaal deze vraag:

```text
Beschrijf de applicatie zo helder en uitgebreid mogelijk.

Neem daarbij op:
1. Wat moet de applicatie doen?
2. Voor wie is de applicatie bedoeld?
3. Wat is het doel van de applicatie?
4. Welk probleem lost de applicatie op?
5. Wie zijn de belangrijkste gebruikers of rollen?
6. Wat zijn de belangrijkste processen of workflows?
7. Wat zijn de Must haves?
8. Wat zijn de Should haves?
9. Wat zijn de Could haves?
10. Wat zijn de Won't haves voor deze fase?
11. Zijn er belangrijke technische randvoorwaarden?
12. Zijn er koppelingen met andere systemen?
13. Zijn er beveiligings-, privacy- of autorisatie-eisen?
14. Wanneer is de eerste versie geslaagd?
```

De gebruiker hoeft dit niet perfect gestructureerd aan te leveren. De AI moet de input ordenen, samenvatten en waar nodig verduidelijken.

### 5.2 AI beoordeelt of de omschrijving voldoende is

De AI moet zelf beoordelen of de omschrijving voldoende is om een grove scope te bepalen.

Voldoende betekent:

- het doel van de applicatie is duidelijk;
- de doelgroep of gebruikers zijn duidelijk;
- de belangrijkste processen zijn globaal duidelijk;
- er is een eerste beeld van Must haves;
- er is een eerste beeld van wat buiten scope valt;
- er is genoeg informatie om eerste user stories te formuleren.

Onvoldoende betekent bijvoorbeeld:

- het doel is nog te vaag;
- niet duidelijk is wie de gebruikers zijn;
- Must haves ontbreken;
- er zijn tegenstrijdigheden;
- de scope is veel te breed;
- er ontbreken essentiële randvoorwaarden.

Als de omschrijving onvoldoende is, stelt de AI gerichte vervolgvragen. De AI mag dan nog geen user stories definitief maken.

Voorbeeld:

```text
De omschrijving is nog niet voldoende om een grove scope te bepalen.

Ik mis nog:
1. Wie gebruikt de applicatie dagelijks?
2. Wat moet absoluut in versie 1 zitten?
3. Welke onderdelen vallen bewust buiten de eerste versie?

Beantwoord deze punten eerst, dan werk ik daarna de scope en user stories uit.
```

### 5.3 Vastleggen in documentatie

De applicatiebeschrijving en grove scope worden vastgelegd in:

```text
.docs/specification.md
.docs/progress.md
.docs/decisions.md indien er scope- of architectuurkeuzes worden gemaakt
```

`specification.md` krijgt hiervoor minimaal deze onderdelen:

```text
# Specification

## Applicatiebeschrijving

## Doel van de applicatie

## Doelgroep en gebruikers

## Probleem dat wordt opgelost

## Belangrijkste processen

## Grove scope

### Must haves

### Should haves

### Could haves

### Won't haves voor deze fase

## Rollen / actoren

## Randvoorwaarden

## Externe koppelingen

## Security, privacy en autorisatie

## Definitie van succes voor de eerste versie

## User stories
```

`progress.md` wordt bijgewerkt met:

```text
## Huidige status

De initiële solution, projecten en documentatiestructuur zijn aangemaakt.
De applicatiebeschrijving en grove scope zijn vastgelegd.
De volgende stap is het uitwerken van de eerste user stories op basis van de vastgelegde scope.

## Volgende logische stap

Werk de eerste user stories uit vanuit .docs/specification.md.
```

### 5.4 Relatie met user stories

User stories worden pas opgesteld nadat de applicatiebeschrijving en grove scope voldoende helder zijn.

Regels:

- User stories moeten herleidbaar zijn naar de applicatiebeschrijving en MoSCoW-scope.
- Must haves krijgen prioriteit bij de eerste user stories.
- Should haves worden pas opgepakt als de basis stabiel is of als de gebruiker dat expliciet wil.
- Could haves worden niet stiekem meegenomen in de eerste implementatie.
- Won't haves worden niet gebouwd, tenzij de gebruiker de scope expliciet wijzigt.
- Als tijdens het bouwen blijkt dat een user story buiten de scope valt, moet dit worden gemeld en vastgelegd.

### 5.5 Scopewijzigingen

Als de gebruiker later de scope wijzigt, moet de AI:

1. De wijziging samenvatten.
2. Controleren of dit Must, Should, Could of Won't beïnvloedt.
3. `.docs/specification.md` bijwerken.
4. `.docs/progress.md` bijwerken.
5. `.docs/decisions.md` bijwerken als het een duidelijke keuze of scopewijziging is.
6. Nieuwe of aangepaste user stories voorstellen.

Scopewijzigingen worden niet stilzwijgend doorgevoerd.

---

## 7. Regels voor automatisch documentatie bijwerken door AI

Een AI-assistent die code genereert of wijzigt, moet bij iedere betekenisvolle wijziging controleren welke documentatie moet worden bijgewerkt.

Betekenisvolle wijzigingen zijn onder andere:

- nieuwe feature;
- nieuwe user story;
- nieuwe projectlaag;
- nieuwe service;
- nieuwe controller;
- nieuwe entity;
- nieuwe repository;
- nieuwe database/migration;
- nieuwe externe koppeling;
- wijziging in datastroom;
- wijziging in deployment;
- wijziging in authenticatie/autorisatie;
- wijziging in technische keuze;
- wijziging in actieve status of voortgang.

Documentatieregels:

```text
Nieuwe of gewijzigde architectuur     → .docs/architecture.md
Nieuwe technische keuze               → .docs/decisions.md
Nieuwe of gewijzigde applicatiescope    → .docs/specification.md, .docs/progress.md, eventueel .docs/decisions.md
Nieuwe of gewijzigde user story        → .docs/specification.md
Nieuwe voortgang of testresultaat      → .docs/progress.md
Nieuwe datastroom                      → .docs/flow.md
Nieuwe deploymentstap                  → .docs/deployment.md
Nieuwe bekende fout/oplossing          → .docs/troubleshooting.md
```

Een AI-assistent moet na iedere wijziging expliciet melden:

```text
Documentatie bijgewerkt:
- .docs/architecture.md: ja/nee, reden
- .docs/decisions.md: ja/nee, reden
- .docs/specification.md: ja/nee, reden
- .docs/progress.md: ja/nee, reden
- .docs/flow.md: ja/nee, reden
- .docs/deployment.md: ja/nee, reden
- .docs/troubleshooting.md: ja/nee, reden
```

Als documentatie niet is bijgewerkt, moet kort worden uitgelegd waarom niet.

---

## 8. Documentatieconsistentiecontrole

Voordat de AI nieuwe user stories, featurebranches of codewijzigingen uitwerkt, moet zij controleren of de belangrijkste documentatiebestanden elkaar niet tegenspreken.

Deze controle is verplicht wanneer:

- een nieuwe AI-sessie start;
- de gebruiker vraagt “waar staan we?”;
- de gebruiker vraagt “wat is de volgende stap?”;
- een nieuwe user story wordt gestart;
- een branch wordt aangemaakt;
- een pull request wordt voorbereid;
- deployment wordt voorbereid;
- de AI merkt dat één document een andere status beschrijft dan een ander document.

### 7.1 Te controleren documenten

Minimaal deze documenten worden met elkaar vergeleken:

```text
.docs/architecture.md
.docs/progress.md
.docs/decisions.md
.docs/specification.md
```

Indien aanwezig of relevant worden ook gecontroleerd:

```text
.docs/flow.md
.docs/deployment.md
.docs/troubleshooting.md
README.md
.github/copilot-instructions.md
```

### 7.2 Rollen van de documenten

Gebruik deze rolverdeling om inconsistenties te beoordelen:

```text
architecture.md   = actuele technische architectuur en structurele werkelijkheid
progress.md       = actuele voortgang, laatste werkende situatie en volgende stap
decisions.md      = actieve en historische technische/functionele keuzes
specification.md  = applicatiebeschrijving, scope, MoSCoW, user stories en acceptatiecriteria
flow.md           = actuele proces- en datastromen
deployment.md     = actuele deploymentwijze en releaseproces
```

Belangrijk:

- `progress.md` mag tijdelijke voortgang bevatten, maar mag niet structureel botsen met `architecture.md`.
- `architecture.md` mag geen verouderde technische situatie beschrijven.
- `decisions.md` moet actieve keuzes bevatten die overeenkomen met de architectuur.
- `specification.md` is leidend voor functionele scope en user stories.
- Als er geen functionele scope is vastgelegd, mogen er geen functionele user stories worden gebouwd.

### 7.3 Wat te doen bij inconsistenties

Als documenten elkaar tegenspreken, moet de AI eerst stoppen met bouwen en de inconsistentie benoemen.

De AI moet dan melden:

```text
Documentatieconsistentiecontrole:

Gevonden inconsistentie:
- Bestand A zegt: ...
- Bestand B zegt: ...

Waarschijnlijke actuele werkelijkheid:
- ...

Voorstel:
- Werk bestand X bij omdat dit achterloopt.
- Laat bestand Y staan omdat dit overeenkomt met de actuele situatie.

Ik werk eerst de documentatie bij voordat ik nieuwe code of user stories voorstel.
```

De AI mag pas verder met user stories of codewijzigingen nadat de documentatieconsistentie is hersteld.

### 7.4 Bron van waarheid bij veelvoorkomende situaties

#### GitHub- en branchstatus

Als `progress.md` en de actuele Git-status bevestigen dat GitHub, `main` en `development` bestaan, maar `architecture.md` nog zegt dat de remote ontbreekt, dan loopt `architecture.md` achter.

Actie:

```text
Werk architecture.md bij zodat GitHub, main en development correct beschreven zijn.
```

#### Functionele scope

Als `architecture.md` en `progress.md` aangeven dat de basis klaar is, maar `specification.md` nog geen applicatiebeschrijving, MoSCoW-scope of user stories bevat, dan is de volgende stap geen code maar scope invullen.

Actie:

```text
Vraag de gebruiker om applicatiebeschrijving en MoSCoW-scope.
Werk specification.md en progress.md bij.
```

#### Technische keuze ontbreekt

Als de code of architectuur een duidelijke keuze bevat, maar `decisions.md` vermeldt die keuze niet, dan loopt `decisions.md` achter.

Actie:

```text
Voeg de keuze toe aan decisions.md met datum, reden, impact en status.
```

#### Architectuur wijkt af van code

Als `architecture.md` een structuur beschrijft die niet overeenkomt met de solution, dan moet de AI eerst bepalen wat de gewenste waarheid is.

Actie:

```text
Meld de afwijking.
Vraag of de code moet worden aangepast aan de architectuur, of architecture.md aan de code.
Doe geen grote refactor zonder expliciete keuze.
```

### 7.5 Verplichte output na controle

Na de controle moet de AI kort rapporteren:

```text
Documentatieconsistentiecontrole:
- architecture.md: actueel / bijwerken nodig
- progress.md: actueel / bijwerken nodig
- decisions.md: actueel / bijwerken nodig
- specification.md: actueel / bijwerken nodig
- conclusie: doorgaan / eerst documentatie herstellen
```

Als bijwerken nodig is, moet de AI de update zelf uitvoeren wanneer zij schrijftoegang heeft. Als dat niet kan, geeft zij een concrete patch of prompt die de gebruiker kan uitvoeren.

### 7.6 Harde stop

Wanneer inconsistenties invloed hebben op de volgende stap, geldt een harde stop.

Voorbeelden:

- `architecture.md` zegt dat GitHub ontbreekt, maar `progress.md` zegt dat GitHub is ingericht.
- `specification.md` bevat geen scope, maar de AI wil een user story bouwen.
- `decisions.md` mist de keuze voor `development`, terwijl branches wel zo zijn ingericht.
- `deployment.md` zegt deployment vanaf `development`, terwijl de richtlijn deployment vanaf `main` voorschrijft.

In deze gevallen mag de AI niet doorgaan met nieuwe code totdat de documentatie is hersteld.

---

## 9. Standaard startprompt voor AI in een bestaand project

Gebruik deze prompt wanneer een nieuwe AI-sessie start in een bestaand project:

```text
Lees eerst de volgende bestanden voordat je codevoorstellen doet:

- .github/copilot-instructions.md
- .docs/architecture.md
- .docs/decisions.md
- .docs/progress.md
- .docs/specification.md
- .docs/flow.md indien aanwezig
- .docs/deployment.md indien relevant

Voer daarna eerst een documentatieconsistentiecontrole uit tussen deze bestanden. Meld eventuele tegenstrijdigheden en los die eerst op voordat je codewijzigingen of user stories uitwerkt.

Gebruik deze bestanden als bron van waarheid voor:
- de actuele architectuur;
- actieve technische keuzes;
- applicatiebeschrijving en grove scope;
- MoSCoW-indeling;
- voortgang;
- user stories;
- open punten;
- volgende logische stap.

Als informatie in deze documenten elkaar tegenspreekt:
1. Meld de tegenstrijdigheid.
2. Doe geen grote codewijziging.
3. Stel een concrete correctie voor in de documentatie.

Werk in kleine verticale slices.
Controleer vóór een nieuwe user story of er een GitHub-repository is, of de `development` branch bestaat, of deze lokaal en remote aanwezig is, of er geen open pull request staat en of de branch vanaf de actuele `development` branch komt. Als GitHub of development ontbreekt, richt dit eerst zelf in wanneer je toegang hebt.
Werk na iedere betekenisvolle wijziging de relevante Markdown-documentatie bij.
Geef na iedere stap acceptatietesten.
Geef aan wanneer een commit/push logisch is.
```

---

## 10. Standaard prompt voor een nieuwe feature

```text
We werken in een bestaande .NET solution met Clean Architecture.

Lees eerst:
- .github/copilot-instructions.md
- .docs/architecture.md
- .docs/decisions.md
- .docs/progress.md
- .docs/specification.md

Taak:
[Beschrijf de gewenste feature]

Werkwijze:
1. Voer eerst een documentatieconsistentiecontrole uit tussen .docs/architecture.md, .docs/progress.md, .docs/decisions.md en .docs/specification.md.
2. Los inconsistenties eerst op voordat je verdergaat.
3. Controleer of de applicatiebeschrijving en grove scope in .docs/specification.md voldoende helder zijn.
2. Controleer of er al een user story bestaat in .docs/specification.md.
3. Als die ontbreekt, voeg eerst een user story met acceptatiecriteria toe op basis van de vastgelegde scope.
3. Controleer of de architectuur moet worden aangepast.
4. Werk in een kleine verticale slice.
5. Houd controllers dun.
6. Plaats businesslogica in Application services.
7. Plaats persistence in Infrastructure.
8. Gebruik DTO's voor API/UI.
9. Gebruik async/await.
10. Voeg Nederlandse XML-documentatie toe aan nieuwe publieke types en interfaces.
11. Werk na de wijziging de relevante documentatie bij:
    - .docs/specification.md
    - .docs/architecture.md
    - .docs/decisions.md
    - .docs/progress.md
    - .docs/flow.md indien de datastroom wijzigt
    - .docs/deployment.md indien deployment wijzigt
    - .docs/troubleshooting.md indien er een bekend probleem/oplossing ontstaat

Geef na afloop:
1. Welke codebestanden zijn aangepast of toegevoegd.
2. Welke documentatiebestanden zijn aangepast.
3. Hoe ik dit test.
4. Of een database migration nodig is.
5. Of dit een logisch commit/push moment is.
```

---

## 11. Standaard solution-structuur

Een nieuwe solution gebruikt bij voorkeur deze lagen:

```text
ProjectName.slnx
│
├── src/
│   ├── ProjectName.Core/
│   ├── ProjectName.Application/
│   ├── ProjectName.Infrastructure/
│   ├── ProjectName.Web/               (server-side Blazor, standaard UI-project)
│   ├── ProjectName.Api/               (optioneel, standaard bij WebAPI-functionaliteit)
│   ├── ProjectName.Blazor/            (optioneel, alleen bij bewuste aparte client/UI)
│   └── ProjectName.Tools.*              (optioneel)
│
├── tests/
│   ├── ProjectName.Core.Tests/
│   ├── ProjectName.Application.Tests/
│   ├── ProjectName.Infrastructure.Tests/
│   └── ProjectName.Web.Tests/
│
├── .github/
│   └── copilot-instructions.md
│
└── .docs/
    ├── architecture.md
    ├── decisions.md
    ├── progress.md
    ├── specification.md
    ├── flow.md
    ├── deployment.md
    └── troubleshooting.md
```

Niet elk project hoeft alle lagen of testprojecten direct te bevatten. Begin klein, maar richt de structuur zo in dat uitbreiding logisch blijft.

---

## 12. Projectlagen

### 9.1 Core

De `Core`-laag bevat de kern van het domein. Deze laag mag geen afhankelijkheid hebben van EF Core, ASP.NET Core, Blazor, externe API's of database-specifieke technologie.

Typische inhoud:

```text
ProjectName.Core/
├── Entities/
├── ValueObjects/
├── Enums/
├── Interfaces/
└── Exceptions/
```

De `Core`-laag bevat:

- entities;
- domeininterfaces;
- domeinregels;
- value objects;
- enums;
- domeinexceptions.

De `Core`-laag bevat niet:

- controllers;
- DbContext;
- EF Core configuratie;
- repository-implementaties;
- DTO's voor API/UI;
- Blazor componenten;
- HTTP-clients;
- infrastructurele details.

### 9.2 Application

De `Application`-laag bevat applicatielogica. Hier staan services, DTO's, service-interfaces, mapping extensions en use-case-achtige logica.

Typische inhoud:

```text
ProjectName.Application/
├── DTOs/
│   └── FeatureName/
├── Enums/
├── Interfaces/
├── Services/
├── Mapping/
└── Validation/
```

De `Application`-laag bevat:

- service-interfaces;
- service-implementaties;
- DTO's;
- mapping tussen entities en DTO's;
- applicatieregels;
- use cases;
- validatie die niet puur UI-specifiek is.

De `Application`-laag mag afhankelijk zijn van `Core`, maar niet van `Infrastructure` of `Web`.

### 9.3 Infrastructure

De `Infrastructure`-laag bevat technische implementaties, zoals EF Core, repositories, externe API-koppelingen, bestandssystemen, adapters en persistence.

Typische inhoud:

```text
ProjectName.Infrastructure/
├── Persistence/
│   ├── AppDbContext.cs
│   ├── Configurations/
│   └── Migrations/
├── Repositories/
├── ExternalServices/
└── DependencyInjection.cs
```

De `Infrastructure`-laag bevat:

- DbContext;
- EF Core entity configurations;
- repository-implementaties;
- database migrations;
- externe service-implementaties;
- bestandsopslag;
- API-clients;
- infrastructurele dependency injection.

### 9.4 Web

De `.Web`-laag bevat standaard de server-side Blazor UI. WebAPI-functionaliteit hoort standaard in een apart `.Api`-project.

Controllers zijn dun:

- Ze ontvangen HTTP-verzoeken.
- Ze valideren basaal inputmodel/modelstate.
- Ze roepen services aan.
- Ze vertalen service-uitkomsten naar HTTP-statuscodes.
- Ze bevatten geen databasecode.
- Ze bevatten geen businesslogica.

### 9.5 Blazor

Wanneer een project een Blazor-front-end bevat, staat UI-logica zoveel mogelijk los van domein- en applicatielogica.

Blazor-componenten:

- zijn verantwoordelijk voor interactie en weergave;
- roepen clientservices aan;
- bevatten zo weinig mogelijk businesslogica;
- gebruiken DTO's, geen EF entities;
- behandelen loading/error states expliciet;
- gebruiken aparte services voor API-calls.

JWT-tokens of andere authenticatiegegevens worden via een aparte service beheerd, niet los verspreid in componenten.

### 9.6 Tools

Sommige projecten hebben consoletools, simulators, importers of ingest-tools.

Voorbeelden:

```text
ProjectName.Tools.Simulator/
ProjectName.Tools.Ingest/
ProjectName.Tools.Migration/
ProjectName.Tools.Import/
```

Regels voor tools:

- Tools schrijven niet rechtstreeks in de database als de architectuur voorschrijft dat data via de WebAPI moet lopen.
- Tools gebruiken duidelijke logging.
- Tools moeten zelfstandig testbaar zijn.
- Configuratie komt uit `appsettings`, environment variables of command line arguments.
- Payloads en protocollen worden zo realistisch mogelijk gemodelleerd als ze echte systemen simuleren.

---

## 13. Standaard .Web- en .Api-projecten

### 10.1 .Web is standaard server-side Blazor

Het `.Web`-project is standaard het UI-project van de applicatie. Dit project wordt standaard aangemaakt als server-side Blazor-project met de normale Visual Studio template-opbouw en het standaard template-uiterlijk.

Standaardkeuze:

```text
ProjectName.Web = server-side Blazor UI-project
```

Het `.Web`-project is dus niet bedoeld als bijna lege WebAPI-host en ook niet als plaats voor API-controllers wanneer er een aparte API nodig is.

Het `.Web`-project moet bij de start de normale Visual Studio template-opbouw behouden. De eerste versie moet direct kunnen starten en herkenbaar zijn als een standaard Blazor-applicatie met layout, navigatie, styling en voorbeeldstructuur.

Afhankelijk van de gebruikte Visual Studio- en .NET-versie kunnen bestandsnamen iets verschillen, maar de structuur lijkt in grote lijnen op:

```text
ProjectName.Web/
├── Components/
│   ├── Layout/
│   ├── Pages/
│   ├── App.razor
│   └── Routes.razor
├── wwwroot/
├── Program.cs
├── appsettings.json
└── appsettings.Development.json
```

Of bij oudere templates:

```text
ProjectName.Web/
├── Pages/
├── Shared/
├── wwwroot/
├── App.razor
├── Program.cs
├── appsettings.json
└── appsettings.Development.json
```

Regels voor `.Web`:

- Maak `.Web` standaard aan als server-side Blazor-project.
- Configureer `.Web` standaard met interactive server rendering.
- Behoud bij de start de standaard Visual Studio template-opbouw.
- Gebruik bij de start het uiterlijk uit `.docs/DefaultTemplate.zip` wanneer dit bestand beschikbaar is.
- Behoud de Visual Studio template-opbouw, maar vervang de visuele shell door de native Blazor-vertaling van `.docs/DefaultTemplate.zip`.
- Verwijder templatepagina's, layout, navigatie of styling niet direct, tenzij daar expliciet opdracht voor is gegeven.
- Gebruik `.Web` als UI-host van de applicatie.
- Razor components gebruiken DTO's en services, geen EF Core entities rechtstreeks.
- Razor components die gebruikersinteractie bevatten, gebruiken expliciet interactive server rendering.
- UI-logica blijft beperkt tot interactie en presentatie.
- Businesslogica blijft in `Application`.
- Persistence blijft in `Infrastructure`.
- Domeinentities blijven in `Core`.
- Plaats standaard geen API-controllers in `.Web`.

### 10.2 .Api is standaard voor WebAPI-functionaliteit

Wanneer de applicatie HTTP API-endpoints nodig heeft, wordt daarvoor standaard een apart `.Api`-project toegevoegd.

Standaardkeuze bij API-functionaliteit:

```text
ProjectName.Api = ASP.NET Core WebAPI-project met controllers
```

Het `.Api`-project bevat de API-laag van de applicatie.

Typische inhoud:

```text
ProjectName.Api/
├── Controllers/
├── Middleware/
├── Program.cs
├── appsettings.json
└── appsettings.Development.json
```

Regels voor `.Api`:

- Gebruik `.Api` voor WebAPI-controllers.
- Gebruik controllers, geen Minimal APIs als standaard.
- Controllers blijven dun.
- Controllers bevatten geen businesslogica.
- Controllers gebruiken Application services.
- Controllers geven DTO's terug.
- Controllers gebruiken geen `DbContext` rechtstreeks.
- API-validatie en HTTP-statuscodes worden in `.Api` afgehandeld.
- Authenticatie/autorisatie voor API-endpoints wordt in `.Api` geconfigureerd.
- `.Api` mag afhankelijk zijn van `Application`, `Infrastructure` en waar nodig `Core`.

### 10.3 Relatie tussen .Web en .Api

Wanneer zowel UI als API nodig zijn, is de standaardopbouw:

```text
ProjectName.Web  → server-side Blazor UI
ProjectName.Api  → WebAPI met controllers
```

De UI praat dan waar passend met de API via HTTP-clientservices, of gebruikt Application services direct wanneer dat bewust eenvoudiger en passend is voor de applicatie. Die keuze moet worden vastgelegd in `.docs/decisions.md` en beschreven in `.docs/architecture.md`.

Voor nieuwe projecten geldt:

- Alleen UI nodig: maak `.Web` als server-side Blazor.
- UI en API nodig: maak `.Web` als server-side Blazor én `.Api` als WebAPI-project.
- Alleen API nodig: maak `.Api`; maak `.Web` dan niet aan, tenzij later een UI nodig is.

Afwijkingen van deze standaard worden expliciet vastgelegd in:

```text
.docs/decisions.md
.docs/architecture.md
```

---

## 14. Blazor interactive server rendering

Het `.Web`-project gebruikt standaard server-side Blazor met interactieve rendering. De applicatie mag dus niet blijven hangen in alleen statische server-side rendering wanneer gebruikersinteractie nodig is.

Standaardregel:

```text
Blazor .Web = server-side Blazor + interactive server rendering
```

### 11.1 Program.cs configuratie

In moderne Blazor Web App templates moet `Program.cs` de Razor components registreren met interactive server components.

Voorbeeld:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

Bij het mappen van components moet ook interactive server render mode worden toegevoegd.

Voorbeeld:

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

### 11.2 Interactiviteit op pagina's en componenten

Pagina's of componenten die interactie nodig hebben, krijgen expliciet een interactive render mode.

Voorbeeld op paginaniveau:

```razor
@page "/counter"
@rendermode InteractiveServer

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

Voorbeeld op componentniveau:

```razor
<ConsumptionForm @rendermode="InteractiveServer" />
```

Gebruik de vorm die past bij de gekozen .NET/Blazor-template. De bedoeling is dat componenten die events, formulieren, knoppen, validatie of live updates gebruiken daadwerkelijk interactief werken.

### 11.3 Wanneer is interactieve rendering verplicht?

Interactive server rendering is verplicht voor onderdelen met:

- knoppen met `@onclick`;
- formulieren met submit- of validatiegedrag;
- zoekvelden met live filtering;
- component state die wijzigt door gebruikersactie;
- navigatie of UI-acties zonder volledige page refresh;
- dashboards of dagoverzichten die direct moeten bijwerken;
- SignalR-achtige interactie;
- Blazor component events.

Voorbeeld: een pagina `/consumption` waarop een gebruiker producten zoekt, een product kiest, hoeveelheid invoert en een dagoverzicht direct bijgewerkt ziet, moet interactief renderen.

### 11.4 Acceptatiecontrole voor interactiviteit

Bij Blazor user stories moet expliciet getest worden dat interactieve onderdelen werken.

Voorbeelden:

```text
[ ] Een knop met @onclick reageert zonder volledige page reload.
[ ] Een formulier kan worden ingevuld en verzonden.
[ ] Validatiemeldingen verschijnen zonder dat de applicatie crasht.
[ ] Een zoekveld of selectie werkt interactief.
[ ] Een overzicht wordt direct bijgewerkt na een actie.
```

Als een knop of formulier niet reageert, moet de AI eerst controleren of interactive server rendering goed is geconfigureerd in:

```text
Program.cs
Routes.razor / App.razor
de betreffende pagina of component
```

### 11.5 Geen stille fallback naar statisch renderen

De AI mag niet aannemen dat Blazor-interactie vanzelf werkt. Bij het toevoegen van interactieve componenten moet zij expliciet controleren of:

- `AddInteractiveServerComponents()` is geregistreerd;
- `AddInteractiveServerRenderMode()` is toegevoegd;
- de pagina of component de juiste render mode gebruikt;
- de template-opbouw van Visual Studio intact blijft;
- er geen events worden toegevoegd aan statisch gerenderde componenten zonder render mode.

Als interactiviteit ontbreekt, moet dit als bug worden behandeld en opgelost voordat de user story als gereed wordt beschouwd.

---

## 15. DefaultTemplate.zip als standaard Blazor designbasis

Wanneer bij de initiële projectopzet een bestand `DefaultTemplate.zip` beschikbaar is naast de instructies of in de projectmap, moet de AI dit gebruiken als standaard visuele en structurele basis voor het `.Web`-project.

Dit template vervangt het standaard Blazor template-uiterlijk als uitgangspunt voor de applicatieshell.

Standaardregel:

```text
DefaultTemplate.zip beschikbaar = design vertalen naar native Blazor/Razor
```

### 12.1 Doel van DefaultTemplate.zip

`.docs/DefaultTemplate.zip` is bedoeld als visuele en structurele referentie voor de Blazor-applicatie.

De AI gebruikt het template voor:

- layoutstructuur;
- navigatie;
- appbar/header;
- drawer/sidebar;
- cards;
- basiscomponenten;
- responsive desktop/mobile gedrag;
- kleurgebruik, spacing, typografie en visuele stijl;
- CSS-classnames waar die zinvol herbruikbaar zijn.

De AI gebruikt het template niet als React-applicatie.

### 12.2 Verplichte interpretatie van React/JSX-bronnen

Als het template React/JSX-bestanden bevat, gelden deze regels:

- Zet JSX niet letterlijk over.
- Gebruik geen React.
- Gebruik geen Babel.
- Gebruik geen npm.
- Gebruik geen Vite/Webpack/React build pipeline.
- Vertaal het design naar native Blazor/Razor-componenten.
- Gebruik Blazor `NavLink` voor navigatie.
- Gebruik normale CSS binnen het Blazor-project.
- Behoud zoveel mogelijk bestaande CSS-classnames uit de aangeleverde stylesheet wanneer dit logisch is.
- Voeg geen onnodige JavaScript-interoperability toe.
- JavaScript interop is alleen toegestaan wanneer native Blazor/CSS dit redelijkerwijs niet kan oplossen.

### 12.3 Verwachte bestanden in het template

De exacte inhoud van `.docs/DefaultTemplate.zip` kan per versie verschillen. Wanneer de volgende bestanden aanwezig zijn, gelden deze richtlijnen:

```text
template.jsx
```

Gebruik als bron voor:

- layoutstructuur;
- navigatie;
- appbar;
- drawer;
- componentopbouw;
- shell-indeling.

```text
styles.css
```

Gebruik als bron voor:

- visuele styling;
- CSS-classnames;
- responsive gedrag;
- kleuren, spacing, borders en typografie.

```text
Graafschap Blazor Template.html
```

Gebruik alleen als visuele referentie voor hoe het eindresultaat eruit hoort te zien.

```text
design-canvas.jsx
tweaks-panel.jsx
```

Gebruik alleen als prototype/design tooling. Deze bestanden worden niet overgenomen in de Blazor-app.

### 12.4 Te maken Blazor-onderdelen

Bij de initiële vertaling van `.docs/DefaultTemplate.zip` naar Blazor maakt of past de AI minimaal deze onderdelen aan:

```text
ProjectName.Web/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   ├── Shared/ of Common/
│   │   ├── AppBar.razor              (optioneel)
│   │   ├── Drawer.razor              (optioneel)
│   │   ├── Card.razor                (optioneel)
│   │   └── Icon.razor                (optioneel)
│   └── Pages/
├── wwwroot/
│   └── css/
│       └── app.css of template.css
└── App.razor / Routes.razor
```

Regels:

- `MainLayout.razor` bevat de applicatieshell.
- `NavMenu.razor` bevat de navigatie-items.
- Herbruikbare delen mogen als losse Razor-components worden gemaakt.
- Navigatie gebruikt `NavLink`.
- Desktop- en mobile layout moeten behouden blijven.
- CSS komt in een normale CSS-file binnen het Blazor-project.
- Styling wordt niet inline verspreid over alle componenten, tenzij het om kleine component-specifieke uitzonderingen gaat.
- Nieuwe C# code krijgt Nederlandse XML-documentatie waar relevant.
- Razor markup krijgt alleen comments waar dit echt uitlegt waarom iets zo is gedaan.

### 12.5 Interactieve shell is verplicht

Wanneer de shell interactieve onderdelen bevat, zoals een hamburgermenu, drawer, collapsible menu, dropdown of knop met `@onclick`, moet de shell interactief renderen.

Belangrijk probleem dat voorkomen moet worden:

```text
De knop wordt wel getoond, maar klikken doet niets omdat de shell statisch rendert.
```

Daarom moet de AI bij het toepassen van `.docs/DefaultTemplate.zip` expliciet controleren of interactive server rendering actief is voor de layout/shell.

Controlepunten:

```text
Program.cs
App.razor
Routes.razor
MainLayout.razor
NavMenu.razor
```

In moderne Blazor Web App templates moet `Program.cs` minimaal bevatten:

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

En bij het mappen van de app:

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
```

Daarnaast moeten `Routes` en `HeadOutlet` interactief worden gerenderd wanneer de layout/shell interactie bevat.

Voorbeeld in `App.razor`:

```razor
<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <HeadOutlet @rendermode="InteractiveServer" />
</head>

<body>
    <Routes @rendermode="InteractiveServer" />
</body>
</html>
```

Of gebruik de equivalente aanpak die past bij de gebruikte .NET/Blazor-template.

Regel:

```text
Een hamburgermenu, drawer of interactieve applicatieshell mag niet statisch renderen.
```

Als het mobiele menu niet opent/sluit, controleert de AI eerst de render mode van `App.razor`, `Routes`, `HeadOutlet`, `MainLayout` en de betreffende componenten voordat zij CSS of markup gaat aanpassen.

### 12.6 Plan vóór implementatie

Bij het toepassen van `.docs/DefaultTemplate.zip` levert de AI eerst een plan van aanpak op. Zij past nog geen code aan voordat de gebruiker akkoord geeft.

Het plan bevat minimaal:

```text
1. Welke templatebestanden zijn gevonden.
2. Welke bestanden als visuele bron worden gebruikt.
3. Welke bestanden niet worden overgenomen.
4. Welke Blazor-componenten worden aangemaakt of aangepast.
5. Welke CSS-bestanden worden aangemaakt of aangepast.
6. Hoe desktop- en mobile layout worden behouden.
7. Hoe interactive server rendering wordt geborgd.
8. Welke acceptatiescenario's worden uitgevoerd.
```

### 12.7 Acceptatiescenario's voor het template

Na toepassing van het template levert de AI minimaal deze acceptatiescenario's op:

```text
Scenario 1 - Applicatie start met template-shell
- Start de applicatie.
- Controleer dat de layout zichtbaar is volgens het template.
- Controleer dat appbar/header, navigatie en contentgebied zichtbaar zijn.

Scenario 2 - Navigatie werkt
- Klik op meerdere navigatie-items.
- Controleer dat Blazor navigatie via NavLink werkt.
- Controleer dat actieve navigatie visueel herkenbaar is.

Scenario 3 - Mobiel hamburgermenu werkt
- Zet de browser in smalle/mobile viewport.
- Klik op het hamburgermenu.
- Controleer dat de drawer opent.
- Klik opnieuw of kies een menu-item.
- Controleer dat de drawer sluit of correct reageert.

Scenario 4 - Geen React/npm afhankelijkheid
- Controleer dat er geen React, Babel, npm, Vite of Webpack nodig is voor de Blazor-app.
- Controleer dat het project met dotnet build werkt.

Scenario 5 - Interactive rendering werkt
- Controleer dat knoppen met @onclick reageren.
- Controleer dat er geen volledige page reload nodig is voor shell-interactie.
```

### 12.8 Documentatie bij toepassing van het template

Wanneer `.docs/DefaultTemplate.zip` is toegepast, werkt de AI minimaal deze bestanden bij:

```text
.docs/architecture.md
.docs/decisions.md
.docs/progress.md
.docs/flow.md indien navigatie of shell-flow relevant is
```

`decisions.md` krijgt bijvoorbeeld:

```text
| Datum | Keuze | Reden | Impact | Status |
|------|-------|-------|--------|--------|
| YYYY-MM-DD | DefaultTemplate.zip als basis voor Blazor shell | Consistente visuele basis voor nieuwe projecten | Standaard Blazor uiterlijk wordt vervangen door native Blazor-vertaling van het template | Actief |
| YYYY-MM-DD | InteractiveServer render mode voor Blazor shell | Drawer/hamburgermenu en layoutinteractie moeten werken | App.razor/Routes/HeadOutlet en interactieve shellcomponenten renderen interactief | Actief |
```

`architecture.md` beschrijft:

- dat `.Web` server-side Blazor is;
- dat de shell gebaseerd is op `.docs/DefaultTemplate.zip`;
- welke componenten de shell vormen;
- hoe interactieve rendering is geconfigureerd;
- dat React/JSX alleen als referentie is gebruikt.

### 12.9 Harde stop

De AI mag de template-integratie niet als afgerond beschouwen zolang:

- het design niet naar native Blazor/Razor is vertaald;
- React/JSX letterlijk is overgenomen;
- npm/React tooling nodig is;
- het hamburgermenu of de drawer niet werkt;
- interactive server rendering voor de shell ontbreekt;
- acceptatiescenario's voor desktop/mobile/interactie ontbreken;
- documentatie niet is bijgewerkt.

---


## 16. Harde stop: initiële Blazor shell moet direct uit DefaultTemplate.zip komen

Wanneer `.docs/DefaultTemplate.zip` aanwezig is, mag de initiële Blazor `.Web`-opzet niet eindigen met een neutrale, standaard of tijdelijke Blazor-shell.

Standaardregel:

```text
DefaultTemplate.zip aanwezig = initiële .Web-shell direct vertalen naar native Blazor/Razor.
```

Niet toegestaan:

```text
Eerst neutrale Blazor shell maken en design later toepassen.
```

### 13.1 Directe acceptatiecriteria voor de initiële basis

De initiële projectbasis is pas klaar wanneer al deze punten waar zijn:

```text
[ ] .Web is server-side Blazor.
[ ] .docs/DefaultTemplate.zip is gelezen.
[ ] De shellstructuur uit het design is vertaald naar MainLayout.razor en NavMenu.razor of vergelijkbare componenten.
[ ] Appbar/header is aanwezig.
[ ] Navigatie-opbouw is aanwezig.
[ ] Sidebar/drawer of mobile menu is aanwezig wanneer het design dat bevat.
[ ] Contentgebied volgt de layoutstructuur van het design.
[ ] CSS uit het template is vertaald naar een normale CSS-file in het Blazor-project.
[ ] React/JSX is niet letterlijk overgenomen.
[ ] Er is geen React/npm/Babel/Vite/Webpack afhankelijkheid toegevoegd.
[ ] Interactive server rendering is actief voor de shell.
[ ] Hamburgermenu/drawer-menu werkt.
[ ] .docs/architecture.md beschrijft dat de shell uit .docs/DefaultTemplate.zip komt.
[ ] .docs/decisions.md bevat de keuze voor .docs/DefaultTemplate.zip als verplichte designbasis.
[ ] .docs/progress.md vermeldt dat de designbaseline is toegepast.
```

Als één van deze punten ontbreekt, is de initiële basis nog niet klaar en mogen er nog geen functionele user stories worden gestart.

### 13.2 Neutrale shell is fout

Als `.docs/DefaultTemplate.zip` aanwezig is, zijn deze formuleringen fout:

```text
De UI is nog een neutrale Blazor app-shell.
Het design uit DefaultTemplate.zip wordt later toegepast.
DefaultTemplate.zip is alleen een toekomstige designreferentie.
De technische bootstrap is klaar, design volgt later.
```

De juiste status is:

```text
De initiële .Web-shell is gebaseerd op .docs/DefaultTemplate.zip.
De layoutstructuur uit het design is vertaald naar native Blazor/Razor.
De shell gebruikt interactieve rendering waar nodig.
```

### 13.3 Verplichte rapportage na initiële .Web-opzet

Na de initiële `.Web`-opzet rapporteert de AI expliciet:

```text
Designbaseline:
- .docs/DefaultTemplate.zip gevonden: ja/nee
- template.jsx gebruikt voor shellstructuur: ja/nee/niet aanwezig
- styles.css gebruikt voor styling: ja/nee/niet aanwezig
- MainLayout.razor gebaseerd op template: ja/nee
- NavMenu.razor gebaseerd op template: ja/nee
- appbar/header vertaald: ja/nee
- drawer/sidebar/mobile menu vertaald: ja/nee
- contentindeling vertaald: ja/nee
- React/npm/Babel/Vite/Webpack toegevoegd: nee
- InteractiveServer voor shell actief: ja/nee
- hamburgermenu/drawer getest: ja/nee
- conclusie: designbaseline gereed / niet gereed
```

Als de conclusie “niet gereed” is, moet de AI eerst een plan maken om de designbaseline te herstellen.

---

## 17. Dependency rules

De afhankelijkheden lopen één kant op:

```text
Web ───────────────┐
Api ───────────────┤
                   ▼
Blazor/API Client → Application → Core
                   ▲
Infrastructure ────┘
```

Toegestaan:

- `Application` gebruikt `Core`.
- `Infrastructure` gebruikt `Application` en `Core`.
- `.Web` gebruikt `Application`, `Infrastructure` en `Core` waar nodig voor de server-side Blazor UI.
- `.Api` gebruikt `Application`, `Infrastructure` en `Core` waar nodig voor WebAPI-endpoints.
- `Blazor` gebruikt DTO's en API-services.

Niet toegestaan:

- `Core` verwijst naar `Application`, `Infrastructure`, `.Web`, `.Api` of `Blazor`.
- `Application` verwijst naar `Infrastructure`, `.Web`, `.Api` of `Blazor`.
- Controllers gebruiken geen `DbContext` rechtstreeks.
- UI gebruikt geen repositories rechtstreeks.
- Domeinentities bevatten geen EF Core attributen tenzij daar bewust voor gekozen is.

---

## 18. Repository pattern

Gebruik een generieke repository voor standaard CRUD-achtige databasehandelingen. Gebruik specifieke repositories alleen wanneer queries of opslaggedrag te domeinspecifiek worden.

Basisinterface:

```csharp
namespace ProjectName.Core.Interfaces;

/// <summary>
/// Beschrijft generieke opslagfunctionaliteit voor domeinentities.
/// </summary>
/// <typeparam name="T">Het type entity dat wordt opgeslagen.</typeparam>
public interface IRepository<T> where T : class, IEntity
{
    /// <summary>
    /// Haalt alle entities van dit type op.
    /// </summary>
    Task<IReadOnlyList<T>> ListAsync();

    /// <summary>
    /// Haalt een entity op basis van de unieke sleutel op.
    /// </summary>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Voegt een nieuwe entity toe.
    /// </summary>
    Task AddAsync(T entity);

    /// <summary>
    /// Werkt een bestaande entity bij.
    /// </summary>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Verwijdert een bestaande entity.
    /// </summary>
    Task DeleteAsync(T entity);
}
```

Wanneer alle entities een vaste sleutel hebben, kan later een interface worden gebruikt:

```csharp
public interface IEntity
{
    int Id { get; set; }
}
```

Dan kan de repository eventueel worden aangescherpt:

```csharp
public interface IRepository<T> where T : class, IEntity
```

Dat moet bewust gebeuren, omdat het invloed heeft op alle entities.

---

## 19. Services als applicatielaag

Services vormen de tussenlaag tussen controllers/UI en repositories/externe systemen.

Een service:

- bevat applicatielogica;
- werkt met DTO's richting Web/UI;
- gebruikt repositories of andere interfaces;
- is async waar I/O wordt gebruikt;
- houdt controllers dun;
- maakt testbare businessflows mogelijk.

Voorbeeld flow:

```text
Controller → Service → Repository → DbContext → Database
```

De controller kent dus niet de database, maar alleen de service.

---

## 20. DTO's en mapping

Gebruik DTO's om data naar buiten of naar binnen te brengen. Geef geen EF entities direct terug vanuit API's. DTO’s gebruiken geen Core/domain-enums rechtstreeks; als een DTO een enum nodig heeft, komt die enum uit de Application-laag.

Redenen:

- Je voorkomt overexposure van databasevelden.
- Je voorkomt circular references.
- Je bepaalt bewust welke data de client krijgt.
- Je kunt input- en outputmodellen scheiden.
- Je houdt API-contracten stabieler.

Naamgeving DTO's:

```text
CreateStudentRequest
UpdateStudentRequest
StudentDetailDto
StudentListItemDto
StudentSummaryDto
StudentResponse
```

Bij voorkeur per feature groeperen:

```text
DTOs/
└── Student/
    ├── CreateStudentRequest.cs
    ├── UpdateStudentRequest.cs
    ├── StudentDetailDto.cs
    └── StudentListItemDto.cs
```

Mapping gebeurt bij voorkeur handmatig via extension methods. Gebruik AutoMapper niet als standaardkeuze in onderwijs- of basisprojecten; handmatige mapping via extension methods maakt de flow beter zichtbaar en voorkomt verborgen configuratie.

---

## 21. Async/await

Gebruik async/await voor I/O-operaties zoals databasecalls, HTTP-calls en bestandsoperaties.

Gebruik bij EF Core:

- `ToListAsync`
- `FirstOrDefaultAsync`
- `SingleOrDefaultAsync`
- `FindAsync`
- `SaveChangesAsync`
- `AnyAsync`
- `CountAsync`

Regels:

- Maak geen async method zonder await, tenzij daar een duidelijke reden voor is.
- Gebruik geen `.Result` of `.Wait()` op Tasks.
- Laat async doorlopen van controller tot database.
- Gebruik `Task<T>` voor resultaat.
- Gebruik `Task` voor acties zonder resultaat.
- Gebruik cancellation tokens wanneer dat nuttig is.

---

## 22. Entity Framework Core

EF Core wordt gebruikt in de Infrastructure-laag.

Aanbevolen:

- SQLite voor eenvoudige lokale ontwikkelprojecten.
- SQL Server wanneer het project dit nodig heeft.
- EF Core InMemory alleen voor snelle demonstraties of beginoefeningen.
- Migrations voor databaseversiebeheer.
- Configuraties in aparte configuration classes bij grotere projecten.

---

## 23. API-ontwerp

Gebruik in het `.Api`-project WebAPI controllers, geen Minimal APIs als standaard in onderwijs- en onderhoudbare projectstructuren.

Standaard HTTP-statuscodes:

- `200 OK` bij succesvolle GET/PUT.
- `201 Created` bij succesvolle POST die iets nieuws maakt.
- `204 No Content` bij succesvolle DELETE of update zonder body.
- `400 Bad Request` bij ongeldige input.
- `401 Unauthorized` bij ontbrekende authenticatie.
- `403 Forbidden` bij onvoldoende rechten.
- `404 Not Found` als resource niet bestaat.
- `500 Internal Server Error` alleen voor onverwachte fouten.

---

## 24. Validatie en foutafhandeling

Gebruik eenvoudige validatie dicht bij inputmodellen, bijvoorbeeld met DataAnnotations.

Controllers mogen ModelState of automatische `[ApiController]`-validatie gebruiken. Complexere validatie hoort in services of aparte validators.

Gebruik centrale foutafhandeling voor onverwachte fouten, bijvoorbeeld via middleware of `UseExceptionHandler`.

API's geven geen stacktraces of interne details terug aan gebruikers.

---

## 25. Authenticatie en autorisatie

Wanneer authenticatie nodig is, gebruik JWT Bearer-authenticatie voor WebAPI's.

Regels:

- Gebruik `[Authorize]` op controllers of acties die beveiligd moeten zijn.
- Gebruik `[AllowAnonymous]` alleen bewust.
- Haal user identity uit claims.
- Stop geen gevoelige informatie in JWT-claims.
- Bewaar secrets niet in code of Git.
- Gebruik configuratie of user secrets voor lokale ontwikkeling.

---

## 26. Naamconventies

Gebruik duidelijke Engelse namen in code. Nederlandse XML-documentatie is toegestaan en gewenst, maar code blijft Engelstalig.

Voorbeelden:

```text
StudentService
IStudentService
StudentController
CreateStudentRequest
StudentListItemDto
StudentDetailDto
EfRepository
AppDbContext
DependencyInjection
RegisterInfrastructure
```

Regels:

- Interfaces beginnen met `I`.
- Services eindigen op `Service`.
- Controllers eindigen op `Controller`.
- DTO's eindigen op `Dto`, `Request`, `Response` of een duidelijke variant.
- Async methods eindigen op `Async`.
- Private fields beginnen met `_`.
- Gebruik PascalCase voor publieke members.
- Gebruik camelCase voor lokale variabelen en parameters.
- Gebruik betekenisvolle namen.

---

## 27. Dependency injection registratie per project

Wanneer een project services, repositories, clients, validators of andere dependency injection-registraties nodig heeft, krijgt dat project een eigen static klasse met extension method(s) voor registratie.

Het doel is dat `Program.cs` overzichtelijk blijft en niet vol komt te staan met losse registraties.

Standaardregel:

```text
Program.cs roept alleen projectbrede registratie-methods aan.
De registratie-details staan in het project waar de betreffende classes thuishoren.
```

### 20.1 Naamgeving

Gebruik bij voorkeur deze naam:

```text
DependencyInjection.cs
```

Alternatief, wanneer dat beter past bij een bestaande codebase:

```text
ServiceCollectionExtensions.cs
```

### 20.2 Application-registratie

Als `ProjectName.Application` eigen services bevat, krijgt dit project een registratieklasse.

Locatie:

```text
ProjectName.Application/
└── DependencyInjection.cs
```

Voorbeeld:

```csharp
namespace ProjectName.Application;

/// <summary>
/// Bevat registraties voor de applicatielaag.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registreert services uit de applicatielaag.
    /// </summary>
    /// <param name="services">De servicecollectie waarin de services worden geregistreerd.</param>
    /// <returns>De bijgewerkte servicecollectie.</returns>
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IMeasurementService, MeasurementService>();

        return services;
    }
}
```

### 20.3 Infrastructure-registratie

Als `ProjectName.Infrastructure` EF Core, repositories, externe clients of adapters bevat, krijgt dit project een eigen registratieklasse.

Locatie:

```text
ProjectName.Infrastructure/
└── DependencyInjection.cs
```

Voorbeeld:

```csharp
namespace ProjectName.Infrastructure;

/// <summary>
/// Bevat registraties voor de infrastructuurlaag.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registreert services uit de infrastructuurlaag.
    /// </summary>
    /// <param name="services">De servicecollectie waarin de services worden geregistreerd.</param>
    /// <param name="connectionString">De connection string voor de database.</param>
    /// <returns>De bijgewerkte servicecollectie.</returns>
    public static IServiceCollection RegisterInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        return services;
    }
}
```

### 20.4 Web-registratie

Als `ProjectName.Web` Blazor-specifieke services, UI-state services of HTTP-clients bevat, krijgt `.Web` een eigen registratieklasse.

Locatie:

```text
ProjectName.Web/
└── DependencyInjection.cs
```

Voorbeeld:

```csharp
namespace ProjectName.Web;

/// <summary>
/// Bevat registraties voor de Blazor UI-laag.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registreert services uit de Blazor UI-laag.
    /// </summary>
    /// <param name="services">De servicecollectie waarin de services worden geregistreerd.</param>
    /// <returns>De bijgewerkte servicecollectie.</returns>
    public static IServiceCollection RegisterWeb(this IServiceCollection services)
    {
        services.AddRazorComponents()
            .AddInteractiveServerComponents();

        return services;
    }
}
```

### 20.5 Api-registratie

Als `ProjectName.Api` API-specifieke services, filters, middleware of configuratie bevat, krijgt `.Api` een eigen registratieklasse.

Locatie:

```text
ProjectName.Api/
└── DependencyInjection.cs
```

Voorbeeld:

```csharp
namespace ProjectName.Api;

/// <summary>
/// Bevat registraties voor de API-laag.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registreert services uit de API-laag.
    /// </summary>
    /// <param name="services">De servicecollectie waarin de services worden geregistreerd.</param>
    /// <returns>De bijgewerkte servicecollectie.</returns>
    public static IServiceCollection RegisterApi(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }
}
```

### 20.6 Program.cs blijft dun

`Program.cs` roept alleen de projectbrede registratie-methods aan.

Voorbeeld voor `.Web`:

```csharp
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");

builder.Services
    .RegisterApplication()
    .RegisterInfrastructure(connectionString)
    .RegisterWeb();

var app = builder.Build();
```

Voorbeeld voor `.Api`:

```csharp
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");

builder.Services
    .RegisterApplication()
    .RegisterInfrastructure(connectionString)
    .RegisterApi();

var app = builder.Build();
```

Regels:

- Voeg losse DI-registraties niet onnodig direct toe aan `Program.cs`.
- Zet registraties in het project waar de betreffende implementaties thuishoren.
- Houd registration methods klein en logisch gegroepeerd.
- Gebruik duidelijke methodnamen zoals `RegisterApplication`, `RegisterInfrastructure`, `RegisterWeb` en `RegisterApi`.
- Geef registration methods `IServiceCollection` terug zodat chaining mogelijk is.
- Voeg Nederlandse XML-documentatie toe aan publieke registratieklassen en methods.
- Als een project geen eigen registraties nodig heeft, hoeft het geen `DependencyInjection.cs` te hebben.
- Wanneer een nieuwe service wordt toegevoegd, werk ook de registratieklasse van dat project bij.
- Wanneer registratiekeuzes architectuurimpact hebben, werk `.docs/architecture.md` en eventueel `.docs/decisions.md` bij.

---

## 28. Vertical slice werkwijze

Werk in kleine verticale stappen. Een verticale slice voegt één stuk functionaliteit end-to-end toe.

Voorbeeld slice:

```text
1. User story controleren of toevoegen in specification.md
2. Architectuurimpact controleren in architecture.md
3. Technische keuze vastleggen in decisions.md indien nodig
4. Entity toevoegen in Core
5. DTO's toevoegen in Application
6. Service-interface toevoegen
7. Service-implementatie toevoegen
8. Repository gebruiken
9. EF configuratie/migratie toevoegen
10. Controller endpoint toevoegen
11. Swagger-test uitvoeren
12. Database controleren
13. Progress.md bijwerken
14. Commit/push doen
```

Voordeel:

- Sneller testbaar.
- Minder grote onduidelijke wijzigingen.
- AI-assistenten maken minder fouten.
- Fouten zijn makkelijker te isoleren.
- De applicatie blijft steeds werkend.
- Documentatie blijft gelijklopen met de code.

---

## 29. Acceptatietesten

Elke wijziging krijgt praktische acceptatietesten.

Voorbeelden:

```text
Acceptatietest 1: Build
- Open de solution in Visual Studio.
- Voer Build Solution uit.
- Controleer dat er geen compile errors zijn.

Acceptatietest 2: Swagger
- Start ProjectName.Web.
- Open Swagger.
- Roep het nieuwe endpoint aan.
- Controleer de verwachte HTTP-statuscode en response.

Acceptatietest 3: Database
- Voer een POST uit via Swagger.
- Controleer in SQLite of de rij is toegevoegd.
```

Bij databasecontrole met SQLite:

```sql
SELECT * FROM Measurements ORDER BY ReceivedAtUtc DESC LIMIT 10;
```

Na een geslaagde kleine wijziging is dit meestal een logisch moment voor commit/push.

---

## 30. GitHub-repository en development branch na initiële basis

Nadat de initiële basis is gelegd, wordt het project in GitHub geplaatst. De initiële basis bestaat minimaal uit:

```text
- solution aangemaakt;
- basisprojecten aangemaakt;
- .github/copilot-instructions.md aangemaakt;
- .docs documentatiestructuur aangemaakt;
- eerste architecture.md aangemaakt;
- eerste decisions.md aangemaakt;
- eerste progress.md aangemaakt;
- eerste specification.md aangemaakt;
- applicatiebeschrijving en grove scope vastgelegd indien al beschikbaar;
- project buildt zonder fouten.
```

Pas daarna wordt de GitHub-repository en branchstructuur ingericht.

### 24.1 GitHub-repository aanmaken

De AI maakt zelf een GitHub-repository aan voor het project wanneer zij daarvoor toegang en rechten heeft. Alleen als de AI technisch geen toegang heeft, geeft zij exacte commando's aan de gebruiker. De repositorynaam moet logisch en herkenbaar zijn en aansluiten bij de projectnaam.

Regels:

- De repository bevat de volledige solution.
- De repository bevat de `.docs` map.
- De repository bevat waar mogelijk `.github/copilot-instructions.md`.
- De repository bevat een `README.md`.
- Secrets, connection strings met wachtwoorden, tokens en lokale bestanden worden niet gecommit.
- `.gitignore` is aanwezig en passend voor Visual Studio/.NET.

### 24.2 Initiële commit op main of master

De initiële basis wordt eerst vastgelegd op de standaardbranch van de repository, meestal `main`.

Voorbeeld:

```bash
git init
git add .
git commit -m "Add initial solution structure and documentation"
git branch -M main
git remote add origin <repository-url>
git push -u origin main
```

Als de organisatie of bestaande omgeving `master` gebruikt, mag `master` worden gebruikt. De voorkeur voor nieuwe repositories is `main`, tenzij bestaande afspraken anders zijn.

### 24.3 Development branch aanmaken

Na de initiële commit wordt een `development` branch aangemaakt vanaf de actuele stabiele basis.

Voorbeeld:

```bash
git checkout -b development
git push -u origin development
```

Vanaf dit moment geldt:

```text
development = basis voor actief ontwikkelwerk
main = stabiele en deploybare basis
feature branches = per user story vanaf development
deployment = altijd vanaf main
```

### 24.4 Branch protection en werkwijze

Waar mogelijk worden branch protection rules ingesteld:

Voor `main` of `master`:

- geen directe commits;
- alleen merge via pull request;
- bij voorkeur alleen vanaf `development` of releasebranches;
- build/tests moeten slagen indien CI beschikbaar is.

Voor `development`:

- user-story branches worden via pull request naar `development` gemerged;
- geen nieuwe user-story branch zolang er nog een open pull request staat;
- build/tests moeten slagen voordat een PR wordt gemerged.

### 24.5 Documentatie bijwerken

Na het aanmaken van de repository en `development` branch worden de documenten bijgewerkt.

`progress.md` krijgt minimaal:

```text
## Repository

GitHub-repository: <repository-url>
Standaardbranch: main
Ontwikkelbranch: development

## Huidige status

De initiële solution, projecten en documentatiestructuur zijn aangemaakt.
De GitHub-repository is aangemaakt.
De development branch is aangemaakt.
Nieuwe user-story branches worden vanaf development gemaakt.
```

`decisions.md` krijgt minimaal:

```text
| Datum | Keuze | Reden | Impact | Status |
|------|-------|-------|--------|--------|
| YYYY-MM-DD | Gebruik van development branch als basis voor user-story branches | Scheidt actief ontwikkelwerk van stabiele main/master | User-story branches en PR's lopen via development | Actief |
| YYYY-MM-DD | Gebruik van gescheiden Core-enums en Application-enums | Voorkomt dat domeinmodel uitlekt naar DTO/UI/API-contracten | Mapping gebeurt expliciet via extension methods | Actief |
```

`architecture.md` krijgt waar relevant een korte beschrijving van de repository- en branchstructuur.

### 24.6 AI-regel

Een AI-assistent moet na het aanmaken van de initiële basis expliciet controleren of de repository- en branchstructuur al bestaan.

De AI moet melden:

```text
Repositorycontrole:
- Is er al een GitHub-repository?
- Is de initiële basis gecommit?
- Bestaat de development branch?
- Is development gebaseerd op de initiële stabiele basis?
- Zijn progress.md en decisions.md bijgewerkt?
```

Als de repository of `development` branch nog ontbreekt, moet de AI die stap zelf uitvoeren wanneer zij toegang heeft. Als dat technisch niet kan, moet zij dit expliciet melden en exacte commando's geven. User-story branches mogen pas daarna worden aangemaakt.

---




## 31. Harde fasepoort: main → development basis → UI/designbaseline → stop → pas daarna US-001

De AI mag na het aanmaken van `main` en de eerste documentatie niet direct verdergaan met functionele code. De initiële ontwikkeling heeft verplichte fases. De volgende fase mag pas starten als de vorige fase volledig klaar, gecommit en gepusht is.

Dit is een harde procesregel.

```text
Fase 0: Guidelines en template staan in .docs
Fase 1: main met minimale repositorybasis
Fase 2: development met volledige technische basis
Fase 3: development met Blazor UI/designbaseline
Fase 4: STOP en vraag akkoord voor US-001
Fase 5: US-001 voorstellen en verfijnen
Fase 6: featurebranch maken
Fase 7: US-001 implementeren
```

### 30.1 Fase 1 - main bevat alleen minimale repositorybasis

`main` is de stabiele basis. Op `main` komt alleen de minimale initiële repositorybasis.

Toegestaan op `main`:

```text
[ ] .gitignore
[ ] README.md
[ ] .docs/development-guidelines.md
[ ] .docs/DefaultTemplate.zip indien aanwezig
[ ] voorbereidende .docs-bestanden
```

Niet toegestaan op `main`:

```text
[ ] functionele user story code
[ ] feature-specifieke domeinentities
[ ] echte applicatieflows
[ ] consumptie/product/order/student/etc. features
[ ] US-001 implementatie
[ ] featurebranch maken vóór akkoord op US-001
[ ] functionele code schrijven vóór het verplichte stopmoment
```

Daarna wordt `main` gepusht.

### 30.2 Fase 2 - development bevat volledige technische basis

Na `main` moet de AI `development` aanmaken of uitchecken. Alle technische baseline-ontwikkeling gebeurt op `development`, niet op een featurebranch.

Toegestaan op `development` in deze fase:

```text
[ ] .slnx solution wanneer tooling dit ondersteunt
[ ] Core-project
[ ] Application-project
[ ] Infrastructure-project
[ ] Web-project
[ ] testprojecten
[ ] IEntity
[ ] IRepository<T>
[ ] basis DI extension classes
[ ] basis EF Core/persistence-inrichting indien nodig
[ ] documentatie-updates
```

Niet toegestaan in deze fase:

```text
[ ] functionele user stories
[ ] feature-specifieke use cases
[ ] feature-specifieke UI-pagina's
[ ] businesslogica voor echte applicatieprocessen
[ ] US-001 implementatie
```

### 30.3 Fase 3 - development bevat Blazor UI/designbaseline

Nog steeds op `development` past de AI de volledige initiële Blazor UI/designbaseline toe.

Verplicht:

```text
[ ] .Web is server-side Blazor.
[ ] .docs/DefaultTemplate.zip is gebruikt als verplichte designbaseline wanneer aanwezig.
[ ] De shell is vertaald naar native Blazor/Razor.
[ ] MainLayout.razor is gebaseerd op de template-shell.
[ ] NavMenu.razor is gebaseerd op de template-navigatie.
[ ] Appbar/header is aanwezig.
[ ] Sidebar/drawer/mobile menu is aanwezig wanneer het template dat bevat.
[ ] Contentindeling volgt de template.
[ ] CSS uit de template is verwerkt in normale CSS in .Web.
[ ] Geen React/npm/Babel/Vite/Webpack.
[ ] InteractiveServer rendering werkt.
[ ] Hamburgermenu/drawer werkt.
```

Daarna moet de AI committen en pushen naar `origin/development`:

```bash
git status
git add .
git commit -m "Add technical baseline and Blazor design shell"
git push -u origin development
```

### 30.4 Fase 4 - verplicht stopmoment

Na Fase 3 moet de AI stoppen. De AI mag niet automatisch US-001 maken, geen featurebranch maken en geen functionele code schrijven.

Verplichte melding:

```text
De initiële basis staat nu op development en is gepusht naar origin/development.

Gereed:
- Clean Architecture-baseline
- Blazor .Web-basis
- DefaultTemplate UI/designbaseline
- interactieve shell
- documentatie
- GitHub main en development

Er is nog geen functionele user story geïmplementeerd.

Wil je dat ik US-001 voorstel en samen met je verfijn?
```

Alleen na expliciete toestemming van de gebruiker mag de AI verder naar Fase 5.

### 30.5 Fase 5 - US-001 voorstellen en verfijnen

De AI stelt US-001 eerst inhoudelijk voor, zonder code te schrijven en zonder branch te maken.

US-001 bevat minimaal:

```text
[ ] titel
[ ] doel
[ ] gebruiker/rol
[ ] waarde
[ ] scope
[ ] out-of-scope
[ ] acceptatiecriteria
[ ] concrete acceptatiescenario's
[ ] technisch plan op hoofdlijnen
[ ] te raken lagen
[ ] documentatie die bijgewerkt moet worden
```

De AI moet expliciet vragen:

```text
Wil je dat ik deze US-001 zo uitvoer?
```

### 30.6 Fase 6 - pas na akkoord featurebranch maken

Pas nadat de gebruiker akkoord geeft op US-001 en het plan, mag de AI een featurebranch maken vanaf `development`.

```bash
git checkout development
git pull
git checkout -b feature/US-001-korte-omschrijving
```

Daarna rapporteert de AI:

```text
Branchcontrole:
- Huidige branch: feature/US-001-korte-omschrijving
- Basisbranch: development
- Pull request doel: development
- Direct op development gewerkt: nee
```

### 30.7 Fase 7 - US-001 implementeren

Pas nu mag de AI functionele code schrijven.

Regels:

- werk alleen aan de goedgekeurde US-001;
- geen extra features meenemen;
- documentatie bijwerken;
- acceptatiescenario's opleveren;
- na testen PR naar `development`.

### 30.8 Harde stop bij fase-overtreding

De AI moet onmiddellijk stoppen als zij merkt dat:

- functionele code wordt geschreven vóór Fase 7;
- US-001 wordt geïmplementeerd op `main` of `development`;
- een featurebranch wordt gemaakt vóór akkoord op US-001;
- de UI/designbaseline nog niet op `development` staat;
- `origin/development` nog niet gepusht is;
- documentatie nog niet bijgewerkt is.

Dan meldt de AI:

```text
Fase-overtreding gedetecteerd.
Ik stop met implementeren en stel eerst een herstelplan voor.
```

---

## 32. Strikte fasering: initiële setup is geen functionele implementatie

De initiële setup is uitsluitend bedoeld om een technische, visuele en organisatorische basis neer te zetten. Tijdens de initiële setup mogen geen functionele user stories worden geïmplementeerd.

Standaardproces:

```text
1. Documentatie opzetten
2. Clean Architecture solution/projecten opzetten
3. Blazor .Web UI/designbaseline toepassen
4. Technische basis toevoegen
5. GitHub koppelen
6. Pushen naar development
7. Stoppen en akkoord vragen
8. US-001 voorstellen en verfijnen
9. Featurebranch maken
10. US-001 implementeren
```

### 29.1 Wat mag wel tijdens de initiële setup?

Tijdens de initiële setup mag de AI alleen werken aan:

```text
[ ] .docs/development-guidelines.md
[ ] .docs/DefaultTemplate.zip
[ ] .docs/architecture.md
[ ] .docs/decisions.md
[ ] .docs/progress.md
[ ] .docs/specification.md als lege/voorbereide structuur
[ ] .docs/flow.md als lege/voorbereide structuur
[ ] .docs/deployment.md als lege/voorbereide structuur
[ ] .docs/troubleshooting.md als lege/voorbereide structuur
[ ] README.md
[ ] .gitignore
[ ] solutionbestand, bij voorkeur .slnx
[ ] Core-project
[ ] Application-project
[ ] Infrastructure-project
[ ] Web-project als server-side Blazor
[ ] testprojecten
[ ] IEntity
[ ] IRepository<T>
[ ] basis DI extension classes
[ ] minimale EF Core/persistence-baseline indien nodig voor de architectuur
[ ] Blazor layout/shell uit .docs/DefaultTemplate.zip
[ ] navigatie/shell zonder domeinfunctionaliteit
[ ] interactive server rendering voor de shell
[ ] GitHub remote
[ ] main en development branches
```

### 29.2 Wat mag niet tijdens de initiële setup?

Tijdens de initiële setup mag de AI nog niet bouwen:

```text
[ ] functionele user stories
[ ] domeinfeatures zoals productbeheer, consumpties, orders, planning, leerlingen, dossiers, etc.
[ ] functionele pagina's anders dan template-, shell- of neutrale startpagina's
[ ] businesslogica voor echte use cases
[ ] concrete service-methodes voor functionele processen
[ ] echte invoerflows voor de uiteindelijke applicatie
[ ] feature-specifieke database-entiteiten, behalve als de gebruiker expliciet zegt dat ze al onderdeel zijn van de technische baseline
[ ] US-001 implementatie
```

Als de gebruiker tijdens de scopefase Must haves noemt, mogen die alleen in `.docs/specification.md` worden vastgelegd. Ze mogen nog niet worden geïmplementeerd tijdens de initiële setup.

### 29.3 Stopmoment na initiële setup

Na de initiële setup moet de AI stoppen en expliciet melden:

```text
De initiële setup is klaar.

Status:
- Documentatie staat klaar.
- Clean Architecture-baseline staat.
- .Web UI/designbaseline is toegepast.
- GitHub is gekoppeld.
- main en development bestaan.
- De initiële basis staat op development en is gepusht.
- Er is nog geen functionele user story geïmplementeerd.

Het systeem is nu klaar voor de eerste user story.

Volgende stap:
US-001 voorstellen en samen verfijnen. Ik maak nog geen featurebranch en schrijf nog geen functionele code totdat je akkoord geeft op de eerste user story.
```

### 29.4 US-001 pas na akkoord

Na de initiële setup mag de AI niet automatisch US-001 bouwen, geen featurebranch maken en geen functionele code schrijven.

De juiste volgorde is:

```text
1. AI stelt één of meer mogelijke US-001 kandidaten voor op basis van specification.md.
2. Gebruiker kiest of past aan.
3. AI werkt US-001 uit met acceptatiecriteria.
4. AI geeft een plan van aanpak.
5. Gebruiker geeft akkoord.
6. AI maakt pas na expliciet akkoord feature/US-001-* vanaf development.
7. AI implementeert US-001.
8. AI levert acceptatiescenario's.
9. Na testen volgt PR naar development.
```

### 29.5 Geen featurebranch vóór user story akkoord

De AI mag niet al een featurebranch maken terwijl US-001 nog niet inhoudelijk is besproken en goedgekeurd.

Standaardregel:

```text
Eerst technische basis en UI/designbaseline op development pushen.
Daarna stopmoment en akkoord vragen.
Daarna user story verfijnen en akkoord.
Daarna pas featurebranch.
Daarna pas implementatie.
```

### 29.6 Herstel als er toch functionele code in de initiële setup zit

Als er tijdens de initiële setup toch functionele code is toegevoegd, moet de AI dit melden en eerst een herstelplan maken.

De AI moet bepalen:

```text
- Welke wijzigingen horen bij de technische baseline?
- Welke wijzigingen horen bij functionele user stories?
- Zijn deze wijzigingen al gecommit?
- Zijn ze al gepusht naar development?
- Moet er worden teruggedraaid, uitgesplitst of alsnog als US-001 branch worden geïsoleerd?
```

De AI mag dit niet stilzwijgend laten staan als onderdeel van de initiële basis.

### 29.7 Acceptatiecriteria voor de initiële setup

De initiële setup is pas gereed als deze acceptatiecriteria voldoen:

```text
[ ] Solution gebruikt .slnx wanneer de tooling dit ondersteunt.
[ ] Alle applicatiecode is C#.
[ ] Clean Architecture-projectstructuur staat.
[ ] .Web is server-side Blazor.
[ ] .docs/DefaultTemplate.zip is toegepast als designbaseline indien aanwezig.
[ ] UI-shell werkt inclusief interactive server rendering.
[ ] Er is geen functionele user story geïmplementeerd.
[ ] Er zijn geen feature-specifieke domeinflows gebouwd.
[ ] GitHub remote is gekoppeld.
[ ] main is gepusht.
[ ] development bevat de initiële basis.
[ ] development is gepusht.
[ ] werkmap is clean.
[ ] progress.md vermeldt dat het systeem klaar is voor US-001.
```

---

## 33. Harde fasegrens: initiële projectbasis eerst op development

De initiële projectbasis mag niet worden uitgevoerd op de branch van de eerste user story. De eerste user-story branch mag pas worden aangemaakt nadat de volledige basis op `development` staat en naar GitHub is gepusht.

Standaardregel:

```text
main → development met initiële basis → push origin/development → feature/US-001 vanaf development
```

Niet toegestaan:

```text
main → feature/US-001 → initiële projectbasis + US-001 samen
development → feature/US-001 → initiële projectbasis alsnog op featurebranch
```

### 28.1 Wat hoort bij de initiële projectbasis?

De initiële projectbasis bevat minimaal:

```text
[ ] Solution aangemaakt in `.slnx`-formaat wanneer de tooling dit ondersteunt.
[ ] Alle applicatiecode is C#.
[ ] Projecten aangemaakt.
[ ] Clean Architecture-projectstructuur staat.
[ ] .docs/development-guidelines.md aanwezig.
[ ] .docs/DefaultTemplate.zip aanwezig wanneer het project een Blazor UI gebruikt.
[ ] .docs/architecture.md aangemaakt en bijgewerkt.
[ ] .docs/decisions.md aangemaakt en bijgewerkt.
[ ] .docs/progress.md aangemaakt en bijgewerkt.
[ ] .docs/specification.md aangemaakt.
[ ] .docs/flow.md aangemaakt indien relevant.
[ ] .docs/deployment.md aangemaakt.
[ ] .docs/troubleshooting.md aangemaakt.
[ ] README.md aangemaakt.
[ ] .Web is server-side Blazor indien UI nodig is.
[ ] DefaultTemplate.zip is direct toegepast als designbaseline indien aanwezig.
[ ] Interactive server rendering is correct geconfigureerd.
[ ] GitHub remote is gekoppeld.
[ ] main is gepusht.
[ ] development is aangemaakt vanaf main.
[ ] initiële projectbasis is gecommit op development.
[ ] er is nog geen functionele user story geïmplementeerd.
[ ] development is gepusht naar origin/development.
[ ] werkmap is clean.
```

Deze basis hoort niet thuis op `feature/US-001-*`.

### 28.2 Verplichte volgorde

De AI gebruikt deze volgorde:

```text
1. Maak lokale solution, projecten, documentatie en designbaseline.
2. Controleer build en basisacceptatie.
3. Commit initiële basis.
4. Push main indien nog nodig.
5. Maak of checkout development.
6. Zorg dat de volledige initiële basis op development staat.
7. Push development naar GitHub.
8. Controleer dat origin/development bestaat.
9. Pas daarna: vraag applicatiescope of werk die bij.
10. Pas daarna: definieer US-001.
11. Pas daarna: maak feature/US-001-* vanaf development.
```

### 28.3 Commands voor correcte basis

Als de initiële basis op `main` staat en `development` nog moet worden ingericht:

```bash
git checkout main
git pull
git checkout -b development
git push -u origin development
```

Als de initiële basis lokaal nog niet gecommit is:

```bash
git status
git add .
git commit -m "Add initial project baseline"
git push
```

Als `development` bestaat maar nog niet de volledige basis bevat:

```bash
git checkout development
git pull
git merge main
git push
```

Gebruik alleen een merge wanneer dit past bij de actuele Git-situatie. De AI moet eerst `git status`, `git branch --show-current`, `git log --oneline --decorate -5` en `git branch --all` controleren.

### 28.4 Verplichte controle vóór US-001

Vóór de eerste user story moet de AI rapporteren:

```text
Initiële basiscontrole:
- Huidige branch: development
- origin/development bestaat: ja
- initiële projectbasis gecommit op development: ja
- initiële projectbasis gepusht naar origin/development: ja
- werkmap clean: ja
- designbaseline toegepast indien DefaultTemplate.zip aanwezig: ja/n.v.t.
- documentatie bijgewerkt: ja
- conclusie: US-001 featurebranch mag worden aangemaakt / nog niet toegestaan
```

Alleen als de conclusie “US-001 mag inhoudelijk worden besproken” is, mag de AI US-001 voorstellen en verfijnen. De featurebranch wordt pas gemaakt nadat de gebruiker akkoord heeft gegeven op US-001 en het implementatieplan. Daarna mag de AI uitvoeren:

```bash
git checkout development
git pull
git checkout -b feature/US-001-korte-omschrijving
```

### 28.5 Als de initiële basis per ongeluk op een featurebranch staat

Als de initiële projectbasis per ongeluk op `feature/US-001-*` of een andere featurebranch is gezet, mag de AI niet verder bouwen aan US-001.

De AI moet eerst een herstelplan maken.

Mogelijke veilige herstelroute als de basis nog niet op `development` staat:

```bash
git status
git branch --show-current
git log --oneline --decorate -5
```

Daarna, afhankelijk van de situatie:

```bash
git checkout development
git pull
git merge feature/US-001-korte-omschrijving
git push
```

Vervolgens wordt de featurebranch opnieuw gemaakt vanaf de nu correcte `development`:

```bash
git checkout development
git pull
git checkout -b feature/US-001-korte-omschrijving
```

Let op:

- Als de featurebranch naast de basis ook al echte US-001 functionaliteit bevat, moet de AI eerst analyseren welke commits bij de basis horen en welke bij US-001.
- De AI mag niet blind mergen wanneer basis en user-story wijzigingen door elkaar lopen.
- De AI moet dan een herstelplan voorleggen voordat zij Git-acties uitvoert.

### 28.6 Documentatie bij fasegrens

`.docs/progress.md` moet expliciet vermelden:

```text
## Initiële projectbasis

Status: gereed
Branch: development
Gepusht naar: origin/development
Laatste commit: <hash> <message>

## Volgende stap

Wacht op akkoord van de gebruiker om US-001 voor te stellen en te verfijnen. Maak pas daarna feature/US-001-* vanaf development.
```

`.docs/decisions.md` moet de keuze bevatten:

```text
| Datum | Keuze | Reden | Impact | Status |
|------|-------|-------|--------|--------|
| YYYY-MM-DD | Initiële projectbasis staat op development vóór US-001 | User-story branches bevatten alleen functionele wijzigingen | US-001 start pas vanaf gepushte development baseline | Actief |
```

### 28.7 Harde stop

De AI mag geen user story analyseren, implementeren of committen zolang:

- de initiële basis nog niet op `development` staat;
- `development` nog niet is gepusht naar GitHub;
- de huidige branch al een `feature/US-001-*` is terwijl de basis nog niet op `development` staat;
- documentatie en designbaseline nog niet op `development` staan;
- de werkmap niet clean is na het pushen van de basis.

---

## 34. Harde stop: user stories nooit direct op development

Een user story mag nooit rechtstreeks op `development` worden geïmplementeerd.

`development` is de integratiebranch. Werk aan een user story gebeurt altijd op een aparte branch die vanaf de actuele `development` branch is gemaakt.

Standaardregel:

```text
development → feature/US-xxx-korte-naam → pull request naar development
```

Niet toegestaan:

```text
development → direct user story implementeren
```


### Verplichte AI-agentregel vóór iedere user story

Voordat een AI-agent een user story analyseert, implementeert of wijzigt, moet zij expliciet vaststellen:

```text
Huidige branch is niet development.
Huidige branch is een featurebranch vanaf development.
```

Als de AI-agent op `development` staat, moet zij eerst controleren dat de initiële projectbasis op `development` staat en naar `origin/development` is gepusht. Pas daarna mag zij een featurebranch maken. Dit geldt ook voor de eerste user story direct na de projectbasis.

Voorbeeld:

```bash
git checkout development
git pull
git checkout -b feature/US-001-korte-omschrijving
```

Daarna pas:

```text
analyse → plan → implementatie → acceptatiescenario's → PR naar development
```

### 26.1 Verplichte branchcontrole vóór implementatie

Voordat de AI een user story implementeert, moet zij de huidige branch controleren.

Verplichte controle:

```bash
git status
git branch --show-current
git branch --all
```

Als de huidige branch `development` is en de AI gaat een user story implementeren, moet zij eerst een nieuwe branch maken.

Voorbeeld:

```bash
git checkout development
git pull
git checkout -b feature/US-001-consumption-flow
```

Daarna mag pas code worden aangepast.

### 26.2 Branchnaam

Gebruik bij voorkeur deze naamgeving:

```text
feature/US-001-consumption-flow
feature/US-002-product-overview
feature/US-003-edit-consumption-entry
```

Regels:

- Begin met `feature/`.
- Neem het user-story nummer op.
- Gebruik een korte Engelstalige omschrijving.
- Gebruik kleine letters en koppeltekens.
- Houd de branchnaam herkenbaar.

### 26.3 Als er per ongeluk op development is gewerkt

Als een user story per ongeluk direct op `development` is geïmplementeerd, mag de AI niet doen alsof dit correct is. De AI moet dit expliciet melden en een herstelroute voorstellen.

Situatie: wijzigingen zijn nog niet gecommit.

```bash
git status
git checkout -b feature/US-xxx-korte-naam
git add .
git commit -m "Implement US-xxx korte omschrijving"
```

Situatie: wijzigingen zijn al lokaal gecommit op `development`, maar nog niet gepusht.

```bash
git status
git branch --show-current
git branch feature/US-xxx-korte-naam
git reset --hard origin/development
git checkout feature/US-xxx-korte-naam
```

Gebruik `git reset --hard` alleen als zeker is dat de commit veilig op de featurebranch staat en er geen onbedoelde lokale wijzigingen verloren gaan.

Situatie: wijzigingen zijn al naar `origin/development` gepusht.

Dan mag de AI niet automatisch history herschrijven. De AI moet eerst de situatie uitleggen en een veilige correctiestrategie voorstellen, bijvoorbeeld:

- alsnog een pull request maken als herstel niet zinvol of veilig is;
- revert commit op `development` en daarna featurebranch correct opnieuw aanbieden;
- in overleg bepalen welke route het veiligst is.

### 26.4 Verplichte melding na implementatie

Na implementatie van een user story meldt de AI altijd:

```text
Branchcontrole:
- Huidige branch: feature/US-xxx-korte-naam
- Basisbranch: development
- Pull request doel: development
- Direct op development gewerkt: nee
```

Als het antwoord op “Direct op development gewerkt” ja is, is de user story niet volgens de richtlijn uitgevoerd en moet eerst herstel plaatsvinden.

---

## 35. Acceptatiescenario's per user story

Bij iedere user story moet de AI concrete acceptatiescenario's opleveren. Deze scenario's zijn bedoeld om door de gebruiker handmatig te testen of de user story goed is geïmplementeerd.

Een algemene melding zoals “Build is geslaagd” is niet genoeg. De gebruiker moet kunnen zien welke functionele stappen getest moeten worden.

Standaardregel:

```text
Geen pull request zonder concrete acceptatiescenario's en testresultaten.
```

### 27.1 Minimale inhoud van acceptatiescenario's

Voor iedere user story worden minimaal deze onderdelen beschreven:

```text
## Acceptatiescenario's voor US-xxx

### Scenario 1 - Titel

Doel:
Wat bewijst dit scenario?

Voorwaarde:
Welke data, gebruiker, pagina of startsituatie is nodig?

Stappen:
1. ...
2. ...
3. ...

Verwacht resultaat:
- ...

Resultaat:
- Niet getest / Geslaagd / Afgewezen

Opmerkingen:
- ...
```

### 27.2 Soorten scenario's

Een user story bevat waar relevant meerdere soorten scenario's:

- happy flow;
- validatie of foutieve invoer;
- edge case;
- bestaande data gebruiken;
- nieuwe data aanmaken;
- navigatie of UI-flow;
- Blazor-interactiviteit, zoals knoppen, formulieren, zoekvelden en directe updates;
- databasecontrole;
- autorisatiecontrole;
- regressiecontrole op bestaande functionaliteit.

Niet elke user story heeft al deze scenario's nodig. De AI moet zelf bepalen welke scenario's relevant zijn.

### 27.3 Voorbeeld voor een consumptie-user-story

Voor een user story waarin een gebruiker consumptie kan registreren, kunnen acceptatiescenario's er zo uitzien:

```text
## Acceptatiescenario's voor US-001 - Consumptie registreren

### Scenario 1 - Bestaand product zoeken en consumptie opslaan

Doel:
Controleren dat een gebruiker een bestaand product kan zoeken, selecteren en als consumptie kan opslaan.

Voorwaarde:
Er bestaat minimaal één product in de database, bijvoorbeeld "Banaan".

Stappen:
1. Start de applicatie.
2. Navigeer naar /consumption.
3. Zoek op een deel van de productnaam, bijvoorbeeld "ban".
4. Selecteer het bestaande product "Banaan".
5. Vul hoeveelheid in gram/ml in.
6. Vul datum en tijd in.
7. Sla de consumptie op.

Verwacht resultaat:
- Het product wordt gevonden op gedeeltelijke naam.
- De consumptie wordt opgeslagen.
- Het dagoverzicht wordt direct bijgewerkt.
- Er verschijnt geen foutmelding.

Resultaat:
- Niet getest

### Scenario 2 - Nieuw product aanmaken tijdens consumptie

Doel:
Controleren dat een gebruiker direct een nieuw product kan aanmaken als het product nog niet bestaat.

Voorwaarde:
Het product "Testproduct" bestaat nog niet.

Stappen:
1. Navigeer naar /consumption.
2. Zoek op "Testproduct".
3. Kies voor nieuw product aanmaken.
4. Vul hoeveelheid, datum en tijd in.
5. Sla de consumptie op.

Verwacht resultaat:
- Het nieuwe product wordt aangemaakt.
- De consumptie wordt gekoppeld aan het nieuwe product.
- Het dagoverzicht wordt bijgewerkt.

Resultaat:
- Niet getest

### Scenario 3 - Validatie bij ontbrekende hoeveelheid

Doel:
Controleren dat de gebruiker geen consumptie zonder hoeveelheid kan opslaan.

Voorwaarde:
Er is een product geselecteerd.

Stappen:
1. Navigeer naar /consumption.
2. Selecteer of maak een product.
3. Laat hoeveelheid leeg of vul 0 in.
4. Probeer op te slaan.

Verwacht resultaat:
- De consumptie wordt niet opgeslagen.
- De gebruiker krijgt een duidelijke validatiemelding.

Resultaat:
- Niet getest
```

### 27.4 Vastleggen in documentatie

Acceptatiescenario's worden vastgelegd in:

```text
.docs/specification.md
.docs/progress.md
```

In `specification.md` staan ze bij de betreffende user story.

In `progress.md` komt de actuele teststatus:

```text
## Laatste acceptatietesten

| Datum | User story | Scenario | Resultaat | Opmerking |
|------|------------|----------|-----------|-----------|
| YYYY-MM-DD | US-001 | Bestaand product zoeken en consumptie opslaan | Geslaagd | Dagoverzicht bijgewerkt |
| YYYY-MM-DD | US-001 | Nieuw product aanmaken tijdens consumptie | Niet getest | Nog uitvoeren |
```

### 27.5 Pull request blokkade

Een user story is niet klaar voor pull request naar `development` zolang:

- acceptatiescenario's ontbreken;
- alle relevante scenario's nog op `Niet getest` staan;
- een scenario `Afgewezen` is zonder herstel;
- testresultaten niet in `progress.md` zijn vastgelegd;
- de AI niet heeft gemeld welke scenario's de gebruiker moet uitvoeren.

### 27.6 Verplichte output na user story

Na implementatie van een user story geeft de AI altijd:

```text
User story:
- US-xxx - Titel

Branch:
- feature/US-xxx-korte-naam

Aangepaste code:
- ...

Aangepaste documentatie:
- ...

Acceptatiescenario's:
1. ...
2. ...
3. ...

Nog uit te voeren door gebruiker:
- Voer de bovenstaande scenario's uit.
- Noteer per scenario Geslaagd of Afgewezen.
- Pas daarna is een pull request naar development logisch.

Pull request:
- Nog niet maken zolang acceptatiescenario's niet zijn uitgevoerd.
```

---

## 36. Branch- en pull requeststrategie per user story

Voor iedere user story wordt verplicht een aparte branch aangemaakt. Een user story mag niet rechtstreeks op `development` worden geïmplementeerd. Een branch bevat dus bij voorkeur precies één user story of één duidelijke, kleine functionele wijziging.

Standaardregel:

```text
1 user story = 1 branch = 1 pull request
```

#### 23.1 Branch altijd vanaf development

Een nieuwe user-story branch wordt altijd gebaseerd op de actuele `development` branch.

Werkwijze:

```text
1. Controleer of er geen open pull request meer staat.
2. Ga naar `development`.
3. Haal de laatste wijzigingen op.
4. Maak vanaf die actuele basis een nieuwe branch voor de user story.
```

Voorbeeld met `development`:

```bash
git checkout development
git pull
git checkout -b feature/US-001-student-aanmaken
```

### 23.2 Geen nieuwe branch bij open pull request

Er mag geen nieuwe user-story branch worden aangemaakt zolang er nog een open pull request staat voor een vorige user story.

Reden:

- voorkomt stapeling van onafgeronde wijzigingen;
- voorkomt afhankelijkheden tussen feature branches;
- maakt review eenvoudiger;
- houdt `development` de betrouwbare basis voor actief ontwikkelwerk;
- maakt terugdraaien of corrigeren eenvoudiger;
- houdt AI-sessies beter bestuurbaar.

Als er nog een open pull request staat:

```text
Eerst de open pull request afronden:
- review uitvoeren;
- eventuele feedback verwerken;
- tests opnieuw uitvoeren;
- pull request mergen;
- `development` updaten;
- daarna pas een nieuwe branch starten.
```

### 23.3 Pull request na succesvolle user story

Wanneer een user story volledig is geïmplementeerd en getest, wordt een pull request gemaakt naar `development`.

Voorwaarden vóór pull request:

```text
[ ] User story staat in .docs/specification.md.
[ ] Acceptatiecriteria zijn afgevinkt of aantoonbaar getest.
[ ] Concrete acceptatiescenario's zijn opgesteld.
[ ] Acceptatiescenario's zijn uitgevoerd of expliciet aan de gebruiker gegeven om uit te voeren.
[ ] Testresultaten zijn vastgelegd in .docs/progress.md.
[ ] Code buildt zonder fouten.
[ ] Relevante tests zijn uitgevoerd.
[ ] Swagger/UI/databasecontrole is uitgevoerd waar relevant.
[ ] .docs/progress.md is bijgewerkt.
[ ] .docs/architecture.md is bijgewerkt indien de architectuur wijzigde.
[ ] .docs/decisions.md is bijgewerkt indien keuzes zijn gemaakt of gewijzigd.
[ ] .docs/flow.md is bijgewerkt indien datastromen zijn gewijzigd.
[ ] .docs/deployment.md is bijgewerkt indien deployment is geraakt.
[ ] .docs/troubleshooting.md is bijgewerkt indien nieuwe bekende problemen/oplossingen zijn ontstaan.
```

### 23.4 Pull request inhoud

Een pull request bevat minimaal:

- verwijzing naar de user story;
- korte samenvatting van de wijziging;
- overzicht van aangepaste codebestanden;
- overzicht van aangepaste documentatiebestanden;
- uitgevoerde acceptatietesten;
- eventuele database migrations;
- eventuele open punten;
- bevestiging of dit veilig naar `development` kan.

Voorbeeld PR-beschrijving:

```text
## User story

US-001 - Student aanmaken

## Samenvatting

Voegt de mogelijkheid toe om een student aan te maken via de applicatie.

## Aangepaste code

- ProjectName.Core/Entities/Student.cs
- ProjectName.Application/Services/StudentService.cs
- ProjectName.Application/DTOs/Student/CreateStudentRequest.cs
- ProjectName.Infrastructure/Repositories/EfRepository.cs
- ProjectName.Web/Components/Pages/Students.razor

## Aangepaste documentatie

- .docs/specification.md
- .docs/progress.md
- .docs/architecture.md

## Tests

- Build Solution: geslaagd
- UI-test student aanmaken: geslaagd
- Databasecontrole: geslaagd

## Open punten

Geen.

## Mergeadvies

Klaar voor merge naar development.
```

### 23.5 Na merge

Na het mergen van de pull request:

```text
1. Ga terug naar development.
2. Haal de laatste wijzigingen op.
3. Controleer dat de merge lokaal beschikbaar is.
4. Controleer of .docs/progress.md de actuele status correct weergeeft.
5. Start daarna pas een nieuwe user-story branch.
```

Voorbeeld:

```bash
git checkout development
git pull
```

### 23.6 AI-regel

Een AI-assistent moet vóór het starten van een nieuwe user story expliciet controleren of de branchstrategie klopt.

De AI moet melden:

```text
Branchcontrole:
- Werk ik op development of op een feature branch?
- Is er nog een open pull request?
- Is de vorige user story gemerged?
- Mag er nu vanaf development een nieuwe branch worden aangemaakt?
```

Als er nog een open pull request is, mag de AI geen nieuwe user-story branch voorstellen. Eerst moet de open pull request worden afgerond.

---

## 37. Commit- en branchstrategie

Werk op feature branches, maar altijd volgens de regel: één user story per branch, gebaseerd op actuele `development`, en pas een nieuwe branch nadat de vorige pull request naar `development` is afgerond en gemerged.

Voorbeelden:

```text
feature/StudentManagement
feature/MeasurementIngest
feature/NetwerkData/Parsing
feature/NetwerkData/Interpretation
bugfix/FixStudentValidation
docs/UpdateArchitecture
```

Commit na kleine werkende stappen.

Goede commitmomenten:

- Na initiële documentatiestructuur.
- Na een uitgewerkte user story.
- Na een compileerbare entity + migration.
- Na een werkende service.
- Na een werkend API endpoint.
- Na een geslaagde Swagger-test.
- Na bijgewerkte documentatie.
- Na een werkende verticale slice.

Commit messages:

```text
Add project documentation structure
Add student management specification
Record database decision
Add measurement entity and repository support
Add latest measurements API endpoint
Update progress after ingest slice
```

---


## 38. GitHub repository-URL verplicht vóór push en development branch

Na de initiële lokale basis moet de AI de gebruiker expliciet om een GitHub repository-URL vragen wanneer zij niet zelf via GitHub tooling een repository kan aanmaken.

Standaardregel:

```text
Geen GitHub remote URL = geen afgeronde initiële basis = geen user stories.
```

### 27.1 Verplichte vraag aan de gebruiker

Als er nog geen remote is gekoppeld, geeft de AI de gebruiker deze instructie:

```text
Maak eerst een lege GitHub-repository aan.

Stappen:
1. Ga naar GitHub.
2. Kies New repository.
3. Geef de repository een naam.
4. Kies Public of Private.
5. Voeg nog geen README, .gitignore of license toe als de lokale basis al bestaat.
6. Maak de repository aan.
7. Kopieer de HTTPS- of SSH-url van de repository.
8. Geef die url hier terug.

Voorbeelden:
- https://github.com/<account>/<repository>.git
- git@github.com:<account>/<repository>.git

Zodra je de URL geeft, koppel ik de remote, push ik main, maak ik development aan en push ik development.
```

### 27.2 AI koppelt remote en pusht zelf

Zodra de gebruiker de repository-URL geeft, voert de AI zelf de koppeling uit wanneer zij toegang heeft tot de lokale Git-omgeving:

```bash
git remote add origin <repository-url>
git push -u origin main
git checkout -b development
git push -u origin development
git checkout development
```

Als `origin` al bestaat, controleert de AI eerst:

```bash
git remote -v
```

Als de remote fout is, mag de AI die niet zomaar vervangen zonder dit te melden. Dan geeft zij eerst een herstelplan.

### 27.3 Harde stop

De AI mag niet verder met applicatiescope, user stories of featurebranches als:

- er geen GitHub repository-URL is;
- `origin` niet is gekoppeld;
- `main` niet gepusht is;
- `development` niet bestaat;
- `development` niet gepusht is;
- de lokale branch niet op `development` staat na setup.

---

## 39. Verplichte automatische GitHub- en branch-inrichting vóór user stories

Na het aanmaken van de initiële basis mag de AI niet doorgaan met user stories totdat Git, GitHub en de `development` branch daadwerkelijk zijn ingericht.

Dit is geen vrijblijvende controle of adviesstap. De AI-omgeving moet deze stappen zelf uitvoeren wanneer zij toegang heeft tot:

- de lokale projectmap;
- Git;
- GitHub CLI (`gh`) of een andere geautoriseerde GitHub-koppeling;
- rechten om een repository aan te maken of te koppelen.

Standaardregel:

```text
Geen user story zonder GitHub-repository, initiële commit op main en development branch.
```

### 25.1 Verplichte volgorde na initiële basis

Zodra de initiële basis klaar is, voert de AI deze volgorde uit:

```text
1. Controleer of de solution buildt.
2. Controleer of Git al geïnitialiseerd is.
3. Initialiseer Git als dat nog niet is gedaan.
4. Maak een initiële commit.
5. Maak of koppel een GitHub-repository.
6. Push de initiële basis naar main.
7. Maak een development branch vanaf main.
8. Push development naar GitHub.
9. Zet de lokale werkbranch op development.
10. Controleer dat de volledige initiële projectbasis op development staat.
11. Push development naar GitHub.
12. Werk .docs/progress.md bij.
13. Werk .docs/decisions.md bij.
14. Ga pas daarna verder met applicatiebeschrijving, scope en user stories.
```

### 25.2 Commands wanneer nog geen Git-repository bestaat

```bash
git init
git add .
git commit -m "Add initial solution structure and documentation"
git branch -M main
```

Daarna maakt of koppelt de AI de GitHub-repository.

Bij gebruik van GitHub CLI:

```bash
gh repo create <repository-name> --private --source=. --remote=origin --push
```

Of, als de repository al bestaat:

```bash
git remote add origin <repository-url>
git push -u origin main
```

Daarna wordt `development` aangemaakt en gepusht:

```bash
git checkout -b development
git push -u origin development
```

### 25.3 Commands wanneer Git al bestaat maar development ontbreekt

```bash
git status
git branch --show-current
git remote -v
git branch --all
```

Als `main` bestaat en gepusht is, maar `development` ontbreekt:

```bash
git checkout main
git pull
git checkout -b development
git push -u origin development
```

### 25.4 Verplichte eindcontrole

Na inrichting moet de AI controleren:

```bash
git status
git branch --show-current
git remote -v
git branch --all
```

De verwachte situatie is:

```text
Huidige branch: development
Remote: GitHub repository aanwezig
Lokale branches: main en development
Remote branches: origin/main en origin/development
Werkmap: clean
```

### 25.5 Documentatie na GitHub-inrichting

Na deze stap werkt de AI minimaal deze bestanden bij:

```text
.docs/progress.md
.docs/decisions.md
```

`progress.md` krijgt minimaal:

```text
## Repository

GitHub-repository: <repository-url>
Standaardbranch: main
Ontwikkelbranch: development

## Huidige status

De initiële solution, projecten en documentatiestructuur zijn aangemaakt.
De initiële basis is gecommit en gepusht naar main.
De development branch is aangemaakt en gepusht.
De lokale werkbranch is development.
Nieuwe user-story branches worden vanaf development gemaakt.
```

`decisions.md` krijgt minimaal:

```text
| Datum | Keuze | Reden | Impact | Status |
|------|-------|-------|--------|--------|
| YYYY-MM-DD | Gebruik van development als ontwikkelbranch | Featurewerk blijft gescheiden van stabiele main | User-story branches starten vanaf development en PR's gaan terug naar development | Actief |
| YYYY-MM-DD | Deployment alleen vanaf main | Main blijft stabiel en releasewaardig | Releases lopen via PR van development naar main | Actief |
```

### 25.6 Als de AI geen GitHub-repository kan aanmaken

Als de AI geen toegang heeft tot GitHub CLI, geen rechten heeft, of authenticatie ontbreekt, mag zij niet doen alsof de repository is aangemaakt.

Dan moet de AI:

1. Duidelijk melden welke stap niet automatisch kon.
2. De exacte commando's geven die de gebruiker moet uitvoeren.
3. Stoppen met user-story werk totdat GitHub en `development` ingericht zijn.
4. Daarna opnieuw `git status`, `git remote -v` en `git branch --all` laten controleren.

De AI mag in dat geval wel helpen met herstelcommando's, maar mag geen user story uitwerken alsof de branchbasis klopt.

### 25.7 Als er al per ongeluk user-story werk is gedaan zonder development branch

Als er al user-story wijzigingen zijn gedaan voordat `development` bestond, moet de AI eerst de Git-situatie herstellen en niet verder bouwen.

Veilige herstelroute wanneer de wijzigingen nog lokaal en ongecommit zijn:

```bash
git status
git checkout -b feature/US-xxx-korte-naam
git add .
git commit -m "Add US-xxx implementation"
```

Daarna moet alsnog `development` worden ingericht vanaf `main`. Vervolgens wordt de featurebranch via pull request naar `development` gebracht.

Als wijzigingen al naar `main` zijn gepusht, moet de AI eerst de situatie analyseren en een veilig herstelplan voorstellen. De AI mag niet automatisch history herschrijven zonder expliciete opdracht.

---

## 40. Release- en deploymentstrategie

Actieve ontwikkeling vindt plaats op `development` en featurebranches. Deployment vindt altijd plaats vanaf `main`.

Standaardregel:

```text
feature branch → pull request naar development
development → pull request naar main
deployment → altijd vanaf main
```

### 25.1 Development is niet de deploymentbranch

`development` is bedoeld voor geïntegreerd ontwikkelwerk. Deze branch bevat afgeronde user stories die via pull requests zijn samengevoegd, maar is niet automatisch releasewaardig.

Regels:

- User-story branches worden gemerged naar `development`.
- `development` wordt gebruikt om functionaliteit te integreren en gezamenlijk te testen.
- `development` wordt niet gebruikt als deploymentbron.
- Een deployment mag niet rechtstreeks vanaf `development` plaatsvinden.

### 25.2 Pull request van development naar main

Wanneer een set user stories klaar is voor release of deployment, wordt een pull request gemaakt van `development` naar `main`.

Voorwaarden vóór deze pull request:

```text
[ ] Alle user-story pull requests naar development zijn afgerond.
[ ] Er staan geen open pull requests voor user stories die nog in deze release moeten.
[ ] development buildt zonder fouten.
[ ] Relevante automatische tests zijn geslaagd.
[ ] Relevante handmatige acceptatietesten zijn uitgevoerd.
[ ] .docs/progress.md beschrijft de actuele releasekandidaat.
[ ] .docs/specification.md heeft de juiste status bij afgeronde user stories.
[ ] .docs/architecture.md is actueel.
[ ] .docs/decisions.md is actueel.
[ ] .docs/deployment.md is actueel.
[ ] Bekende problemen zijn vastgelegd in .docs/troubleshooting.md.
```

Voorbeeld:

```bash
git checkout development
git pull

git checkout main
git pull

# Maak daarna via GitHub een pull request:
# base: main
# compare: development
```

### 25.3 Pull request inhoud voor release

Een pull request van `development` naar `main` bevat minimaal:

- release- of deploymentdoel;
- overzicht van afgeronde user stories;
- overzicht van belangrijkste wijzigingen;
- uitgevoerde tests;
- eventuele database migrations;
- eventuele deploymentstappen;
- bekende beperkingen;
- bevestiging dat `.docs/deployment.md` actueel is;
- bevestiging dat deployment vanaf `main` kan plaatsvinden.

Voorbeeld PR-beschrijving:

```text
## Release naar main

Doel:
Release van de afgeronde studentbeheer-functionaliteit.

## Afgeronde user stories

- US-001 - Student aanmaken
- US-002 - Studentoverzicht tonen
- US-003 - Student bewerken

## Tests

- Build development: geslaagd
- Unit tests: geslaagd
- Handmatige UI-tests: geslaagd
- Databasecontrole: geslaagd

## Documentatie

- .docs/progress.md bijgewerkt
- .docs/specification.md bijgewerkt
- .docs/deployment.md gecontroleerd
- .docs/architecture.md gecontroleerd

## Deployment

Deployment mag plaatsvinden vanaf main nadat deze PR is gemerged.

## Open punten

Geen blokkerende punten.
```

### 25.4 Deployment altijd vanaf main

Na het mergen van de pull request van `development` naar `main`, wordt deployment uitgevoerd vanaf `main`.

Regels:

- Deployment gebeurt alleen vanaf `main`.
- Deployment gebeurt niet vanaf `development`.
- Deployment gebeurt niet vanaf een featurebranch.
- De versie op `main` moet buildbaar en releasewaardig zijn.
- Deploymentstappen staan in `.docs/deployment.md`.
- Als CI/CD wordt gebruikt, triggert deployment bij voorkeur alleen op `main`.
- Hotfixes worden als aparte flow beschreven en mogen niet stilzwijgend buiten deze regels vallen.

Voorbeeld lokale controle vóór deployment:

```bash
git checkout main
git pull
dotnet build
```

### 25.5 Documentatie bij release/deployment

Bij een release of deployment worden minimaal deze documenten gecontroleerd of bijgewerkt:

```text
.docs/progress.md
.docs/deployment.md
.docs/specification.md
.docs/architecture.md
.docs/decisions.md
.docs/troubleshooting.md
```

`progress.md` krijgt bijvoorbeeld:

```text
## Laatste release/deployment

Branch: main
Bron: pull request van development naar main
Status: gereed voor deployment / gedeployed
Datum: YYYY-MM-DD

## Volgende logische stap

Start nieuwe user-story branch vanaf development voor de volgende wijziging.
```

`decisions.md` krijgt waar nodig:

```text
| Datum | Keuze | Reden | Impact | Status |
|------|-------|-------|--------|--------|
| YYYY-MM-DD | Deployments vinden alleen plaats vanaf main | Main blijft stabiele releasebranch | Development wordt niet direct gedeployed | Actief |
```

### 25.6 AI-regel

Een AI-assistent moet bij deploymentvragen expliciet controleren vanaf welke branch gewerkt wordt.

De AI moet melden:

```text
Deploymentcontrole:
- Staat de releasekandidaat op development?
- Is er een pull request van development naar main gemaakt?
- Is die pull request gemerged?
- Wordt deployment uitgevoerd vanaf main?
- Is .docs/deployment.md actueel?
```

Als deployment vanaf `development` of een featurebranch wordt voorgesteld, moet de AI dit corrigeren en eerst een pull request van `development` naar `main` voorstellen.

---

## 41. Deployment

Deploymentdocumentatie moet concreet zijn. Deployment vindt altijd plaats vanaf `main`; `development` en featurebranches worden niet direct gedeployed.

Beschrijf minimaal:

- benodigde runtime;
- benodigde SDK;
- database;
- connection strings;
- environment variables;
- Docker-instructies indien van toepassing;
- poorten;
- startvolgorde;
- hoe je logs bekijkt;
- hoe je controleert of de applicatie werkt;
- hoe je een update uitvoert;
- hoe je rollback uitvoert.

Voor Docker-projecten:

```text
docker compose up -d
docker compose logs -f
docker compose down
docker compose pull
docker compose up -d --build
```

Beschrijf expliciet het verschil tussen:

- lokaal draaien vanuit Visual Studio;
- draaien via Docker;
- draaien op een server of Raspberry Pi;
- database buiten of binnen Docker.

---

## 42. Logging

Gebruik gestructureerde logging via `ILogger<T>`.

Log:

- start/stop van tools;
- ontvangen berichten;
- fouten bij externe koppelingen;
- API-calls vanuit ingest-tools;
- validatiefouten waar relevant;
- belangrijke statusovergangen.

Log geen wachtwoorden, tokens of privacygevoelige gegevens.

---

## 43. Richtlijnen voor onderwijsprojecten

Wanneer het project bedoeld is voor studenten:

- Maak de architectuur zichtbaar en uitlegbaar.
- Vermijd te veel magie.
- Gebruik handmatige mapping in plaats van AutoMapper.
- Gebruik controllers in plaats van Minimal APIs.
- Leg async/await expliciet uit.
- Laat studenten zien waarom DTO's nodig zijn.
- Laat studenten Swagger gebruiken.
- Gebruik duidelijke mappen.
- Houd voorbeelden realistisch maar niet te groot.
- Bouw de complexiteit per week op.
- Laat studenten eerst begrijpen, daarna abstraheren.

---

## 44. Richtlijnen voor BootManager-achtige projecten

Voor projecten die data ontvangen van externe apparaten, sensoren, netwerkprotocollen of simulators:

- Modelleer data zo dicht mogelijk bij de echte bron.
- Maak onderscheid tussen ruwe data, geparste data, geïnterpreteerde data en opgeslagen domeindata.
- Gebruik aparte verticale slices per datatype.
- Laat tools via de WebAPI schrijven als dat de gekozen architectuur is.
- Houd simulator, ingest, parsing, interpretation en persistence gescheiden.
- Voeg console logging toe aan tools.
- Test via Swagger en database-inspectie.
- Gebruik realistische payloads en IDs.
- Documenteer aannames over protocollen.

Voorbeeld flow:

```text
Simulator → UDP → Ingest Tool → WebAPI → Application Service → Repository → Database
```

Voor netwerkdata:

```text
Raw message
→ Parser
→ Parsed message
→ Interpreter
→ Domain entity
→ Repository
→ Database
→ API/UI
```

Belangrijk:

- Noem data niet schijnbaar of werkelijk als dat volgens het protocol niet klopt.
- Respecteer definities van standaarden zoals NMEA2000 wanneer relevant.
- Leg afwijkingen expliciet vast in documentatie.

---

## 45. Richtlijnen voor Raspberry Pi-achtige projecten

Voor projecten die op een Raspberry Pi of kleine server draaien:

- Houd deploymentdocumentatie concreet.
- Beschrijf netwerktoegang.
- Beschrijf Docker-instellingen.
- Beschrijf host network mode wanneer toegang tot fysieke netwerkinterfaces nodig is.
- Beschrijf beperkingen van containers.
- Log duidelijk wat de applicatie doet.
- Voeg health checks toe waar nuttig.
- Maak duidelijk welke processen op de host draaien en welke in Docker.

Wanneer een container toegang nodig heeft tot host-netwerkapparatuur, controleer bewust of standaard Docker bridge networking voldoende is. Soms is host networking, extra capabilities of een host-side helper nodig.

---

## 46. Fouten tijdens testen: eerst analyse en plan, daarna pas implementeren

Wanneer de gebruiker tijdens testen fouten, afwijkend gedrag of ontbrekende functionaliteit meldt, mag de AI niet direct code aanpassen.

De standaard werkwijze is:

```text
Eerst begrijpen → dan plan maken → dan akkoord vragen → daarna pas implementeren
```

### 28.1 Harde regel

Bij een testfout, bugmelding of onverwacht gedrag geldt:

```text
De AI mag niet direct patchen.
```

De AI moet eerst:

1. De fout samenvatten.
2. Controleren in welke user story of acceptatiescenario de fout valt.
3. Bepalen of het gaat om:
   - bug;
   - ontbrekende acceptatie-eis;
   - onduidelijke user story;
   - verkeerde technische implementatie;
   - regressie;
   - documentatie-inconsistentie;
   - testdata- of configuratieprobleem.
4. De waarschijnlijke oorzaak benoemen.
5. De impact op architectuur, data, UI, tests en documentatie inschatten.
6. Eén of meer herstelopties geven.
7. Een concreet wijzigingsplan voorstellen.
8. Pas na akkoord of expliciete opdracht de wijziging uitvoeren.

### 28.2 Verplichte output bij gemelde testfout

Wanneer de gebruiker een fout meldt, geeft de AI eerst dit soort reactie:

```text
Ik ga dit niet direct aanpassen. Eerst analyseer ik de fout en stel ik een herstelplan voor.

Foutmelding / observatie:
- ...

Betrokken user story:
- US-xxx - ...

Betrokken acceptatiescenario:
- Scenario ... - ...

Waarschijnlijke oorzaak:
- ...

Impact:
- Code:
- Data:
- UI:
- Architectuur:
- Documentatie:
- Tests:

Herstelopties:
1. ...
2. ...

Voorgesteld plan:
1. ...
2. ...
3. ...

Te wijzigen bestanden:
- ...

Documentatie die moet worden bijgewerkt:
- .docs/specification.md: ja/nee
- .docs/progress.md: ja/nee
- .docs/architecture.md: ja/nee
- .docs/decisions.md: ja/nee
- .docs/flow.md: ja/nee
- .docs/troubleshooting.md: ja/nee

Acceptatiecontrole na herstel:
1. ...
2. ...

Wil je dat ik dit plan zo uitvoer?
```

De AI mag pas na expliciete toestemming of opdracht zoals “voer uit”, “pas toe”, “implementeer dit plan” of vergelijkbaar de code aanpassen.

### 28.3 Wanneer wel direct kleine correcties mogen

De AI mag alleen direct aanpassen zonder apart plan wanneer het gaat om een zeer kleine, niet-inhoudelijke correctie én de gebruiker expliciet vraagt om die wijziging direct te doen.

Voorbeelden:

- typfout in documentatie;
- naam van een kopje aanpassen;
- duidelijke ontbrekende using toevoegen na compile error;
- formattering herstellen.

Ook dan moet de AI kort melden wat is aangepast.

### 28.4 Wanneer altijd eerst akkoord nodig is

Altijd eerst analyse en akkoord bij:

- wijziging in domeinmodel;
- wijziging in database of migration;
- wijziging in repositorygedrag;
- wijziging in services of businesslogica;
- wijziging in Blazor state/interactiviteit;
- wijziging in branchstructuur;
- wijziging in acceptatiecriteria;
- wijziging in user story scope;
- wijziging in architectuur;
- wijziging in deployment;
- herstel na foutieve commit of branch.

### 28.5 Bugfix-branch

Als een fout wordt opgelost nadat een user-story branch al is gemerged naar `development`, wordt de bugfix als aparte branch vanaf `development` gemaakt.

Naamgeving:

```text
bugfix/US-001-fix-consumption-validation
bugfix/fix-blazor-interactivity
bugfix/fix-product-search
```

Regels:

- Bugfixbranches starten vanaf `development`.
- Bugfixbranches gaan via pull request terug naar `development`.
- Bij releasebugs op `main` moet eerst een hotfixstrategie worden bepaald en vastgelegd in `decisions.md`.

### 28.6 Documentatie bij fouten

Elke relevante fout tijdens testen wordt vastgelegd in `.docs/progress.md`.

Voorbeeld:

```text
## Testbevindingen

| Datum | User story | Scenario | Bevinding | Status | Vervolg |
|------|------------|----------|-----------|--------|---------|
| YYYY-MM-DD | US-001 | Nieuw product aanmaken | Product wordt opgeslagen, maar dagoverzicht wordt niet bijgewerkt | Open | Herstelplan opstellen |
```

Als de fout een structurele oorzaak of bekende oplossing heeft, wordt ook `.docs/troubleshooting.md` bijgewerkt.

### 28.7 Acceptatiescenario's na herstel

Na een bugfix of correctie moet de AI altijd nieuwe of aangepaste acceptatiescenario's geven.

Minimaal:

- scenario dat de oorspronkelijke fout reproduceert;
- scenario dat aantoont dat de fout is opgelost;
- regressiescenario voor bestaande werking.

De resultaten worden vastgelegd in `.docs/progress.md`.

### 28.8 Geen scope-uitbreiding via bugfix

Een bugfix mag niet ongemerkt nieuwe functionaliteit toevoegen.

Als tijdens het oplossen blijkt dat eigenlijk extra functionaliteit nodig is, moet de AI dit melden als scopewijziging. Dan moet eerst `.docs/specification.md` worden bijgewerkt en eventueel een nieuwe user story worden gemaakt.

---

## 47. Pull requests en code review

Een pull request bevat:

- samenvatting van de wijziging;
- waarom de wijziging nodig is;
- welke bestanden/lagen geraakt zijn;
- hoe getest is;
- welke documentatie is bijgewerkt;
- eventuele migraties;
- eventuele breaking changes;
- screenshots of Swagger voorbeelden indien relevant.

Reviewvragen:

- Staat de code in de juiste laag?
- Is de controller dun?
- Is businesslogica niet per ongeluk in Web/UI beland?
- Zijn DTO's gebruikt in plaats van entities?
- Is async correct gebruikt?
- Zijn namen duidelijk?
- Is XML-documentatie toegevoegd waar gewenst?
- Is de wijziging klein genoeg?
- Zijn acceptatietesten uitgevoerd?
- Zijn `architecture.md`, `decisions.md`, `progress.md` en `specification.md` waar nodig bijgewerkt?

---

## 48. Standaard checklist voor nieuwe functionaliteit

```text
[ ] Is duidelijk welke feature of slice wordt toegevoegd?
[ ] Heeft de gebruiker een GitHub repository-URL gegeven of heeft de AI zelf een repository aangemaakt?
[ ] Heeft de AI zelf de GitHub-repository aangemaakt of gekoppeld?
[ ] Is de initiële basis gecommit op main?
[ ] Heeft de AI zelf de development branch aangemaakt vanaf main?
[ ] Is development gepusht naar GitHub?
[ ] Zijn progress.md en decisions.md bijgewerkt met de repository- en branchstructuur?
[ ] Is de applicatiebeschrijving vastgelegd in .docs/specification.md?
[ ] Is de grove scope met Must/Should/Could/Won't haves vastgelegd?
[ ] Heeft de AI beoordeeld of de omschrijving voldoende is voor eerste user stories?
[ ] Staat de user story in .docs/specification.md?
[ ] Is er geen open pull request van een vorige user story?
[ ] Is de solution aangemaakt als `.slnx` wanneer de tooling dit ondersteunt?
[ ] Is alle applicatiecode C#?
[ ] Is bevestigd dat de initiële setup geen functionele user story bevat?
[ ] Staat de Blazor-basis en UI/designbaseline op development?
[ ] Is development met technische basis en UI/designbaseline gepusht?
[ ] Is het verplichte stopmoment na de initiële setup uitgevoerd?
[ ] Heeft de gebruiker akkoord gegeven om US-001 te laten voorstellen/verfijnen?
[ ] Is US-001 inhoudelijk verfijnd en goedgekeurd vóór het maken van de featurebranch?
[ ] Staat de volledige initiële projectbasis op development?
[ ] Is development met de initiële basis gepusht naar origin/development?
[ ] Is de werkmap clean na het pushen van de initiële basis?
[ ] Is vóór deze user story een featurebranch vanaf development gemaakt?
[ ] Is de branch aangemaakt vanaf de actuele `development` branch?
[ ] Is gecontroleerd dat de actieve branch niet `development` is?
[ ] Wordt er niet rechtstreeks op `development` gewerkt?
[ ] Heeft de featurebranch een naam zoals `feature/US-xxx-korte-naam`?
[ ] Zijn acceptatiecriteria vastgelegd?
[ ] Is bepaald welke laag geraakt wordt?
[ ] Is `.Web` opgezet als server-side Blazor UI-project met standaard template-opbouw?
[ ] Is `.docs/DefaultTemplate.zip` gecontroleerd en gebruikt als designbasis wanneer beschikbaar?
[ ] Is het design vertaald naar native Blazor/Razor zonder React/npm/Babel?
[ ] Werkt het hamburgermenu/drawer-menu interactief?
[ ] Is interactive server rendering geconfigureerd in `.Web`?
[ ] Hebben interactieve pagina's/componenten de juiste render mode?
[ ] Is bij WebAPI-functionaliteit een apart `.Api`-project gebruikt?
[ ] Is architecture.md gecontroleerd of bijgewerkt?
[ ] Is decisions.md gecontroleerd of bijgewerkt?
[ ] Is progress.md bijgewerkt?
[ ] Is flow.md bijgewerkt als de datastroom wijzigt?
[ ] Is deployment.md bijgewerkt als deployment wijzigt?
[ ] Is troubleshooting.md bijgewerkt bij nieuwe bekende problemen?
[ ] Is de entity nodig?
[ ] Implementeert de entity `IEntity`?
[ ] Worden auditvelden en soft delete correct afgehandeld?
[ ] Kan standaardgedrag via de generic repository voor `IEntity` worden afgehandeld?
[ ] Zijn DTO's nodig?
[ ] Worden Core/domain-enums niet rechtstreeks gebruikt in DTO’s/UI/API?
[ ] Zijn benodigde DTO/API/UI-enums aangemaakt in Application?
[ ] Zijn enum-mappings via extension methods toegevoegd?
[ ] Zijn mappings als extension methods toegevoegd of bijgewerkt?
[ ] Is een service-interface nodig?
[ ] Is een service-implementatie nodig?
[ ] Is de service geregistreerd via de static dependency injection extension class van het betreffende project?
[ ] Is repositoryfunctionaliteit nodig?
[ ] Is repositoryregistratie toegevoegd aan de dependency injection extension class van Infrastructure?
[ ] Is EF configuratie nodig?
[ ] Is een migration nodig?
[ ] Is een controller endpoint nodig?
[ ] Is UI nodig?
[ ] Is logging nodig?
[ ] Is validatie nodig?
[ ] Zijn concrete acceptatiescenario's beschreven?
[ ] Zijn acceptatiescenario's uitvoerbaar voor de gebruiker?
[ ] Is bij testfouten eerst een analyse- en herstelplan gemaakt voordat code is aangepast?
[ ] Zijn bugfixes of testbevindingen vastgelegd in progress.md?
[ ] Zijn acceptatietesten beschreven?
[ ] Buildt de solution?
[ ] Werkt Swagger of UI?
[ ] Is dit een logisch commit/push moment?
[ ] Is bij deployment een pull request van `development` naar `main` gemaakt?
[ ] Vindt deployment plaats vanaf `main`?
[ ] Is de user story volledig getest en klaar voor een pull request naar `development`?
```

---

## 49. Standaard prompt voor een nieuw project

```text
Ik wil een nieuw .NET project opzetten volgens Clean Architecture.

Gebruik deze uitgangspunten:
- C# en de hoogste geïnstalleerde stabiele .NET-versie.
- Controleer of vraag naar de beschikbare SDK's wanneer de versie onzeker is.
- Solution met minimaal Core, Application, Infrastructure en Web.
- `.Web` is standaard een server-side Blazor UI-project met de normale Visual Studio template-opbouw.
- Als `.docs/DefaultTemplate.zip` beschikbaar is, gebruik dit als visuele en structurele basis voor de Blazor shell in plaats van het standaard Blazor uiterlijk.
- Vertaal React/JSX uit het template naar native Blazor/Razor en gebruik geen React, Babel, npm, Vite of Webpack.
- `.Web` gebruikt standaard interactive server rendering via `AddInteractiveServerComponents`, `AddInteractiveServerRenderMode` en passende render modes op interactieve pagina's/componenten.
- Voeg een apart `.Api`-project toe zodra WebAPI-functionaliteit nodig is.
- WebAPI-functionaliteit komt standaard in een apart `.Api`-project met controllers, geen Minimal APIs.
- Application bevat DTO's, interfaces, services en mapping.
- Core bevat entities, domeininterfaces, enums en domeinregels.
- Infrastructure bevat EF Core, DbContext, repositories, migrations en dependency injection.
- Gebruik `IEntity` als standaardbasis voor persistente domeinentities.
- Gebruik een generic repository voor standaardgedrag voor entities die `IEntity` implementeren.
- Gebruik repository pattern waar zinvol.
- Gebruik extension methods voor mapping en eenvoudige herbruikbare taken.
- Gebruik dependency injection.
- Registreer dependencies per project via een eigen static `DependencyInjection` extension class.
- Houd `Program.cs` dun: roep daar alleen projectbrede registratie-methods aan zoals `RegisterApplication`, `RegisterInfrastructure`, `RegisterWeb` en eventueel `RegisterApi`.
- Gebruik async/await voor database- en I/O-calls.
- Gebruik DTO's richting API/UI, geen EF entities direct teruggeven.
- Gebruik aparte Application-enums voor DTO/API/UI wanneer domain enums nodig lijken.
- Gebruik Core/domain-enums niet rechtstreeks in DTO’s, Razor components of API-contracten.
- Gebruik handmatige mapping of mapping extension methods.
- Voeg Nederlandse XML-documentatie toe aan nieuwe publieke types, interfaces en belangrijke methods.
- Respecteer duidelijke Engelse naamgeving in code.
- Maak de eerste stap klein en compileerbaar.
- Geef na iedere stap acceptatietesten.
- Bij testfouten of bugs: maak eerst een analyse- en herstelplan en pas niets aan voordat ik akkoord geef.
- Geef bij iedere user story concrete acceptatiescenario's met stappen, verwacht resultaat en teststatus.
- Geef aan wanneer een commit/push logisch is.
- Gebruik per user story een aparte branch vanaf de actuele `development` branch.
- Maak die featurebranch verplicht vóórdat je een user story analyseert of implementeert.
- Implementeer nooit rechtstreeks op `development`.
- Implementeer user stories nooit rechtstreeks op `development`.
- Geef iedere user story een branchnaam zoals `feature/US-xxx-korte-naam`.
- Start geen nieuwe user-story branch als er nog een open pull request staat.
- Maak na succesvolle implementatie en tests een pull request naar `development`.
- Voor deployment: maak eerst een pull request van `development` naar `main`.
- Deploy altijd vanaf `main`.

Maak ook direct deze documentatiestructuur:
- .docs/architecture.md
- .docs/decisions.md
- .docs/progress.md
- .docs/specification.md
- .docs/flow.md
- .docs/deployment.md
- .docs/troubleshooting.md

Zorg dat de applicatiebeschrijving, doelgroep, doel, grove scope en Must/Should/Could/Won't haves in specification.md komen.
Zorg dat user stories pas worden uitgewerkt nadat de applicatiebeschrijving voldoende helder is.
Zorg dat user stories in specification.md komen.
Zorg dat architectuurkeuzes in architecture.md en decisions.md komen.
Zorg dat voortgang en laatste werkende situatie in progress.md komen.

Maak eerst een voorstel voor de solution-structuur en documentatiestructuur. Nadat de initiële basis is aangemaakt en buildt, maak zelf een GitHub-repository aan of koppel een bestaande repository wanneer je daarvoor toegang hebt. Commit de initiële basis op main, maak daarna zelf een development branch, zorg dat de volledige initiële projectbasis op development staat en push origin/development voordat een user-story branch wordt gemaakt. Werk progress.md en decisions.md bij met deze repository- en branchstructuur. Voer daarna een documentatieconsistentiecontrole uit tussen architecture.md, progress.md, decisions.md en specification.md. Vraag daarna aan de gebruiker om de applicatie helder en uitgebreid te beschrijven voordat je user stories of code uitwerkt. Pas nog niets toe voordat ik akkoord geef.
```

---


## 50. IEntity als vaste basis voor entities

Alle persistente domeinentities gebruiken standaard een gedeelde `IEntity`-interface. Deze interface zorgt voor een herkenbare basis voor opslag, auditing en generiek repositorygedrag.

De interface staat bij voorkeur in:

```text
ProjectName.Core/
└── Interfaces/
    └── IEntity.cs
```

Voorbeeld:

```csharp
namespace ProjectName.Core.Interfaces;

/// <summary>
/// Beschrijft de standaard eigenschappen die iedere persistente domeinentity heeft.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// De unieke sleutel van de entity.
    /// </summary>
    int Id { get; set; }

    /// <summary>
    /// Het moment waarop de entity is aangemaakt, uitgedrukt in UTC.
    /// </summary>
    DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Het moment waarop de entity voor het laatst is aangepast, uitgedrukt in UTC.
    /// </summary>
    DateTime? UpdatedAtUtc { get; set; }

    /// <summary>
    /// Het moment waarop de entity logisch is verwijderd, uitgedrukt in UTC.
    /// </summary>
    DateTime? DeletedAtUtc { get; set; }
}
```

Regels:

- Iedere persistente domeinentity implementeert `IEntity`, tenzij expliciet wordt vastgelegd waarom dat niet logisch is.
- `CreatedAtUtc` wordt gevuld bij het aanmaken.
- `UpdatedAtUtc` wordt gevuld bij wijzigingen.
- `DeletedAtUtc` wordt gebruikt voor soft delete.
- Een entity met een gevulde `DeletedAtUtc` wordt standaard als verwijderd beschouwd.
- Gebruik UTC-datums voor auditvelden, geen lokale tijd.
- Infrastructure mag deze velden automatisch vullen via repositorylogica of via `SaveChanges`/`SaveChangesAsync` in de `DbContext`.
- Als een project bewust geen soft delete gebruikt, wordt dat vastgelegd in `.docs/decisions.md`.

Voorbeeld entity:

```csharp
namespace ProjectName.Core.Entities;

/// <summary>
/// Vertegenwoordigt een student in het systeem.
/// </summary>
public class Student : IEntity
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <inheritdoc />
    public DateTime CreatedAtUtc { get; set; }

    /// <inheritdoc />
    public DateTime? UpdatedAtUtc { get; set; }

    /// <inheritdoc />
    public DateTime? DeletedAtUtc { get; set; }

    /// <summary>
    /// De voornaam van de student.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// De achternaam van de student.
    /// </summary>
    public string LastName { get; set; } = string.Empty;
}
```

---

## 51. Generic repository voor IEntity

Gebruik een generic repository voor standaard opslaggedrag van entities die `IEntity` implementeren. Dit voorkomt dubbele CRUD-code en zorgt dat auditvelden en soft delete consequent worden verwerkt.

De repository-interface staat bij voorkeur in:

```text
ProjectName.Core/
└── Interfaces/
    └── IRepository.cs
```

Basisinterface:

```csharp
namespace ProjectName.Core.Interfaces;

/// <summary>
/// Beschrijft generieke opslagfunctionaliteit voor persistente domeinentities.
/// </summary>
/// <typeparam name="T">Het type entity dat wordt opgeslagen.</typeparam>
public interface IRepository<T> where T : class, IEntity
{
    /// <summary>
    /// Haalt alle niet-verwijderde entities van dit type op.
    /// </summary>
    Task<IReadOnlyList<T>> ListAsync();

    /// <summary>
    /// Haalt een niet-verwijderde entity op basis van de unieke sleutel op.
    /// </summary>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Voegt een nieuwe entity toe.
    /// </summary>
    Task AddAsync(T entity);

    /// <summary>
    /// Werkt een bestaande entity bij.
    /// </summary>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Verwijdert een bestaande entity logisch door `DeletedAtUtc` te vullen.
    /// </summary>
    Task DeleteAsync(T entity);
}
```

Standaardgedrag:

- `ListAsync` geeft standaard alleen records terug waarbij `DeletedAtUtc == null`.
- `GetByIdAsync` geeft standaard geen logisch verwijderde records terug.
- `AddAsync` vult `CreatedAtUtc`.
- `UpdateAsync` vult `UpdatedAtUtc`.
- `DeleteAsync` verwijdert standaard logisch door `DeletedAtUtc` te vullen.
- Fysiek verwijderen wordt alleen gebruikt wanneer dat bewust nodig is en vastgelegd is in `decisions.md`.

Voorbeeld implementatiegedachte in Infrastructure:

```csharp
namespace ProjectName.Infrastructure.Repositories;

/// <summary>
/// EF Core implementatie van de generieke repository.
/// </summary>
/// <typeparam name="T">Het type entity dat wordt opgeslagen.</typeparam>
public class EfRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly AppDbContext _dbContext;

    public EfRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<T>> ListAsync()
    {
        return await _dbContext.Set<T>()
            .Where(x => x.DeletedAtUtc == null)
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id && x.DeletedAtUtc == null);
    }

    public async Task AddAsync(T entity)
    {
        entity.CreatedAtUtc = DateTime.UtcNow;

        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        entity.UpdatedAtUtc = DateTime.UtcNow;

        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        entity.DeletedAtUtc = DateTime.UtcNow;

        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
```

Bij complexere queries kan naast de generic repository een specifieke repository of queryservice worden toegevoegd. Gebruik de generic repository niet geforceerd voor alles wanneer een specifieke query duidelijker, efficiënter of veiliger is.

---


## 52. Enums in Clean Architecture

Enums met domeinbetekenis horen in de juiste laag. Een domain enum uit `Core` mag niet rechtstreeks uitlekken naar DTO’s, API-contracten, Razor components of UI-code.

Standaardregel:

```text
Core/domain enum ≠ DTO/API/UI enum
```

Niet toegestaan:

```text
ProjectName.Core.Enums.OrderStatus gebruiken in een DTO
ProjectName.Core.Enums.ConsumptionMoment gebruiken in een Razor component
ProjectName.Core.Enums.StudentStatus direct teruggeven via een API response
```

Wel toegestaan:

```text
Core enum gebruiken binnen Core en domeinlogica
Application enum gebruiken in DTO’s, services, API-contracten en UI
Expliciet mappen tussen Application enum en Core enum via extension methods
```

### 18.1 Domain enums in Core

Domain enums staan in `Core` wanneer ze onderdeel zijn van het domeinmodel of domeinregels.

Voorbeeld:

```text
ProjectName.Core/
└── Enums/
    └── ConsumptionMoment.cs
```

Voorbeeld:

```csharp
namespace ProjectName.Core.Enums;

/// <summary>
/// Beschrijft het domeinmoment waarop een consumptie plaatsvindt.
/// </summary>
public enum ConsumptionMoment
{
    Breakfast = 1,
    Lunch = 2,
    Dinner = 3,
    Snack = 4
}
```

Deze enum mag worden gebruikt door:

- domeinentities;
- domeinservices;
- domeinregels;
- repository-implementaties wanneer zij entities opslaan of laden;
- Application services intern, mits zij de waarde daarna mappen naar een DTO/API enum voordat de waarde naar buiten gaat.

Deze enum mag niet rechtstreeks worden gebruikt door:

- DTO’s;
- Razor components;
- API responses;
- API requestmodellen;
- Blazor forms;
- UI-keuzelijsten;
- externe contracten.

### 18.2 DTO/API/UI enums in Application

Wanneer een DTO, API-contract of UI een enum nodig heeft, wordt een aparte enum gemaakt in de Application-laag.

Voorkeurslocatie:

```text
ProjectName.Application/
└── Enums/
    └── ConsumptionMomentDto.cs
```

Voorbeeld:

```csharp
namespace ProjectName.Application.Enums;

/// <summary>
/// Beschrijft het consumptiemoment zoals gebruikt in DTO's en UI/API-contracten.
/// </summary>
public enum ConsumptionMomentDto
{
    Breakfast = 1,
    Lunch = 2,
    Dinner = 3,
    Snack = 4
}
```

Regels:

- DTO’s gebruiken Application-enums.
- Razor components gebruiken Application-enums of DTO’s met Application-enums.
- API requests en responses gebruiken Application-enums.
- De UI mag geen enum uit `Core` importeren.
- De API mag geen enum uit `Core` als contract naar buiten geven.
- Naamgeving mag eindigen op `Dto`, `Contract`, `Option` of een duidelijke projectspecifieke naam.
- Kies één naamstijl per project en leg die vast in `decisions.md` als dit afwijkt van de standaard.

### 18.3 Mapping via extension methods

Mapping tussen Core-enums en Application-enums gebeurt expliciet via extension methods.

Voorkeurslocatie:

```text
ProjectName.Application/
└── Mapping/
    └── ConsumptionMomentMappingExtensions.cs
```

Voorbeeld:

```csharp
namespace ProjectName.Application.Mapping;

/// <summary>
/// Bevat mappingfuncties voor consumptiemomenten.
/// </summary>
public static class ConsumptionMomentMappingExtensions
{
    /// <summary>
    /// Zet een DTO-consumptiemoment om naar een domeinconsumptiemoment.
    /// </summary>
    /// <param name="value">Het DTO-consumptiemoment.</param>
    /// <returns>Het overeenkomstige domeinconsumptiemoment.</returns>
    public static ConsumptionMoment ToDomain(this ConsumptionMomentDto value)
    {
        return value switch
        {
            ConsumptionMomentDto.Breakfast => ConsumptionMoment.Breakfast,
            ConsumptionMomentDto.Lunch => ConsumptionMoment.Lunch,
            ConsumptionMomentDto.Dinner => ConsumptionMoment.Dinner,
            ConsumptionMomentDto.Snack => ConsumptionMoment.Snack,
            _ => throw new ArgumentOutOfRangeException(
                nameof(value),
                value,
                "Onbekend consumptiemoment.")
        };
    }

    /// <summary>
    /// Zet een domeinconsumptiemoment om naar een DTO-consumptiemoment.
    /// </summary>
    /// <param name="value">Het domeinconsumptiemoment.</param>
    /// <returns>Het overeenkomstige DTO-consumptiemoment.</returns>
    public static ConsumptionMomentDto ToDto(this ConsumptionMoment value)
    {
        return value switch
        {
            ConsumptionMoment.Breakfast => ConsumptionMomentDto.Breakfast,
            ConsumptionMoment.Lunch => ConsumptionMomentDto.Lunch,
            ConsumptionMoment.Dinner => ConsumptionMomentDto.Dinner,
            ConsumptionMoment.Snack => ConsumptionMomentDto.Snack,
            _ => throw new ArgumentOutOfRangeException(
                nameof(value),
                value,
                "Onbekend consumptiemoment.")
        };
    }
}
```

Regels:

- Mapping is expliciet.
- Geen impliciete casts.
- Geen magic strings.
- Geen directe hergebruik van Core-enums in DTO’s om mapping “makkelijker” te maken.
- Voeg Nederlandse XML-documentatie toe aan publieke mapping extension methods.
- Als enumwaarden bewust anders zijn tussen Core en Application, leg dit vast in `decisions.md`.

### 18.4 Shared project alleen bij uitzondering

Een gedeelde locatie of `Shared` project voor enums is niet de standaard.

Een shared enum mag alleen worden gebruikt als de enum aantoonbaar domeinneutraal en technisch algemeen is.

Voorbeelden van mogelijke gedeelde technische enums:

```text
SortDirection
ThemeMode
PageSizeOption
ExportFormat
```

Voorbeelden die meestal niet in Shared horen:

```text
OrderStatus
ConsumptionMoment
StudentStatus
ProductType
InvoiceState
ReservationStatus
```

Regels voor shared enums:

- Gebruik `Shared` niet als sluiproute om domain types overal beschikbaar te maken.
- Gebruik `Shared` alleen na expliciete keuze.
- Leg de keuze vast in `.docs/decisions.md`.
- Beschrijf in `.docs/architecture.md` waarom de enum gedeeld mag zijn.
- Als er twijfel is, kies voor gescheiden Core-enum en Application-enum met mapping.

### 18.5 Controle bij code review

Bij iedere user story controleert de AI:

```text
[ ] Worden Core/domain-enums niet gebruikt in DTO’s?
[ ] Worden Core/domain-enums niet gebruikt in Razor components?
[ ] Worden Core/domain-enums niet direct teruggegeven via API responses?
[ ] Bestaan er aparte Application-enums waar DTO/UI/API die nodig hebben?
[ ] Is mapping tussen Core-enums en Application-enums expliciet via extension methods?
[ ] Is een eventuele Shared-enum keuze vastgelegd in decisions.md?
```

### 18.6 Herstel bij fout gebruik

Als een Core-enum al in DTO’s of UI is gebruikt, moet de AI niet stilzwijgend doorgaan.

De AI moet dan:

1. Benoemen waar de Core-enum uitlekt.
2. Een Application-enum voorstellen.
3. Mapping extension methods voorstellen.
4. DTO’s/UI/API aanpassen naar de Application-enum.
5. Tests en acceptatiescenario’s bijwerken.
6. `architecture.md`, `decisions.md` en `progress.md` bijwerken indien de architectuurkeuze nog niet vastligt.

---

## 53. Extension methods voor mapping en eenvoudige herbruikbare logica

Gebruik extension methods voor eenvoudige, herbruikbare bewerkingen op entities, DTO's en eenvoudige types. Dit is vooral geschikt voor mapping en kleine transformaties die geen externe afhankelijkheden nodig hebben.

Geschikte toepassingen:

- mapping van entity naar DTO;
- mapping van DTO naar entity wanneer dit eenvoudig blijft;
- kleine formatting- of conversiefuncties;
- eenvoudige domeinneutrale helpers;
- herbruikbare projecties voor lijstweergaven.

Niet geschikt voor extension methods:

- databasecalls;
- logica met externe services;
- complexe businessregels;
- logica waarvoor dependency injection nodig is;
- logica die eigenlijk in een Application service hoort;
- code die veel verborgen side effects heeft.

Plaats mapping extensions bij voorkeur in de Application-laag:

```text
ProjectName.Application/
└── Mapping/
    ├── StudentMappingExtensions.cs
    └── MeasurementMappingExtensions.cs
```

Voorbeeld entity naar DTO:

```csharp
namespace ProjectName.Application.Mapping;

/// <summary>
/// Bevat mappingfuncties voor studenten.
/// </summary>
public static class StudentMappingExtensions
{
    /// <summary>
    /// Zet een studententity om naar een lijstweergave-DTO.
    /// </summary>
    /// <param name="entity">De studententity die wordt omgezet.</param>
    /// <returns>Een DTO voor lijstweergave.</returns>
    public static StudentListItemDto ToListItemDto(this Student entity)
    {
        return new StudentListItemDto
        {
            Id = entity.Id,
            FullName = $"{entity.FirstName} {entity.LastName}",
            CreatedAtUtc = entity.CreatedAtUtc
        };
    }

    /// <summary>
    /// Zet een studententity om naar een detail-DTO.
    /// </summary>
    /// <param name="entity">De studententity die wordt omgezet.</param>
    /// <returns>Een DTO voor detailweergave.</returns>
    public static StudentDetailDto ToDetailDto(this Student entity)
    {
        return new StudentDetailDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            CreatedAtUtc = entity.CreatedAtUtc,
            UpdatedAtUtc = entity.UpdatedAtUtc
        };
    }
}
```

Voorbeeld gebruik in een service:

```csharp
public async Task<IReadOnlyList<StudentListItemDto>> GetAllAsync()
{
    var students = await _studentRepository.ListAsync();

    return students
        .Select(x => x.ToListItemDto())
        .ToList();
}
```

Richtlijnen:

- Geef extension methods duidelijke namen zoals `ToDetailDto`, `ToListItemDto`, `ToEntity`, `ApplyUpdate` of `IsDeleted`.
- Houd extension methods klein en voorspelbaar.
- Voeg Nederlandse XML-documentatie toe aan publieke extension methods.
- Gebruik extension methods niet om afhankelijkheden te verbergen.
- Houd mapping expliciet en leesbaar.
- Gebruik AutoMapper niet als standaardkeuze wanneer handmatige mapping via extension methods voldoende duidelijk is.

Voorbeeld eenvoudige entity-helper:

```csharp
namespace ProjectName.Core.Extensions;

/// <summary>
/// Bevat herbruikbare hulpfuncties voor entities.
/// </summary>
public static class EntityExtensions
{
    /// <summary>
    /// Geeft aan of een entity logisch verwijderd is.
    /// </summary>
    /// <param name="entity">De entity die wordt gecontroleerd.</param>
    /// <returns>True wanneer de entity logisch verwijderd is.</returns>
    public static bool IsDeleted(this IEntity entity)
    {
        return entity.DeletedAtUtc.HasValue;
    }
}
```

Let op: plaats extension methods die alleen met DTO's of application mapping te maken hebben in `Application`. Plaats alleen generieke domeinhelpers in `Core`.

---

## 54. Wat een AI-assistent niet automatisch moet doen

Een AI-assistent mag niet automatisch:

- Grote refactors uitvoeren zonder opdracht.
- Projectstructuur wijzigen zonder reden.
- Minimal APIs introduceren als controllers de standaard zijn.
- AutoMapper toevoegen zonder expliciete keuze.
- Direct entities teruggeven vanuit controllers.
- Core/domain-enums rechtstreeks gebruiken in DTO’s, Razor components, API requests of API responses.
- DbContext injecteren in controllers als services bedoeld zijn.
- Secrets in code zetten.
- Nieuwe packages toevoegen zonder motivatie.
- Naamgeving veranderen zonder noodzaak.
- Businesslogica in UI-componenten stoppen.
- Database rechtstreeks laten benaderen vanuit tools als de architectuur API-first is.
- Oude code verwijderen zonder impactanalyse.
- Testfouten direct patchen zonder eerst analyse, impact en herstelplan voor te leggen.
- JSX uit `.docs/DefaultTemplate.zip` letterlijk overnemen of React/npm tooling toevoegen aan de Blazor-app.
- Een interactieve Blazor shell opleveren zonder te controleren dat `Routes`, `HeadOutlet`, layout en componenten interactief renderen.
- Een user story implementeren terwijl de actieve branch `development` is.
- De eerste user story starten zonder eerst een featurebranch vanaf `development` te maken.
- De initiële projectbasis uitvoeren op de branch van de eerste user story.
- US-001 starten voordat de initiële projectbasis op `development` staat en gepusht is.
- Functionele user stories implementeren tijdens de initiële setup.
- Code schrijven voor US-001 vóór het verplichte stopmoment na de initiële setup.
- Een featurebranch voor US-001 maken vóórdat de technische basis en UI/designbaseline op development zijn gepusht.
- Een featurebranch voor US-001 maken vóór akkoord op de verfijnde user story en het plan.
- Een featurebranch maken voordat US-001 inhoudelijk is verfijnd en akkoord is gegeven.
- Een `.sln` maken wanneer `.slnx` beschikbaar en passend is.
- Andere programmeertalen of runtimes toevoegen terwijl C# volstaat.
- De initiële Blazor .Web-basis afronden met een neutrale of standaard shell terwijl .docs/DefaultTemplate.zip aanwezig is.
- DefaultTemplate.zip behandelen als latere designreferentie wanneer het bij de initiële setup aanwezig is.
- Doorgaan met user stories terwijl nog geen GitHub remote URL is gekoppeld en gepusht.
- Standaarden of protocolbetekenissen verzinnen.
- Documentatie overslaan wanneer architectuur, keuzes, user stories of voortgang veranderen.

---

## 55. Samenvatting van de vaste ontwikkelstijl

```text
Hoogste geïnstalleerde stabiele .NET-versie
C#
Clean Architecture
Server-side Blazor als standaard `.Web`-project
Interactive server rendering standaard geconfigureerd in Blazor
DefaultTemplate.zip als standaard designbasis voor Blazor shell
React/JSX alleen als visuele referentie, vertalen naar native Blazor/Razor
Guidelines en DefaultTemplate.zip staan altijd in .docs
Tool-onafhankelijke startprompt bovenaan guidelines
AGENTS.md als tool-onafhankelijke AI-ingang
CLAUDE.md als Claude Code-ingang
Solution standaard als .slnx wanneer ondersteund
Applicatiecode standaard in C#
Initiële setup bevat geen functionele user stories
Harde fasepoort: main → development basis/UI → stop → US-001
Na initiële setup stoppen en wachten op akkoord vóór US-001
US-001 eerst verfijnen, dan pas featurebranch en implementatie
Initiële projectbasis eerst op development en pushen vóór US-001
AI-agent maakt vóór iedere user story verplicht een featurebranch vanaf development
Initiële Blazor shell moet direct uit DefaultTemplate.zip komen
Geen neutrale Blazor shell wanneer DefaultTemplate.zip aanwezig is
GitHub repository-URL of automatische repo-aanmaak verplicht vóór user stories
Apart `.Api`-project voor WebAPI-functionaliteit
Controllers voor WebAPI in `.Api`
Application services
DTO's
Geen Core/domain-enums rechtstreeks in DTO’s/UI/API
Aparte Application-enums voor DTO/API/UI-contracten
Expliciete enum mapping via extension methods
Handmatige mapping
IEntity als standaardbasis voor entities
Generic repository voor standaardgedrag van IEntity
Repository pattern waar zinvol
Extension methods voor mapping en eenvoudige herbruikbare taken
EF Core in Infrastructure
Dependency injection
Static dependency injection extension class per project
Dunne Program.cs met projectbrede registratie-methods
Async/await
Dunne controllers
Geen businesslogica in UI
Kleine verticale slices
Nederlandse XML-documentatie
Acceptatietesten per stap
Commit/push na werkende kleine wijzigingen
Eén user story per featurebranch
Nooit user stories rechtstreeks op development implementeren
Concrete acceptatiescenario's per user story
Bij testfouten eerst analyse en herstelplan, daarna pas implementeren
AI maakt GitHub-repository zelf aan na initiële basis waar mogelijk
AI maakt development branch zelf aan na initiële basis
Harde stop: geen user story zonder GitHub, main en development
Nieuwe branch altijd vanaf actuele development
Geen nieuwe user-story branch zolang er een open pull request staat
Pull request naar development na volledig geteste user story
Pull request van development naar main voor release/deployment
Deployment altijd vanaf main
Actief bijgehouden architecture.md
Actief bijgehouden decisions.md
Actief bijgehouden progress.md
Applicatiebeschrijving en grove scope in specification.md
MoSCoW-indeling voordat user stories worden gebouwd
User stories in specification.md
Documentatie in Markdown
Documentatieconsistentiecontrole vóór nieuwe user stories of codewijzigingen
Inconsistenties eerst herstellen, daarna pas bouwen
```

Dit document is bedoeld als vaste basis. Projectspecifieke keuzes mogen hiervan afwijken, maar alleen bewust en gedocumenteerd.


## Appendix: Geconstateerde inhoud DefaultTemplate.zip

Bij het opstellen van deze richtlijn is de volgende inhoud in het aangeleverde templatebestand aangetroffen:

- `Graafschap Blazor Template.html`
- `design-canvas.jsx`
- `styles.css`
- `template.jsx`
- `tweaks-panel.jsx`

Deze lijst is informatief. De richtlijn blijft gelden voor toekomstige versies van `.docs/DefaultTemplate.zip`, ook als de exacte inhoud wijzigt.

---
