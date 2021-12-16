# -*- coding: utf-8 -*-


# imports
from gui import *
from controller import *
from repository import *
from domain import *
from AntColonyOptimization import *

def setUpParamsManually(map):
    print("Initialization")
    print("Input the drone starting position: ")
    droneStartX = int(input("x= "))
    droneStartY = int(input("y= "))
    if map.valid_position(droneStartX, droneStartY) is False:
        return None
    drone = Drone(droneStartX, droneStartY)

    print("The energy of the drone: ")
    droneEnergy = int(input("energy= "))

    x = int(input("The number of sensors= "))
    sensors = []
    for i in range(x):
        print("Sensor " + str(i))
        sX = int(input("Sensor " + str(i) + " X position= "))
        sY = int(input("Sensor " + str(i) + " Y position= "))
        sensor = Sensor(i, sX, sY)
        sensors.append(sensor)

    return [drone, droneEnergy, sensors]

def setUpParamsRandom(map):
    print("Drone and sensor positions are initialized randomly")
    dronePosition = map.randomValidPosition()
    drone = Drone(dronePosition[0], dronePosition[1])

    droneEnergy = ENERGY

    x = SENSORS
    sensors = []
    for i in range(x):
        pos = map.randomValidPosition()
        sensor = Sensor(i, pos[0], pos[1])
        sensors.append(sensor)

    return [drone, droneEnergy, sensors]

def main():
    m = Map(mapLengh, mapLengh)
    m.randomMap()
    # init = setUpParamsManually(m)
    init = setUpParamsRandom(m)
    if init is None:
        print("Incorrect data introduced. Sensors/Drone may overlap forbidden positions.")
        return

    drone = init[0]
    droneEnergy = init[1]
    sensors = init[2]
    repo = repository(m, drone, droneEnergy, sensors)
    c = controller(repo)
    c.initializeDistanceMatrix()

    dm = c.getDistanceMatrix()

    antColonyDistanceMatrix = np.zeros((SENSORS + 1, SENSORS + 1))

    for i in range(SENSORS):
        antColonyDistanceMatrix[i][SENSORS] = drone.distances[i]
        antColonyDistanceMatrix[SENSORS][i] = drone.distances[i]

    for i in range(SENSORS):
        for j in range(SENSORS):
            antColonyDistanceMatrix[i][j] = dm[i][j]

    for i in range(len(antColonyDistanceMatrix)):
        for j in range(len(antColonyDistanceMatrix)):
            if antColonyDistanceMatrix[i][j] == 0.0 and i != j:
                print("One or more sensors is/are unreachable")
                return

    """
    for i in range(SENSORS + 1):
        for j in range(SENSORS + 1):
            print(antColonyDistanceMatrix[i][j], end=" ")
        print()
    """

    aco = AntColonyOptimization(antColonyDistanceMatrix)
    pathLength, path = aco.run()

    finalPath = c.makePath(pathLength, path)
    path, result = c.adjustBatteryToPath(finalPath)
    for e in result:
        print("Sensor (" + str(e[0]) + ", " + str(e[1]) + ") : " + str(e[2]) + " seen squares using " + str(e[3]) + " battery")
    movingDrone(m, path, sensors, drone, 0.1)


main()