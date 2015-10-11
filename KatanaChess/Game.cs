using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaChess
{
    /// <summary>
    /// * NAME: 
    ///     Game.cs
    /// 
    /// * DESCRIPTION
    ///     This class holds the data structure responsible for keeping track of the state of the board.
    ///     That is, the position of all pieces, whose turn it is, tracking of move duplication .
    /// 
    /// * AUTHOR:
    ///     Daniel Melnikov
    /// 
    /// * DATE:
    ///     9/12/15
    /// </summary>
    public static class Game
    {
        private static int clickcount = 0, clickvalue;
        private static int alphaY, alphaX, betaY, betaX; 
        private static bool isValid;
        private static int pieceType;

        public enum pieceID
        {
            Pawn = 1, // -1/1
            Knight = 2, // -2/2
            Bishop = 3, // -3/3
            Rook = 4, // -4/4
            Queen = 5, // -5/5
            King = 6 // -6/6
        };

        private static int[,] theBoard = new int[,] { {-4, -2, -3, -5, -6, -3, -2, -4},
                                              {-1, -1, -1, -1, -1, -1, -1, -1},
                                              { 0,  0,  0,  0,  0,  0,  0,  0},
                                              { 0,  0,  0,  0,  0,  0,  0,  0},
                                              { 0,  0,  0,  0,  0,  0,  0,  0},
                                              { 0,  0,  0,  0,  0,  0,  0,  0},
                                              { 1,  1,  1,  1,  1,  1,  1,  1},
                                              { 4,  2,  3,  5,  6,  3,  2,  4}};
        
        /// <summary>
        /// * NAME: 
        /// * SYNOPSIS:
        /// * DESCRIPTION: 
        ///     Determines and calls the appropriate function to check the legality and validity of a move
        /// * AUTHOR:
        /// * DATE:
        ///  
        /// </summary>
        /// <param name="pieceType"></param>
        /// <param name="initY"></param>
        /// <param name="initX"></param>
        /// <param name="targY"></param>
        /// <param name="targX"></param>
        /// <returns name="isValid"></returns>
        public static bool validateMove(int pieceType, int initY, int initX, int targY, int targX)
        {
            pieceID switchID = (pieceID)Math.Abs(pieceType);
            switch (switchID)
            {
                case pieceID.Pawn:
                    isValid = Rules.isPawnMoveValid(initY, initX, targY, targX, theBoard, pieceType);
                    break;
                case pieceID.Knight:
                    isValid = Rules.isKnightMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.Bishop:
                    isValid = Rules.isBishopMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.Rook:
                    isValid = Rules.isRookMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.Queen:
                    isValid = Rules.isQueenMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.King:
                    isValid = Rules.isKingMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                default:
                    isValid = false;
                    break;
            }
            return isValid;
        }

        // Updates the board display based on board state
        public static void updateBoardView(GameDisplay boardView)
        {
            pieceID switchID;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switchID = (pieceID)Math.Abs(theBoard[i, j]);
                    pieceType = theBoard[i, j];
                    switch (switchID)
                    {
                        case pieceID.Pawn:
                            if (pieceType == 1)
                            {
                                boardView.setButtonImage(i, j, 1); 
                            }
                            else if (pieceType == -1)
                            {
                                boardView.setButtonImage(i, j, -1);
                            }
                            break;
                        case pieceID.Knight:
                            if (pieceType == 2)
                            {
                                boardView.setButtonImage(i, j, 2);
                            }
                            else if (pieceType == -2)
                            {
                                boardView.setButtonImage(i, j, -2);
                            }
                            break;
                        case pieceID.Bishop:
                            if (pieceType == 3)
                            {
                                boardView.setButtonImage(i, j, 3);
                            }
                            else if (pieceType == -3)
                            {
                                boardView.setButtonImage(i, j, -3);
                            }
                            break;
                        case pieceID.Rook:
                            if (pieceType == 4)
                            {
                                boardView.setButtonImage(i, j, 4);
                            }
                            else if (pieceType == -4)
                            {
                                boardView.setButtonImage(i, j, -4);
                            }
                            break;
                        case pieceID.Queen:
                            if (pieceType == 5)
                            {
                                boardView.setButtonImage(i, j, 5);
                            }
                            else if (pieceType == -5)
                            {
                                boardView.setButtonImage(i, j, -5);
                            }
                            break;
                        case pieceID.King:
                            if (pieceType == 6)
                            {
                                boardView.setButtonImage(i, j, 6);
                            }
                            else if (pieceType == -6)
                            {
                                boardView.setButtonImage(i, j, -6);
                            }
                            break;
                        default:
                            boardView.setButtonImage(i, j, 0);
                            break;
                    }
                }
            }
        }

        // Checks for captured pieces within the previous turn and updates the capList
        public static void checkCaptures()
        {

        }

        // Accepts input from buttons
        public static void onClick(int yVal, int xVal, GameDisplay boardView)
        {
		    clickvalue = clickcount % 2;
            clickcount++;
		
		    switch(clickvalue)
		    {
			    case 0:
                    alphaY = yVal;
                    alphaX = xVal;
                    pieceType = theBoard[alphaY, alphaX];
                    
                    break;
                case 1:
                    betaY = yVal;
                    betaX = xVal;

                    if(validateMove(pieceType, alphaY, alphaX, betaY, betaX))
                    {
                        Rules.makeMove(pieceType, alphaY, alphaX, betaY, betaX, theBoard);
                        Rules.checkPawnConvert(theBoard);
                        updateBoardView(boardView);
                        Katana.swingKatana(theBoard);
                        Rules.checkPawnConvert(theBoard);
                        updateBoardView(boardView);
                    }
                    break;
            }
        }
    }
}
