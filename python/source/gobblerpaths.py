import pytmx
import tmxloadedlayer

class GobblerPaths(tmxloadedlayer.TmxLoadedLayer):
	"""Represents the tile grid for Gobbler's paths."""
	def __init__(self, tmxdata):
		self._load_layer(tmxdata, tmxdata.gobblerpaths_layer, tmxdata.gobblerpaths_layer_number)
