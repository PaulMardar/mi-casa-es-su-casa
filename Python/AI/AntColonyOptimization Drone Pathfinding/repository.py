# -*- coding: utf-8 -*-

import pickle
from domain import *


class repository():
    def __init__(self, map, drone, energy, sensors):
        self.cmap = map
        self.drone = drone
        self.sensors = sensors
        self.energy = energy
        self.computeSeenSquares(self.sensors)

    # compute seen squares (number of eventual seen squares / number of squares seen on the go)

    def computeSeenSquares(self, sensors):
        for i in range(len(sensors)):
            for j in range(1, 6):
                sensors[i].seenSquares[j] = self.cmap.readUDMSensors(sensors[i].getX(), sensors[i].getY(), j)
                if sensors[i].seenSquares[j] > sensors[i].seenSquares[j - 1]:
                    sensors[i].maxSeenSquares = sensors[i].seenSquares[j]
                    sensors[i].maxBattery = j

    def getSensors(self):
        return self.sensors

    def setSensors(self, sensors):
        self.sensors = sensors

    def getDistanceMatrix(self):
        return self.distanceMatrix

    def setDistanceMatrix(self, distanceMatrix):
        self.distanceMatrix = distanceMatrix

    def getEnergy(self):
        return self.energy

    def setEnergy(self, energy):
        self.energy = energy

    def loadMap(self):
        self.cmap.loadMap("test1.map")

    def saveMap(self):
        self.cmap.saveMap("test.map")

    def getMap(self):
        return self.cmap

    def getDrone(self):
        return self.drone