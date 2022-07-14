# Bomb Jack - Summer Semester Assignment (2022)

Author: David Hřivna
Keywords: C#, Windows Forms, Game


## Introduction

This program is my final assignment for the Programming 2 course at MFF UK. Idea was to create a game similar to [Bomb Jack](https://en.wikipedia.org/wiki/Bomb_Jack) game in C# using Windows forms.

## Controls

- Left Arrow - Player move left
- Right Arrow - Player move right
- Spacebar - Player jump

## Starting game

Program starts in "Menu Window" where player can choose between playing example stages or creating his/her own in editor or load map from json file. After starting, a "Game Window" is shown and player can start playing. Score and remaining lives are shown in the window title.

## Technical information

Project is developed in .NET 6.0. 

### Class structure
- GameObject

-- MovableObject

--- Player

--- Monster

-- Bomb

-- Wall

