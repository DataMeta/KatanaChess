using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaChess
{
    public static class Move
    {
        // Check move for validity
        // All methods under construction [...]
        public static int isMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            return 1;
        }

        // Will need code for pawn movement in both direction
        // Add start line clause
        // Add "not blocked" clause for double hop
        public static bool isPawnMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            bool isValid;
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if ((targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1)
                && (theBoard[targetX, targetY] == 0) && (deltaX == 1))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }

        // Ready for testing with GUI
        public static bool isKnightMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            bool isValid;
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if((deltaX == 2 && (deltaY == 1 || deltaY == -1)) || (deltaX == 1 && (deltaY == -2 || deltaY == 2))
                || (deltaX == -1 && (deltaY == 2 || deltaY == -2)) || (deltaX == -2 && (deltaY == 1 || deltaY == -1))
                && (targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }

        // Add "not blocked" clause
        public static bool isBishopMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            bool isValid;
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if ((targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1)
                && (deltaX == deltaY) && (targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }

        // Almost ready for testing with GUI
        public static bool isRookMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if (targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1)
            {
                if (deltaY == 0)
                {
                    if(deltaX == 0)
                    {
                        return false;
                    }
                    else if (deltaX > 0)
                    {
                        for (int i = initX + 1; i < targetX - 1; i++)
                        {
                            if(theBoard[initY, i] != 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else if (deltaX < 0)
                    {
                        for (int i = initX - 1; i > targetX + 1; i--)
                        {
                            if (theBoard[initY, i] != 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
                else if (deltaX == 0) 
                {
                    if(deltaY == 0)
                    {
                        return false;
                    }
                    else if(deltaY > 0)
                    {
                        for (int i = initY + 1; i < targetY - 1; i++)
                        {
                            if (theBoard[i, initX] != 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else if (deltaY < 0)
                    {
                        for (int i = initY - 1; i > targetY + 1; i--)
                        {
                            if (theBoard[i, initX] != 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        // Add "not blocked" clause
        public static bool isQueenMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            bool isValid;
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if ((targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1) 
                && (((deltaX == deltaY) && (targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1)) 
                || ((deltaY == 0 && (deltaX > 0 || deltaX < 0)) || (deltaX == 0 && (deltaY > 0 || deltaX < 0)))))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }

        // Add "doesn't move into check" clause
        public static bool isKingMoveValid(int initX, int initY, int targetX, int targetY, int[,] theBoard)
        {
            bool isValid;
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if ((targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1)
                && (deltaX == 1 && (deltaY == 0 || deltaY == 1 || deltaY == -1)) 
                || (deltaX == 0 && (deltaY == -1 || deltaY == 1))
                || (deltaX == -1 && (deltaY == 0 || deltaY == -1 || deltaY == 1)))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
