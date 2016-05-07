using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTestTetris.GameLogic
{
    class ConsoleUIHandler : IUIHandler
    {
        #region class data
        private GameHandler gameHandler=new GameHandler(20,20);
        #endregion

        #region ctor & dtor
        public ConsoleUIHandler()
        {
            Console.Clear();
            Console.CursorVisible = false;
            gameHandler.start();
        }
        #endregion

        #region Class methods
        //
        public void onStart()
        {
            Console.WriteLine( "\nPress Enter to start");
            Console.ReadLine();
            Console.Clear();
            drawGameBoard(gameHandler.getActualBoard());
        }
        //
        public void drawGameBoard(int[,] gameBoard) {
            for (int i = 0; i <= gameBoard.GetUpperBound(0); i++) {
                Console.Write("*");
                for (int j = 1; j <= gameBoard.GetUpperBound(1)-1; j++)
                {
                    if (i == gameBoard.GetUpperBound(0))
                        Console.Write(Utilities.FilledPoint);
                    else if (gameBoard[i, j] != 0)
                        Console.Write(Utilities.FilledPoint);
                    else
                        Console.Write(Utilities.EmptyPoint);
                }
                Console.WriteLine(Utilities.FilledPoint);
            }
        }
        //
        public bool handleUsreInput(Utilities.Key _key)
        {
            if (gameHandler.onKeyPress(_key)) {
                if (gameHandler.takeAStepDown())
                    refresh();
                else
                    return false;
            }
            return true ;
        }
        //
        public void refresh()
        {
            Console.Clear();
            drawGameBoard(gameHandler.getActualBoard());
            //gameHandler.step();
        }
        //
        public void tellUser(string words)
        {
            Console.WriteLine(words);
        }
        //
        public void onGameFinish()
        {
            Console.Clear();
            Console.WriteLine("No possible move, Game Finished!\nGoodbye :( ...");
            Console.ReadLine();
        }
        #endregion

    }
}
