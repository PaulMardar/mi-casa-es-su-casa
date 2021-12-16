from queue import PriorityQueue

from repository import *


class controller():
    def __init__(self, repo):
        self.repo = repo
        self.distanceMatrix = np.zeros((SENSORS, SENSORS))

    def getDistanceMatrix(self):
        return self.distanceMatrix

    def initializeDistanceMatrix(self):
        sensors = self.repo.getSensors()
        for i in range(len(sensors)):
            for j in range(i+1, len(sensors)):
                length, path = self.searchAStar(sensors[i].getX(), sensors[i].getY(), sensors[j].getX(), sensors[j].getY())
                if length is False:
                    return -1
                sensors[i].setPath(j, path)
                sensors[j].setPath(i, path[::-1])
                self.distanceMatrix[i][j] = length
                self.distanceMatrix[j][i] = length
        drone = self.repo.getDrone()
        for i in range(len(sensors)):
            length, path = self.searchAStar(drone.startX, drone.startY, sensors[i].getX(), sensors[i].getY())
            if length is False:
                return -1
            drone.distances[i] = length
            drone.path[i] = path
        return 1


    def computeHeuristic(self, X, Y, finalX, finalY):
        # Manhattan distance
        return abs(X - finalX) + abs(Y - finalY)

    def searchAStar(self, initialX, initialY, finalX, finalY):
        mapM = self.repo.getMap()

        found = False
        visited = []
        toVisit = PriorityQueue()
        current_distances = np.zeros((mapLengh, mapLengh))

        parent = []
        for i in range(0, mapLengh):
            parent.append([])
            for j in range(0, mapLengh):
                parent[i].append((-2, -2))

        length = 0
        finalPath = []
        toVisit.put((0, (initialX, initialY)))
        current_distances[initialX][initialY] = 0
        while toVisit.empty() is False and found is False:
            node = toVisit.get()[1]
            visited.append(node)
            if node == (finalX, finalY):
                while node != (initialX, initialY):
                    finalPath.append(node)
                    length += 1
                    node = parent[node[0]][node[1]]
                finalPath.append(node)
                found = True
            else:
                for i in range(0, 4):
                    newX = node[0] + v[i][0]
                    newY = node[1] + v[i][1]
                    if 0 <= newX < mapLengh and 0 <= newY < mapLengh and mapM.surface[newX][newY] == 0 and (newX, newY) not in visited:
                        if current_distances[newX][newY] == 0 or current_distances[newX][newY] > current_distances[node[0]][node[1]] + 1:
                            current_distances[newX][newY] = current_distances[node[0]][node[1]] + 1
                            parent[newX][newY] = node
                        else:
                            continue
                        toVisit.put((current_distances[newX][newY] + self.computeHeuristic(newX, newY, finalX, finalY), (newX, newY)))
                if toVisit.empty() is True:
                    return False, False
        return length, finalPath[::-1]

    def makePath(self, pathLength, points):
        sensors = self.repo.getSensors()
        finalPath = self.repo.getDrone().path[points[1]]
        for i in range(1, SENSORS):
            thisSensor = 0
            nextSensor = 0
            for sensor in sensors:
                if sensor.getID() == points[i]:
                    thisSensor = sensor
                if sensor.getID() == points[i + 1]:
                    nextSensor = sensor
            finalPath.extend(thisSensor.getPath(nextSensor.getID()))
        return finalPath

    def adjustBatteryToPath(self, finalPath):
        battery = ENERGY
        sensorPositionAndEnergy = []
        path = []
        result = []
        sensors = self.repo.getSensors()
        for i in range(len(sensors)):
            sensorPositionAndEnergy.append([sensors[i].getX(), sensors[i].getY(), sensors[i].maxSeenSquares, sensors[i].getSeenSquares(), sensors[i].maxBattery])
        prev = -1
        for e in finalPath:
            if e == prev:
                continue
            prev = e
            path.append(e)
            battery -= 1
            if battery == 0:
                break
            for i in range(len(sensorPositionAndEnergy)):
                if sensorPositionAndEnergy[i][0] == e[0] and sensorPositionAndEnergy[i][1] == e[1]:
                    if battery >= sensorPositionAndEnergy[i][4]:
                        battery -= sensorPositionAndEnergy[i][4]
                        result.append([e[0], e[1], sensorPositionAndEnergy[i][2], sensorPositionAndEnergy[i][4]])
                    elif battery < sensorPositionAndEnergy[i][4]:
                        result.append([e[0], e[1], sensorPositionAndEnergy[i][3][battery], battery])
                        battery = 0
            if battery == 0:
                break

        return path, result
