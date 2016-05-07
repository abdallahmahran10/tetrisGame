using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTestTetris.GameLogic
{
    public interface IUIHandler
    {
        /// <summary>
        /// on game start, init display screen and game handler
        /// </summary>
        void onStart();
        /// <summary>
        /// Draw a game board array
        /// </summary>
        /// <param name="gameBoard">game board to draw</param>
        void drawGameBoard(int[,] gameBoard);
        /// <summary>
        /// handle user input 
        /// </summary>
        /// <param name="_key">user input</param>
        /// <returns></returns>
        bool handleUsreInput(Utilities.Key _key);
        /// <summary>
        /// refresh the screen
        /// </summary>
        void refresh();
        /// <summary>
        /// display something to the user
        /// </summary>
        /// <param name="words">something to display</param>
        void tellUser(string words);
        /// <summary>
        /// handle operations on game finish like clearing the screen 
        /// and display goodbye msg
        /// </summary>
        void onGameFinish();
    }
}
