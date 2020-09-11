class BoardError(Exception):
    pass

class Console:

    def __init__(self, service):
        self.__service=service
        self.m = int(input("introdu m "))
        self.n = self.m

    def initializare_board(self):
        """
        creates the board
        """
        self.__service.create_board(self.m,self.n)


    def print_board(self):
        for i in range(self.n):
            for j in range(self.m):
                print(str(self.__service.board[i][j]), end= " " )
            print()

    def do_move(self):
        x = int(input("introdu coloana unde vrei sa faci o mutare: "))
        y = int(input("introdu linia unde vrei sa faci mutarea: "))
        if(x<=0 or y<=0 or x >self.m or y>self.n):
            raise BoardError
        self.__service.player_move(x,y,self.m,self.n)
    def ai_do_move(self):
        self.__service.ai_move(self.m , self.n)


    def run(self):
        self.initializare_board()
        while True:
            try:
                self.print_board()
                print(self.__service.board_empty_spaces(self.m, self.n))
            #    print(self.__service.board)
                self.do_move()
                if(self.__service.board_empty_spaces(self.m,self.n) == 0):
                    print("PLAYER WINS")
                    self.print_board()
                    return
                self.ai_do_move()
                if (self.__service.board_empty_spaces(self.m,self.n) ==0):
                    print("AI WINS")
                    self.print_board()
                    return
            except BoardError:
                print('Try a valid move next time')
            except OverflowError:
                print("OVER FLOW try again a move where the central point is 0")
            except Exception:
                print("excepting a stupid exception")
        pass
