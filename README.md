# FF5PR.EnemyRowFix

A BepInEx plugin which aims to backport the original enemy front/back row mechanics used in the SNES/GBA/PS1 versions of Final Fantasy V to the Pixel Remaster.

## Features

TODO:

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

TODO: