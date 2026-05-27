Voer de verplichte sessiestart uit. Doorloop alle stappen volledig voordat je iets analyseert of wijzigt.

## Stap 1 — Documentatie lezen

Lees de volgende bestanden volledig in deze volgorde:

1. `AGENTS.md`
2. `.docs/development-guidelines.md`
3. `.docs/progress.md`
4. `.docs/specification.md` (wanneer aanwezig)
5. `.docs/architecture.md` (wanneer aanwezig)
6. `.docs/decisions.md` (wanneer aanwezig)
7. `.docs/flow.md` (wanneer aanwezig)
8. `.docs/troubleshooting.md` (wanneer aanwezig)

## Stap 2 — Git-status controleren

Bepaal:

- Huidige branch
- Of de working tree clean is
- Welke branches bestaan (main, development, feature-branches)
- Of er openstaande wijzigingen zijn
- Of er een openstaande pull request is die eerst afgerond moet worden

## Stap 3 — Fase bepalen

Bepaal op basis van `progress.md` en de fasepoorten in `development-guidelines.md` in welke fase het project zich bevindt.

## Stap 4 — Scopecheck

Controleer of `specification.md` een daadwerkelijke applicatiebeschrijving bevat: doel, doelgroep en belangrijkste processen.

Als `specification.md` ontbreekt of leeg/onvolledig is: stop hier. Vraag de gebruiker om de applicatie te beschrijven voordat je verdergaat. Maak geen technische bestanden, geen solution, geen branches en geen GitHub-koppeling totdat de scope is vastgelegd.

## Stap 5 — Consistentiecheck

Controleer of `progress.md`, `specification.md`, `architecture.md` en `decisions.md` consistent zijn met elkaar. Noteer tegenstrijdigheden.

## Stap 6 — Rapportage

Rapporteer:

| Onderdeel | Status |
|-----------|--------|
| Huidige fase | |
| Huidige branch | |
| Working tree | |
| Scope vastgelegd | |
| Documentatieconsistentie | |
| Volgende toegestane stap | |
| Blokkades | |

## Stap 7 — Stoppen bij blokkades

Als er documentatie-inconsistenties zijn of de huidige fase niet klopt: stop hier. Stel een herstelplan voor en wacht op akkoord. Pas geen code aan.

## Stap 8 — Herinnering user story workflow

Als de volgende stap een user story betreft, geldt altijd deze volgorde:

1. User story opstellen op basis van `specification.md`
2. Volledige user story voorleggen aan de gebruiker voor inhoudelijk akkoord
3. Wijzigingen van de gebruiker verwerken in `specification.md` — herhalen totdat de gebruiker akkoord geeft
4. Pas daarna technische vragen stellen
5. Implementatieplan opstellen en voorleggen
6. Wachten op akkoord implementatieplan
7. Featurebranch aanmaken en implementeren

Sla geen enkele stap over. Ga niet zelf door naar de volgende stap zonder expliciete bevestiging van de gebruiker.
