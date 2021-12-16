import csv
import matplotlib.pyplot as plt
from random import uniform
import numpy as np
from ui import *

def loadData(fileName, firstVal, secondVal, outputLabel):
    data = []
    with open(fileName) as csv_file:
        csv_reader = csv.reader(csv_file, delimiter=',')
        rows = list(csv_reader)
        dataNames = rows[0]
        for row in rows[1:]:
            data.append(row)

    return [(float(data[i][dataNames.index(firstVal)]), float(data[i][dataNames.index(secondVal)])) for i in range(len(data))], [str(data[i][dataNames.index(outputLabel)]) for i in range(len(data))]
    # list with all points fancy

def euclideanDistance(leftPos, rightPos):
    return np.linalg.norm(np.array(leftPos) - np.array(rightPos))

def generateClusters(domain, numberOfClusters=4, tabu=None):
    clustersSet = set()
    (xBottom, yBottom), (xTop, yTop) = domain
    while len(clustersSet) != numberOfClusters:
        centroid = uniform(xBottom, xTop), uniform(yBottom, yTop)
        if tabu is not None and centroid not in tabu:
            clustersSet.add(centroid)
        else:
            clustersSet.add(centroid)
    return clustersSet


def convertCentroidToClasses(centroids):
    centroidsKeys = list(centroids.keys())
    left = min(centroidsKeys, key=lambda x: x[0])
    centroidsKeys.remove(left)

    right = max(centroidsKeys, key=lambda x: x[0])
    centroidsKeys.remove(right)

    bottom = min(centroidsKeys, key=lambda x: x[1])
    centroidsKeys.remove(bottom)

    top = centroidsKeys[0]

    return {left: 'A', top: 'B', right: 'C', bottom: 'D'}

def getMaxAndMin(matrix):
    firstCol = [x[0] for x in matrix]
    secondCol = [x[1] for x in matrix]
    return (min(firstCol), min(secondCol)), (max(firstCol), max(secondCol))

def createStatistics(real, computed, labels):
    acc = sum([1 if realLabel == computedLabel else 0  for realLabel, computedLabel in zip(real, computed)]) / len(inputs)
    precision = {}
    rappel = {}

    for label in labels:
        correct = sum([1 if realLabel == computedLabel == label else 0 for realLabel, computedLabel in zip(real, computed)])
        total = sum([1 if computedLabel == label else 0 for realLabel, computedLabel in zip(real, computed)])
        precision[label] = correct / total
        total = sum([1 if realLabel == label else 0 for realLabel, computedLabel in zip(real, computed)])
        rappel[label] = correct / total

    score = {classifications: 2 * P * R / (P + R) for (classifications, P), R in zip(precision.items(), rappel.values())}
    return {'acc': acc, 'precision': precision, 'rappel': rappel, 'score': score}


def main(clustersSet, matrixInputs, outputs):
    centroids = list(clustersSet)[:]
    keepGoing = True

    clustersToSet = {centroid: [] for centroid in centroids}
    while keepGoing:
        keepGoing = False
        inputToCentroid = {}
        for input in matrixInputs:
            inputToCentroid[input] = min(centroids, key=lambda centroid: euclideanDistance(input, centroid))

        clustersToSet = {centroid: [input for input, inputCentroid in inputToCentroid.items() if inputCentroid == centroid] for centroid in centroids}

        newCentroids = [(sum([x[0] for x in sets]) / len(sets), sum([x[1] for x in sets]) / len(sets)) if len(sets) != 0
                        else None for centroid, sets in clustersToSet.items()]

        validCentroids = [centroid for centroid in newCentroids if centroid is not None]
        if len(clustersSet) - len(validCentroids) != 0:
            print('not a centroid!')
            newCentroids = validCentroids + list(generateClusters(getMaxAndMin(matrixInputs), len(clustersSet) - len(validCentroids), validCentroids))

        for newCentroid in newCentroids:
            keepGoing = keepGoing or newCentroid not in centroids

        if keepGoing:
            centroids = newCentroids
        else:
            centroidToClass = convertCentroidToClasses(clustersToSet)
            print(centroidToClass)
            print('statistics')
            computedDict = {}
            for centroid, set in clustersToSet.items():
                for input in set:
                    computedDict[input] = centroidToClass[centroid]
            Labels = [computedDict[input] for input in matrixInputs]

            for values, result in createStatistics(outputs, Labels, colors.keys()).items():
                print(f"{values}: {result}")

        points = plotAll(matrixInputs, outputs, clustersToSet, colors)
        plt.pause(0.1)
        if keepGoing:
            points.remove()

    return clustersToSet


def plotAll(inputs, outputs, centroidToInputs, colors):
    centroidToClass = convertCentroidToClasses(centroidToInputs)

    plt.subplot(1, 2, 1)
    points = plotComputedData(centroidToInputs, centroidToClass, colors)
    plt.title('GEenerated Output')
    return points

inputs, outputs = loadData('dataset.csv', 'val1', 'val2', 'label')

colors = {
    'A': 'green',
    'B': 'blue',
    'C': 'pink',
    'D': 'red'
}

main(generateClusters(getMaxAndMin(inputs)), inputs, outputs)
plt.show()