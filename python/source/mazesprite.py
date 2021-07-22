import pygame
import gamedata
from directions import *
from functions import GameFunctions

class MazeSprite(pygame.sprite.Sprite):
	"""This is a base class for any sprite which is bound to the maze.  Generally, this means gobbler and the ghosts."""
	def __init__(self, graphics, navigator):
		self.frames = []
		self.up_frames = []
		self.down_frames = []
		self.left_frames = []
		self.right_frames = []
		self.load_frames(graphics)
		self.frame_index = 0
		self.direction = direction_left
		self.position = (0, 0)
		self.image = self.frames[self.frame_index]
		self.last_animation_change = 0
		self.speed = self.get_speed()
		self.navigator = navigator
		self.navigator.attach_player(self)
		self.direction_frames = {
			"up": self.up_frames,
			"down": self.down_frames,
			"left": self.left_frames,
			"right": self.right_frames
		}

	# Override this in descendent classes.
	# Each sprite knows how to load its own images.
	def load_frames(self, graphics):
		pass

	# Override this in descendent classes.
	def get_speed(self):
		"""Returns the number of pixels to move at a time."""
		return 1

	def get_startup_position(self):
		"""This is the tile location in the maze where the sprite
		will start at the beginning of the game."""
		pass

	def get_startup_direction(self):
		"""This is the direction the sprite is facing at the
		beginning of the game."""
		pass

	def reset(self):
		"""This positions the sprite at its startup location and direction."""
		self.set_center_tile_position(self.get_startup_position())
		self.set_direction(self.get_startup_direction())

	def animation_delay_ms(self):
		return 30

	def animate(self, game_time):
		"""Advances the image in the sprite's current animation sequence (frames)."""
		if (game_time > self.last_animation_change + self.animation_delay_ms()):
			self.last_animation_change = game_time
			self.advance_frame()

	def reset_frame(self):
		"""Moves to the first image in the sprite's current animation (frames)."""
		self.frame_index = 0
		self.image = self.frames[self.frame_index]

	def advance_frame(self):
		"""Moves to the next image in the sprite's current animation (frames)."""
		frame_count = len(self.frames)
		self.frame_index = (self.frame_index + 1) % frame_count
		self.image = self.frames[self.frame_index]

	def move(self, game_time):
		"""Increment's the sprite's location according to its direction and speed."""
		if (True):
			(x, y) = self.position
			(h, v) = self.direction.velocity
			(newx, newy) = (x + int(h * self.speed), y + int(v * self.speed))
			self.position = (newx, newy)

	def attempt_direction(self, maze,  paths, f, direction):
		"""This will change the direction of the sprite to the specified direction
		if the direction is a valid direction in the maze at this sprite's location.
		Returns true if successful, false if the direction is invalid."""
		if f.player_is_tile_aligned(self):
			if f.player_cango(self, paths, direction):
				self.set_direction(direction)
				return True
		return False

	def set_direction(self, direction):
		"""Sets a new direction for the sprite and updates all necessary aspects of the sprite to match."""
		self.direction = direction
		if (self.frames != self.direction_frames[direction.name]):
			self.frames = self.direction_frames[direction.name]
			self.reset_frame()

	def render(self, screen):
		"""Draws this prite on the screen."""
		screen.blit(self.image, self.position)

	def get_center_tile_position(self):
		"""Returns the x,y pixel positions of the center tile in this 3x3 sprite."""
		(x, y) = self.position
		return (x + 8, y + 8)

	def get_center_rect(self):
		"""Returns the pixel rect of the center tile in this sprite."""
		(x, y) = self.get_center_tile_position()
		return pygame.Rect(x, y, 8, 8)

	def set_center_tile_position(self, tile_xy):
		"""Set the tile grid location of the center tile for this sprite."""
		# Sprites are 24x24, which is a 3x3 tile grid.
		# Setting the center tile means the upper-left pixel position is
		# one tile left and one tile up from the center tile."""
		(tile_x, tile_y) = tile_xy
		(upper_left_tile_x, upper_left_tile_y) = (tile_x - 1, tile_y - 1)
		upper_left_pixels = (upper_left_tile_x * 8, upper_left_tile_y * 8)
		self.position = upper_left_pixels

