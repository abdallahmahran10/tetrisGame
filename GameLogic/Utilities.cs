using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTestTetris.GameLogic
{
    public class Utilities
    {
        /// <summary>
        /// Available Tetris Keys
        /// </summary>
        public enum Key
        {
            Left,
            Right,
            ROTATE_RIGHT,
            ROTATE_LEFT,
            INVALID
        }
        static private Random random = new Random();
        //
        public static string FilledPoint = "*";
        public static string EmptyPoint  = " ";
        //
        public static int getRandom(int start, int end)
        {
            return random.Next(start, end);
        }
        //
        /// <summary>
        /// Rotates a piece clockwise
        /// </summary>
        /// <param name="pieceArray">piece to rotate</param>
        /// <returns>rotated array</returns>
        public static int[,] rotateRight(int[,] pieceArray)
        {
            int w = pieceArray.GetUpperBound(0) + 1;
            int h = pieceArray.GetUpperBound(1) + 1;
            int[,] rotated = new int[h, w];
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    rotated[j, w - i - 1] = pieceArray[i, j];
                }
            }

            return rotated;
        }
        //
        /// <summary>
        /// Rotates a piece clockwise 3 Times to achive a counter clockwise
        /// </summary>
        /// <param name="pieceArray">piece to rotate</param>
        /// <returns>rotated piece</returns>
        public static int[,] rotateLeft(int[,] pieceArray)
        {
            return rotateRight(rotateRight(rotateRight(pieceArray)));
        }
    }
}
