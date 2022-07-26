# Bomb Jack –⁠⁠⁠ Summer Semester Assignment (2022)

Author: David Hřivna

Keywords: C#, Windows Forms, Game


## Introduction

This program is my final assignment for the Programming 2 course at MFF UK. Idea was to create a game similar to [Bomb Jack](https://en.wikipedia.org/wiki/Bomb_Jack) in C# using Windows forms.

## Controls

- Left Arrow –⁠⁠⁠ Player move left
- Right Arrow –⁠⁠⁠ Player move right
- Spacebar –⁠⁠⁠ Player jump

## Goal

Player need to collect all bombs in stage to win. Monsters hunt him and reduce remaining lives. When player has no more remaining lives, he loses.

## Starting game

Program starts in `Menu Window` where the player can choose between playing example stages (in Resources directory) or creating his/her own in editor or load map from json file. After starting, a "Game Window" is shown and player can start playing. Score and remaining lives are shown in the window title. When lose/win `Message box` is shown. If you want to load map, you must follow the format of the maps (must be same as from map editor). I suggest using map editor for all custom maps.

## Map editor

Game allows you to create your own map and store it as json file. You can add mosnters, bombs, walls and set spawnpoint. Walls must be at least the same length as width of objects (64 px). You place the items by clicking (lines need 2 clicks).

## Technical information

Project is developed in .NET 6.0. All game objects are children of the `GameObject` class. `MovableObject` class has `Player` and `Monster` children. Non-moving children classes (`Bomb`, `Wall`) are directly children of `GameObject` class. 
Developed in Visual Studio 2022 Community.

### Class structure
- `GameObject`

    - `Bomb`

    - `Wall`

    - `MovableObject`

        - `Player`

        - `Monster`

