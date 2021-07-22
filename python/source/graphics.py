import pygame
from gamedata import *
import pytmx
import tmxloadedlayer
import pytmx.util_pygame
import maze


class Graphics:
	def __init__(self):
		gsize = GameData.GOBBLER_SPRITE_SIZE
		self.img_gobbler_left = [
			pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GOBBLER_SPRITES_FILENAMES[0]).convert_alpha(), gsize),
			pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GOBBLER_SPRITES_FILENAMES[1]).convert_alpha(), gsize)
		]
		self.img_gobbler_right = [
			pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GOBBLER_SPRITES_FILENAMES[2]).convert_alpha(), gsize),
			pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GOBBLER_SPRITES_FILENAMES[3]).convert_alpha(), gsize)
		]
		self.img_gobbler_down = [
			pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GOBBLER_SPRITES_FILENAMES[4]).convert_alpha(), gsize),
			pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GOBBLER_SPRITES_FILENAMES[5]).convert_alpha(), gsize)
		]
		self.img_gobbler_up = [
			pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GOBBLER_SPRITES_FILENAMES[6]).convert_alpha(), gsize),
			pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GOBBLER_SPRITES_FILENAMES[7]).convert_alpha(), gsize)
		]


		self.img_ghost_yellow = pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GHOST_SPRITES_FILENAMES[0]).convert_alpha(), gsize)
		self.img_ghost_pink = pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GHOST_SPRITES_FILENAMES[1]).convert_alpha(), gsize)
		self.img_ghost_cyan = pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GHOST_SPRITES_FILENAMES[2]).convert_alpha(), gsize)
		self.img_ghost_red = pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GHOST_SPRITES_FILENAMES[3]).convert_alpha(), gsize)
		self.img_ghost_duress = pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GHOST_SPRITES_FILENAMES[4]).convert_alpha(), gsize)
		self.img_ghost_eyesonly = pygame.transform.smoothscale(pygame.image.load(GameData.IMAGE_GHOST_SPRITES_FILENAMES[5]).convert_alpha(), gsize)

	# def printHold(self, text):
	# 	print(text, end="")

	def draw_tileset(self, tileset, screen):
		tw = 8
		th = 8
		for y in range(tileset.ytilecount):
			for x in range(tileset.xtilecount):
				tile = tileset.tile_grid[x][y]
				if (tile != None):
					(x, y, gid, tiled_gid, img) = tile
					if (img != None):
						position = (tw * x, th * y)
						screen.blit(img, position)

	def draw_maze(self, maze, screen):
		self.draw_tileset(maze, screen)

	# def _print_tiles(self, tmxdata, tmxloadedlayer, translate_gid):
	# 	for y in range(tmxloadedlayer.ytilecount):
	# 		for x in range(tmxloadedlayer.xtilecount):
	# 			maze_tile_data = tmxloadedlayer.tile_grid[x][y]
	# 			(x, y, gid, tiled_gid, img) = maze_tile_data
	# 			charToPrint = gid

	# 			if (translate_gid):
	# 				if (gid in tmxdata.maps.tiledgidmap):
	# 					tiledgid = tmxdata.maps.tiledgidmap[gid]
	# 					charToPrint = str(tiledgid)
	# 				else:
	# 					charToPrint = "."
	# 				charToPrint = str(tiled_gid)

	# 			self.printHold(charToPrint)
	# 		print("|")

	def _load_paths_layer(self, layer, layer_number):
		self.paths_layer_number = layer_number
		self.paths_layer = layer

	def _load_pellets_layer(self, layer, layer_number):
		self.pellets_layer_number = layer_number
		self.pellets_layer = layer

	def draw_pellets(self, pellets, screen):
		self.draw_tileset(pellets, screen)

	def draw_gobbler(self, screen):
		pass

	def draw_ghosts(self, screen):
		pass

	def draw_ghost(self, ghost, screen):
		pass

	def draw_ghostpaths(self, ghostpaths, screen):
		self.draw_tileset(ghostpaths, screen)

	def draw_gobblerpaths(self, gobblerpaths, screen):
		self.draw_tileset(gobblerpaths, screen)

	def draw_you_win(self, screen):
		gameover_font = pygame.font.Font(None, 100)
		gameover_text = gameover_font.render('YOU WIN!', True, [0, 175, 0])
		screen.blit(gameover_text, ((screen.get_width() - gameover_text.get_rect().width)/ 2, (screen.get_height() - gameover_text.get_rect().height) /2))
		pygame.display.update()

	def draw_you_died(self, screen):
		gameover_font = pygame.font.Font(None, 100)
		gameover_text = gameover_font.render('YOU DIED!', True, [255, 0, 0])
		screen.blit(gameover_text, ((screen.get_width() - gameover_text.get_rect().width)/ 2, (screen.get_height() - gameover_text.get_rect().height) /2))
		pygame.display.update()

	def draw_rect(self, rect, screen):
		if (GameData.DEBUG):
			x1 = rect.left
			y1 = rect.top
			x2 = rect.right
			y2 = rect.bottom
			pygame.draw.polygon(screen, pygame.color.Color("Red"), [(x1-8, y1-8), (x2+8, y1-8), (x2+8, y2+8), (x1-8, y2+8), (x1-8, y1-8)], 1)
			pygame.draw.rect(screen, pygame.color.Color("Red"), rect)

