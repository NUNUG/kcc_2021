import pytmx
import pytmx.util_pygame
from gamedata import GameData

class TmxData():
	"""This class is a singular resource for accessing all tile maps.
	Each layer is read via pytmx and preloaded into the self.maps property
	and the layer objects and indexes are cached."""
	def __init__(self):
		# Load maze map from file.
		self.maps = pytmx.util_pygame.load_pygame(GameData.MAZEMAP_FILENAME)
		self.maze_pixel_size = (self.maps.width, self.maps.height)
		self._iterate_layers()
	def _iterate_layers(self):
		print("Loading tile data...")
		layer_number = -1
		for layer in self.maps.layers:
			layer_number = layer_number + 1
			if isinstance(layer, pytmx.TiledTileLayer):
				print("Found layer: ", layer.name)
				if (layer.name == "Maze"):
					self.maze_layer = layer
					self.maze_layer_number = layer_number
				if (layer.name == "GhostPaths"):
					self.ghostpaths_layer = layer
					self.ghostpaths_layer_number = layer_number
				if (layer.name == "GobblerPaths"):
					self.gobblerpaths_layer = layer
					self.gobblerpaths_layer_number = layer_number
				if (layer.name == "Pellets"):
					self.pellets_layer = layer
					self.pellets_layer_number = layer_number
		self.layer_count = layer_number + 1
