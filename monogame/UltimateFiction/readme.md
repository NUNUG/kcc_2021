# Ultimate Fiction

Ultimate Fiction is a computer game inspired by SquareSoft's Final Fantasy for the Nintendo Entertainment System.  It was written as a project to teach C# and MonoGame programming to kids a the Kids Code Camp 2021.

## Availability
You can find the original materials in the Git repository here:
```
github.com/ultimatefiction
```

## About The Project
### People
The program, graphics, sounds, music, maps, documentation and teaching curriculum were created by Phil Gilmore.

### Tools
These are the tools that were used to create the game.
- Visual Studio 2019
- Tiled Editor
- Paint.NET
- Audacity
- Rytmik Studio
- git

These are the tools you will need for the class:
- Visual Studio 2019 Community Edition or greater
- Tiled Editor version 1.4 or newer
- Paint.NET


## Building the Project
Once you've cloned the repository, you should be able to build the solution in Visual Studio 2019.  All dependencies are NuGet packages or at included in the Git reposiory, so no other downloads should be necessary.

## The Sprites
The sprites are all 8 pixel by 8 pixel images in a single sprite sheet.  The sprite sheets are Paint.NET project files (they have a .PDN file extension).  I used my spritesheet template file as a starting point for the spritesheet.  It is a 64 8x8 blocks in both the X and Y directions, for a total of 64x64 blocks, or 4096.  That's a lot of space.  It's enough that we can surely fit all our graphics into a single sprite sheet and that makes our game simpler.  

It has several layers to help me draw 8x8 pixels, such as a grid, and to help me find the index of each one.  These layers should usually be set to invisible before saving as a PNG file, which is the final version that will be used in the game.  If your sprites have garbage in them, you may have saved a PNG with one of the layers visible which shouldn't have been.

## The Tilemaps and Tiles
Tilemaps are used to create the scrolling background image when the player is walking around in the game.  It's also used for most other backgrounds, such as the menus and the battle scenes.

The tilemaps are created in the Tiled editor. It requires two files.  The first is a tilemap file which the Tiled editor creates and the second is a tilesheet.  The tilesheet is a PNG graphics file which you create in Paint.NET.  I created the tilesheet using the same graphics template file that I used for the SpriteSheets.  It gives me a 64x64 grid of 8x8 blocks.  In the tilesheet image, the transparency and layer order is different than it is in the spritesheets.

There is a second tilesheet, which is a grid of colored numbers.  It is named zones.png.  I use this tilesheet to define different zones where monsters are encountered, which lets me "paint" different battle difficulties on the map.  I also use them to define where the player can walk.  These zones are painted in their own layers in the tilemap in the Tiled editor.

There are only two tilesheets.  Each layer uses only one or the other.  They are not mixed together in any of the layers.

## Sound
I used Audacity and a microphone to create all the sound effects.  I didn't download any from the internet.  I did them all with my mouth and then edited them. Under no circumstances do you have to pay for sound effects if you don't want to.

Sounds effects are saved as 16-bit PCM wave files.

## Music
The music was created using Rytmik.  It's very easy to use.  I paid $7 for it on sale, so it's not free.  If you want to make your own music for free, you can use a free program such as Magix MusicMaker or CakeWalk but they are not simple to use.

## Playing The Game

### Game Scenes
- Title Screen: The title screen allows you to start a new game or continue your old game.
- Overworld: The overworld is any scene where you are free to walk about.  This does not just include the aerial view of you traversing the land, forests and oceans, but also when walking through tunnels or dungeons etc.  While these may not be considered by a player to be overworld views, the program doesn't actually know that they are different.  It uses the same code to do all of them.  So I will refer to all of these scenes as the overworld.
- Battle Encounter: When you encounter enemies in the overworld, you will be thrust into battle.  The battle scene is where you engage in the fight.  When the fight is over, you rerturn to the overworld.
- RPG Menu: This is a role-playing game.  To manage your character's stats and equipment, there is the RPG menu.  Press ENTER to go to the menu, press Z to select a menu element or press X to go back.
- Commerce Menu: This is an interaction between your characters and a shop keeper.  There are many kinds of shop keepers but they all engage in commerce in the same way.
- Dialog: When you interact with an NPC or an object, a dialog may appear to tell you what happened or what the person said.  Press Z or scroll or close the dialog.  You will return to the overworld when the dialog closes.

