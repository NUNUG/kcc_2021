import tmxdata

class TmxLoadedLayer():
	"""This is tghe base class for all loaded tile map objects."""
	def create_empty_grid(self, x_tiles, y_tiles):
		self.tile_grid = []
		for x in range(x_tiles):
			rowdata = []
			self.tile_grid.append(rowdata)
			for y in range(y_tiles):
				rowdata.append(None)

	def _load_layer(self, tmxdata, layer, layer_number):
		"""Create a new 2D grid and then fill it with tiles from the
		specified layer in tmxdata."""
		self.layer = layer
		self.layer_number = layer_number
		self.xtilecount = layer.width
		self.ytilecount = layer.height
		self.create_empty_grid(self.xtilecount, self.ytilecount)
		# Put data in the matrix
		for x, y, gid in self.layer:
			img = tmxdata.maps.get_tile_image(x, y, self.layer_number)
			if (gid in tmxdata.maps.tiledgidmap):
				tiled_gid = tmxdata.maps.tiledgidmap[gid]
			else:
				tiled_gid = 0
			self.tile_grid[x][y] = (x, y, gid, tiled_gid, img)
