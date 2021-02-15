import random

class Service:

    def __init__(self):
        self.board = []

    def create_board(self, m, n):
        """
        m int
        n int
        create a matrix of m X n
        """
        x = []
        for i in range(m):
            x.append(0)
        for i in range(n):
            self.board.append(x[:])

    def board_empty_spaces(self,m,n):
        nr =0
        for i in range(m):
            for j in range(n):
                if(self.board[i][j] == 0):
                    nr=nr+1
        return nr


    @property
    def return_board(self=None):
        return self.board

    def player_move(self,a,y,m,n):
        if (self.valid_move(a,y)==False):
            raise OverflowError
        for i in range(3):
            for j in range(3):
                if((a-i)>=0 and (y-j)>=0 and (a-i)<m and (y-j)<n):
                    self.board[a-i][y-j]=1

    def valid_move(self,x,y):
        if (self.board[x-1][y-1]== 1):
            return False
        else:
            return True

    def ai_move(self, m , n ):
        ai_on=True
        if self.board_empty_spaces(m,n)<25 and ai_on== True:
            pass
        #implement the AI

        for i in range(m):
            for j in range(n):
                x=random.randrange(1,m)
                y=random.randrange(1,n)
                if (self.board[x-1][y-1] == 0):
                    for i1 in range(3):
                        for j1 in range(3):
                            if ((x - i1) >= 0 and (y - j1) >= 0 and (x - i1) < m and (y - j1) < n):
                                self.board[x - i1][y - j1] = 1
                    return
        for x in range(m):
            for y in range(n):
                if(self.board[x][y]==0):
                    for i in range(3):
                        for j in range(3):
                            if ((x - i) >= 0 and (y - j) >= 0 and (x - i) < m and (y - j) < n):
                                self.board[x - i][y - j] = 1



    def minmax(self, curentDEPTH, indexNod,maxTurn,score,targetDepth):
        if(curentDEPTH == targetDepth):
            return score[indexNod]
        if(maxTurn):
            return max(self.minmax((curentDEPTH+1,indexNod*2,False,)))
            pass

    def score(self,m,n):
        score =m*n-self.board_empty_spaces(m,n)
        return score

"""     self.board[a][y-1]= 1
        self.board[a-2][y-1]= 1
        self.board[a-1][y-1]=1   # the one point 
        self.board[a][y]= 1
        self.board[a-2][y]= 1
        self.board[a-1][y]=1
        self.board[a][y-2]= 1
        self.board[a-2][y-2]= 1
        self.board[a-1][y-2]=1
"""




