from directions import *
import gamedata
import mazesprite

class GhostSprite(mazesprite.MazeSprite):
	"""A base class for all ghost sprites."""
	def __init__(self, graphics, navigator):
		self.color = self.get_color()
		self.is_scared = False
		mazesprite.MazeSprite.__init__(self, graphics, navigator)

	def get_color():
		"""Indicates the color of this ghost."""
		pass
	def get_hunting_frames(self, graphics):
		"""Returns the images to use when in hunt mode."""
		pass
	def get_startup_position(self):
		"""Returns the tile position where this ghost should be when the game starts."""
		pass
	def get_startup_direction(self):
		"""Returns the direction the sprite should be facing when the game starts."""
		pass

	def load_frames(self, graphics):
		"""This sets the frames properties to contain the appropriate image sets."""
		self.hunting_frames = self.get_hunting_frames(graphics)
		self.scared_frames = self.get_scared_frames(graphics)
		self.eyesonly_frames = self.get_eyesonly_frames(graphics)
		self.set_all_frames(self.hunting_frames)

	def set_all_frames(self, frames):
		"""Sets the framesets for all 4 directions to the specified single set of frames.
		We can do this with ghosts because right now they only have a single sprite
		image.  IF they had different images for up, down, left and right we'd have to
		address them individually."""
		self.up_frames = frames
		self.down_frames = frames
		self.left_frames = frames
		self.right_frames = frames
		self.frames = frames

		self.direction_frames = {
			"up": self.up_frames,
			"down": self.down_frames,
			"left": self.left_frames,
			"right": self.right_frames
		}

	def get_scared_frames(self, graphics):
		"""Returns the frameset with 'scared' ghost images. """
		return [graphics.img_ghost_duress]

	def get_eyesonly_frames(self, graphics):
		"""Returns the frameset with 'eyes only' ghost images."""
		return [graphics.img_ghost_eyesonly]


	# This overrides the get_speed() method in the mazesprite class, which GobblerSprite inherits.
	def get_speed(self):
		"""Returns the number of pixels that the sprite will move at a time."""
		return gamedata.GameData.GOBBLER_SPEED

	def run_away(self):
		"""Puts this ghost in 'scared' mode."""
		self.is_scared = True
		#self.frames = self.scared_frames
		self.set_all_frames(self.scared_frames)
		# I need to slow down the ghosts when they're scared
		# but messing with the speed causes all kinds of
		# problems with running through walls.
		#self.speed = self.get_speed() // 2

	def hunt(self):
		"""Puts this ghost in 'hunt' mode."""
		self.is_scared = False
		self.set_all_frames(self.hunting_frames)


class YellowGhostSprite(GhostSprite):
	"""Represent's the yellow ghost's graphics, animation and behaviors."""
	def __init__(self, graphics, navigator):
		GhostSprite.__init__(self, graphics, navigator)

	def get_color(self):
		return "Yellow"

	def get_hunting_frames(self, graphics):
		return [graphics.img_ghost_yellow]

	def get_startup_position(self):
		return gamedata.GameData.YELLOW_GHOST_STARTUP_POSITION

	def get_startup_direction(self):
		return gamedata.GameData.YELLOW_GHOST_STARTUP_DIRECTION


class PinkGhostSprite(GhostSprite):
	"""Represent's the pink ghost's graphics, animation and behaviors."""
	def __init__(self, graphics, navigator):
		GhostSprite.__init__(self, graphics, navigator)

	def get_color(self):
		return "Pink"

	def get_hunting_frames(self, graphics):
		return [graphics.img_ghost_pink]

	def get_startup_position(self):
		return gamedata.GameData.PINK_GHOST_STARTUP_POSITION

	def get_startup_direction(self):
		return gamedata.GameData.PINK_GHOST_STARTUP_DIRECTION


class CyanGhostSprite(GhostSprite):
	"""Represent's the cyan ghost's graphics, animation and behaviors."""
	def __init__(self, graphics, navigator):
		GhostSprite.__init__(self, graphics, navigator)

	def get_color(self):
		return "Cyan"

	def get_hunting_frames(self, graphics):
		return [graphics.img_ghost_cyan]

	def get_startup_position(self):
		return gamedata.GameData.CYAN_GHOST_STARTUP_POSITION

	def get_startup_direction(self):
		return gamedata.GameData.CYAN_GHOST_STARTUP_DIRECTION


class RedGhostSprite(GhostSprite):
	"""Represent's the red ghost's graphics, animation and behaviors."""
	def __init__(self, graphics, navigator):
		GhostSprite.__init__(self, graphics, navigator)

	def get_color(self):
		return "Red"

	def get_hunting_frames(self, graphics):
		return [graphics.img_ghost_red]

	def get_startup_position(self):
		return gamedata.GameData.RED_GHOST_STARTUP_POSITION

	def get_startup_direction(self):
		return gamedata.GameData.RED_GHOST_STARTUP_DIRECTION
