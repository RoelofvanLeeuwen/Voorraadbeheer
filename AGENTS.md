# AGENTS.md

Deze repository gebruikt AI-codeagents zoals GitHub Copilot, Codex CLI, Claude, ChatGPT, Cursor, Windsurf of vergelijkbare tools.

Dit bestand is de compacte, tool-onafhankelijke ingang voor AI-agents. De volledige richtlijnen staan in:

```text
.docs/development-guidelines.md
```

## Sessiestart (verplicht voor alle AI-tools)

Voer aan het begin van iedere sessie — vóór elke analyse, suggestie of wijziging — de volgende stappen uit:

1. Lees `.docs/development-guidelines.md` volledig.
2. Lees `.docs/progress.md` — bepaal de huidige fase.
3. Lees `.docs/specification.md` — begrijp de scope.
4. Lees `.docs/architecture.md` — begrijp de structuur.
5. Lees `.docs/decisions.md` — begrijp de gemaakte keuzes.
6. Controleer de huidige Git-branch en working tree.
7. Controleer of `specification.md` een daadwerkelijke applicatiebeschrijving bevat: doel, doelgroep en belangrijkste processen. Als dit ontbreekt of leeg is: stop en vraag de gebruiker om de applicatie te beschrijven. Maak geen technische bestanden, geen solution, geen branches en geen GitHub-koppeling totdat de scope is vastgelegd.
8. Rapporteer: huidige fase, huidige branch, scope vastgelegd (ja/nee), volgende toegestane stap en eventuele blokkades.
9. Stop als documenten inconsistent zijn — stel eerst een herstelplan voor en wacht op akkoord.

**Claude Code-gebruikers:** typ `/init` voor een geautomatiseerde sessiestart.

## Lees eerst

Voordat je iets analyseert, wijzigt, genereert of commit, lees of controleer je minimaal:

```text
.docs/development-guidelines.md
.docs/architecture.md
.docs/decisions.md
.docs/progress.md
.docs/specification.md
.docs/DefaultTemplate.zip, wanneer aanwezig
.docs/flow.md, wanneer aanwezig
.docs/deployment.md, wanneer relevant
.docs/troubleshooting.md, wanneer aanwezig
README.md, wanneer aanwezig
```

## Harde fasepoort

Volg deze volgorde zonder stappen over te slaan:

```text
0. STOP: vraag de gebruiker om de applicatiescope te beschrijven
   (doel, doelgroep, belangrijkste processen)
   Maak geen bestanden, geen solution, geen branches en geen GitHub-koppeling
   totdat de gebruiker de scope heeft gegeven en specification.md is gevuld.
1. Documentatie en repositorybasis (met gevulde specification.md)
2. main pushen
3. development aanmaken
4. Technische Clean Architecture-basis op development
5. Blazor .Web UI/designbaseline op development
6. Push naar origin/development
7. STOP: vraag of een user story voorgesteld en verfijnd mag worden
8. User story opstellen op basis van specification.md
9. STOP: leg de volledige user story voor aan de gebruiker voor inhoudelijk akkoord
   - Gebruiker kan inhoud aanpassen, toevoegen of verwijderen
   - Verwerk alle wijzigingen direct in specification.md
   - Blijf in deze stap totdat de gebruiker expliciet inhoudelijk akkoord geeft
10. Stel eventuele technische vragen die nodig zijn voor het implementatieplan
11. Implementatieplan opstellen en voorleggen aan de gebruiker
12. STOP: wacht op akkoord implementatieplan
13. Na akkoord featurebranch maken
14. User story implementeren
```

Na de initiële setup mag je niet automatisch een user story bouwen.

## User story workflow

Volg bij elke user story deze volgorde zonder stappen over te slaan:

