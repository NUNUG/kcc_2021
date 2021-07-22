import pygame
import graphics
import tmxdata
import tmxloadedlayer

class Maze(tmxloadedlayer.TmxLoadedLayer):
	"""Represents the tile map for the maze (walls)."""
	def __init__(self, tmxdata):
		self._load_layer(tmxdata, tmxdata.maze_layer, tmxdata.maze_layer_number)
