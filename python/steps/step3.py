###############################################################################
# Gobbler Step 3 - Draw maze
###############################################################################
# We add Pygame, create a window and an empty game loop
###############################################################################

# PyGame stuff
import pygame
from pygame.locals import *
import sys
# Tile data
import tmxdata
import maze
# Game files
import graphics
import functions

# Sound and graphics init for PyGame
pygame.init()

# Set up the screen.
screen_size = (55*8, 61*8)
screen = pygame.display.set_mode([screen_size[0], screen_size[1]])
pygame.display.set_caption("Gobbler")

# System setup
g = graphics.Graphics()
f = functions.GameFunctions(g, None)

# Tilesets Setup
tmxdata = tmxdata.TmxData()
maze = maze.Maze(tmxdata)

# Game Loop setup
fps = 60

# This is the main game loop.  Everything below here repeats forever.
while True:
	pygame.time.Clock().tick(fps)

	for event in pygame.event.get():
		# Pay attention if the user clicks the X to quit.
		if event.type == pygame.QUIT:
			sys.exit()

		# Check the keyboard for keypresses. (These buttons must be pressed repeatedly.)
		if event.type == pygame.KEYDOWN:
			if (event.key == K_ESCAPE):
				sys.exit()

	# Draw the maze
	screen.fill(Color("White"))
	g.draw_maze(maze, screen)

	# Put the scene on the monitor.
	pygame.display.update()

# End of game loop.
