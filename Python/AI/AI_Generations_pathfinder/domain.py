from utils import ENERGY, numberOfSenzors, INFITINITY, N, M, MAP_FILL, DIRECTIONS
import numpy as np
from queue import Queue
from random import randint, random

class Ant():
    def __init__(self):
        self.visited = [0]
        self.energy = ENERGY
        self.choices = [0]

    def createNewAnt(self):
        copy = Ant()
        copy.visited.clear()
        copy.choices.clear()
        copy.energy = self.energy
        for i in range(len(self.visited)):
            copy.visited.append(self.visited[i])
            copy.choices.append(self.choices[i])
        return copy

class Graph():
    def __init__(self, map):
        self.map = map
        self.ph = [[1000 for j in range(numberOfSenzors + 1)] for i in range(numberOfSenzors + 1)]
        self.dist = [[0 for j in range(numberOfSenzors + 1)] for i in range(numberOfSenzors + 1)]
        self.choice_ph = [[1000 for j in range(6)] for i in range(numberOfSenzors + 1)]

    def __str__(self):
        string=""
        for i in range(numberOfSenzors + 1):
            for j in range(numberOfSenzors + 1):
                string = string + str(int(self.dist[i][j]))
            string = string + "\n"
        string = string + str(self.map)
        return string
        

class Map():
    def __init__(self):
        self.start_x = randint(0, N-1)
        self.start_y = randint(0, M-1)
        self.surface = np.zeros((N, M))
        self.senzors = []
    
    def random_map(self):
        for i in range(N):
            for j in range(M):
                if random() <= MAP_FILL:
                    self.surface[i][j] = 1
        while(self.surface[self.start_x][self.start_y] == 1):
            self.start_x = randint(0, N-1)
            self.start_y = randint(0, M-1)
        self.surface[self.start_x][self.start_y] = 2
        senzors_placed = 0
        while senzors_placed < numberOfSenzors:
            x = randint(0, N-1)
            y = randint(0, M-1)
            if self.surface[x][y] == 0:
                self.surface[x][y] = 2
                senzors_placed = senzors_placed + 1
                self.senzors.append([x,y])
        self.refresh()

    def calculate_distance(self, x1, y1, x2, y2):
        if x1 == x2 and y1 == y2:
            return 0
        q = Queue()
        q.put([x1, y1])
        self.surface[x1][y1]=2
        while q.empty() == False:
            front = q.get()
            for d in DIRECTIONS:
                x = front[0] + d[0]
                y = front[1] + d[1]
                if self.validCell(x, y):
                    self.surface[x][y] = self.surface[front[0]][front[1]]+1
                    if x == x2 and y == y2:
                        result = self.surface[x][y]-2
                        self.refresh()
                        return result
                    q.put([x,y])
        self.refresh()
        return INFITINITY
    
    def refresh(self):
        for i in range(N):
            for j in range(M):
                if self.surface[i][j] != 1:
                    self.surface[i][j] = 0

    def validCell(self, x, y):
        return 0 <= x and x < N and 0 <= y and y < M and self.surface[x][y] == 0

    def inbound(self, x, y):
        return 0 <= x and x < N and 0 <= y and y < M

    def not_wall(self, x, y):
        return self.inbound(x, y) and self.surface[x][y] != 1 

    def calculate_cells(self, senzor, choice):
        x = self.senzors[senzor-1][0]
        y = self.senzors[senzor-1][1]

        colored_cells = []
        for i in range(4):
            curx = x
            cury = y
            dx = DIRECTIONS[i][0]
            dy = DIRECTIONS[i][1]

            for _ in range(choice):
                if self.not_wall(curx + dx, cury + dy):
                    self.surface[curx + dx][cury + dy] = 2
                    colored_cells.append([curx+dx, cury+dy])
                    curx = curx + dx
                    cury = cury + dy
                else:
                    break
        
        return colored_cells
        
    def path_between(self, x1,  y1, x2, y2):
        path = []
        if x1 == x2 and y1 == y2:
            return path
        q = Queue()
        q.put([x1, y1])
        self.surface[x1][y1]=2
        while q.empty() == False:
            front = q.get()
            for d in DIRECTIONS:
                x = front[0] + d[0]
                y = front[1] + d[1]
                if self.validCell(x, y):
                    self.surface[x][y] = self.surface[front[0]][front[1]]+1
                    if x == x2 and y == y2:
                        break
                    q.put([x,y])
        curx = x2
        cury = y2
        while self.surface[curx][cury] != 2:
            for i in range(4):
                newx = curx + DIRECTIONS[i][0]
                newy = cury + DIRECTIONS[i][1]
                if self.inbound(newx, newy) and self.surface[newx][newy] == self.surface[curx][cury] - 1:
                    path.insert(0, [newx, newy])
                    curx = newx
                    cury = newy
                    break
        self.refresh()
        return path

    def discovered_cells(self):
        result = 0
        for i in range(N):
            for j in range(M):
                if self.surface[i][j] == 2:
                    result = result + 1
        return result

    def expand(self, x, y):
        self.surface[x][y] = 2
        for direction in DIRECTIONS:
            currentX = x + direction[0]
            currentY = y + direction[1]
            while(self.validCell(currentX, currentY)):
                self.surface[currentX][currentY] = 2
                currentX = currentX + direction[0]
                currentY = currentY + direction[1]

    def calculateExpansion(self):
        result = 0
        for i in range(N):
            for j in range(M):
                if self.surface[i][j] == 2:
                    result = result + 1
        return result

    def createCopy(self):
        copy = Map()
        for i in range(N):
            for j in range(M):
                copy.surface[i][j] = self.surface[i][j]
        for i in range(numberOfSenzors):
            copy.senzors.append([self.senzors[i][0], self.senzors[i][1]])
        copy.start_x = self.start_x
        copy.start_y = self.start_y
        return copy

    def __str__(self):
        string=""
        for i in range(N):
            for j in range(M):
                if self.start_x == i and self.start_y == j:
                    string = string + "2"
                elif [i, j] in self.senzors:
                    string = string + "3"
                else:
                    string = string + str(int(self.surface[i][j]))
            string = string + "\n"
        
        return string