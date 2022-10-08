from dis import dis
import matplotlib.pyplot as plt
import numpy as np
from matplotlib.ticker import MultipleLocator
import mplcursors as mpc

time = []
distance = []
velocity = []
acceleration = []

val = input("1: Position v Time, 2: Velocity v Time, 3: Acceleration v Time")

#read file and append to time and position arrays
with open("output.txt") as f:
    for line in f:
        data = line.split()
        if (data):
            if (val == "1"):
                time.append(float(data[0]))
                distance.append(float(data[1]))
            elif (val == "2"):
                time.append(float(data[0]))
                velocity.append(float(data[2]))
            elif (val == "3"):
                time.append(float(data[0]))
                acceleration.append(float(data[3]))
            else:
                break


if (val == "1"):
    plt.plot(time, distance, marker="o")
    plt.title("Distance v Time")
    plt.ylabel("Distance")

elif (val == "2"):
    plt.plot(time, velocity, marker="o")
    plt.title("Velocity x Time")
    plt.ylabel("Velocity")

elif (val == "3"):
    plt.plot(time, acceleration, marker="o")
    plt.title("Acceleration x Time")
    plt.ylabel("Acceleration")

else:
    plt.title("Invalid Input", color="red")

mpc.cursor(hover = True)
plt.xlabel("Time")
plt.grid()
plt.show()