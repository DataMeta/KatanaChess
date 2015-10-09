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

        // Makes a move
        public static void makeMove(int pieceType, int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            theBoard[initY, initX] = 0;
            theBoard[targY, targX] = pieceType;
        }

        // Scans whether a pawn threatens target coordinates
        public static bool pawnScan(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            int pawnID = 1;
            if (kingY + 1 < 8 && kingY + 1 > -1 && kingX + 1 < 8 && kingX + 1 > -1
                && theBoard[kingY + 1, kingX + 1] == pawnID) // Diagonal down right
            {
                return true;
            }
            if (kingY + 1 < 8 && kingY + 1 > -1 && kingX - 1 < 8 && kingX - 1 > -1
                && theBoard[kingY + 1, kingX - 1] == pawnID) // Diagonal down left
            {
                return true;
            }
            return false; 
        }

        // Scans whether a knight threatens target coordinates
        public static bool knightScan(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            int knightID = 2;

            if (targY + 1 < 8 && targY + 1 > -1 && targX + 2 < 8 && targX + 2 > -1
                && theBoard[targY + 1, targX + 2] == knightID) // 1 Down 2 Right
            {
                return true;
            }
            if (targY + 2 < 8 && targY + 2 > -1 && targX + 1 < 8 && targX + 1 > -1
                && theBoard[targY + 2, targX + 1] == knightID) // 2 Down 1 Right
            {
                return true;
            }
            if (targY + 2 < 8 && targY + 2 > -1 && targX - 1 < 8 && targX - 1 > -1
                && theBoard[targY + 2, targX - 1] == knightID) // 2 Down 1 Left
            {
                return true;
            }
            if (targY + 1 < 8 && targY + 1 > -1 && targX - 2 < 8 && targX - 2 > -1
                && theBoard[targY + 1, targX - 2] == knightID) // 1 Down 2 Left
            {
                return true;
            }
            if (targY - 1 < 8 && targY - 1 > -1 && targX - 2 < 8 && targX - 2 > -1
                && theBoard[targY - 1, targX - 2] == knightID) // 1 Up 2 Left
            {
                return true;
            }
            if (targY - 2 < 8 && targY - 2 > -1 && targX - 1 < 8 && targX - 1 > -1
                && theBoard[targY - 2, targX - 1] == knightID) // 2 Up 1 Left
            {
                return true;
            }
            if (targY - 2 < 8 && targY - 2 > -1 && targX + 1 < 8 && targX + 1 > -1
                && theBoard[targY - 2, targX + 1] == knightID) // 2 Up 1 Right
            {
                return true;
            }
            if (targY - 1 < 8 && targY - 1 > -1 && targX + 2 < 8 && targX + 2 > -1
                && theBoard[targY - 1, targX + 2] == knightID) // 1 Up 2 Right
            {
                return true;
            }
            return false;
        }

        // Scans whether a bishop threatens target coordinates
        public static bool bishopScan(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            int bishopID = 3;
            blockFlag = false;
            int j;
            if (targY + 1 < 8) // Out of bounds check
            {
                blockFlag = false;
                j = targY + 1;
                for (int i = targX + 1; i < 8; i++) // Diagonal down-right
                {
                    if (theBoard[j, i] == bishopID)
                    {
                        int m = j - 1;
                        for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
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
                    if (theBoard[j, i] == bishopID)
                    {
                        int m = j - 1;
                        for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
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
                    if (theBoard[j, i] == bishopID)
                    {
                        int m = j + 1;
                        for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
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
                    if (theBoard[j, i] == bishopID)
                    {
                        int m = j + 1;
                        for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
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
            return false;
        }

        // Scans whether a rook threatens target coordinates
        public static bool rookScan(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            int rookID = 4;
            blockFlag = false;

            if (targY + 1 < 8) // Out of bounds check
            {
                for (int i = targY + 1; i < 8; i++) // Vertical down
                {
                    if (theBoard[i, targX] == rookID)
                    {
                        for (int n = i - 1; n > targY; n--) // Scan back for blocking pieces
                        {
                            if (theBoard[n, targX] != 0)
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
                    if (theBoard[i, targX] == rookID)
                    {
                        for (int n = i + 1; n < targY; n++) // Scan back for blocking pieces
                        {
                            if (theBoard[n, targX] != 0)
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
                    if (theBoard[targY, i] == rookID)
                    {
                        for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
                        {
                            if (theBoard[targY, n] != 0)
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
                    if (theBoard[targY, i] == rookID)
                    {
                        for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
                        {
                            if (theBoard[targY, n] != 0)
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
            return false;
        }

        // Scans whether a queen threatens target coordinates
        public static bool queenScan(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            blockFlag = false;
            int queenID = 5;
            int j;
            if (targY + 1 < 8) // Out of bounds check
            {
                blockFlag = false;
                j = targY + 1;
                for (int i = targX + 1; i < 8; i++) // Diagonal down-right
                {
                    if (theBoard[j, i] == queenID)
                    {
                        int m = j - 1;
                        for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
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
                    if (theBoard[j, i] == queenID)
                    {
                        int m = j - 1;
                        for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
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
                    if (theBoard[j, i] == queenID)
                    {
                        int m = j + 1;
                        for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
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
                    if (theBoard[j, i] == queenID)
                    {
                        int m = j + 1;
                        for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
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

            blockFlag = false;

            if (targY + 1 < 8) // Out of bounds check
            {
                for (int i = targY + 1; i < 8; i++) // Vertical down
                {
                    if (theBoard[i, targX] == queenID)
                    {
                        for (int n = i - 1; n > targY; n--) // Scan back for blocking pieces
                        {
                            if (theBoard[n, targX] != 0)
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
                    if (theBoard[i, targX] == queenID)
                    {
                        for (int n = i + 1; n < targY; n++) // Scan back for blocking pieces
                        {
                            if (theBoard[n, targX] != 0)
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
                    if (theBoard[targY, i] == queenID)
                    {
                        for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
                        {
                            if (theBoard[targY, n] != 0)
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
                    if (theBoard[targY, i] == queenID)
                    {
                        for (int n = i + 1; n < targX; n++) // Scan back for blocking pieces
                        {
                            if (theBoard[targY, n] != 0)
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
            return false;
        }

        // Scans whether a king threatens target coordinates
        public static bool kingScan()
        {
            return false;
        }


        // Determines whether the pending capture move will remove the friendly king from check
        /* private static bool doesCapRelieveCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            int kingID;
            if (theBoard[initY, initX] > 0)
            {
                kingID = 6;

                // Add pawn clause

                if (theBoard[targY, targX] == -2)
                {
                    if (knightScan(kingID, initY, initX, targY, targX, theBoard))
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }

                else if (theBoard[targY, targX] == -3)
                {
                    if (bishopScan(kingID, initY, initX, targY, targX, theBoard))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (theBoard[targY, targX] == -4)
                {
                    if (rookScan(kingID, initY, initX, targY, targX, theBoard))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (theBoard[targY, targX] == -5)
                {
                    if (queenScan(kingID, initY, initX, targY, targX, theBoard))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            else if(theBoard[initY, initX] < 0)
            {
                kingID = -6;

                // Add pawn clause

                if (theBoard[targY, targX] == 2)
                {
                    if (knightScan(kingID, initY, initX, targY, targX, theBoard))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (theBoard[targY, targX] == 3)
                {
                    if (bishopScan(kingID, initY, initX, targY, targX, theBoard))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (theBoard[targY, targX] == 4)
                {
                    if (rookScan(kingID, initY, initX, targY, targX, theBoard))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (theBoard[targY, targX] == 5)
                {
                    if (queenScan(kingID, initY, initX, targY, targX, theBoard))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        } */

        // Determines whether the pending King move will directly put it into check
        private static bool willMovePutKingInCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
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
                        if (theBoard[i, targX] == -4 || theBoard[i, targX] == -5)
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
                        if (theBoard[i, targX] == -4 || theBoard[i, targX] == -5)
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
                        if (theBoard[targY, i] == -4 || theBoard[targY, i] == -5)
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
                        if (theBoard[targY, i] == -4 || theBoard[targY, i] == -5)
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
                        if (theBoard[j, i] == -3 || theBoard[j, i] == -5)
                        {
                            int m = j - 1;
                            for (int n = i - 1; n > targX; n--) // Scan back for blocking pieces
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

                    blockFlag = false;
                    j = targY + 1;
                    for (int i = targX - 1; i > -1; i--) // Diagonal down-left
                    {
                        if (theBoard[j, i] == -3 || theBoard[j, i] == -5)
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
                        if (theBoard[j, i] == -3 || theBoard[j, i] == -5)
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
                        if (theBoard[j, i] == -3 || theBoard[j, i] == -5)
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
                        if (theBoard[i, targX] == 4 || theBoard[i, targX] == 5)
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
                        if (theBoard[i, targX] == 4 || theBoard[i, targX] == 5)
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
                        if (theBoard[targY, i] == 4 || theBoard[targY, i] == 5)
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
                        if (theBoard[targY, i] == 4 || theBoard[targY, i] == 5)
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
                        if (theBoard[j, i] == 3 || theBoard[j, i] == 5)
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
                        if (theBoard[j, i] == 3 || theBoard[j, i] == 5)
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

                if (targY - 1 > -1) // Out of bounds check
                {
                    blockFlag = false;
                    j = targY - 1;
                    for (int i = targX + 1; i < 8; i++) // Diagonal up-right
                    {
                        if (theBoard[j, i] == 3 || theBoard[j, i] == 5)
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
                        if (theBoard[j, i] == 3 || theBoard[j, i] == 5)
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

        // Determines whether friendly king is in check
        private static bool isKingInCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
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
                        if (theBoard[i, kingX] == -4 || theBoard[i, kingX] == -5)
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
                        if (theBoard[i, kingX] == -4 || theBoard[i, kingX] == -5)
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
                        if (theBoard[kingY, i] == -4 || theBoard[kingY, i] == -5)
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
                        if (theBoard[kingY, i] == -4 || theBoard[kingY, i] == -5)
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
                        if (theBoard[k, i] == -3 || theBoard[k, i] == -5)
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
                        if (theBoard[k, i] == -3 || theBoard[k, i] == -5)
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
                        if (theBoard[k, i] == -3 || theBoard[k, i] == -5)
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
                        if (theBoard[k, i] == -3 || theBoard[k, i] == -5)
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
                        if ((theBoard[i, kingX] == 4 || theBoard[i, kingX] == 5)) 
                        {
                            for(int n = i - 1; n > kingY; n--)
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
                        if (theBoard[i, kingX] == 4 || theBoard[i, kingX] == 5)
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
                        if ((theBoard[kingY, i] == 4 || theBoard[kingY, i] == 5))
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
                        if (theBoard[kingY, i] == 4 || theBoard[kingY, i] == 5)
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
                
                // White Bishop/Queen scan
                int k;
                if (kingY + 1 < 8) // Out of bound check
                {
                    blockFlag = false;
                    k = kingY + 1;
                    for (int i = kingX + 1; i < 8; i++) // Diagonal down-right
                    {
                        if (theBoard[k, i] == 3 || theBoard[k, i] == 5)
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
                        if (theBoard[k, i] == 3 || theBoard[k, i] == 5)
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
                        if (theBoard[k, i] == 3 || theBoard[k, i] == 5)
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
                        if (theBoard[k, i] == 3 || theBoard[k, i] == 5)
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

        // Simulates a move and determines whether it will result in a check for friendly King
        private static bool simulateMoveForCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            int pieceType = theBoard[initY, initX];
            int targType = theBoard[targY, targX];

            theBoard[initY, initX] = 0;
            theBoard[targY, targX] = pieceType;

            if (isKingInCheck(targY, targX, 0, 0, theBoard)) // If king in check after move simulation, return true
            {
                theBoard[initY, initX] = pieceType;
                theBoard[targY, targX] = targType;
                return true;
            }
            else
            {
                theBoard[initY, initX] = pieceType;
                theBoard[targY, targX] = targType;
                return false;
            }
        }


        // Validates pawn movement
        public static bool isPawnMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard, int pieceType)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1))
            {
                if (!isKingInCheck(initY, initX, targY, targX, theBoard)
                    && simulateMoveForCheck(initY, initX, targY, targX, theBoard))
                {
                    return false;
                }

                if (isKingInCheck(initY, initX, targY, targX, theBoard)
                    && simulateMoveForCheck(initY, initX, targY, targX, theBoard))
                {
                    return false;
                }

                if (pieceType == 1) // White pawn case
                {
                    if (deltaX == 0)
                    {
                        if (deltaY == -1)
                        {
                            if (theBoard[targY, targX] != 0)
                            {
                                return false;
                            }
                            return true;
                        }
                        else if (deltaY == -2 && initY == 6)
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

        // Validates knight movement
        public static bool isKnightMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1) && (deltaX != 0 && deltaY != 0)
                && ((deltaX == 2 && (deltaY == 1 || deltaY == -1)) || (deltaX == 1 && (deltaY == -2 || deltaY == 2))
                || (deltaX == -1 && (deltaY == 2 || deltaY == -2)) || (deltaX == -2 && (deltaY == 1 || deltaY == -1))))
            {
                if ((theBoard[initY, initX] == 2) && ((theBoard[targY, targX] > 0) || theBoard[targY, targX] == -6))
                {
                    return false;
                }
                else if ((theBoard[initY, initX] == -2) && ((theBoard[targY, targX] < 0) || theBoard[targY, targX] == 6))
                {
                    return false;
                }

                if (!isKingInCheck(initY, initX, targY, targX, theBoard) 
                    && simulateMoveForCheck(initY, initX, targY, targX, theBoard))
                {
                    return false;
                }

                if (isKingInCheck(initY, initX, targY, targX, theBoard) 
                    && simulateMoveForCheck(initY, initX, targY, targX, theBoard))
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

        // Validates bishop movement
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

                if (!isKingInCheck(initY, initX, targY, targX, theBoard)
                    && simulateMoveForCheck(initY, initX, targY, targX, theBoard))
                {
                    return false;
                }

                if (isKingInCheck(initY, initX, targY, targX, theBoard)
                    && simulateMoveForCheck(initY, initX, targY, targX, theBoard))
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

        // Validates rook movement
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
                if (!isKingInCheck(initY, initX, targY, targX, theBoard)
                    && simulateMoveForCheck(initY, initX, targY, targX, theBoard))
                {
                    return false;
                }

                if (isKingInCheck(initY, initX, targY, targX, theBoard)
                    && simulateMoveForCheck(initY, initX, targY, targX, theBoard))
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

        // Validates queen movement
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

                if (!isKingInCheck(initY, initX, targY, targX, theBoard)
                    && simulateMoveForCheck(initY, initX, targY, targX, theBoard))
                {
                    return false;
                }

                if (isKingInCheck(initY, initX, targY, targX, theBoard)
                    && simulateMoveForCheck(initY, initX, targY, targX, theBoard))
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

        // Validates king movement
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
                    && !willMovePutKingInCheck(initY, initX, targY, targX, theBoard))
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
                else if (initY == 0 && initX == 4 && targY == 0 
                    && !isKingInCheck(initY, initX, targY, targX, theBoard)
                    && !willMovePutKingInCheck(initY, initX, targY, targX, theBoard)) // Black king castling
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
                else if (initY == 7 && initX == 4 && targY == 7
                    && !isKingInCheck(initY, initX, targY, targX, theBoard)
                    && !willMovePutKingInCheck(initY, initX, targY, targX, theBoard)) // White king castling
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

        // Determines if a pawn has reached the enemy's back rank
        // Converts the AI's pawn
        // Opens a dialog for the user to chose which piece to convert it to
        public static void checkPawnConvert(int[,] theBoard)
        {
            Random r = new Random();
            int blackPawnX = -1;
            int whitePawnX = -1;
            int rand;

            for (int i = 0; i < 8; i++)
            {
                if (theBoard[7, i] == -1)
                {
                    blackPawnX = i;
                }
                if (theBoard[0, i] == 1)
                {
                    whitePawnX = i;
                }
            }

            
            if (blackPawnX != -1)
            {
                rand = r.Next(-5, -2);
                theBoard[7, blackPawnX] = rand;
            }
            else if (whitePawnX != -1)
            {
                rand = r.Next(2, 5);
                theBoard[0, whitePawnX] = rand;
            }
            
        }

        //public static int isMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        //{
        //    return 1;
        //}
    }
}
