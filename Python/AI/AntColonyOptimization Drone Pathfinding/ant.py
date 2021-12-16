
class Ant():
    def __init__(self, tourLength):
        self.trailSize = tourLength
        self.trail = [-1] * tourLength
        self.visited = [False] * tourLength

    def visitSensor(self, current, toVisit):
        self.trail[current + 1] = toVisit
        self.visited[toVisit] = True

    def checkVisited(self, city):
        return self.visited[city]

    def trailLength(self, distanceMatrix):
        length = 0 # distanceMatrix[self.trail[self.trailSize - 1]][self.trail[0]]
        for i in range(0, self.trailSize - 1):
            length += distanceMatrix[self.trail[i]][self.trail[i + 1]]
        return length

    def clear(self):
        for i in range(0, self.trailSize):
            self.visited[i] = False