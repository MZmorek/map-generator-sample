# map-generator-sample
Sample code for generating map & objects using Perlin Noise & tilemaps.

Breakdown of most important classes' functionalities:

**MapGeneration.cs** & **ObjectGeneration.cs** - classes responsible for generating terrain and placing objects everytime the game is started.

**MapParametersConfiguration** & **WorldObjectConfiguration** - ScriptableObjects containing various map & object generation parameters.

**WorldObject** - class containing basic information about world objects.

I didn't add the whole SaveSystem, because this repo should mainly show the WorldGeneration :)
