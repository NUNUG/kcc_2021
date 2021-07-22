direction_name_up = "up"
direction_name_down ="down"
direction_name_left = "left"
direction_name_right ="right"
direction_name_stop = "stop"

direction_velocity_up = (0, -1)
direction_velocity_down = (0, 1)
direction_velocity_left = (-1, 0)
direction_velocity_right = (1, 0)
direction_velocity_stop = (0, 0)

class Direction:
	def __init__(self, name, velocity, opposite):
		self.name = name
		self.velocity = velocity
		self.opposite = opposite

direction_stop = Direction(direction_name_stop, direction_velocity_stop, None)

direction_up = Direction(direction_name_up, direction_velocity_up, None)
direction_down = Direction(direction_name_down, direction_velocity_down, direction_up)
direction_up.opposite = direction_down

direction_left = Direction(direction_name_left, direction_velocity_left, None)
direction_right = Direction(direction_name_right,direction_velocity_right, direction_left)
direction_left.opposite = direction_right

all_directions = [direction_up, direction_down, direction_left, direction_right]

directions_byname = {}
for d in [direction_up, direction_down, direction_left, direction_right, direction_stop]:
	directions_byname[d.name] = d
