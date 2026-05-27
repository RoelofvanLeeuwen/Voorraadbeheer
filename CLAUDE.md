# CLAUDE.md

Dit project gebruikt Claude Code als AI-codeagent.

Lees eerst:

```text
AGENTS.md
.docs/development-guidelines.md
.docs/architecture.md
.docs/decisions.md
.docs/progress.md
.docs/specification.md
.docs/DefaultTemplate.zip, wanneer aanwezig
```

`AGENTS.md` bevat de compacte tool-onafhankelijke instructie.  
`.docs/development-guidelines.md` bevat de volledige richtlijnen.

## Sessiestart

Typ `/init` aan het begin van iedere sessie. Dit commando leest automatisch alle vereiste documenten, controleert de huidige fase en branch, en rapporteert de volgende toegestane stap.

## Belangrijkste regels

- Volg altijd de fasepoorten uit `.docs/development-guidelines.md`.
- Implementeer geen functionele user stories tijdens de initiële setup.
- Zet eerst de technische basis en Blazor UI/designbaseline op `development`.
- Push `development` naar GitHub.
- Stop daarna en vraag of US-001 voorgesteld en verfijnd mag worden.
- Maak geen featurebranch vóór akkoord op US-001 en het implementatieplan.
- Schrijf nooit user-story code rechtstreeks op `development`.
- Gebruik `.docs/DefaultTemplate.zip` direct als designbaseline voor Blazor `.Web` wanneer aanwezig.
- Gebruik C#.
- Gebruik `.slnx` wanneer de tooling dit ondersteunt.
- Gebruik Clean Architecture.
- Gebruik geen Core/domain-enums rechtstreeks in DTO's, Razor components of API-contracten.
- Bij testfouten: eerst analyse en herstelplan, daarna pas aanpassen na akkoord.

## Claude-specifieke werkwijze

Typ `/init` aan het begin van iedere sessie.

Als je `/init` niet gebruikt, voer dan handmatig uit:

1. Lees `AGENTS.md`.
2. Lees `.docs/development-guidelines.md`.
3. Controleer `.docs/progress.md`.
4. Controleer `.docs/architecture.md`.
5. Controleer `.docs/decisions.md`.
6. Controleer `.docs/specification.md`.
7. Rapporteer de huidige fase.
8. Rapporteer de huidige Git-branch.
9. Rapporteer of de volgende stap is toegestaan.

Als je merkt dat de huidige fase niet klopt, stop dan en stel eerst een herstelplan voor.
