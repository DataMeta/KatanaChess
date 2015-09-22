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
        // Is default case needed?
        public static int isMoveValid(int initY, int initX, int targetY, int targetX, int[,] theBoard)
        {
            return 1;
        }

        // Will need code for pawn movement in both directions
        // Add start line clause
        // Add "not blocked" clause for double hop
        public static bool isPawnMoveValid(int initY, int initX, int targetY, int targetX, int[,] theBoard)
        {
            bool isValid;
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if ((targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1) && (deltaX != 0 && deltaY != 0)
                && (theBoard[targetY, targetX] == 0) && (deltaX == 1))
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
        public static bool isKnightMoveValid(int initY, int initX, int targetY, int targetX, int[,] theBoard)
        {
            bool isValid;
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if ((targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1) && (deltaX != 0 && deltaY != 0)
                && (deltaX == 2 && (deltaY == 1 || deltaY == -1)) || (deltaX == 1 && (deltaY == -2 || deltaY == 2))
                || (deltaX == -1 && (deltaY == 2 || deltaY == -2)) || (deltaX == -2 && (deltaY == 1 || deltaY == -1)))
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
        public static bool isBishopMoveValid(int initY, int initX, int targetY, int targetX, int[,] theBoard)
        {
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if ((targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1) 
                && (deltaX != 0 && deltaY != 0) && (deltaX == deltaY))
            {
                if(deltaY > 0)
                {
                    if(deltaX > 0)
                    {
                        for (int i = initX + 1; i < targetX - 1; i++)
                        {
                            if (theBoard[i, i] != 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else if(deltaX < 0)
                    {
                        int j = initY + 1;
                        for (int i = initX - 1; i > targetX - 1; i--)
                        {
                            if(theBoard[j, i] != 0)
                            {
                                return false;
                            }
                            j++;
                        }
                        return true;
                    }
                }
                else if(deltaY < 0)
                {
                    if (deltaX > 0)
                    {
                        int j = initY - 1;
                        for (int i = initX + 1; i > targetX + 1; i++)
                        {
                            if (theBoard[j, i] != 0)
                            {
                                return false;
                            }
                            j--;
                        }
                        return true;
                    }
                    else if (deltaX < 0)
                    {
                        for (int i = initX - 1; i < targetX + 1; i--)
                        {
                            if (theBoard[i, i] != 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        // Ready for testing with GUI
        public static bool isRookMoveValid(int initY, int initX, int targetY, int targetX, int[,] theBoard)
        {
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if ((targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1) && (deltaX != 0 && deltaY != 0))
            {
                if (deltaY == 0)
                {
                    if (deltaX > 0)
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
                    if(deltaY > 0)
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

        // Add "not blocked" clause by merging rook and bishop block checks
        public static bool isQueenMoveValid(int initY, int initX, int targetY, int targetX, int[,] theBoard)
        {
            bool isValid;
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if ((targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1) && (deltaX != 0 && deltaY != 0)
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
        public static bool isKingMoveValid(int initY, int initX, int targetY, int targetX, int[,] theBoard)
        {
            bool isValid;
            int deltaX = targetX - initX;
            int deltaY = targetY - initY;
            if ((targetX < 8 && targetX > -1 && targetY < 8 && targetY > -1) && (deltaX != 0 && deltaY != 0)
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

        public static void makeMove()
        {

        }

    }
}
