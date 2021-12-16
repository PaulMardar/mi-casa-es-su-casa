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
    pygame.display.set_caption("Drone Ant Colony Optimization")
    
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
    

def movingDrone(currentMap, path, speed = 1,  markSeen = True):
    # animation of a drone on a path
    
    screen = initPyGame((N * 20, M * 20))

    drona = pygame.image.load("drona.png")
        
    for i in range(len(path)):
        screen.blit(image(currentMap), (0,0))
        
        brick = pygame.Surface((20,20))
        brick.fill(GREEN)
        for j in range(i+1):
            screen.blit(brick, (path[j][1] * 20, path[j][0] * 20))
        
        screen.blit(drona, (path[i][1] * 20, path[i][0] * 20))
        senzor = pygame.Surface((20, 20))
        senzor.fill(RED)
        for senz in currentMap.senzors:
            screen.blit(senzor, (senz[1] * 20, senz[0] * 20))

        openCell = pygame.Surface((20, 20))
        openCell.fill(GRAYBLUE)
        if([path[i][0], path[i][1]] in currentMap.senzors):
            idx = currentMap.senzors.index([path[i][0], path[i][1]])
            cells = currentMap.calculate_cells(idx+1, path[i][2])
            for cell in cells:
                print(cell[0], cell[1])
                screen.blit(openCell, (cell[1] * 20, cell[0] * 20))
        pygame.display.flip()
        time.sleep(0.5 * speed)            
    closePyGame()
        
def image(currentMap, colour = BLUE, background = WHITE):
    # creates the image of a map
    
    imagine = pygame.Surface((N * 20, M * 20))
    brick = pygame.Surface((20,20))
    brick.fill(colour)
    imagine.fill(background)
    for i in range(N):
        for j in range(M):
            if (currentMap.surface[i][j] == 1):
                imagine.blit(brick, ( j * 20, i * 20))
    senzor = pygame.Surface((20, 20))
    senzor.fill(RED)
    for senz in currentMap.senzors:
        imagine.blit(senzor, (senz[1] * 20, senz[0] * 20))
    return imagine

def showMap(cmap):
    screen = initPyGame((N*20, M*20))
    screen.blit(image(cmap), (0,0)) 
    drona = pygame.image.load("drona.png")        
    screen.blit(drona, (cmap.start_y * 20, cmap.start_x * 20))
    pygame.display.flip()
    closePyGame()
