using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace KatanaChess
{
    /// <summary>
    /// * NAME
    ///     Katana.cs
    ///     
    /// * DESCRIPTION
    ///     This is the AI of the chess engine
    ///     It evaluates the state of the board and chooses a move to make
    ///     
    /// * AUTHOR
    ///     Daniel Melnikov
    ///     
    /// * DATE
    ///     9/27/15
    /// </summary>
    public static class Katana
    {
        /// <summary>
        /// A Move struct that holds all necessary information to make a move with
        /// </summary>
        public struct Move
        {
            public int initPiece;
            public int initY;
            public int initX;
            public int targPiece;
            public int targY;
            public int targX;
            public int value;
        }

        /// <summary>
        /// The type of the move initiating piece
        /// </summary>
        private static int initPiece;

        /// <summary>
        /// The Y coordinate of the initiating piece
        /// </summary>
        private static int initY;

        /// <summary>
        /// The X coordinate of the initiating piece
        /// </summary>
        private static int initX;

        /// <summary>
        /// The type of the target piece
        /// </summary>
        private static int targPiece;

        /// <summary>
        /// The Y coordinate of the target piece
        /// </summary>
        private static int targY;

        /// <summary>
        /// The X coordinate of the target piece
        /// </summary>
        private static int targX;

        /// <summary>
        /// The heuristic value of the move
        /// </summary>
        private static int value;


        /// <summary>
        /// The value of the strongest move in validMoveList
        /// </summary>
        private static int strongMove1 = 0;

        /// <summary>
        /// The index of the strongest move in validMoveList
        /// </summary>
        private static int indexOfStrongMove1 = 0;

        /// <summary>
        /// The value of the second strongest move in validMoveList
        /// </summary>
        private static int strongMove2 = 0;

        /// <summary>
        /// The index of the second strongest move in validMoveList
        /// </summary>
        private static int indexOfStrongMove2 = 0;

        /// <summary>
        /// The value of the third strongest move in validMoveList
        /// </summary>
        private static int strongMove3 = 0;

        /// <summary>
        /// The index of the third strongest move in validMoveList
        /// </summary>
        private static int indexOfStrongMove3 = 0;

        /// <summary>
        /// Heuristic value for a pawn
        /// </summary>
        private static int pawnVal = 10;

        /// <summary>
        /// Heuristic value for a knight
        /// </summary>
        private static int knightVal = 28;

        /// <summary>
        /// Heuristic value for a bishop
        /// </summary>
        private static int bishopVal = 33;

        /// <summary>
        /// Heuristic value for a rook
        /// </summary>
        private static int rookVal = 50;

        /// <summary>
        /// Heuristic value for a queen
        /// </summary>
        private static int queenVal = 82;

 
        /// <summary>
        /// * NAME
        ///     public static void Katana::SwingKatana(int[,] theBoard)
        ///     
        /// * DESCRIPTION
        ///     Commences and handles AI thought process
        ///     
        /// * RETURNS
        ///     This method returns nothing
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE:
        ///     9/27/15
        /// </summary>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        public static void SwingKatana(int[,] theBoard)
        {
            SelectMove(theBoard, GetMoves(theBoard));
        }

        /// <summary>
        /// * NAME
        ///     private static List<Move> Katana::GetMoves(int[,] theBoard)  
        ///     
        /// * DESCRIPTION
        ///     Loops through all legal moves without going out of bounds, calls Game::ValidateMove() for each one
        ///     Applies heuristic scans on each pending move and the surrounding board states
        ///     Stores moves as Move structs in List<Move>validMoveList
        ///     
        /// * RETURNS
        ///     Returns a list of moves called validMoveList
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/27/15
        /// </summary>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        private static List<Move> GetMoves(int[,] theBoard)
        {
            List<Move> validMoveList = new List<Move>();
            for (int initY = 0; initY < 8; initY++)
            {
                for (int initX = 0; initX < 8; initX++)
                {
                    for (int targY = 0; targY < 8; targY++)
                    {
                        for (int targX = 0; targX < 8; targX++)
                        {
                            if (theBoard[initY, initX] < 0 && 
                                Game.ValidateMove(theBoard[initY, initX], initY, initX, targY, targX))
                            {
                                Move move = new Move();
                                move.initPiece = theBoard[initY, initX];
                                move.initY = initY;
                                move.initX = initX;
                                move.targPiece = theBoard[targY, targX];
                                move.targY = targY;
                                move.targX = targX;

                                switch (move.targPiece)
                                {
                                    case 0:
                                        move.value = 0;
                                        break;
                                    case 1:
                                        move.value = pawnVal;
                                        break;
                                    case 2:
                                        move.value = knightVal;
                                        break;
                                    case 3:
                                        move.value = bishopVal;
                                        break;
                                    case 4:
                                        move.value = rookVal;
                                        break;
                                    case 5:
                                        move.value = queenVal;
                                        break;
                                    default:
                                        break;
                                }


                                // Scan for threat at target square
                                if (Rules.PawnScan(targY, targX, theBoard, false)
                                    || Rules.KnightScan(targY, targX, theBoard, false)
                                    || Rules.BishopScan(targY, targX, theBoard, false)
                                    || Rules.RookScan(targY, targX, theBoard, false)
                                    || Rules.QueenScan(targY, targX, theBoard, false)
                                    || Rules.KingScan(targY, targX, theBoard, false))
                                {
                                    switch (Math.Abs(move.initPiece))
                                    {
                                        case 0:
                                            move.value = 0;
                                            break;
                                        case 1:
                                            move.value -= pawnVal;
                                            break;
                                        case 2:
                                            move.value -= knightVal;
                                            break;
                                        case 3:
                                            move.value -= bishopVal;
                                            break;
                                        case 4:
                                            move.value -= rookVal;
                                            break;
                                        case 5:
                                            move.value -= queenVal;
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                // Scan for imminent threat at initial square
                                if (Rules.PawnScan(initY, initX, theBoard, false)
                                    || Rules.KnightScan(initY, initX, theBoard, false)
                                    || Rules.BishopScan(initY, initX, theBoard, false)
                                    || Rules.RookScan(initY, initX, theBoard, false)
                                    || Rules.QueenScan(initY, initX, theBoard, false)
                                    || Rules.KingScan(initY, initX, theBoard, false))
                                {
                                    switch (Math.Abs(move.initPiece))
                                    {
                                        case 0:
                                            move.value = 0;
                                            break;
                                        case 1:
                                            move.value += pawnVal;
                                            break;
                                        case 2:
                                            move.value += knightVal;
                                            break;
                                        case 3:
                                            move.value += bishopVal;
                                            break;
                                        case 4:
                                            move.value += rookVal;
                                            break;
                                        case 5:
                                            move.value += queenVal;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                validMoveList.Add(move);
                            }
                        }
                    }
                }
            }
            return validMoveList;
        }


        /// <summary>
        /// * NAME
        ///     private static void SelectMove(int[,] theBoard, List<Move> validMoveList)
        ///     
        /// * DESCRIPTION
        ///     Selects from the three strongest moves and makes a move
        ///     
        /// * RETURNS
        ///     This method returns nothing
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/27/15
        /// </summary>
        /// <param name="theBoard">The 2-dimensional array representation of the pieces and their positions on a chessboard</param>
        /// <param name="validMoveList">A list of move structs containing the move information</param>
        private static void SelectMove(int[,] theBoard, List<Move> validMoveList)
        {
            // Code for outputting validMoveList
            //string testOutput = "";
            //foreach (Move move in validMoveList)
            //{
            //    testOutput += move.initPiece.ToString() + "  " + move.initY.ToString() + "_" + move.initX.ToString() + " :: "
            //                + move.targPiece.ToString() + "  " + move.targY.ToString() + "_" + move.targX.ToString() + " val = "
            //                + move.value.ToString() + "\n";
            //}
            //MessageBox.Show(testOutput);

            Random r = new Random();
            
            if (validMoveList.Count == 0)
            {
                MessageBox.Show("Checkmate!");
                return;
            }

            // Find strongest three moves
            for (int i = 0; i < validMoveList.Count; i++)
            {
                value = validMoveList.ElementAt(i).value; 
                if (value > strongMove3)
                {
                    strongMove3 = value;
                    indexOfStrongMove3 = i;
                }
                if (strongMove3 > strongMove2)
                {
                    strongMove2 = strongMove3;
                    indexOfStrongMove2 = indexOfStrongMove3;
                }
                if (strongMove2 > strongMove1)
                {
                    strongMove1 = strongMove2;
                    indexOfStrongMove1 = indexOfStrongMove2;
                }
            }
            
            if (strongMove1 == 0 && strongMove2 == 0 && strongMove3 == 0)
            {
                int rand = r.Next(validMoveList.Count);
                initPiece = validMoveList.ElementAt(rand).initPiece;
                initY = validMoveList.ElementAt(rand).initY;
                initX = validMoveList.ElementAt(rand).initX;
                targPiece = validMoveList.ElementAt(rand).targPiece;
                targY = validMoveList.ElementAt(rand).targY;
                targX = validMoveList.ElementAt(rand).targX;
            }

            else if (strongMove1 != 0 && strongMove2 != 0 && strongMove3 != 0)
            {
                int rand = r.Next(1, 3);
                if (rand == 1)
                {
                    initPiece = validMoveList.ElementAt(indexOfStrongMove1).initPiece;
                    initY = validMoveList.ElementAt(indexOfStrongMove1).initY;
                    initX = validMoveList.ElementAt(indexOfStrongMove1).initX;
                    targPiece = validMoveList.ElementAt(indexOfStrongMove1).targPiece;
                    targY = validMoveList.ElementAt(indexOfStrongMove1).targY;
                    targX = validMoveList.ElementAt(indexOfStrongMove1).targX;
                }

                else if (rand == 2)
                {
                    initPiece = validMoveList.ElementAt(indexOfStrongMove2).initPiece;
                    initY = validMoveList.ElementAt(indexOfStrongMove2).initY;
                    initX = validMoveList.ElementAt(indexOfStrongMove2).initX;
                    targPiece = validMoveList.ElementAt(indexOfStrongMove2).targPiece;
                    targY = validMoveList.ElementAt(indexOfStrongMove2).targY;
                    targX = validMoveList.ElementAt(indexOfStrongMove2).targX;
                }

                else if (rand == 3)
                {
                    initPiece = validMoveList.ElementAt(indexOfStrongMove3).initPiece;
                    initY = validMoveList.ElementAt(indexOfStrongMove3).initY;
                    initX = validMoveList.ElementAt(indexOfStrongMove3).initX;
                    targPiece = validMoveList.ElementAt(indexOfStrongMove3).targPiece;
                    targY = validMoveList.ElementAt(indexOfStrongMove3).targY;
                    targX = validMoveList.ElementAt(indexOfStrongMove3).targX;
                }  
            }

            else if (strongMove1 != 0 && strongMove2 != 0 && strongMove3 == 0)
            {
                int rand = r.Next(1, 2);
                if (rand == 1)
                {
                    initPiece = validMoveList.ElementAt(indexOfStrongMove1).initPiece;
                    initY = validMoveList.ElementAt(indexOfStrongMove1).initY;
                    initX = validMoveList.ElementAt(indexOfStrongMove1).initX;
                    targPiece = validMoveList.ElementAt(indexOfStrongMove1).targPiece;
                    targY = validMoveList.ElementAt(indexOfStrongMove1).targY;
                    targX = validMoveList.ElementAt(indexOfStrongMove1).targX;
                }

                else if (rand == 2)
                {
                    initPiece = validMoveList.ElementAt(indexOfStrongMove2).initPiece;
                    initY = validMoveList.ElementAt(indexOfStrongMove2).initY;
                    initX = validMoveList.ElementAt(indexOfStrongMove2).initX;
                    targPiece = validMoveList.ElementAt(indexOfStrongMove2).targPiece;
                    targY = validMoveList.ElementAt(indexOfStrongMove2).targY;
                    targX = validMoveList.ElementAt(indexOfStrongMove2).targX;
                }
            }

            else 
            {
                initPiece = validMoveList.ElementAt(indexOfStrongMove1).initPiece;
                initY = validMoveList.ElementAt(indexOfStrongMove1).initY;
                initX = validMoveList.ElementAt(indexOfStrongMove1).initX;
                targPiece = validMoveList.ElementAt(indexOfStrongMove1).targPiece;
                targY = validMoveList.ElementAt(indexOfStrongMove1).targY;
                targX = validMoveList.ElementAt(indexOfStrongMove1).targX;
            }

            // Reset variables
            strongMove1 = 0;
            indexOfStrongMove1 = 0;
            strongMove2 = 0;
            indexOfStrongMove2 = 0;
            strongMove3 = 0;
            indexOfStrongMove3 = 0;

            // Make the move
            Rules.MakeMove(initPiece, initY, initX, targY, targX, theBoard);
        }
    }
}

