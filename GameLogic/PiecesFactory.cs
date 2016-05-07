using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTestTetris.GameLogic
{
    public class PiecesFactory
    {
        #region Members data
        private List<int[,]> Pieces;
        #endregion 
        
        #region ctor & dtor
        public PiecesFactory()
        {
            Pieces = new List<int[,]>();

            // Piece 1  
            // ****
            Pieces.Add(new int[1, 4] { { 1, 1, 1, 1 } });

            // Piece 2   
            //  *
            //  *
            //  **
            Pieces.Add(new int[3, 2] { { 1, 0},{ 1, 0}, { 1, 1 } });


            // Piece 3
            //   *
            //   *
            //  **
            Pieces.Add(new int[3, 2] { { 0,1 }, { 0, 1 }, { 1, 1 } });


            // Piece 4
            //   *
            //  **
            //  *
            Pieces.Add(new int[3, 2] { { 0, 1 }, { 1, 1 }, { 1, 0 } });           

            // Piece 5
            //   **
            //   **
            Pieces.Add(new int[2, 2] { { 1, 1 }, { 1, 1 } });
        }
        #endregion 
        
        #region Members Methods
        // get random piece (array of pair)
        public Piece getRandPieces()
        {
            int rnd = Utilities.getRandom(0, 4);
            return new Piece(this.Pieces[rnd]);
        }
        #endregion 

    }
}