### Title screen
When you start the game, you will see the title screen.  There are three options.  `Continue` will look for a saved game.  If there isn't one, it will create a new one and you will begin playing.  `New Game` will erase any saved game, create a new one and you will begin playing the new game.  `Quit` will end the program.

### Continue
When you continue a game or start a new game, you will find yourself walking about on the overworld map.  From here it is up to you where you want to go.  

### New Game
A new game will erase any current game if it is present, create a new game and then _Continue_ it.

### Game Play
You play as a party of 4 heroes.  There is a warrior, a black belt fighter, a black mage and a white mage.  They will travel the world to defeat the 4 elemental fiends and restore the elements to the 4 orbs to restore the planet.  

You can walk around and enter caves, tunnels, castles or towns.  Everything works in squares, so you move one square at a time.  Use the arrow keys to walk.  If you step onto a square which is a tunnel, cave, castle or town, you will automatically enter that place and find yourself in a new location.  You can also enter shops.  Shops will not take you to a new location where you can walk around, but will instead send you to a commerce menu where you can interact with the shop keeper.  

If you encounter a person (NPC) in the game, you can walk up to them and, while facing them, press the Z key to talk to them.  Pressing Z again will scroll through the conversation or close the dialog and return you to the overworld.  

If you encounter an object that you want to interact with, you can treat it just like an NPC.  Walk up to it and press Z to interact with it.

To Manage your player's health, spells, equipment, or view their status, use the RPG menu.  You can enter the RPG menu by pressing ENTER.  Navigate the menu with the arrow keys, then enter an element using the Z key.  To go back or cancel an operation, use the X key.  When you use the X key at the root of the menu, the menu will close and you will be returned to the overworld.

In the overworld, most areas have wild monsters running loose.  As you walk through the overworld, you will occasionally encounter these enemy monsters.  When that happens, you will be thrust into battle and have to defeat the enemies to continue.  If all your players die, your game is over and you will return to the title screen.  If you are victorious, your players will game experience and usually some gold.  With enough experience, your player's level will increase and they will become stronger.

You can save your progress periodically.  To save your progress, enter a town, go to the inn and stay the night.  It will cost you some of your gold.  You can then continue from that town the next time you play the game.

### Heroes
#### Warrior
The warrior is a tough weapons user.  The warrior can wield the most powerful swords and armor.

#### Black Belt
The Black Belt fighter uses hand-to-hand combat.  These fighters will not use any weapons and wears light armor.

#### Black Mage
The Black Mage is a powerful user of black magic.  Black magic is destructive and can attack your enemies.  Some spells require a certain player level to cast them.  You can buy black magic spells in the towns.

#### White Mage
The White Mage is a powerful user of white magic.  White magic is restorative and can be used to heal or assist your friends in battle.  Some spells require a certain player level to cast them.  You can buy white magic spells in the towns.

### Relics
Relics are special items that you can obtain which have different effects.  Some will open doors, some will convince people to do different things, etc.  Relics are not explicitly used.  Just having them is enough to make them work.

### Items
Items are one-time-use objects that can be consumed from the RPG menu.  They are usually restorative, like a cure potion.

### Armor
Armor items go on specific parts of the body.  Gloves go on the hands, body armor goes on the torso.  You can equip one item of each type at the same time.  Some armors are heavy and can't be worn by weaker players, such as mages.

### Weapons
Each player can have a weapon, except for the Black Belt.  Every weapon is suited for only one of your heroes.  Only a warrior can use swords, the white mage uses hammers and wands, the black mage uses staves and daggers.

### Spells
Each spell requires a certain player level.  A level-1 spell requires the hero to be level 1 before they can buy it.  A level-8 spell requires the hero to be level 8 before they can buy it.  They name of the spell will be _L#-spellname_.  The # will be the required level number.  

### Battle
I had planned to build a turn-based battle system, but I didn't have time.  The battles are automatic and not interactive.  In the battle scene, every hero takes a turn fighting the enemies and the enemies take a turn fighting back.  Everyone will try to make the best choice about how to fight.  