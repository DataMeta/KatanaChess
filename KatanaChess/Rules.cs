﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaChess
{
    public static class Rules
    {
        private static int deltaY;
        private static int deltaX;

        public static void makeMove(int pieceType, int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            theBoard[initY, initX] = 0;
            theBoard[targY, targX] = pieceType;
        }

        // Is default case needed? Probably not
        public static int isMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            return 1;
        }

        // Validates properly!
        public static bool isPawnMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard, int pieceType)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1))
            {
                if(pieceType == 1) // White pawn case
                {
                    if(deltaX == 0)
                    {
                        if(deltaY == -1)
                        {
                            if(theBoard[targY, targX] != 0)
                            {
                                return false;
                            }
                            return true;
                        }
                        else if(deltaY == -2 && initY == 6)
                        {
                            if ((theBoard[targY + 1, targX] != 0) || (theBoard[targY, targX] != 0))
                            {
                                return false;
                            }
                            return true;
                        }
                    }
                    else if((deltaX == 1 || deltaX == -1) && deltaY == -1)
                    {
                        if (theBoard[targY, targX] >= 0 || theBoard[targY, targX] == -6)
                        {
                            return false;
                        }
                        return true;
                    }
                }
                else if (pieceType == -1) // Black pawn case
                {
                    if (deltaX == 0)
                    {
                        if (deltaY == 1)
                        {
                            if (theBoard[targY, targX] != 0)
                            {
                                return false;
                            }
                            return true;
                        }
                        else if (deltaY == 2 && initY == 1)
                        {
                            if ((theBoard[targY, targX] != 0) || (theBoard[targY - 1, targX] != 0))
                            {
                                return false;
                            }
                            return true;
                        }
                    }
                    else if ((deltaX == 1 || deltaX == -1) && deltaY == 1)
                    {
                        if (theBoard[targY, targX] <= 0 || theBoard[targY, targX] == 6)
                        {
                            return false;
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

        // Validates properly!
        public static bool isKnightMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            int deltaX = targX - initX;
            int deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1) && (deltaX != 0 && deltaY != 0)
                && (deltaX == 2 && (deltaY == 1 || deltaY == -1)) || (deltaX == 1 && (deltaY == -2 || deltaY == 2))
                || (deltaX == -1 && (deltaY == 2 || deltaY == -2)) || (deltaX == -2 && (deltaY == 1 || deltaY == -1)))
            {
                if ((theBoard[initY, initX] == 2) && ((theBoard[targY, targX] > 0) || theBoard[targY, targX] == -6))
                {
                    return false;
                }
                else if ((theBoard[initY, initX] == -2) && ((theBoard[targY, targX] < 0) || theBoard[targY, targX] == 6))
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        // Validates properly!
        public static bool isBishopMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1) && 
                (deltaX != 0 && deltaY != 0) && (Math.Abs(deltaX) == Math.Abs(deltaY)))
            {
                if ((theBoard[initY, initX] == 3) && ((theBoard[targY, targX] > 0) || theBoard[targY, targX] == -6))
                {
                    return false;
                }
                else if ((theBoard[initY, initX] == -3) && ((theBoard[targY, targX] < 0) || theBoard[targY, targX] == 6))
                {
                    return false;
                }
                if(deltaY > 0)
                {
                    if (deltaX > 0) 
                    {
                        int j = initY + 1;
                        for (int i = initX + 1; i < targX; i++)
                        {
                            if (theBoard[j, i] != 0)
                            {
                                return false;
                            }
                            j++;
                        }
                        return true;
                    }
                    else if(deltaX < 0) 
                    {
                        int j = initY + 1;
                        for (int i = initX - 1; i > targX; i--)
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
                        for (int i = initX + 1; i < targX; i++)
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
                        int j = initY - 1;
                        for (int i = initX - 1; i > targX; i--)
                        {
                            if (theBoard[j, i] != 0)
                            {
                                return false;
                            }
                            j--;
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

        // Validates properly!
        public static bool isRookMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1) && 
                ((deltaX == 0 && deltaY != 0) || (deltaY == 0 && deltaX !=0)))
            {
                if ((theBoard[initY, initX] == 4) && ((theBoard[targY, targX] > 0)  || theBoard[targY, targX] == -6))
                {
                    return false;
                }
                else if ((theBoard[initY, initX] == -4) && ((theBoard[targY, targX] < 0) || theBoard[targY, targX] == 6))
                {
                    return false;
                }
                if (deltaY == 0)
                {
                    if (deltaX > 0)
                    {
                        for (int i = initX + 1; i < targX; i++)
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
                        for (int i = initX - 1; i > targX; i--)
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
                        for (int i = initY + 1; i < targY; i++)
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
                        for (int i = initY - 1; i > targY; i--)
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

        // Validates properly!
        public static bool isQueenMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1) &&
                ((Math.Abs(deltaX) == Math.Abs(deltaY)) || 
                (((deltaX == 0 && deltaY != 0) || (deltaY == 0 && deltaX != 0)))))
            {
                if ((theBoard[initY, initX] == 5) && ((theBoard[targY, targX] > 0) || theBoard[targY, targX] == -6))
                {
                    return false;
                }
                else if ((theBoard[initY, initX] == -5) && ((theBoard[targY, targX] < 0) || theBoard[targY, targX] == 6))
                {
                    return false;
                }
                if (deltaY == 0)
                {
                    if (deltaX > 0)
                    {
                        for (int i = initX + 1; i < targX; i++)
                        {
                            if (theBoard[initY, i] != 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else if (deltaX < 0)
                    {
                        for (int i = initX - 1; i > targX; i--)
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
                    if (deltaY > 0)
                    {
                        for (int i = initY + 1; i < targY; i++)
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
                        for (int i = initY - 1; i > targY; i--)
                        {
                            if (theBoard[i, initX] != 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    return false;
                }
                if (deltaY > 0)
                {
                    if (deltaX > 0)
                    {
                        int j = initY + 1;
                        for (int i = initX + 1; i < targX; i++)
                        {
                            if (theBoard[j, i] != 0)
                            {
                                return false;
                            }
                            j++;
                        }
                        return true;
                    }
                    else if (deltaX < 0)
                    {
                        int j = initY + 1;
                        for (int i = initX - 1; i > targX; i--)
                        {
                            if (theBoard[j, i] != 0)
                            {
                                return false;
                            }
                            j++;
                        }
                        return true;
                    }
                }
                else if (deltaY < 0)
                {
                    if (deltaX > 0)
                    {
                        int j = initY - 1;
                        for (int i = initX + 1; i < targX; i++)
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
                        int j = initY - 1;
                        for (int i = initX - 1; i > targX; i--)
                        {
                            if (theBoard[j, i] != 0)
                            {
                                return false;
                            }
                            j--;
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

        // Validates properly!
        // Add "doesn't move into check" clause, or create a separate method
        public static bool isKingMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if (targX < 8 && targX > -1 && targY < 8 && targY > -1)
            {
                if(((deltaY == 1 && (deltaX == 0 || deltaX == 1 || deltaX == -1)) || 
                    (deltaY == 0 && (deltaX == -1 || deltaX == 1)) || 
                    (deltaY == -1 && (deltaX == 0 || deltaX == -1 || deltaX == 1))))
                {
                    if ((theBoard[initY, initX] == 6) && ((theBoard[targY, targX] > 0) || (theBoard[targY, targX] == -6)))
                    {
                        return false;
                    }
                    else if ((theBoard[initY, initX] == -6) && ((theBoard[targY, targX] < 0) || (theBoard[targY, targX] == 6)))
                    {
                        return false;
                    }
                    return true;
                }
                else if(initY == 0 && initX == 4) // Black king castling
                {
                    if(deltaX == 2 && theBoard[0,7] == -4 && 
                        (theBoard[0, 5] == 0 && theBoard[0, 6] == 0)) // Kingside
                    {
                        makeMove(-4, 0, 7, 0, 5, theBoard); // Rook moves
                        return true;
                    }
                    else if (deltaX == -2 && theBoard[0, 0] == -4 &&
                        (theBoard[0, 3] == 0 && theBoard[0, 2] == 0 && theBoard[0, 1] == 0)) // Queenside
                    {
                        makeMove(-4, 0, 0, 0, 3, theBoard); // Rook moves
                        return true;
                    }
                    return false;
                }
                else if (initY == 7 && initX == 4) // White king castling
                {
                    if (deltaX == 2 && theBoard[7, 7] == 4 &&
                        (theBoard[7, 5] == 0 && theBoard[7, 6] == 0)) // Kingside
                    {
                        makeMove(4, 7, 7, 7, 5, theBoard); // Rook moves
                        return true;
                    }
                    else if (deltaX == -2 && theBoard[7, 0] == 4 &&
                        (theBoard[7, 3] == 0 && theBoard[7, 2] == 0 && theBoard[7, 1] == 0)) // Queenside
                    {
                        makeMove(4, 7, 0, 7, 3, theBoard); // Rook moves
                        return true;
                    }
                    return false;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
