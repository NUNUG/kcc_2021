import pytmx
import tmxloadedlayer

class Pellets(tmxloadedlayer.TmxLoadedLayer):
	"""Represents the grid of pellets which are drawn on the screen."""
	def __init__(self, tmxdata):
		self._load_layer(tmxdata, tmxdata.pellets_layer, tmxdata.pellets_layer_number)

	def reset(self, template):
		"""Create a new set of pellets by copying the
		provided pellet template."""
		# Copy pellet data from the template to ourselves.
		self.pellet_count = 0
		self.create_empty_grid(self.xtilecount, self.ytilecount)
		for x in range(self.xtilecount):
			for y in range(self.ytilecount):
				self.tile_grid[x][y] = template.tile_grid[x][y]
				(x, y, gid, tiled_gid, _) = self.tile_grid[x][y]
				if (gid != 0):
					self.pellet_count = self.pellet_count + 1

	def pellet_at(self, tile_x, tile_y):
		"""Returns the pellet data at the specified tile coordinate."""
		if (tile_x > self.xtilecount):
			print("Tile coordinates out of bounds x: ", tile_x, self.xtilecount)
		if (tile_y > self.ytilecount):
			print("Tile coordinates out of bounds y: ", tile_y, self.ytilecount)
		return self.tile_grid[tile_x][tile_y]

	def gobble(self, tile_x, tile_y):
		"""Removes any pellete that might exist at the specified tile coordinate."""
		self.tile_grid[tile_x][tile_y] = None
		self.pellet_count = self.pellet_count - 1

	def all_gone(self):
		"""Queries whether all the pellets have been gobbled yet.
		Returns True if all pellets are gobbled, False if there are any pellets left."""
		return self.pellet_count == 0
