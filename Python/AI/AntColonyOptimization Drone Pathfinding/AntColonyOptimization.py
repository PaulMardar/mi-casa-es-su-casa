from random import *

import numpy
import pygame

from utils import *
import numpy as np

from ant import *


class AntColonyOptimization():
    def __init__(this, distanceMatrix):
        this.graph = distanceMatrix
        this.numberOfSensors = len(this.graph)
        this.numberOfAnts = NUMBER_OF_ANTS
        this.trails = np.zeros((this.numberOfSensors, this.numberOfSensors))
        this.probabilities = [0.0] * this.numberOfSensors

        this.ants = []

        for i in range(this.numberOfAnts):
            this.ants.append(Ant(this.numberOfSensors))

        # from utils
        this.iterations = ITERATIONS
        this.q0 = Q0

        this.rho = RHO
        this.alpha = ALPHA
        this.beta = BETA

        this.c = C
        this.currentIndex = -1
        this.bestTourOrder = []
        this.bestTourLength = -1

    def run(this):
        for i in range(this.iterations):
            this.solve()
        return this.bestTourLength, this.bestTourOrder

    def solve(this):
        this.setUpAnts()
        this.clearTrails()
        for i in range(this.numberOfSensors - 1):
            this.moveAnts()
        this.updateBest()

    def moveAnts(this):
        for ant in this.ants:
            x = this.selectNextCity(ant)
            ant.visitSensor(this.currentIndex, x)
            this.trails[ant.trail[this.currentIndex]][x] *= this.rho
            this.trails[ant.trail[this.currentIndex]][x] += 1 / this.graph[ant.trail[this.currentIndex]][x]
            this.trails[x][ant.trail[this.currentIndex]] = this.trails[ant.trail[this.currentIndex]][x]
        this.currentIndex += 1

    def selectNextCity(this, ant):
        # x = random()
        # if x < this.q0:
        #     toVisit = -1
        #     arg = -1
        #     for sensor in range(this.numberOfSensors):
        #         if ant.checkVisited(sensor) is False:
        #             if this.trails[ant.trail[this.currentIndex]][sensor] ** ALPHA * (1 / this.graph[ant.trail[this.currentIndex]][sensor]) ** BETA > arg:
        #                 arg = this.trails[ant.trail[this.currentIndex]][sensor] ** ALPHA * (1 / this.graph[ant.trail[this.currentIndex]][sensor]) ** BETA
        #                 toVisit = sensor
        # #     return toVisit
        # else:
        this.computeProbabilities(ant)
        r = random()
        total = 0.0
        for i in range(this.numberOfSensors):
            total += this.probabilities[i]
            if total >= r:
                return i

    def computeProbabilities(this, ant):
        pheromone = 0.0
        for sensor in range(this.numberOfSensors):
            if ant.checkVisited(sensor) is False:
                pheromone += this.trails[ant.trail[this.currentIndex]][sensor] ** ALPHA * (
                            1 / this.graph[ant.trail[this.currentIndex]][sensor]) ** BETA
        for sensor in range(this.numberOfSensors):
            if ant.checkVisited(sensor):
                this.probabilities[sensor] = 0.0
            else:
                numerator = this.trails[ant.trail[this.currentIndex]][sensor] ** ALPHA * (
                            1 / this.graph[ant.trail[this.currentIndex]][sensor]) ** BETA
                this.probabilities[sensor] = numerator / pheromone

    def updateBest(this):
        if this.bestTourOrder == []:
            this.bestTourOrder = this.ants[0].trail
            this.bestTourLength = this.ants[0].trailLength(this.graph)
        for ant in this.ants:
            if ant.trailLength(this.graph) < this.bestTourLength:
                this.bestTourLength = ant.trailLength(this.graph)
                this.bestTourOrder = ant.trail.copy()

    def setUpAnts(this):
        for ant in this.ants:
            ant.clear()
            ant.visitSensor(-1, SENSORS)  # visit the drone
        this.currentIndex = 0

    def clearTrails(this):
        for i in range(this.numberOfSensors):
            for j in range(this.numberOfSensors):
                this.trails[i][j] = this.c
        if this.bestTourLength > -1:
            for i in range(len(this.bestTourOrder) - 1):
                this.trails[i][i + 1] += 1 / this.bestTourLength
