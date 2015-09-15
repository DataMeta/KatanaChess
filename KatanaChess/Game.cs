﻿/**/
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
    public class Game
    {
        static int[,] theBoard = new int[,] { {-4, -2, -3, -6, -5, -3, -2, -4},
                                       {-1, -1, -1, -1, -1, -1, -1, -1},
                                        {0,  0,  0,  0,  0,  0,  0,  0},
                                        {0,  0,  0,  0,  0,  0,  0,  0},
                                        {0,  0,  0,  0,  0,  0,  0,  0},
                                        {0,  0,  0,  0,  0,  0,  0,  0},
                                        {1,  1,  1,  1,  1,  1,  1,  1},
                                        {4,  2,  3,  5,  6,  3,  2,  4}};
        
        // checks the validity and legality of a move
        // consider untilizing algebraic chess notation for parameter passing
        // method under construction [...] 
        static bool validateMove(string pieceType, int initX, int initY, int targetX, int targetY)
        {
            switch (pieceType)
            {
                case "pawn":
                    Move.isPawnMoveValid(initX, initY, targetX, targetY, theBoard);
                    break;
                case "knight":
                    Move.isKnightMoveValid(initX, initY, targetX, targetY, theBoard);
                    break;
                case "bishop":
                    Move.isBishopMoveValid(initX, initY, targetX, targetY, theBoard);
                    break;
                case "rook":
                    Move.isRookMoveValid(initX, initY, targetX, targetY, theBoard);
                    break;
                case "queen":
                    Move.isQueenMoveValid(initX, initY, targetX, targetY, theBoard);
                    break;
                case "king":
                    Move.isKingMoveValid(initX, initY, targetX, targetY, theBoard);
                    break;
                default:
                    Move.isMoveValid(initX, initY, targetX, targetY, theBoard);
                    break;
            }
            return false;
        }

        // checks for captured pieces within the previous turn and updates the capList
        static void checkCaptures()
        {

        }

        // updates the state of the board in memory
        static void updateBoard()
        {

        }
    }
}