1. **Opstellen** — stel de user story op basis van `specification.md`. Gebruik de vastgelegde scope; verzin niets.
2. **Voorleggen** — presenteer de volledige user story aan de gebruiker: beschrijving, acceptatiecriteria en eventuele opmerkingen.
3. **Verfijnen** — de gebruiker kan inhoud aanpassen, toevoegen of verwijderen. Verwerk alle wijzigingen direct in `specification.md`. Herhaal dit totdat de gebruiker expliciet inhoudelijk akkoord geeft.
4. **Technische vragen** — stel pas daarna eventuele technische vragen die nodig zijn voor het implementatieplan.
5. **Implementatieplan** — stel het plan op en leg het voor aan de gebruiker.
6. **Akkoord implementatieplan** — wacht op expliciete goedkeuring voordat je een featurebranch aanmaakt.
7. **Featurebranch** — maak de branch aan en start de implementatie.

Alle wijzigingen aan een user story worden altijd opgeslagen in `specification.md`.

## Verboden tijdens initiële setup

Tijdens de initiële setup mag je niet bouwen:

```text
- functionele user stories
- feature-specifieke domeinentities
- echte applicatieflows
- businesslogica voor echte use cases
- feature-specifieke UI-pagina's
- US-001 implementatie
```

De initiële setup bevat alleen:

```text
- documentatie
- Clean Architecture-baseline
- technische basis
- Blazor .Web shell
- DefaultTemplate UI/designbaseline
- GitHub remote
- main en development
```

## Branchregels

- Werk nooit rechtstreeks aan een user story op `development`.
- Maak pas een featurebranch nadat de user story en het plan zijn goedgekeurd.
- Featurebranches starten altijd vanaf `development`.
- Gebruik branchnamen zoals:

```text
feature/US-001-korte-omschrijving
bugfix/US-001-korte-omschrijving
```

- Pull requests voor user stories gaan naar `development`.
- Releases/deployments gaan via pull request van `development` naar `main`.
- Deployment gebeurt alleen vanaf `main`.

## Designregels

Als `.docs/DefaultTemplate.zip` aanwezig is:

- Gebruik dit direct als verplichte designbaseline voor de initiële Blazor `.Web` shell.
- Eindig niet met een neutrale of standaard Blazor-shell.
- Vertaal React/JSX naar native Blazor/Razor.
- Gebruik geen React, Babel, npm, Vite of Webpack.
- Gebruik gewone CSS binnen het Blazor-project.
- Zorg dat de shell interactief rendert.
- Controleer dat hamburgermenu/drawer werkt.

## Clean Architecture

- Gebruik C#.
- Gebruik `.slnx` wanneer de tooling dit ondersteunt.
- Gebruik Core, Application, Infrastructure, Web en testprojecten.
- `.Web` is server-side Blazor.
- WebAPI-functionaliteit komt in een apart `.Api`-project.
- Core/domain types lekken niet naar UI/API.
- Core/domain-enums worden niet rechtstreeks gebruikt in DTO's, Razor components of API-contracten.
- DTO/API/UI-enums staan in Application en worden expliciet gemapt via extension methods.
- DI-registraties staan per project in een static `DependencyInjection` extension class.
- `Program.cs` blijft dun.

## Testen en fouten

- Lever bij iedere user story concrete acceptatiescenario's op.
- Bij testfouten of bugs: maak eerst een analyse- en herstelplan.
- Pas code pas aan na expliciet akkoord.
- Leg testbevindingen vast in `.docs/progress.md`.
- Leg structurele oplossingen vast in `.docs/troubleshooting.md`.

## Documentatie

Werk documentatie bij bij iedere betekenisvolle wijziging:

```text
.docs/architecture.md
.docs/decisions.md
.docs/progress.md
.docs/specification.md
.docs/flow.md, wanneer relevant
.docs/deployment.md, wanneer relevant
.docs/troubleshooting.md, wanneer relevant
```

Als documenten elkaar tegenspreken, stop dan met bouwen en herstel eerst de documentatieconsistentie.
