using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTestTetris.GameLogic
{
    class GameHandler
    {
        #region Class Data
        // Pieces Factory
        PiecesFactory piecesFactory = new PiecesFactory();
        private int[,] GameBoard = new int[20, 20];
        private int posX;
        private int posY;
        private Piece currentPiece = null;
        private Piece nextPiece = null;
        #endregion

        #region ctor & dtor
        public GameHandler(int h, int w)
        {
            GameBoard = new int[h, w];
        }
        #endregion
        
        #region Methods
        /// <summary>
        /// call this function every time we add new piece
        /// </summary>
        /// <returns></returns>
        public bool start()
        {
            posY = 0;
            posX = GameBoard.GetUpperBound(1) / 2;
            currentPiece = piecesFactory.getRandPieces();//nextPiece != null ? nextPiece : piecesFactory.getRandPieces();
            nextPiece = piecesFactory.getRandPieces();
            return canPosAt(currentPiece, posX, posY);
        }
        

        /// <summary>
        /// move pice one step down if possible, 
        /// if not add new pice in the top by calling start() function
        /// </summary>
        public bool takeAStepDown()
        {
            bool canTakeAStep = true;
            if (canPosAt(currentPiece, posX, posY + 1))
            {
                posY++;
            }
            else
            {
                GameBoard = gluePiece(currentPiece, GameBoard, posX, posY);
                canTakeAStep = start();
            }
            return canTakeAStep;
        }
        //

        /// <summary>
        /// glue piece in the game board and returns the new board
        /// </summary>
        /// <param name="Piece">Piece to glue</param>
        /// <param name="board">Board array to glue the piece in it</param>
        /// <param name="x">Piece X position</param>
        /// <param name="y">Piece Y position</param>
        /// <returns>the new board </returns>
        private int[,] gluePiece(Piece piece, int[,] board, int x, int y)
        {
            if (x + piece.PieceArray.GetUpperBound(1) <= board.GetUpperBound(1) && y + piece.PieceArray.GetUpperBound(0) <= board.GetUpperBound(0))
            {
                for (int i = 0; i <= piece.PieceArray.GetUpperBound(1); i++)
                {
                    for (int j = 0; j <= piece.PieceArray.GetUpperBound(0); j++)
                    {
                        if (piece.PieceArray[j, i] != 0)
                        {
                            board[y + j, x + i] = piece.PieceArray[j, i];
                        }
                    }
                }
            }
            return board;
        }

        /// <summary>
        /// handle user pressed  Key
        /// </summary>
        /// <param name="k">Tetris Key</param>
        public bool onKeyPress(Utilities.Key key)
        {
            if (key == Utilities.Key.INVALID)
                return false;
            Piece temp;
            switch (key)
            {
                case Utilities.Key.Left:
                    if (posX > 1 && canPosAt(currentPiece, posX - 1, posY))
                    {
                        posX--;
                        return true;
                    }
                    break;
                case Utilities.Key.Right:
                    if (posX < GameBoard.GetUpperBound(0) - currentPiece.PieceArray.GetUpperBound(0) && canPosAt(currentPiece, posX + 1, posY))
                    {
                        posX++;
                        return true;
                    }
                    break;
                case Utilities.Key.ROTATE_LEFT:
                    temp = new Piece(Utilities.rotateLeft(currentPiece.PieceArray));
                    if (canPosAt(temp, posX, posY))
                    {
                        currentPiece.rotateCounterClockwise();
                        return true;
                    }
                    break;
                case Utilities.Key.ROTATE_RIGHT:
                    temp = new Piece(Utilities.rotateRight(currentPiece.PieceArray));
                    if (canPosAt(temp, posX, posY))
                    {
                        currentPiece.rotateClockwise();
                        return true;
                    }
                    break;
                default:
                    return false;

            }

            return false;
        }

        /// <summary>
        /// checks if we can move a certain "piece" to a spacific pos 
        /// </summary>
        /// <param name="piece">piece to check</param>
        /// <param name="x">X Pos (0 based)</param>
        /// <param name="y">Y Pos (0 based)</param>
        /// <returns>true, if positionable</returns>
        private bool canPosAt(Piece piece, int x, int y)
        {
            int[,] copy = (int[,])GameBoard.Clone();

            if (x + piece.PieceArray.GetUpperBound(1) < copy.GetUpperBound(1) && y + piece.PieceArray.GetUpperBound(0) < copy.GetUpperBound(0))
            {
                for (int i = 0; i <= piece.PieceArray.GetUpperBound(1); i++)
                {
                    for (int j = 0; j <= piece.PieceArray.GetUpperBound(0); j++)
                    {
                        //I=X Coord
                        //J=Y Coord
                        if (piece.PieceArray[j, i] != 0)
                        {
                            if (copy[y + j, x + i] != 0)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// get actual current board
        /// </summary>
        /// <returns>current board array</returns>
        public int[,] getActualBoard()
        {
            int[,] pieceArray = (int[,])currentPiece.PieceArray.Clone();
            int[,] actualBoard = (int[,])GameBoard.Clone();


            for (int i = 0; i <= pieceArray.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= pieceArray.GetUpperBound(1); j++)
                {
                    if (pieceArray[i, j] != 0)
                    {
                        pieceArray[i, j] = 7;
                    }
                }
            }
            actualBoard = gluePiece(new Piece(pieceArray), actualBoard, posX, posY);

            return actualBoard;
        }        
        //
        public int[,] getBoard()
        {
            return GameBoard;
        }
        #endregion
    }
}
