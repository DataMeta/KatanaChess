/**/
/*
 
NAME
        Board.cs

SYNOPSIS
        int[,] pieceArray --> A 2-dimensional array that keeps track of which pieces are where

DESCRIPTION
        This class holds the data structures responsible for keeping track of the state of the board.
        That is, the position of all pieces, whose turn it is, tracking of move duplication .

RETURNS
        Returns true if the open was successful and false if it was opened
        as a phantom.  One of these two cases will always occur.

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
    class Board
    {
        static int[,] pieceArray = new int[,]{ {-4, -2, -3, -6, -5, -3, -2, -4},
                                               {-1, -1, -1, -1, -1, -1, -1, -1},
                                                {0,  0,  0,  0,  0,  0,  0,  0},
                                                {0,  0,  0,  0,  0,  0,  0,  0},
                                                {0,  0,  0,  0,  0,  0,  0,  0},
                                                {0,  0,  0,  0,  0,  0,  0,  0},
                                                {1,  1,  1,  1,  1,  1,  1,  1},
                                                {4,  2,  3,  5,  6,  3,  2,  4}};   
    }
}
