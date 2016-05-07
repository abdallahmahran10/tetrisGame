using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingTestTetris.GameLogic
{
    public class Piece
    {
        public int[,] PieceArray{set;get;}
        //
        public Piece(int[,] pieceArray)
        {
            this.PieceArray = pieceArray;
        }
        //
        #region Piece methods
        public int[,] rotateClockwise()
        {
            PieceArray = Utilities.rotateRight(this.PieceArray);
            return PieceArray;
        }
        //
        public int[,] rotateCounterClockwise()
        {
            PieceArray = Utilities.rotateLeft(this.PieceArray);
            return PieceArray;
        }
        #endregion
    }
}
