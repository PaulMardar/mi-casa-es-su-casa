import pickle
from domain import Map, Ant, Graph
from utils import ANTS, numberOfSenzors

class Repository():
    def __init__(self):
        self.cmap = None
        self.graph = None
        self.ants = None
        self.stopped_ants = None

    def create_ants(self):
        self.ants = [Ant() for _ in range(ANTS)]
        self.stopped_ants = []
        
    def create_graph(self):
        self.graph = Graph(self.cmap)

    def random_map(self):
        self.cmap = Map()
        self.cmap.random_map()

    def save_map(self):
        with open("file.map", "wb") as file:
            pickle.dump(self.cmap, file)
    
    def load_map(self):
        with open("file.map", "rb") as file:
            self.cmap = pickle.load(file)
            