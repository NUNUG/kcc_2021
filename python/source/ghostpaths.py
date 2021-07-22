import pytmx
import tmxloadedlayer

class GhostPaths(tmxloadedlayer.TmxLoadedLayer):
	"""Represents the tile map for the ghost paths tiles."""
	def __init__(self, tmxdata):
		self._load_layer(tmxdata, tmxdata.ghostpaths_layer, tmxdata.ghostpaths_layer_number)
