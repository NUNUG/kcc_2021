###############################################################################
# Gobbler Step 13 - Ghost Collisions
###############################################################################
# Gobbler runs through the maze, but the ghosts don't hurt him.  We will
# check for collisions with ghosts.  If Gobbler collides with a ghost,
# it's game over.
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
import ghostpaths
# Game files
import sounds
import graphics
import functions
from directions import *
from navigators import *
# Graphics files
import gobblersprite
import ghostsprite

# Sound and graphics init for PyGame
pygame.mixer.pre_init(22050, -16, 2, 256)
pygame.init()
pygame.mixer.init()

# Set up the screen.
screen_size = (55*8, 61*8)
screen = pygame.display.set_mode([screen_size[0], screen_size[1]])
pygame.display.set_caption("Gobbler")

# System setup
g = graphics.Graphics()
s = sounds.GameSounds()
f = functions.GameFunctions(g, s)

# Tilesets Setup
tmxdata = tmxdata.TmxData()
maze = maze.Maze(tmxdata)
pellets_template = pellets.Pellets(tmxdata)
pellets = pellets.Pellets(tmxdata)
pellets.reset(pellets_template)
ghost_paths = ghostpaths.GhostPaths(tmxdata)
gobbler_paths = gobblerpaths.GobblerPaths(tmxdata)

# Sprites Setup
gobbler = gobblersprite.GobblerSprite(g, GobblerNavigator(f, gobbler_paths))
ghost_yellow = ghostsprite.YellowGhostSprite(g, RandomNavigator(f, ghost_paths))
ghost_pink = ghostsprite.PinkGhostSprite(g, RandomNavigator(f, ghost_paths))
ghost_cyan = ghostsprite.CyanGhostSprite(g, RandomNavigator(f, ghost_paths))
ghost_red = ghostsprite.RedGhostSprite(g, RandomNavigator(f, ghost_paths))

# Lists setup
all_ghosts = [ghost_yellow, ghost_pink, ghost_cyan, ghost_red]
all_sprites = [gobbler, ghost_yellow, ghost_pink, ghost_cyan, ghost_red]

# Start background music.
s.play_music_casual()

# Game Loop setup
fps = 60

# Reset all sprites to their starting positions in the maze
for sprite in all_sprites:
	sprite.reset()

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

	gobbler_rect = gobbler.get_center_rect()
	(p_x, p_y, _, _) = gobbler_rect
	if (f.pixel_is_tile_aligned(p_x, p_y)):
		tile_loc = f.tile_location_of_pixel(p_x, p_y)
		(t_x, t_y) = tile_loc

		# Look for a pellet here
		pellet = pellets.pellet_at(t_x, t_y)
		if (pellet != None):
			(x, y, gid, tiled_gid, _) = pellet
			# Is it a power pellet?
			if (gid != 0):
				is_power_pellet = (tiled_gid == 196)
				if (is_power_pellet):
					f.power_up(game_time, gobbler, all_ghosts)
					s.play_music_urgent()
					s.sound_crunch.play()
				else:
					s.sound_gobble.play()
				pellets.gobble(t_x, t_y)
	if f.power_up_expired(game_time):
		if (f.powered_up):
			f.power_down(gobbler, all_ghosts)
			s.play_music_casual()

	for sprite in all_sprites:
		sprite.navigator.navigate()

	# Look for collisisons with ghosts
	for ghost in all_ghosts:
		has_collision = f.check_ghost_collision(gobbler, ghost)
		if has_collision:
			if ghost.is_scared:
				f.chomp(ghost)
			else:
				f.haunt(ghost, gobbler)

	# Draw the maze
	screen.fill(Color("White"))
	g.draw_maze(maze, screen)

	# Draw the pellets
	g.draw_pellets(pellets, screen)

	# Animate each sprite
	for sprite in all_sprites:
		sprite.animate(game_time)

	# Adjust the location of the sprite in the maze.
	for sprite in all_sprites:
		sprite.move(game_time)

	# Draw the Gobbler
	gobbler.render(screen)

	# Draw the ghosts
	for ghost in all_ghosts:
		ghost.render(screen)

	# Put the scene on the monitor.
	pygame.display.update()

# End of game loop.
