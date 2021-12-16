from gui import *
from controller import *
from repository import *
from domain import *
import statistics
from matplotlib import pyplot

def copyList(clist):
    newList = []
    for elem in clist:
        newList.append(elem)
    return newList

def printMenu():
    print("0. exit")
    print("1. map options")
    print("2. algorithm options")

def printMapOptions():
    print("0. exit")
    print("1. create random map")
    print("2. load map")
    print("3. save map")
    print("4. visualise map")

def printAlgorithmOptions():
    print("0. exit")
    print("1. run solver")
    print("2. view best path")

def main():
    repository = Repository()
    controller = Controller(repository)

    while True:
        printMenu()
        userInput = input(">")
        if userInput == "0":
            break
        elif userInput == "1":
            while True:
                printMapOptions()
                userInput = input(">")
                if userInput == "0":
                    break
                elif userInput == "1":
                    repository.random_map()
                    repository.create_graph()
                    repository.create_ants()
                    controller = Controller(repository)
                elif userInput == "2":
                    repository.load_map()
                    repository.create_graph()
                    repository.create_ants()
                    controller = Controller(repository)
                elif userInput == "3":
                    controller.repository.save_map()
                elif userInput == "4":
                    string=""
                    for i in range(numberOfSenzors + 1):
                        for j in range(numberOfSenzors + 1):
                            string = string + str(int(controller.repository.graph.dist[i][j]))
                            string = string + " "
                        string = string + "\n"
                    print(string)
                    showMap(repository.cmap)
        elif userInput == "2":
            best_path = []
            while True:
                printAlgorithmOptions()
                userInput = input(">")
                if userInput == "0":
                    break
                elif userInput == "1":
                    best_path = controller.run()
                elif userInput == "2":
                    print(best_path)
                    movingDrone(controller.repository.cmap, best_path)


if __name__ == "__main__":
    main()