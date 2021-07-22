from directions import *
from functions import GameFunctions
import random

class Navigator:
	"""This is the base class for all navigator classes."""
	def __init__(self, game_functions, paths):
		self.game_functions = game_functions
		self.player = None
		self.paths = paths
	def attach_player(self, mazesprite):
		"""A player will call this to attach the navigator to itself.
		It's not part of the constructor because the player doesn't
		exist yet when we construct the navigator."""
		self.player = mazesprite
	def can_change_direction(self, direction):
		"""Indicates whether the sprite is at a location and direction
		where it can go in any other direction."""
		if self.game_functions.player_is_tile_aligned(self.player):
		 	if self.game_functions.player_cango(self.player, self.paths, direction):
				 return True
		return False
	def get_available_directions(self):
		"""This creates a list of all the directions except the 'back' direction."""
		result = []
		for d in all_directions:
			if (d != self.player.direction.opposite):
				result.append(d)
		return result
	def can_navigate(self):
		"""A preliminary check to see if we should try navigating a new direction."""
		player_rect = self.player.get_center_rect()
		(p_x, p_y, _, _) = player_rect
		return self.game_functions.pixel_is_tile_aligned(p_x, p_y)
	def navigate(self):
		"""Gives the sprite the opportunity to make decisions about when
		and where to move in a new direction."""
		pass


class VoidNavigator(Navigator):
	"""This is a navigator tht does nothing.  We only use it as a placeholder when
	building the game, allowing us to take baby steps and add a proper navigator later.
	This is not a real navigator to be used in the game."""
	#def __init__(self, game_functions, paths):
	def __init__(self):
		#Navigator.__init__(self, game_functions, paths)
		pass
	def navigate(self):
		pass


class GobblerNavigator(Navigator):
	""""A simple navigator for Gobbler.  Gobbler is controlled by the keyboard
	and so he doesn't have much need for a navigator to decide where to go.
	Basically, all this navigator does is prevent Gobbler from walking
	through walls."""
	def __init__(self, game_functions, paths):
		Navigator.__init__(self, game_functions, paths)
	def navigate(self):
		if self.can_navigate():
			cango = self.game_functions.player_cango(self.player, self.paths, self.player.direction)
			if (not cango):
				self.player.direction = direction_stop


class RandomNavigator(Navigator):
	"""This is the navigator we will use for our ghosts.
	This is a very simple navigation system.  It makes random decisions
	about where to turn or whether to keep going straight whenever it
	encounters an opportunity to change directions."""
	def __init__(self, game_functions, paths):
		Navigator.__init__(self, game_functions, paths)
	def get_random_direction(self, available_directions):
		lowest = 0
		highest = len(available_directions) - 1
		i = random.randint(lowest, highest)
		new_direction = available_directions[i]
		return new_direction
	def shuffle_directions(self, directions_list):
		"""Randomizes a list of directions by swapping each element
		in the list with a random element in the list once."""
		lst = []
		lst.extend(directions_list)
		cnt = len(lst)
		for i in range(cnt):
			swapindex = random.randint(0, cnt-1)
			swapper = lst[i]
			lst[i] = lst[swapindex]
			lst[swapindex] = swapper
		return lst
	def navigate(self):
		if self.can_navigate():
			available_directions = self.get_available_directions()
			random_directions = self.shuffle_directions(available_directions)
			for direction in random_directions:
				cango = self.game_functions.player_cango(self.player, self.paths, direction)
				if (cango):
					self.player.set_direction(direction)
					break


class SpasticNavigator(Navigator):
	"""A flawed navigator which lets ghosts go through walls.  Just for fun!"""
	def __init__(self, game_functions, paths):
		Navigator.__init__(self, game_functions, paths)
	def get_random_direction(self, available_directions):
		lowest = 0
		highest = len(available_directions) - 1
		i = random.randint(lowest, highest)
		new_direction = available_directions[i]
		return new_direction
	def shuffle_directions(self, directions_list):
		"""Randomizes a list of directions by swapping each element
		in the list with a random element in the list once."""
		lst = []
		lst.extend(directions_list)
		cnt = len(lst)
		for i in range(cnt):
			swapindex = random.randint(0, cnt-1)
			swapper = lst[i]
			lst[i] = lst[swapindex]
			lst[swapindex] = swapper
		return lst
	def navigate(self):
		if self.can_navigate():
			new_direction = self.get_random_direction(self.get_available_directions())
			c = 0
			while not self.game_functions.player_cango(self.player, self.paths, new_direction):
				new_direction = self.get_random_direction(self.get_available_directions())
				c = c + 1
				if (c >= 4):
					break
			self.player.set_direction(new_direction)

class PacingNavigator(Navigator):
	"""The sprite will simply go back and forth between two walls and will never turn."""
	def __init__(self, game_functions, paths):
		Navigator.__init__(self, game_functions, paths)
	def get_random_direction(self, available_directions):
		lowest = 0
		highest = len(available_directions) - 1
		i = random.randint(lowest, highest)
		new_direction = available_directions[i]
		return new_direction
	def navigate(self):
		if self.can_navigate():
			new_direction = self.player.direction
			cango = self.game_functions.player_cango(self.player, self.paths, new_direction)
			if (not cango):
				self.player.direction = self.player.direction.opposite

