import os
import os.path
import pygame
from gamedata import *

class GameSounds:
	"""This class is the sole access point for sound effects and music.
	Each music resource is played or stopped by one of the methods of this
	object.  Each sound effect is a simple member with its own play and stop
	members."""
	def __init__(self):
		self.sound_death = pygame.mixer.Sound(GameData.SOUND_DEATH_FILENAME)
		self.sound_gobble = pygame.mixer.Sound(GameData.SOUND_GOBBLE_FILENAME)
		self.sound_crunch = pygame.mixer.Sound(GameData.SOUND_CRUNCH_FILENAME)
		self.sound_chomp = pygame.mixer.Sound(GameData.SOUND_CHOMP_FILENAME)

	def play_music_casual(self):
		pygame.mixer.music.load(GameData.MUSIC_CASUAL_FILENAME)
		pygame.mixer.music.play(-1)

	def play_music_urgent(self):
		pygame.mixer.music.load(GameData.MUSIC_URGENT_FILENAME)
		pygame.mixer.music.play(-1)

	def stop_music(self):
		pygame.mixer.music.stop()
