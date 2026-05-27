# GitHub Copilot instructies

De volledige ontwikkelrichtlijnen staan in `.docs/development-guidelines.md`.  
De compacte AI-ingang staat in `AGENTS.md`.

## Sessiestart (verplicht)

Voer aan het begin van iedere sessie de sessiestart uit zoals beschreven in `AGENTS.md` onder het kopje **Sessiestart**. Doe dit voordat je iets analyseert, suggereert of wijzigt.

## Belangrijkste regels

- Lees `AGENTS.md` en `.docs/development-guidelines.md` voordat je iets wijzigt.
- Volg de fasepoort in `AGENTS.md` zonder stappen over te slaan.
- Vraag de gebruiker om de applicatiescope als `specification.md` leeg of onvolledig is.
- Implementeer nooit user-story code rechtstreeks op `development`.
- Leg een user story altijd eerst voor aan de gebruiker voor inhoudelijk akkoord voordat je technische vragen stelt of een implementatieplan maakt.
- Maak een featurebranch pas na akkoord op de user story én het implementatieplan.
- Bij testfouten of bugs: eerst analyse en herstelplan, daarna pas aanpassen na akkoord.
- Werk documentatie bij na elke betekenisvolle wijziging.
