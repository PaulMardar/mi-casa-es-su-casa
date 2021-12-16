# -*- coding: utf-8 -*-

#Creating some colors
BLUE  = (0, 0, 255)
GRAYBLUE = (50,120,120)
RED   = (255, 0, 0)
GREEN = (0, 255, 0)
BLACK = (0, 0, 0)
WHITE = (255, 255, 255)

ENERGY = 70
SENSORS = 7
NUMBER_OF_ANTS = 4
ITERATIONS = 1000
Q0 = 0.2
Q = 500
RHO = 0.9
ALPHA = 0.8
BETA = 2
C = 1.0

#define directions
UP = 0
DOWN = 2
LEFT = 1
RIGHT = 3

#define indexes variations 
v = [[-1, 0], [1, 0], [0, 1], [0, -1]]

#define mapsize 

mapLengh = 20

MAX_VALUE = 22334142142141