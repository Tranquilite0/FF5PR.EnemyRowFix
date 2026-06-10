# FF5PR.EnemyRowFix

A BepInEx plugin which aims to backport the original enemy front/back row mechanics used in the SNES/GBA/PS1 versions of Final Fantasy V to the Pixel Remaster.

## Details
* FFV Pixel seems to determine enemy row using the same 3x3 enemy grid that I-IV use.
* FFV SNES/GBA/PS1 uses a more nuanced formula where an enemy's X position and sprite width are used to determine if it is in line with the frontmost enemy.

## Installation

1. If you previously installed BepInEx and have a "mono" folder in the game directory, remove the "mono" and "BepInEx" folders.
1. Download BepInEx 6.0.0-pre.2 IL2CPP build from [here](https://github.com/BepInEx/BepInEx/releases/download/v6.0.0-pre.2/BepInEx-Unity.IL2CPP-win-x64-6.0.0-pre.2.zip) and extract the content to the game directory.
    - In your steam library you can right click on the game and select `Manage->Browse local files`.
    - (It's where "FINAL FANTASY V.exe" is located).
    - Replace the files if asked.
1. Download the mod from the [Releases](/../../releases/latest) page and extract the content to the game directory.
    - Replace the files if asked.
1. On Steam Deck, add to the Steam launch options : `export WINEDLLOVERRIDES="winhttp=n,b"; %command%`
1. Run the game once to generate the config file, change the config in `(GAME_PATH)\BepInEx\config\FF5PR.EnemyRowFix.cfg` and restart the game.

## Notes
* The SNES/GBA/PS1 versions have enemies and sprite widths aligned to 8px tile boundaries, while Pixel has no such limitations.
* Enemy formations on Pixel often differ in subtle ways.
* To make enemy row behavior match the original 100% would probably required adjusting the X positions of all the enemy groups.