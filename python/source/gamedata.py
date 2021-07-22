from directions import *

class GameData:
	"""This class contains settings and resource data only."""
	IMAGE_GOBBLER_SPRITESHEET_FILENAME = "../assets/graphics/gobbler-spritesheet.png"
	IMAGE_GOBBLER_SPRITESHEET_SPRITECOUNT = 8
	IMAGE_GOBBLER_SPRITES_FILENAMES = [
		"../assets/graphics/GobblerSprite-left1.png",
		"../assets/graphics/GobblerSprite-left2.png",
		"../assets/graphics/GobblerSprite-right1.png",
		"../assets/graphics/GobblerSprite-right2.png",
		"../assets/graphics/GobblerSprite-down1.png",
		"../assets/graphics/GobblerSprite-down2.png",
		"../assets/graphics/GobblerSprite-up1.png",
		"../assets/graphics/GobblerSprite-up2.png"
	]
	IMAGE_GHOST_SPRITES_FILENAMES = [
		"../assets/graphics/ghost-yellow.png",
		"../assets/graphics/ghost-pink.png",
		"../assets/graphics/ghost-cyan.png",
		"../assets/graphics/ghost-red.png",
		"../assets/graphics/ghost-duress.png",
		"../assets/graphics/ghost-eyesonly.png",
	]
	IMAGE_GHOSTS_SPRITESHEET_FILENAME = "../assets/graphics/ghosts-spritesheet.png"
	IMAGE_GHOSTS_SPRITESHEET_SPRITECOUNT = 4
	GHOST_IMAGE_SIZE = (160,189)
	GHOST_IMAGE_COUNT = 4
	GOBBLER_IMAGE_SIZE = (189,189)
	GOBBLER_SPRITE_SIZE = (24, 24)
	GOBBLER_IMAGE_COUNT = 8
	GOBBLER_ANIMATION_DELAY = 200
	GOBBLER_SPEED = 2
	GOBBLER_POWERUP_DURATION_SECONDS = 6

	GOBBLER_STARTUP_POSITION = (28, 46)
	GOBBLER_STARTUP_DIRECTION = direction_left
	YELLOW_GHOST_STARTUP_POSITION = (22, 26)
	YELLOW_GHOST_STARTUP_DIRECTION = direction_down
	PINK_GHOST_STARTUP_POSITION = (25, 29)
	PINK_GHOST_STARTUP_DIRECTION = direction_up
	CYAN_GHOST_STARTUP_POSITION = (29, 27)
	CYAN_GHOST_STARTUP_DIRECTION = direction_down
	RED_GHOST_STARTUP_POSITION = (32, 30)
	RED_GHOST_STARTUP_DIRECTION = direction_up

	DEBUG = False

	MAZEMAP_FILENAME = "../assets/tiles/GobblerMaze.tmx"

	MUSIC_CASUAL_FILENAME = "../assets/sound/Gobbler-Casual.mp3"
	MUSIC_URGENT_FILENAME = "../assets/sound/Gobbler-Urgent.mp3"
	SOUND_DEATH_FILENAME = "../assets/sound/Gobbler-Death.wav"
	SOUND_GOBBLE_FILENAME = "../assets/sound/Gobbler-Gobble.wav"
	SOUND_CRUNCH_FILENAME = "../assets/sound/Gobbler-Crunch.wav"
	SOUND_CHOMP_FILENAME = "../assets/sound/Gobbler-Chomp.wav"
