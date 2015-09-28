/**/
/*
 
NAME
        Board.cs

SYNOPSIS
        int[,] pieceArray --> A 2-dimensional array that keeps track of which pieces are where

DESCRIPTION
        This class holds the data structures responsible for keeping track of the state of the board.
        That is, the position of all pieces, whose turn it is, tracking of move duplication .

AUTHOR
        Daniel Melnikov

DATE
        9/12/2015 7:28pm

*/
/**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaChess
{
    public static class Game
    {
        static int clickcount = 0, clickvalue;
        static int alphaY, alphaX, betaY, betaX; 
        static bool isValid;
        static int pieceType;

        public enum pieceID
        {
            Pawn = 1, // -1/1
            Knight = 2, // -2/2
            Bishop = 3, // -3/3
            Rook = 4, // -4/4
            Queen = 5, // -5/5
            King = 6 // -6/6
        };

        static int[,] theBoard = new int[,] { {-4, -2, -3, -5, -6, -3, -2, -4},
                                              {-1, -1, -1, -1, -1, -1, -1, -1},
                                               {0,  0,  0,  0,  0,  0,  0,  0},
                                               {0,  0,  0,  0,  0,  0,  0,  0},
                                               {0,  0,  0,  0,  0,  0,  0,  0},
                                               {0,  0,  0,  0,  0,  0,  0,  0},
                                               {1,  1,  1,  1,  1,  1,  1,  1},
                                               {4,  2,  3,  5,  6,  3,  2,  4}};

        //static int[,] theBoard = new int[,] { {-4, -2,  -3,  -5,  -6,  -3, -2,  -4},
        //                                       {-1,  -1,  -1,  -1,  -1,  -1,  -1,  -1},
        //                                       {0,  0,  0,  0,  0,  0,  0,  0},
        //                                       {0,  0,  0,  0,  0,  0,  0,  0},
        //                                       {0,  0,  0,  0,  0,  6,  0,  0},
        //                                       {0,  0,  0,  0,  1,  0,  0,  0},
        //                                       {1,  1,  1,  1,  0,  1,  1,  1},
        //                                       {4,  2,  3,  5,  0,  3,  2,  4}};
        
        // Checks the validity and legality of a move
        // Method under construction [.] 
        static public bool validateMove(int pieceType, int initY, int initX, int targY, int targX)
        {
            pieceID switchID = (pieceID)Math.Abs(pieceType);
            switch (switchID)
            {
                case pieceID.Pawn:
                    isValid = Move.isPawnMoveValid(initY, initX, targY, targX, theBoard, pieceType);
                    break;
                case pieceID.Knight:
                    isValid = Move.isKnightMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.Bishop:
                    isValid = Move.isBishopMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.Rook:
                    isValid = Move.isRookMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.Queen:
                    isValid = Move.isQueenMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.King:
                    isValid = Move.isKingMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                default:
                    //isValid = Move.isMoveValid(initX, initY, targX, targY, theBoard);
                    break;
            }
            return isValid;
        }

        // Updates the board display based on board state
        static public void updateBoardView(GameDisplay boardView)
        {
            pieceID switchID;
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
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
        static public void checkCaptures()
        {

        }

        // Accepts input from buttons
        static public void onClick(int yVal, int xVal, GameDisplay boardView)
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
                        Move.makeMove(pieceType, alphaY, alphaX, betaY, betaX, theBoard);
                        updateBoardView(boardView);
                    }
                    break;
            }
        }
    }
}
