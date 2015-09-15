using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaChess
{
    public class Move
    {
        // Check move for validity
        // All methods under construction [...]
        public static int isMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            return 1;
        }

        // Add start line clause
        // Will need code for pawn movement in the other direction
        // Confirm "not blocked" clause (recheck later)
        public static bool isPawnMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            int diffX = targetX - initX;
            int diffY = targetY - initY;
            if ((theBoard[targetX,targetY] == 0) && (diffX == 1) && (targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isKnightMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            int diffX = targetX - initX;
            int diffY = targetY - initY;
            if((diffX == 2 && (diffY == 1 || diffY == -1)) || (diffX == 1 && (diffY == -2 || diffY == 2))
                || (diffX == -1 && (diffY == 2 || diffY == -2)) || (diffX == -2 && (diffY == 1 || diffY == -1))
                && (targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Add "not blocked" clause
        public static bool isBishopMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            int diffX = targetX - initX;
            int diffY = targetY - initY;
            if ((diffX == diffY) && (targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1)
                && (targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Add "not blocked" clause
        public static bool isRookMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            int diffX = targetX - initX;
            int diffY = targetY - initY;
            if (((diffX > 0 && diffY == 0) || (diffY > 0 && diffX == 0)) 
                && (targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Add bishop + rook rules
        // Add "not blocked" clause
        // Add "not out of bounds" clause
        public static int isQueenMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            int diffX = targetX - initX;
            int diffY = targetY - initY;
            return 1;
        }

        // Add movement rules
        // Add "not blocked" clause
        // Add "doesn't move into check" clause
        // Add "not out of bounds" clause
        public static int isKingMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            int diffX = targetX - initX;
            int diffY = targetY - initY;
            return 1;
        }
    }
}
