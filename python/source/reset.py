from shutil import copyfile

step_count = 15

print("This will clean up and reset your work to any step throughout the session.")
print("If you want to play the finished game, go to step 0.")
print("Enter the number for the step you want to work on (Example: 1):")
desiredStep = input()

try:
	i = int(desiredStep)
except:
	i = -1

if (i < 0) or (i > step_count):
	print(desiredStep + " is not a valid step number.  Valid steps numers are 1 through "+str(step_count)+".")
else:
	src = "../steps/step" + str(i) + ".py"
	dest = "./gobbler.py"
	copyfile(src, dest)
	print("Copied ", src, " to ", dest)
