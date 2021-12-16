# -*- coding: utf-8 -*-

from pygame.locals import *
import pygame, time
from utils import *
from domain import *

def initPyGame(dimension):
    # init the pygame
    pygame.init()
    logo = pygame.image.load("logo32x32.png")
    pygame.display.set_icon(logo)
    pygame.display.set_caption("drone exploration with ACO")
    
    # create a surface on screen that has the size of 800 x 480
    screen = pygame.display.set_mode(dimension)
    screen.fill(WHITE)
    return screen


def closePyGame():
    # closes the pygame
    running = True
    # loop for events
    while running:
        # event handling, gets all event from the event queue
        for event in pygame.event.get():
            # only do something if the event is of type QUIT
            if event.type == pygame.QUIT:
                # change the value to False, to exit the main loop
                running = False
    pygame.quit()
    

def movingDrone(currentMap, path, sensors, drone, speed = 1,  markSeen = True):
    # animation of a drone on a path
    
    screen = initPyGame((currentMap.n * 20, currentMap.m * 20))

    drona = pygame.image.load("drona.png")

    brickS = pygame.Surface((20, 20))
    brickS.fill(RED)
    brickD = pygame.Surface((20, 20))
    brickD.fill(BLACK)
    sensorPositions = []
    for i in range(len(path)):
        screen.blit(image(currentMap), (0,0))
        for s in sensors:
            x = s.getX()
            y = s.getY()
            sensorPositions.append([x, y])
            screen.blit(brickS, (y * 20, x * 20))
        if markSeen:
            brick = pygame.Surface((20,20))
            brick.fill(GREEN)
            for j in range(i+1):
                x = path[j][0]
                y = path[j][1]
                if [x, y] in sensorPositions:
                    screen.blit(brickS, (y * 20, x * 20))
                elif drone.getStartX() == x and drone.getStartY() == y:
                    screen.blit(brickD, (y * 20, x * 20))
                else:
                    screen.blit(brick, (y * 20, x * 20))

        screen.blit(drona, (path[i][1] * 20, path[i][0] * 20))
        pygame.display.flip()
        time.sleep(0.5 * speed)            
    closePyGame()
        
def image(currentMap, colour = BLUE, background = WHITE):
    # creates the image of a map
    
    imagine = pygame.Surface((currentMap.n * 20, currentMap.m * 20))
    brick = pygame.Surface((20, 20))
    brick.fill(colour)
    imagine.fill(background)
    for i in range(currentMap.n):
        for j in range(currentMap.m):
            if (currentMap.surface[i][j] == 1):
                imagine.blit(brick, ( j * 20, i * 20))
                
    return imagine        
    