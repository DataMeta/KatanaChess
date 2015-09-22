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
        // Add enum for pieceTypes

        static int clickcount, clickvalue;
        static int alphaY, alphaX, betaY, betaX; 
        static bool isValid;
        static int pieceType;

        public enum pieceID
        {
            Pawn, Knight, Bishop, Rook, Queen, King
        };

        static int[,] theBoard = new int[,] { {-4, -2, -3, -6, -5, -3, -2, -4},
                                              {-1, -1, -1, -1, -1, -1, -1, -1},
                                               {0,  0,  0,  0,  0,  0,  0,  0},
                                               {0,  0,  0,  0,  0,  0,  0,  0},
                                               {0,  0,  0,  0,  0,  0,  0,  0},
                                               {0,  0,  0,  0,  0,  0,  0,  0},
                                               {1,  1,  1,  1,  1,  1,  1,  1},
                                               {4,  2,  3,  5,  6,  3,  2,  4}};
        
        // Checks the validity and legality of a move
        // Method under construction [...] 
        static public bool validateMove(pieceID switchID, int initY, int initX, int targetY, int targetX)
        {
            switch (switchID)
            {
                case pieceID.Pawn:
                    isValid = Move.isPawnMoveValid(initY, initX, targetY, targetX, theBoard);
                    break;
                case pieceID.Knight:
                    isValid = Move.isKnightMoveValid(initY, initX, targetY, targetX, theBoard);
                    break;
                case pieceID.Bishop:
                    isValid = Move.isBishopMoveValid(initY, initX, targetY, targetX, theBoard);
                    break;
                case pieceID.Rook:
                    isValid = Move.isRookMoveValid(initY, initX, targetY, targetX, theBoard);
                    break;
                case pieceID.Queen:
                    isValid = Move.isQueenMoveValid(initY, initX, targetY, targetX, theBoard);
                    break;
                case pieceID.King:
                    isValid = Move.isKingMoveValid(initY, initX, targetY, targetX, theBoard);
                    break;
                default:
                    //isValid = Move.isMoveValid(initX, initY, targetX, targetY, theBoard);
                    break;
            }
            return isValid;
        }

        // Checks for captured pieces within the previous turn and updates the capList
        static public void checkCaptures()
        {

        }

        // Updates the board display based on board state
        static public void updateBoard()
        {
            
        }

        static public void onClick(int yVal, int xVal)
        {
		    clickcount++;
		    clickvalue = clickcount % 2;
		
		    switch(clickvalue)
		    {
			    case 1:
                    alphaY = yVal;
                    alphaX = xVal;
                    pieceType = theBoard[alphaY, alphaX];

                    break;
                case 2:
                    betaY = yVal;
                    betaX = xVal;

                    if(validateMove((pieceID)Math.Abs(pieceType), alphaY, alphaX, betaY, betaX))
                    {
                        //Move.makeMove();
                    }
                    break;
            }
        }
    }
}
