# -*- coding: utf-8 -*-
import pickle
from random import *

import numpy
import pygame

from utils import *
import numpy as np

class Map():
    def __init__(self, n=20, m=20):
        self.n = n
        self.m = m
        self.surface = np.zeros((self.n, self.m))

    def randomMap(self, fill=0.2):
        for i in range(self.n):
            for j in range(self.m):
                if random() <= fill:
                    self.surface[i][j] = 1

    def randomValidPosition(self):
        while True:
            x = randint(0, self.n - 1)
            y = randint(0, self.m - 1)
            if self.surface[x][y] == 0:
                return [x, y]

    def __str__(self):
        string = ""
        for i in range(self.n):
            for j in range(self.m):
                string = string + str(int(self.surface[i][j]))
            string = string + "\n"
        return string

    def valid_position(self, a, b):
        return a >= 0 and a < self.n and b >= 0 and b < self.m and self.surface[a][b] != 1

    def saveMap(self, numFile="test.map"):
        with open(numFile, 'wb') as f:
            pickle.dump(self, f)
            f.close()

    def loadMap(self, numfile):
        with open(numfile, "rb") as f:
            dummy = pickle.load(f)
            self.n = dummy.n
            self.m = dummy.m
            self.surface = dummy.surface
            f.close()

    def readUDMSensors(self, x, y, rangeR):
        discovered = 0

        range = rangeR
        xf = x - 1
        while xf >= 0 and self.surface[xf][y] == 0 and range > 0:
            discovered += 1
            xf = xf - 1
            range -= 1

        range = rangeR
        xf = x + 1
        while xf < self.n and self.surface[xf][y] == 0 and range > 0:
            discovered += 1
            xf = xf + 1
            range -= 1

        range = rangeR
        yf = y + 1
        while yf < self.m and self.surface[x][yf] == 0 and range > 0:
            discovered += 1
            yf = yf + 1
            range -= 1

        range = rangeR
        yf = y - 1
        while yf >= 0 and self.surface[x][yf] == 0 and range > 0:
            discovered += 1
            yf = yf - 1
            range -= 1

        return discovered


class Drone():
    def __init__(self, x, y):
        self.x = x
        self.y = y
        self.startX = x
        self.startY = y
        self.path = dict()
        self.distances = dict()

    def mapWithDrone(self, mapImage):
        drona = pygame.image.load("drona.png")
        mapImage.blit(drona, (self.y * 20, self.x * 20))

        return mapImage

    def getStartX(self):
        return self.startX

    def getStartY(self):
        return self.startY

class Sensor():
    def __init__(self, id, x, y):
        self.__id = id
        self.__x = x
        self.__y = y
        self.seenSquares = [0, 0, 0, 0, 0, 0] # initialised from repo
        self.path = dict()
        self.maxSeenSquares = 0 # repo
        self.maxBattery = 0 # repo

    def setPath(self, otherSensor, p):
        self.path[otherSensor] = p

    def getPath(self, otherSensor):
        return self.path[otherSensor]

    def getID(self):
        return self.__id

    def getX(self):
        return self.__x

    def getY(self):
        return self.__y

    def getSeenSquares(self):
        return self.seenSquares

    def setSeenSqares(self, x):
        self.seenSquares = x


