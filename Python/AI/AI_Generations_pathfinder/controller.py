from repository import Repository
from utils import COLONIES, numberOfSenzors
from random import randint
import math

class Controller():
    def __init__(self, repository):
        self.repository = repository
        self.bestPath = []
        self.bestResult = 0

    def run(self):
        for _ in range(COLONIES):
            while len(self.repository.ants) > 0:
               pass # do smt great

            self.update_ph()
            self.repository.create_ants()

        #return path

    def update_ph(self):
            #how the fk should i DO THIS ? p = p*0.95 + new value of pheromone
            self.repository.cmap.refresh()

    def choose_destination(self, node, energy):
        totalph = 0
        for i in range(numberOfSenzors + 1):
            if energy > self.repository.graph.dist[node][i] and node != i:
                totalph = totalph + self.repository.graph.ph[node][i]
        #print(totalph)
        if totalph == 0:
            return -1
        dest = randint(0, totalph)
        for i in range(numberOfSenzors + 1):
            if energy > self.repository.graph.dist[node][i] and node != i:
                dest = dest - self.repository.graph.ph[node][i]
                if dest <= 0:
                    return i

    def choose_choice(self, node, energy):
        totalph = 0
        stop = int(min(energy, 6.0))
        for i in range(stop):
            totalph = totalph + self.repository.graph.choice_ph[node][i]
        dest = randint(0, totalph)
        for i in range(stop):
            dest = dest - self.repository.graph.choice_ph[node][i]
            if dest <= 0:
                return i