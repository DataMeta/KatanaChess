using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaChess
{
    /// <summary>
    /// * NAME
    ///     Rules.cs
    ///     
    /// * DESCRIPTION
    ///     This class handles all movement validation, check evaluation, and applies moves
    ///     It also has methods to help the AI see what is going on with the board strategically
    ///     
    /// * AUTHOR
    ///     Daniel Melnikov
    ///     
    /// * DATE
    ///     9/14/15
    /// </summary>
    public static class Rules
    {
        /// <summary>
        /// The absolute value diffence between a target square's and initial square's Y coordinates
        /// </summary>
        private static int deltaY;

        /// <summary>
        /// The absolute value diffence between a target square's and initial square's X coordinates
        /// </summary>
        private static int deltaX;

        /// <summary>
        /// The Y coordinate of the King's location
        /// </summary>
        private static int kingY;

        /// <summary>
        /// The X coordinate of the King's location
        /// </summary>
        private static int kingX;

        /// <summary>
        /// A flag used to keep track of whether the space between a checking piece and the king is blocked by another piece
        /// </summary>
        private static bool blockFlag = false;

        /// <summary>
        /// * NAME 
        ///     public static void Rules::MakeMove(int pieceType, int initY, int initX, int targY, int targX, int[,] theBoard)
        ///     
        /// * DESCRIPTION
        ///     Applies the chess piece movement to theBoard
        ///     
        /// * RETURNS
        ///     This method returns nothing
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/14/15
        /// </summary>
        /// <param name="pieceType">An integer value corresponding to a type of chess piece</param>
        /// <param name="initY">The Y coordinate of the square of the piece whose move is under validation (initiating square)</param>
        /// <param name="initX">The X coordinate of the initiating square</param>
        /// <param name="targY">The Y coordinate of the target square to which the initiating piece is to move to</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        public static void MakeMove(int pieceType, int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            theBoard[initY, initX] = 0;
            theBoard[targY, targX] = pieceType;
        }

        /// <summary>
        /// * NAME
        ///     public static bool Rules::PawnScan(int targY, int targX, int[,] theBoard, bool ally)
        ///     
        /// * DESCRIPTION
        ///     Scans either whether an enemy pawn threatens the target square, or whether an allied pawn defends it
        ///     
        /// * RETURNS
        ///     Returns true if a pawn is detected
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     10/07/15
        /// </summary>
        /// <param name="targY">The Y coordinate of the target square for which the method checks if it is threatened by an enemy pawn</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <param name="ally">A boolean flag. When true, scan for an allied pawn. When false, scan for an enemy pawn</param>
        /// <returns></returns>
        public static bool PawnScan(int targY, int targX, int[,] theBoard, bool ally)
        {
            int pawnID;
            if (ally)
            {
                pawnID = -1;
            }
            else
            {
                pawnID = 1;
            }
            
            if (targY + 1 < 8 && targY + 1 > -1 && targX + 1 < 8 && targX + 1 > -1
                && theBoard[targY + 1, targX + 1] == pawnID) // Diagonal down right
            {
                return true;
            }
            if (targY + 1 < 8 && targY + 1 > -1 && targX - 1 < 8 && targX - 1 > -1
                && theBoard[targY + 1, targX - 1] == pawnID) // Diagonal down left
            {
                return true;
            }
            return false; 
        }

        /// <summary>
        /// * NAME
        ///     public static bool Rules::KnightScan(int targY, int targX, int[,] theBoard, bool ally)
        ///     
        /// * DESCRIPTION
        ///     Scans either whether an enemy knight threatens the target square, or whether an allied knight defends it
        ///     
        /// * RETURNS
        ///     Returns true if a knight is detected
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     10/07/15
        /// </summary>
        /// <param name="targY">The Y coordinate of the target square for which the method checks if it is threatened by an enemy knight</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <param name="ally">A boolean flag. When true, scan for an allied knight. When false, scan for an enemy knight</param>
        /// <returns></returns>
        public static bool KnightScan(int targY, int targX, int[,] theBoard, bool ally)
        {
            int knightID;
            if (ally)
            {
                knightID = -2;
            }
            else
            {
                knightID = 2;
            }

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

        /// <summary>
        /// * NAME
        ///     public static bool Rules::BishopScan(int targY, int targX, int[,] theBoard, bool ally)
        ///     
        /// * DESCRIPTION
        ///     Scans either whether an enemy bishop threatens the target square, or whether an allied bishop defends it
        ///     
        /// * RETURNS
        ///     Returns true if a bishop is detected
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     10/07/15
        /// </summary>
        /// <param name="targY">The Y coordinate of the target square for which the method checks if it is threatened by an enemy bishop</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <param name="ally">A boolean flag. When true, scan for an allied bishop. When false, scan for an enemy bishop</param>
        /// <returns></returns>
        public static bool BishopScan(int targY, int targX, int[,] theBoard, bool ally)
        {
            int bishopID;
            if (ally)
            {
                bishopID = -3;
            }
            else
            {
                bishopID = 3;
            }
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

        /// <summary>
        /// * NAME
        ///     public static bool Rules::RookScan(int targY, int targX, int[,] theBoard, bool ally)
        ///     
        /// * DESCRIPTION
        ///     Scans either whether an enemy rook threatens the target square, or whether an allied rook defends it
        ///     
        /// * RETURNS
        ///     Returns true if a rook is detected
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     10/07/15
        /// </summary>
        /// <param name="targY">The Y coordinate of the target square for which the method checks if it is threatened by an enemy rook</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <param name="ally">A boolean flag. When true, scan for an allied rook. When false, scan for an enemy rook</param>
        /// <returns></returns>
        public static bool RookScan(int targY, int targX, int[,] theBoard, bool ally)
        {
            int rookID;
            if (ally)
            {
                rookID = -4;
            }
            else
            {
                rookID = 4;
            }
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

        /// <summary>
        /// * NAME
        ///     public static bool Rules::QueenScan(int targY, int targX, int[,] theBoard, bool ally)
        ///     
        /// * DESCRIPTION
        ///     Scans either whether an enemy queen threatens the target square, or whether an allied queen defends it
        ///     
        /// * RETURNS
        ///     Returns true if a queen is detected
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     10/07/15
        /// </summary>
        /// <param name="targY">The Y coordinate of the target square for which the method checks if it is threatened by an enemy queen</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <param name="ally">A boolean flag. When true, scan for an allied queen. When false, scan for an enemy queen</param>
        /// <returns></returns>
        public static bool QueenScan(int targY, int targX, int[,] theBoard, bool ally)
        {
            blockFlag = false;
            int queenID;
            if (ally)
            {
                queenID = -5;
            }
            else
            {
                queenID = 5;
            }
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

        /// <summary>
        /// * NAME
        ///     public static bool Rules::KingScan(int targY, int targX, int[,] theBoard, bool ally)
        ///     
        /// * DESCRIPTION
        ///     Scans either whether an enemy king threatens the target square, or whether an allied king defends it
        ///     
        /// * RETURNS
        ///     Returns true if a king is detected
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     10/07/15
        /// </summary>
        /// <param name="targY">The Y coordinate of the target square for which the method checkS if it is threatened by an enemy king</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <param name="ally">A boolean flag. When true, scan for an allied king. When false, scan for an enemy king</param>
        /// <returns></returns>
        public static bool KingScan(int targY, int targX, int[,] theBoard, bool ally)
        {
            int kingID;
            if (ally)
            {
                kingID = -6;
            }
            else
            {
                kingID = 6;
            }

            if (targY + 1 < 8 && targY + 1 > -1 && targX + 1 < 8 && targX + 1 > -1) // SE
            {
                if (theBoard[targY + 1, targX + 1] == kingID)
                {
                    return true;
                }
            }
            if (targY - 1 < 8 && targY - 1 > -1 && targX + 1 < 8 && targX + 1 > -1) // NE
            {
                if (theBoard[targY - 1, targX + 1] == kingID)
                {
                    return true;
                }
            }
            if (targY - 1 < 8 && targY - 1 > -1 && targX - 1 < 8 && targX - 1 > -1) // NW
            {
                if (theBoard[targY - 1, targX - 1] == kingID)
                {
                    return true;
                }
            }
            if (targY + 1 < 8 && targY + 1 > -1 && targX - 1 < 8 && targX - 1 > -1) // SW
            {
                if (theBoard[targY + 1, targX - 1] == kingID)
                {
                    return true;
                }
            }
            if (targY + 1 < 8 && targY + 1 > -1) // S
            {
                if (theBoard[targY + 1, targX] == kingID)
                {
                    return true;
                }
            }
            if (targY - 1 < 8 && targY - 1 > -1) // N
            {
                if (theBoard[targY - 1, targX] == kingID)
                {
                    return true;
                }
            }
            if (targX + 1 < 8 && targX + 1 > -1) // E
            {
                if (theBoard[targY, targX + 1] == kingID)
                {
                    return true;
                }
            }
            if (targX - 1 < 8 && targX - 1 > -1) // W
            {
                if (theBoard[targY, targX - 1] == kingID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// * NAME
        ///     private static bool Rules::WillMovePutKingInCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
        ///     
        /// * DESCRIPTION
        ///     Determines whether the pending king move will directly put it into check
        ///     
        /// * RETURNS
        ///     Returns true if execution of the move will out the king in check
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     10/03/15
        /// </summary>
        /// <param name="initY">The Y coordinate of the square of the piece whose move is under validation</param>
        /// <param name="initX">The X coordinate of the initiating square</param>
        /// <param name="targY">The Y coordinate of the target square to which the king is to move to</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <returns></returns>
        private static bool WillMovePutKingInCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
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

        /// <summary>
        /// * NAME
        ///     private static bool Rules::IsKingInCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
        /// 
        /// * DESCRIPTION
        ///     Determines whether the friendly king is in check
        ///     
        /// * RETURNS
        ///     Returns true if the king is currently in check
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/28/15
        /// </summary>
        /// <param name="initY">The Y coordinate of the square of the piece whose move is under validation</param>
        /// <param name="initX">The X coordinate of the initiating square</param>
        /// <param name="targY">The Y coordinate of the target square to which the piece is to move to</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <returns></returns>
        private static bool IsKingInCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
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

        /// <summary>
        /// * NAME
        ///     private static bool Rules::SimulateMoveForCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
        ///     
        /// * DESCRIPTION
        ///     Simulates a move and determines whether it will result in a check for friendly King
        ///     
        /// * RETURNS
        ///     Returns true if the move will result in the king being in check
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/28/15
        /// </summary>
        /// <param name="initY">The Y coordinate of the square of the piece whose move is under validation</param>
        /// <param name="initX">The X coordinate of the initiating square</param>
        /// <param name="targY">The Y coordinate of the target square to which the piece is to move to</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <returns></returns>
        private static bool SimulateMoveForCheck(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            int pieceType = theBoard[initY, initX];
            int targType = theBoard[targY, targX];

            theBoard[initY, initX] = 0;
            theBoard[targY, targX] = pieceType;

            if (IsKingInCheck(targY, targX, 0, 0, theBoard)) // If king in check after move simulation, return true
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


        /// <summary>
        /// * NAME 
        ///     public static bool Rules::IsPawnMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard, int pieceType)
        ///     
        /// * DESCRIPTION
        ///     Validates pawn movement
        ///     
        /// * RETURNS
        ///     Returns true if the pending move is valid
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/15/15
        /// </summary>
        /// <param name="initY">The Y coordinate of the square of the piece whose move is under validation</param>
        /// <param name="initX">The X coordinate of the initiating square</param>
        /// <param name="targY">The Y coordinate of the target square to which the piece is to move to</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <param name="pieceType"></param>
        /// <returns></returns>
        public static bool IsPawnMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard, int pieceType)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if ((targX < 8 && targX > -1 && targY < 8 && targY > -1))
            {
                if (!IsKingInCheck(initY, initX, targY, targX, theBoard)
                    && SimulateMoveForCheck(initY, initX, targY, targX, theBoard))
                {
                    return false;
                }

                if (IsKingInCheck(initY, initX, targY, targX, theBoard)
                    && SimulateMoveForCheck(initY, initX, targY, targX, theBoard))
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


        /// <summary>
        /// * NAME 
        ///     public static bool Rules::IsKnightMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        ///     
        /// * DESCRIPTION
        ///     Validates knight movement
        ///     
        /// * RETURNS
        ///     Returns true if the pending move is valid
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/15/15
        /// </summary>
        /// <param name="initY">The Y coordinate of the square of the piece whose move is under validation</param>
        /// <param name="initX">The X coordinate of the initiating square</param>
        /// <param name="targY">The Y coordinate of the target square to which the piece is to move to</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <returns></returns>
        public static bool IsKnightMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
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

                if (!IsKingInCheck(initY, initX, targY, targX, theBoard) 
                    && SimulateMoveForCheck(initY, initX, targY, targX, theBoard))
                {
                    return false;
                }

                if (IsKingInCheck(initY, initX, targY, targX, theBoard) 
                    && SimulateMoveForCheck(initY, initX, targY, targX, theBoard))
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


        /// <summary>
        /// * NAME 
        ///     public static bool Rules::IsBishopMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        ///     
        /// * DESCRIPTION
        ///     Validates bishop movement
        ///     
        /// * RETURNS
        ///     Returns true if the pending move is valid
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/16/15
        /// </summary>
        /// <param name="initY">The Y coordinate of the square of the piece whose move is under validation</param>
        /// <param name="initX">The X coordinate of the initiating square</param>
        /// <param name="targY">The Y coordinate of the target square to which the piece is to move to</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <returns></returns>
        public static bool IsBishopMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
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

                if (!IsKingInCheck(initY, initX, targY, targX, theBoard)
                    && SimulateMoveForCheck(initY, initX, targY, targX, theBoard))
                {
                    return false;
                }

                if (IsKingInCheck(initY, initX, targY, targX, theBoard)
                    && SimulateMoveForCheck(initY, initX, targY, targX, theBoard))
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


        /// <summary>
        /// * NAME 
        ///     public static bool Rules::IsRookMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        ///     
        /// * DESCRIPTION
        ///     Validates rook movement
        ///     
        /// * RETURNS
        ///     Returns true if the pending move is valid
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/16/15
        /// </summary>
        /// <param name="initY">The Y coordinate of the square of the piece whose move is under validation</param>
        /// <param name="initX">The X coordinate of the initiating square</param>
        /// <param name="targY">The Y coordinate of the target square to which the piece is to move to</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <returns></returns>
        public static bool IsRookMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
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
                if (!IsKingInCheck(initY, initX, targY, targX, theBoard)
                    && SimulateMoveForCheck(initY, initX, targY, targX, theBoard))
                {
                    return false;
                }

                if (IsKingInCheck(initY, initX, targY, targX, theBoard)
                    && SimulateMoveForCheck(initY, initX, targY, targX, theBoard))
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


        /// <summary>
        /// * NAME 
        ///     public static bool Rules::IsQueenMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard, int pieceType)
        ///     
        /// * DESCRIPTION
        ///     Validates the queen's move
        ///     
        /// * RETURNS
        ///     Returns true if the pending move is valid
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/16/15
        /// </summary>
        /// <param name="initY">The Y coordinate of the square of the piece whose move is under validation</param>
        /// <param name="initX">The X coordinate of the initiating square</param>
        /// <param name="targY">The Y coordinate of the target square to which the piece is to move to</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <returns></returns>
        public static bool IsQueenMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
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

                if (!IsKingInCheck(initY, initX, targY, targX, theBoard)
                    && SimulateMoveForCheck(initY, initX, targY, targX, theBoard))
                {
                    return false;
                }

                if (IsKingInCheck(initY, initX, targY, targX, theBoard)
                    && SimulateMoveForCheck(initY, initX, targY, targX, theBoard))
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


        /// <summary>
        /// * NAME 
        ///     public static bool Rules::IsKingMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        ///     
        /// * DESCRIPTION
        ///     Validates king movement
        ///     
        /// * RETURNS
        ///     Returns true if the pending move is valid
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/15/15
        /// </summary>
        /// <param name="initY">The Y coordinate of the square of the piece whose move is under validation</param>
        /// <param name="initX">The X coordinate of the initiating square</param>
        /// <param name="targY">The Y coordinate of the target square to which the piece is to move to</param>
        /// <param name="targX">The X coordinate of the target square</param>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <returns></returns>
        public static bool IsKingMoveValid(int initY, int initX, int targY, int targX, int[,] theBoard)
        {
            deltaX = targX - initX;
            deltaY = targY - initY;
            if (targX < 8 && targX > -1 && targY < 8 && targY > -1)
            {
                if(((deltaY == 1 && (deltaX == 0 || deltaX == 1 || deltaX == -1)) 
                    || (deltaY == 0 && (deltaX == -1 || deltaX == 1)) 
                    || (deltaY == -1 && (deltaX == 0 || deltaX == -1 || deltaX == 1)))
                    //&& !isKingInCheck(initY, initX, targY, targX, theBoard)
                    && !WillMovePutKingInCheck(initY, initX, targY, targX, theBoard))
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
                    && !IsKingInCheck(initY, initX, targY, targX, theBoard)
                    && !WillMovePutKingInCheck(initY, initX, targY, targX, theBoard)) // Black king castling
                {
                    if(deltaX == 2 && theBoard[0,7] == -4 && 
                        (theBoard[0, 5] == 0 && theBoard[0, 6] == 0)) // Kingside
                    {
                        MakeMove(-4, 0, 7, 0, 5, theBoard); // Rook moves
                        return true;
                    }
                    else if (deltaX == -2 && theBoard[0, 0] == -4 &&
                        (theBoard[0, 3] == 0 && theBoard[0, 2] == 0 && theBoard[0, 1] == 0)) // Queenside
                    {
                        MakeMove(-4, 0, 0, 0, 3, theBoard); // Rook moves
                        return true;
                    }
                    return false;
                }
                else if (initY == 7 && initX == 4 && targY == 7
                    && !IsKingInCheck(initY, initX, targY, targX, theBoard)
                    && !WillMovePutKingInCheck(initY, initX, targY, targX, theBoard)) // White king castling
                {
                    if (deltaX == 2 && theBoard[7, 7] == 4 &&
                        (theBoard[7, 5] == 0 && theBoard[7, 6] == 0)) // Kingside
                    {
                        MakeMove(4, 7, 7, 7, 5, theBoard); // Rook moves
                        return true;
                    }
                    else if (deltaX == -2 && theBoard[7, 0] == 4 &&
                        (theBoard[7, 3] == 0 && theBoard[7, 2] == 0 && theBoard[7, 1] == 0)) // Queenside
                    {
                        MakeMove(4, 7, 0, 7, 3, theBoard); // Rook moves
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


        /// <summary>
        /// * NAME
        ///     public static void Rules::CheckPawnConvert(int[,] theBoard)
        ///     
        /// * DESCRIPTION
        ///     Determines whether a pawn has reached the enemy's back file and converts it if so
        ///     
        /// * RETURNS
        ///     This method returns nothing
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     10/6/15
        /// </summary>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        public static void CheckPawnPromotion(int[,] theBoard)
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

    }
}
