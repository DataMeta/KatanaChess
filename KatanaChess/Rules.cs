using System;
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
        private static int kingY;
        private static int kingX;
        private static bool blockFlag = false;

        public static void makeMove(int pieceType, int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            theBoard[initY, initX] = 0;
            theBoard[targY, targX] = pieceType;
        }

        public static bool isKingInCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            blockFlag = false;
            // White player case
            if(theBoard[initY, initX] > 0) 
            {
                // Determine position of white King
                for (int i = 0; i < 8; i++) 
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if(theBoard[i, j] == 6)
                        {
                            kingY = i;
                            kingX = j;
                        }
                    }
                }
                    
                // Black Rook/Queen scan

                if (kingY + 1 < 8) // Out of bounds checking
                {
                    for (int i = kingY + 1; i < 8; i++) // Vertical down
                    {
                        if (theBoard[i, kingX] == -4 || theBoard[i, kingX] == -5 && theBoard[i - 1, kingX] == 0)
                        {
                            for (int n = i - 1; n > kingY; n--) // Scan back for blocking pieces
                            { 
                                if (theBoard[n, kingX] != 0)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                if (kingY - 1 > -1) // Out of bounds check
                {
                    for (int i = kingY - 1; i > -1; i--) // Vertical up
                    {
                        if (theBoard[i, kingX] == -4 || theBoard[i, kingX] == -5 && theBoard[i + 1, kingX] == 0)
                        {
                            for (int n = i + 1; n < kingY; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[n, kingX] != 0)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                if (kingX + 1 < 8) // Out of bounds check
                {
                    for (int i = kingX + 1; i < 8; i++) // Horizontal right
                    {
                        if (theBoard[kingY, i] == -4 || theBoard[kingY, i] == -5 && theBoard[kingY, i - 1] == 0)
                        {
                            for (int n = i - 1; n > kingX; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[kingY, n] != 0)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                if (kingX - 1 > -1) // Out of bounds check
                {
                    for (int i = kingX - 1; i > -1; i--) // Horizontal left
                    {
                        if (theBoard[kingY, i] == -4 || theBoard[kingY, i] == -5 && theBoard[kingY, i + 1] == 0)
                        {
                            for (int n = i + 1; n < kingX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[kingY, n] != 0)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }

                // Black Bishop/Queen scan
                int k;
                if (kingY + 1 < 8) // Out of bounds check
                {
                    blockFlag = false;
                    k = kingY + 1;
                    for (int i = kingX + 1; i < 8; i++) // Diagonal down-right
                    {
                        if (theBoard[k, i] == -3 || theBoard[k, i] == -5 && theBoard[k - 1, i - 1] == 0)
                        {
                            int m = k - 1;
                            for (int n = i - 1; n > kingX; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0)
                                {
                                    blockFlag = true;
                                }
                                m--;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (k + 1 < 8)
                        {
                            k++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    blockFlag = false;
                    k = kingY + 1;
                    for (int i = kingX - 1; i > -1; i--) // Diagonal down-left
                    {
                        if (theBoard[k, i] == -3 || theBoard[k, i] == -5 && theBoard[k - 1, i + 1] == 0)
                        {
                            int m = k - 1;
                            for (int n = i + 1; n < kingX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0)
                                {
                                    blockFlag = true;
                                }
                                m--;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (k + 1 < 8)
                        {
                            k++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (kingY - 1 > -1) // Out of bounds check
                {
                    blockFlag = false;
                    k = kingY - 1;
                    for (int i = kingX + 1; i < 8; i++) // Diagonal up-right
                    {
                        if (theBoard[k, i] == -3 || theBoard[k, i] == -5 && theBoard[k + 1, i - 1] == 0)
                        {
                            int m = k + 1;
                            for (int n = i - 1; n > kingX; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0)
                                {
                                    blockFlag = true;
                                }
                                m++;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (k - 1 > -1)
                        {
                            k--;
                        }
                        else
                        {
                            break;
                        }
                    }

                    blockFlag = false;
                    k = kingY - 1;
                    for (int i = kingX - 1; i > -1; i--) // Diagonal up-left
                    {
                        if (theBoard[k, i] == -3 || theBoard[k, i] == -5 && theBoard[k + 1, i + 1] == 0)
                        {
                            int m = k + 1;
                            for (int n = i + 1; n < kingX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0)
                                {
                                    blockFlag = true;
                                }
                                m++;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (k - 1 > -1)
                        {
                            k--;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                // Black Knight scan
                if (kingY + 1 < 8 && kingY + 1 > -1 && kingX + 2 < 8 && kingX + 2 > - 1 
                    && theBoard[kingY + 1, kingX + 2] == -2) // 1 Down 2 Right
                {
                    return true;
                }
                if (kingY + 2 < 8 && kingY + 2 > -1 && kingX + 1 < 8 && kingX + 1 > -1
                    && theBoard[kingY + 2, kingX + 1] == -2) // 2 Down 1 Right
                {
                    return true;
                }
                if (kingY + 2 < 8 && kingY + 2 > -1 && kingX - 1 < 8 && kingX - 1 > -1 
                    && theBoard[kingY + 2, kingX - 1] == -2) // 2 Down 1 Left
                {
                    return true;
                }
                if (kingY + 1 < 8 && kingY + 1 > -1 && kingX - 2 < 8 && kingX - 2 > -1
                    && theBoard[kingY + 1, kingX - 2] == -2) // 1 Down 2 Left
                {
                    return true;
                }
                if (kingY - 1 < 8 && kingY - 1 > -1 && kingX - 2 < 8 && kingX - 2 > -1 
                    && theBoard[kingY - 1, kingX - 2] == -2) // 1 Up 2 Left
                {
                    return true;
                }
                if (kingY - 2 < 8 && kingY - 2 > -1 && kingX - 1 < 8 && kingX - 1 > -1 
                    && theBoard[kingY - 2, kingX - 1] == -2) // 2 Up 1 Left
                {
                    return true;
                }
                if (kingY - 2 < 8 && kingY - 2 > -1 && kingX + 1 < 8 && kingX + 1 > -1 
                    && theBoard[kingY - 2, kingX + 1] == -2) // 2 Up 1 Right
                {
                    return true;
                }
                if (kingY - 1 < 8 && kingY - 1 > -1 && kingX + 2 < 8 && kingX + 2 > -1 
                    && theBoard[kingY - 1, kingX + 2] == -2) // 1 Up 2 Right
                {
                    return true;
                }

                // Black Pawn scan
                if (kingY - 1 < 8 && kingY - 1 > -1 && kingX + 1 < 8 && kingX + 1 > -1
                    && theBoard[kingY - 1, kingX + 1] == -1) // Diagonal up right
                {
                    return true;
                }
                if (kingY - 1 < 8 && kingY - 1 > -1 && kingX - 1 < 8 && kingX - 1 > -1
                    && theBoard[kingY - 1, kingX - 1] == -1) // Diagonal up left
                {
                    return true;
                }
                return false;
            }

            // Black player case
            else if (theBoard[initY, initX] < 0) 
            {
                for (int i = 0; i < 8; i++) 
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if(theBoard[i, j] == -6)
                        {
                            kingY = i;
                            kingX = j;
                        }
                    }
                }
                    
                // White Rook/Queen scan
                if (kingY + 1 < 8) // Out of bounds check
                {
                    for (int i = kingY + 1; i < 8; i++) // Vertical down
                    {
                        if (theBoard[i, kingX] == 4 || theBoard[i, kingX] == 5 && theBoard[i - 1, kingX] == 0) 
                        {
                            for(int n = i - 1; n > kingX; n--)
                            {
                                if (theBoard[n, kingX] != 0)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                if (kingY - 1 > -1) // Out of bounds check
                {
                    for (int i = kingY - 1; i > -1; i--) // Vertical up
                    {
                        if (theBoard[i, kingX] == 4 || theBoard[i, kingX] == 5 && theBoard[i + 1, kingX] == 0)
                        {
                            for (int n = i + 1; n < kingX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[n, kingX] != 0)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                if (kingX + 1 < 8) // Out of bounds check
                {
                    for (int i = kingX + 1; i < 8; i++) // Horizontal right
                    {
                        if (theBoard[kingY, i] == 4 || theBoard[kingY, i] == 5 && theBoard[kingY, i - 1] == 0)
                        {
                            for (int n = i - 1; n > kingY; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[kingY, n] != 0)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                if (kingX - 1 > -1) // Out of bounds check
                {
                    for (int i = kingX - 1; i > -1; i--) // Horizontal left 
                    {
                        if (theBoard[kingY, i] == 4 || theBoard[kingY, i] == 5 && theBoard[kingY, i + 1] == 0)
                        {
                            for (int n = i + 1; n < kingY; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[kingY, n] != 0)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                
                // White Bishop/Queen scan
                int k;
                if (kingY + 1 < 8) // Out of bound check
                {
                    blockFlag = false;
                    k = kingY + 1;
                    for (int i = kingX + 1; i < 8; i++) // Diagonal down-right
                    {
                        if (theBoard[k, i] == 3 || theBoard[k, i] == 5 && theBoard[k - 1, i - 1] == 0)
                        {
                            int m = k - 1;
                            for (int n = i - 1; n > kingX; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0)
                                {
                                    blockFlag = true;
                                }
                                m--;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (k + 1 < 8)
                        {
                            k++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    blockFlag = false;
                    k = kingY + 1;
                    for (int i = kingX - 1; i > -1; i--) // Diagonal down-left
                    {
                        if (theBoard[k, i] == 3 || theBoard[k, i] == 5 && theBoard[k - 1, i + 1] == 0)
                        {
                            int m = k - 1;
                            for (int n = i + 1; n < kingX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0)
                                {
                                    blockFlag = true;
                                }
                                m--;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (k + 1 < 8)
                        {
                            k++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (kingY - 1 > -1) // Out of bounds check
                {
                    blockFlag = false;
                    k = kingY - 1;
                    for (int i = kingX + 1; i < 8; i++) // Diagonal up-right
                    {
                        if (theBoard[k, i] == 3 || theBoard[k, i] == 5 && theBoard[k + 1, i + 1] == 0)
                        {
                            int m = k + 1;
                            for (int n = i - 1; n > kingX; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0)
                                {
                                    blockFlag = true;
                                }
                                m++;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (k - 1 > -1)
                        {
                            k--;
                        }
                        else
                        {
                            break;
                        }
                    }

                    blockFlag = false;
                    k = kingY - 1;
                    for (int i = kingX - 1; i > -1; i--) // Diagonal up-left
                    {
                        if (theBoard[k, i] == 3 || theBoard[k, i] == 5 && theBoard[k + 1, i - 1] == 0)
                        {
                            int m = k + 1;
                            for (int n = i + 1; n < kingX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0)
                                {
                                    blockFlag = true;
                                }
                                m++;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (k - 1 > -1)
                        {
                            k--;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                // White Knight scan
                if (kingY + 1 < 8 && kingY + 1 > -1 && kingX + 2 < 8 && kingX + 2 > - 1 
                    && theBoard[kingY + 1, kingX + 2] == 2) // 1 Down 2 Right
                {
                    return true;
                }
                if (kingY + 2 < 8 && kingY + 2 > -1 && kingX + 1 < 8 && kingX + 1 > -1
                    && theBoard[kingY + 2, kingX + 1] == 2) // 2 Down 1 Right
                {
                    return true;
                }
                if (kingY + 2 < 8 && kingY + 2 > -1 && kingX - 1 < 8 && kingX - 1 > -1 
                    && theBoard[kingY + 2, kingX - 1] == 2) // 2 Down 1 Left
                {
                    return true;
                }
                if (kingY + 1 < 8 && kingY + 1 > -1 && kingX - 2 < 8 && kingX - 2 > -1
                    && theBoard[kingY + 1, kingX - 2] == 2) // 1 Down 2 Left
                {
                    return true;
                }
                if (kingY - 1 < 8 && kingY - 1 > -1 && kingX - 2 < 8 && kingX - 2 > -1 
                    && theBoard[kingY - 1, kingX - 2] == 2) // 1 Up 2 Left
                {
                    return true;
                }
                if (kingY - 2 < 8 && kingY - 2 > -1 && kingX - 1 < 8 && kingX - 1 > -1 
                    && theBoard[kingY - 2, kingX - 1] == 2) // 2 Up 1 Left
                {
                    return true;
                }
                if (kingY - 2 < 8 && kingY - 2 > -1 && kingX + 1 < 8 && kingX + 1 > -1 
                    && theBoard[kingY - 2, kingX + 1] == 2) // 2 Up 1 Right
                {
                    return true;
                }
                if (kingY - 1 < 8 && kingY - 1 > -1 && kingX + 2 < 8 && kingX + 2 > -1 
                    && theBoard[kingY - 1, kingX + 2] == 2) // 1 Up 2 Right
                {
                    return true;
                }

                // White Pawn scan
                if (kingY + 1 < 8 && kingY + 1 > -1 && kingX + 1 < 8 && kingX + 1 > -1
                    && theBoard[kingY + 1, kingX + 1] == 1) // Diagonal down right
                {
                    return true;
                }
                if (kingY + 1 < 8 && kingY + 1 > -1 && kingX - 1 < 8 && kingX - 1 > -1
                    && theBoard[kingY + 1, kingX - 1] == 1) // Diagonal down left
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool doesMovePutKingInCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            blockFlag = false;
            // White case
            if (theBoard[initY, initX] > 0)
            {
                // Black Rook/Queen scan

                if (targY + 1 < 8) // Out of bounds check
                {
                    for (int i = targY + 1; i < 8; i++) // Vertical down
                    {
                        if (theBoard[i, targX] == -4 || theBoard[i, targX] == -5 && theBoard[i - 1, targX] == 0)
                        {
                            for (int n = i - 1; n > targY; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[n, targX] != 0 && theBoard[n, targX] != 6)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                if (targY - 1 > -1) // Out of bounds check
                {
                    for (int i = targY - 1; i > -1; i--) // Vertical up
                    {
                        if (theBoard[i, targX] == -4 || theBoard[i, targX] == -5 && theBoard[i + 1, targX] == 0)
                        {
                            for (int n = i + 1; n < targY; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[n, targX] != 0 && theBoard[n, targX] != 6)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                if (targX + 1 < 8) // Out of bounds check
                {
                    for (int i = targX + 1; i < 8; i++) // Horizontal right
                    {
                        if (theBoard[targY, i] == -4 || theBoard[targY, i] == -5 && theBoard[targY, i - 1] == 0)
                        {
                            for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[targY, n] != 0 && theBoard[targY, n] != 6)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                if (targX - 1 > -1) // Out of bounds check
                {
                    for (int i = targX - 1; i > -1; i--) // Horizontal left
                    {
                        if (theBoard[targY, i] == -4 || theBoard[targY, i] == -5 && theBoard[targY, i + 1] == 0)
                        {
                            for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[targY, n] != 0 && theBoard[targY, n] != 6)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                
                // Black Bishop/Queen scan
                int j;
                if (targY + 1 < 8) // Out of bounds check
                {
                    blockFlag = false;
                    j = targY + 1;
                    for (int i = targX + 1; i < 8; i++) // Diagonal down-right
                    {
                        if (theBoard[j, i] == -3 || theBoard[j, i] == -5 && theBoard[j - 1, i - 1] == 0)
                        {
                            int m = j - 1;
                            for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0 && theBoard[m, n ] != 6)
                                {
                                    blockFlag = true;
                                }
                                m--;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (j + 1 < 8)
                        {
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    blockFlag = false;
                    j = targY + 1;
                    for (int i = targX - 1; i > -1; i--) // Diagonal down-left
                    {
                        if (theBoard[j, i] == -3 || theBoard[j, i] == -5 && theBoard[j - 1, i + 1] == 0)
                        {
                            int m = j - 1;
                            for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0 && theBoard[m, n] != 6)
                                {
                                    blockFlag = true;
                                }
                                m--;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (j + 1 < 8)
                        {
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (targY - 1 > -1) // Out of bounds check
                {
                    blockFlag = false;
                    j = targY - 1;
                    for (int i = targX + 1; i < 8; i++) // Diagonal up-right
                    {
                        if (theBoard[j, i] == -3 || theBoard[j, i] == -5 && theBoard[j + 1, i - 1] == 0)
                        {
                            int m = j + 1;
                            for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0 && theBoard[m, n] != 6)
                                {
                                    blockFlag = true;
                                }
                                m++;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (j - 1 > -1)
                        {
                            j--;
                        }
                        else
                        {
                            break;
                        }
                    }

                    blockFlag = false;
                    j = targY - 1;
                    for (int i = targX - 1; i > -1; i--) // Diagonal up-left
                    {
                        if (theBoard[j, i] == -3 || theBoard[j, i] == -5 && theBoard[j + 1, i + 1] == 0)
                        {
                            int m = j + 1;
                            for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0 && theBoard[m, n] != 6)
                                {
                                    blockFlag = true;
                                }
                                m++;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (j - 1 > -1)
                        {
                            j--;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                // Black Knight scan
                if (targY + 1 < 8 && targY + 1 > -1 && targX + 2 < 8 && targX + 2 > -1
                    && theBoard[targY + 1, targX + 2] == -2) // 1 Down 2 Right
                {
                    return true;
                }
                if (targY + 2 < 8 && targY + 2 > -1 && targX + 1 < 8 && targX + 1 > -1
                    && theBoard[targY + 2, targX + 1] == -2) // 2 Down 1 Right
                {
                    return true;
                }
                if (targY + 2 < 8 && targY + 2 > -1 && targX - 1 < 8 && targX - 1 > -1
                    && theBoard[targY + 2, targX - 1] == -2) // 2 Down 1 Left
                {
                    return true;
                }
                if (targY + 1 < 8 && targY + 1 > -1 && targX - 2 < 8 && targX - 2 > -1
                    && theBoard[targY + 1, targX - 2] == -2) // 1 Down 2 Left
                {
                    return true;
                }
                if (targY - 1 < 8 && targY - 1 > -1 && targX - 2 < 8 && targX - 2 > -1
                    && theBoard[targY - 1, targX - 2] == -2) // 1 Up 2 Left
                {
                    return true;
                }
                if (targY - 2 < 8 && targY - 2 > -1 && targX - 1 < 8 && targX - 1 > -1
                    && theBoard[targY - 2, targX - 1] == -2) // 2 Up 1 Left
                {
                    return true;
                }
                if (targY - 2 < 8 && targY - 2 > -1 && targX + 1 < 8 && targX + 1 > -1
                    && theBoard[targY - 2, targX + 1] == -2) // 2 Up 1 Right
                {
                    return true;
                }
                if (targY - 1 < 8 && targY - 1 > -1 && targX + 2 < 8 && targX + 2 > -1
                    && theBoard[targY - 1, targX + 2] == -2) // 1 Up 2 Right
                {
                    return true;
                }

                // Black Pawn scan
                if (targY - 1 < 8 && targY - 1 > -1 && targX + 1 < 8 && targX + 1 > -1
                    && theBoard[targY - 1, targX + 1] == -1) // Diagonal up right
                {
                    return true;
                }
                if (targY - 1 < 8 && targY - 1 > -1 && targX - 1 < 8 && targX - 1 > -1
                    && theBoard[targY - 1, targX - 1] == -1) // Diagonal up left
                {
                    return true;
                }

                // Black King scan

                if (targY + 1 < 8 && targY + 1 > -1 && targX + 1 < 8 && targX + 1 > -1) // SE
                {
                    if (theBoard[targY + 1, targX + 1] == -6)
                    {
                        return true;
                    }
                }
                if (targY - 1 < 8 && targY - 1 > -1 && targX + 1 < 8 && targX + 1 > -1) // NE
                {
                    if (theBoard[targY - 1, targX + 1] == -6)
                    {
                        return true;
                    }
                }
                if (targY - 1 < 8 && targY - 1 > -1 && targX - 1 < 8 && targX - 1 > -1) // NW
                {
                    if (theBoard[targY - 1, targX - 1] == -6)
                    {
                        return true;
                    }
                }
                if (targY + 1 < 8 && targY + 1 > -1 && targX - 1 < 8 && targX - 1 > -1) // SW
                {
                    if (theBoard[targY + 1, targX - 1] == -6)
                    {
                        return true;
                    }
                }
                if (targY + 1 < 8 && targY + 1 > -1) // S
                {
                    if (theBoard[targY + 1, targX] == -6)
                    {
                        return true;
                    }
                }
                if (targY - 1 < 8 && targY - 1 > -1) // N
                {
                    if (theBoard[targY - 1, targX] == -6)
                    {
                        return true;
                    }
                }
                if (targX + 1 < 8 && targX + 1 > -1) // E
                {
                    if (theBoard[targY, targX + 1] == -6)
                    {
                        return true;
                    }
                }
                if (targX - 1 < 8 && targX - 1 > -1) // W
                {
                    if (theBoard[targY, targX - 1] == -6)
                    {
                        return true;
                    }
                }
                blockFlag = false;
                return false;
            }

            // Black case
            else if (theBoard[initY, initX] < 0)
            {
                // White Rook/Queen scan

                if (targY + 1 < 8) // Out of bounds checking
                {
                    for (int i = targY + 1; i < 8; i++) // Vertical down
                    {
                        if (theBoard[i, targX] == 4 || theBoard[i, targX] == 5 && theBoard[i - 1, targX] == 0)
                        {
                            for (int n = i - 1; n > targY; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[n, targX] != 0 && theBoard[n, targX] != -6)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }

                if (targY - 1 > -1) // Out of bounds check
                {
                    for (int i = targY - 1; i > -1; i--) // Vertical up
                    {
                        if (theBoard[i, targX] == 4 || theBoard[i, targX] == 5 && theBoard[i + 1, targX] == 0)
                        {
                            for (int n = i + 1; n < targY; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[n, targX] != 0 && theBoard[n, targX] != -6)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }

                if (targX + 1 < 8) // Out of bounds check
                {
                    for (int i = targX + 1; i < 8; i++) // Horizontal right
                    {
                        if (theBoard[targY, i] == 4 || theBoard[targY, i] == 5 && theBoard[targY, i - 1] == 0)
                        {
                            for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[targY, n] != 0 && theBoard[targY, n] != -6)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }

                if (targX - 1 > -1) // Out of bounds check
                {
                    for (int i = targX - 1; i > -1; i--) // Horizontal left
                    {
                        if (theBoard[targY, i] == 4 || theBoard[targY, i] == 5 && theBoard[targY, i + 1] == 0)
                        {
                            for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[targY, n] != 0 && theBoard[targY, n] != -6)
                                {
                                    blockFlag = true;
                                }
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false;
                            }
                        }
                    }
                }
                

                // White Bishop/Queen scan
                int j;

                if (targY + 1 < 8) // Out of bounds check
                {
                    blockFlag = false;
                    j = targY + 1;
                    for (int i = targX + 1; i < 8; i++) // Diagonal down-right
                    {
                        if (theBoard[j, i] == 3 || theBoard[j, i] == 5 && theBoard[j - 1, i - 1] == 0)
                        {
                            int m = j - 1;
                            for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0 && theBoard[m, n] != -6)
                                {
                                    blockFlag = true;
                                }
                                m--;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if(j + 1 < 8)
                        {
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    blockFlag = false;
                    j = targY + 1;
                    for (int i = targX - 1; i > -1; i--) // Diagonal down-left
                    {
                        if (theBoard[j, i] == 3 || theBoard[j, i] == 5 && theBoard[j - 1, i + 1] == 0)
                        {
                            int m = j - 1;
                            for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0 && theBoard[m, n] != -6)
                                {
                                    blockFlag = true;
                                }
                                m--;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (j + 1 < 8)
                        {
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                
                if(targY - 1 > -1) // Out of bounds check
                {
                    blockFlag = false;
                    j = targY - 1;
                    for (int i = targX + 1; i < 8; i++) // Diagonal up-right
                    {
                        if (theBoard[j, i] == 3 || theBoard[j, i] == 5 && theBoard[j + 1, i - 1] == 0)
                        {
                            int m = j + 1;
                            for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0 && theBoard[m, n] != -6)
                                {
                                    blockFlag = true;
                                }
                                m++;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (j - 1 > -1)
                        {
                            j--;
                        }
                        else
                        {
                            break;
                        }
                    }

                    blockFlag = false;
                    j = targY - 1;
                    for (int i = targX - 1; i > -1; i--) // Diagonal up-left
                    {
                        if (theBoard[j, i] == 3 || theBoard[j, i] == 5 && theBoard[j + 1, i + 1] == 0)
                        {
                            int m = j + 1;
                            for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
                            {
                                if (theBoard[m, n] != 0 && theBoard[m, n] != -6)
                                {
                                    blockFlag = true;
                                }
                                m++;
                            }
                            if (blockFlag == false)
                            {
                                return true;
                            }
                            else
                            {
                                blockFlag = false; // Reset flag
                            }
                        }
                        if (j - 1 > -1)
                        {
                            j--;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                // White Knight scan
                if (targY + 1 < 8 && targY + 1 > -1 && targX + 2 < 8 && targX + 2 > -1
                    && theBoard[targY + 1, targX + 2] == 2) // 1 Down 2 Right
                {
                    return true;
                }
                if (targY + 2 < 8 && targY + 2 > -1 && targX + 1 < 8 && targX + 1 > -1
                    && theBoard[targY + 2, targX + 1] == 2) // 2 Down 1 Right
                {
                    return true;
                }
                if (targY + 2 < 8 && targY + 2 > -1 && targX - 1 < 8 && targX - 1 > -1
                    && theBoard[targY + 2, targX - 1] == 2) // 2 Down 1 Left
                {
                    return true;
                }
                if (targY + 1 < 8 && targY + 1 > -1 && targX - 2 < 8 && targX - 2 > -1
                    && theBoard[targY + 1, targX - 2] == 2) // 1 Down 2 Left
                {
                    return true;
                }
                if (targY - 1 < 8 && targY - 1 > -1 && targX - 2 < 8 && targX - 2 > -1
                    && theBoard[targY - 1, targX - 2] == 2) // 1 Up 2 Left
                {
                    return true;
                }
                if (targY - 2 < 8 && targY - 2 > -1 && targX - 1 < 8 && targX - 1 > -1
                    && theBoard[targY - 2, targX - 1] == 2) // 2 Up 1 Left
                {
                    return true;
                }
                if (targY - 2 < 8 && targY - 2 > -1 && targX + 1 < 8 && targX + 1 > -1
                    && theBoard[targY - 2, targX + 1] == 2) // 2 Up 1 Right
                {
                    return true;
                }
                if (targY - 1 < 8 && targY - 1 > -1 && targX + 2 < 8 && targX + 2 > -1
                    && theBoard[targY - 1, targX + 2] == 2) // 1 Up 2 Right
                {
                    return true;
                }

                // White Pawn scan
                if (targY + 1 < 8 && targY + 1 > -1 && targX + 1 < 8 && targX + 1 > -1
                    && theBoard[targY + 1, targX + 1] == 1) // Diagonal down right
                {
                    return true;
                }
                if (targY + 1 < 8 && targY + 1 > -1 && targX - 1 < 8 && targX - 1 > -1
                    && theBoard[targY + 1, targX - 1] == 1) // Diagonal down left
                {
                    return true;
                }

                // White King scan

                if (targY + 1 < 8 && targY + 1 > -1 && targX + 1 < 8 && targX + 1 > -1) // SE
                {
                    if (theBoard[targY + 1, targX + 1] == 6)
                    {
                        return true;
                    }
                }
                if (targY - 1 < 8 && targY - 1 > -1 && targX + 1 < 8 && targX + 1 > -1) // NE
                {
                    if (theBoard[targY - 1, targX + 1] == 6)
                    {
                        return true;
                    }
                }
                if (targY - 1 < 8 && targY - 1 > -1 && targX - 1 < 8 && targX - 1 > -1) // NW
                {
                    if (theBoard[targY - 1, targX - 1] == 6)
                    {
                        return true;
                    }
                }
                if (targY + 1 < 8 && targY + 1 > -1 && targX - 1 < 8 && targX - 1 > -1) // SW
                {
                    if (theBoard[targY + 1, targX - 1] == 6)
                    {
                        return true;
                    }
                }
                if (targY + 1 < 8 && targY + 1 > -1) // S
                {
                    if (theBoard[targY + 1, targX] == 6)
                    {
                        return true;
                    }
                }
                if (targY - 1 < 8 && targY - 1 > -1) // N
                {
                    if (theBoard[targY - 1, targX] == 6)
                    {
                        return true;
                    }
                }
                if (targX + 1 < 8 && targX + 1 > -1) // E
                {
                    if (theBoard[targY, targX + 1] == 6)
                    {
                        return true;
                    }
                }
                if (targX - 1 < 8 && targX - 1 > -1) // W
                {
                    if (theBoard[targY, targX - 1] == 6)
                    {
                        return true;
                    }
                }
                blockFlag = false;
                return false;
            }
            blockFlag = false;
            return false;
        }

        public static bool isPawnMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard, int pieceType)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1) 
                && !isKingInCheck(initY, initX, targY, targX, theBoard))
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

        public static bool isKnightMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            int deltaX = targX - initX;
            int deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1) && (deltaX != 0 && deltaY != 0)
                && (deltaX == 2 && (deltaY == 1 || deltaY == -1)) || (deltaX == 1 && (deltaY == -2 || deltaY == 2))
                || (deltaX == -1 && (deltaY == 2 || deltaY == -2)) || (deltaX == -2 && (deltaY == 1 || deltaY == -1))
                && !isKingInCheck(initY, initX, targY, targX, theBoard))
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

        public static bool isBishopMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1) && 
                (deltaX != 0 && deltaY != 0) && (Math.Abs(deltaX) == Math.Abs(deltaY))
                && !isKingInCheck(initY, initX, targY, targX, theBoard))
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

        public static bool isRookMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1) && 
                ((deltaX == 0 && deltaY != 0) || (deltaY == 0 && deltaX !=0))
                && !isKingInCheck(initY, initX, targY, targX, theBoard))
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

        public static bool isQueenMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1) &&
                ((Math.Abs(deltaX) == Math.Abs(deltaY)) || 
                (((deltaX == 0 && deltaY != 0) || (deltaY == 0 && deltaX != 0))))
                && !isKingInCheck(initY, initX, targY, targX, theBoard))
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

        // Does not check whether King is currently in check, only whether the move will result in that
        public static bool isKingMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if (targX < 8 && targX > -1 && targY < 8 && targY > -1)
            {
                if(((deltaY == 1 && (deltaX == 0 || deltaX == 1 || deltaX == -1)) 
                    || (deltaY == 0 && (deltaX == -1 || deltaX == 1)) 
                    || (deltaY == -1 && (deltaX == 0 || deltaX == -1 || deltaX == 1)))
                    //&& !isKingInCheck(initY, initX, targY, targX, theBoard)
                    && !doesMovePutKingInCheck(initY, initX, targY, targX, theBoard))
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
                else if(initY == 0 && initX == 4 && targY == 0) // Black king castling
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
                else if (initY == 7 && initX == 4 && targY == 7) // White king castling
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

        public static int isMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            return 1;
        }
    }
}
