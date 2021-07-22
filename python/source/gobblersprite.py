import pygame
import mazesprite
import graphics
import gamedata

class GobblerSprite(mazesprite.MazeSprite):
	"""Represent's the gobbler's graphics, animation and behaviors."""
	def __init__(self, graphics, navigator):
		mazesprite.MazeSprite.__init__(self, graphics, navigator)
		#self.direction = (1, 1)

	def animation_delay_ms(self):
		return gamedata.GameData.GOBBLER_ANIMATION_DELAY

	# This overrides the load_frames() method in the mazesprite class, which GobblerSprite inherits.
	def load_frames(self, graphics):
		self.up_frames = graphics.img_gobbler_up
		self.down_frames = graphics.img_gobbler_down
		self.left_frames = graphics.img_gobbler_left
		self.right_frames = graphics.img_gobbler_right
		self.frames = self.left_frames

	# This overrides the get_speed() method in the mazesprite class, which GobblerSprite inherits.
	def get_speed(self):
		return gamedata.GameData.GOBBLER_SPEED

	def get_startup_position(self):
		return gamedata.GameData.GOBBLER_STARTUP_POSITION

	def get_startup_direction(self):
		return gamedata.GameData.GOBBLER_STARTUP_DIRECTION

