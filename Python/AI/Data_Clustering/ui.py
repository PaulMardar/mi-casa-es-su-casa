
import csv
import matplotlib.pyplot as plt
from random import uniform
import numpy as np


def plotData(inputs, outputs, colors):
    for class_ in colors:
        classInputs = [x for index, x in enumerate(inputs) if outputs[index] == class_]
        plt.scatter([x[0] for x in classInputs], [x[1] for x in classInputs], label="stars", color=colors[class_],marker="*", s=10)


def plotCentroids(centroids, color='white'):
    return plt.scatter([x[0] for x in centroids], [x[1] for x in centroids], label="stars", color=color, marker="*", s=50)


def plotComputedData(centroidToInputs, centroidToClass, colors):
    for centroid, inputs in centroidToInputs.items():
        plt.scatter([x[0] for x in inputs], [x[1] for x in inputs], label="stars", color=colors[centroidToClass[centroid]], marker="*", s=10)
    return plotCentroids(centroidToInputs.keys())


