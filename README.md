# Hobbyistcoder.Editor.Utilities
Useful editor extensions and utilities for Unity 3D

## Find and replace sprite renderer color

- Select a color using the color picker tool in the editor
- Choose a replacement color
- Choose a variance (colors can sometimes vary very slightly based on what was picked) - so use a low variance like 0.01 to ensure that similar colors are not replaced too.
- Hit replace to replace all sprite colors in the scene that match the picked color within variance range with the chosen color

![find and replace sprite color](http://i.imgur.com/rRU2anH.gif)
