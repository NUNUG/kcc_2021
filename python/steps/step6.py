###############################################################################
# Gobbler Step 6 - Keyboard
###############################################################################
# Gobbler will go where the keyboard tells him to.
###############################################################################

# PyGame stuff
import pygame
from pygame.locals import *
import sys
# Tile data
import tmxdata
import maze
import pellets
import gobblerpaths
# Game files
import graphics
import functions
from directions import *
from navigators import *
# Graphics files
import gobblersprite

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
pellets_template = pellets.Pellets(tmxdata)
pellets = pellets.Pellets(tmxdata)
pellets.reset(pellets_template)
gobbler_paths = gobblerpaths.GobblerPaths(tmxdata)

# Sprites Setup
gobbler = gobblersprite.GobblerSprite(g, VoidNavigator())

# Game Loop setup
fps = 60

# Set gobbler's starting position in the maze
gobbler.reset()

# This is the main game loop.  Everything below here repeats forever.
while True:
	pygame.time.Clock().tick(fps)
	game_time = pygame.time.get_ticks()

	for event in pygame.event.get():
		# Pay attention if the user clicks the X to quit.
		if event.type == pygame.QUIT:
			sys.exit()

		# Check the keyboard for keypresses. (These buttons must be pressed repeatedly.)
		if event.type == pygame.KEYDOWN:
			if (event.key == K_ESCAPE):
				sys.exit()

	keys = pygame.key.get_pressed()
	if keys[K_UP]:
		gobbler.attempt_direction(maze, gobbler_paths, f, direction_up)
	if keys[K_DOWN]:
		gobbler.attempt_direction(maze, gobbler_paths, f, direction_down)
	if keys[K_LEFT]:
		gobbler.attempt_direction(maze, gobbler_paths, f, direction_left)
	if keys[K_RIGHT]:
		gobbler.attempt_direction(maze, gobbler_paths, f, direction_right)

	# Draw the maze
	screen.fill(Color("White"))
	g.draw_maze(maze, screen)

	# Draw the pellets
	g.draw_pellets(pellets, screen)

	# Animate the Gobbler
	gobbler.animate(game_time)

	# Move the Gobbler
	gobbler.move(game_time)

	# Draw the Gobbler
	gobbler.render(screen)

	# Put the scene on the monitor.
	pygame.display.update()

# End of game loop.
