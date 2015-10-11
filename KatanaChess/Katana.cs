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
    /// * NAME: 
    /// * DESCRIPTION:
    /// * AUTHOR:
    /// * DATE:
    /// </summary>
    public static class Katana
    {
        /// <summary>
        /// 
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

        private static int initPiece;
        private static int initY;
        private static int initX;
        private static int targPiece;
        private static int targY;
        private static int targX;
        private static int value;

        private static int stronkMove1 = 0;
        private static int indexOfStronkMove1 = 0;
        private static int stronkMove2 = 0;
        private static int indexOfStronkMove2 = 0;
        private static int stronkMove3 = 0;
        private static int indexOfStronkMove3 = 0;

        private static int pawnVal = 10;
        private static int knightVal = 28;
        private static int bishopVal = 33;
        private static int rookVal = 50;
        private static int queenVal = 90;
        private static int kingVal = 10000;
        private static int check = 500;
        private static int checkmate = 10000;
        private static int phalanx; // minimum 2 friendly units next to each other with overlapping arcs of attack
        private static int chain; // minimum 2 friendly units directly defending each other 
        private static int fork; // putting minimum 2 enemy units under simultaneous attack
        private static int block; // a unit is blocked by a friendly unit or non-threatening enemy (?)
        private static int vantage; // a unit is in an open position to attack without impediment
        private static int ambush; // a unit is in a position to defend effectively

        //private static int captureDiff;
        //private static int stronkMove;

        /* Uses variables to keep track of notable squares to improve and 
         * speed up value determination for the rest of the moves.
         * (Ex. Contended squares, open files, open ranks, )*/

        /* Uses variables to keep track of notable piece states 
         * (Ex. When blocked, has avenue of attack, is open to attack/check, is pinned [esp. to king]) */

        // Commences AI thought process
        /// <summary>
        /// * NAME: 
        /// * SYNOPSIS:
        /// * DESCRIPTION:
        /// * AUTHOR:
        /// * DATE:
        /// </summary>
        /// <param name="theBoard"></param>
        public static void SwingKatana(int[,] theBoard)
        {
            GetMoves(theBoard);
        }

        /* Loops through all legal moves without going out of bounds, 
         * calling validateMove for each one, storing them as Move structs in a list<Move> */
        // Calls evalMoves() to give each move a value
        /// <summary>
        /// * NAME: 
        /// * SYNOPSIS:
        /// * DESCRIPTION:
        /// * AUTHOR:
        /// * DATE:
        /// </summary>
        /// <param name="theBoard"></param>
        private static void GetMoves(int[,] theBoard)
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
            SelectMove(theBoard, validMoveList);
        }

        // Determines a move to make for a ply
        /// <summary>
        /// * NAME: 
        /// * SYNOPSIS:
        /// * DESCRIPTION:
        /// * AUTHOR:
        /// * DATE:
        /// </summary>
        /// <param name="theBoard"></param>
        /// <param name="validMoveList"></param>
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

            for (int i = 0; i < validMoveList.Count; i++)
            {
                value = validMoveList.ElementAt(i).value; 
                if (value > stronkMove3)
                {
                    stronkMove3 = value;
                    indexOfStronkMove3 = i;
                }
                if (stronkMove3 > stronkMove2)
                {
                    stronkMove2 = stronkMove3;
                    indexOfStronkMove2 = indexOfStronkMove3;
                }
                if (stronkMove2 > stronkMove1)
                {
                    stronkMove1 = stronkMove2;
                    indexOfStronkMove1 = indexOfStronkMove2;
                }
            }
            
            if (stronkMove1 == 0 && stronkMove2 == 0 && stronkMove3 == 0)
            {
                int rand = r.Next(validMoveList.Count);
                initPiece = validMoveList.ElementAt(rand).initPiece;
                initY = validMoveList.ElementAt(rand).initY;
                initX = validMoveList.ElementAt(rand).initX;
                targPiece = validMoveList.ElementAt(rand).targPiece;
                targY = validMoveList.ElementAt(rand).targY;
                targX = validMoveList.ElementAt(rand).targX;
            }

            else if (stronkMove1 != 0 && stronkMove2 != 0 && stronkMove3 != 0)
            {
                int rand = r.Next(1, 3);
                if (rand == 1)
                {
                    initPiece = validMoveList.ElementAt(indexOfStronkMove1).initPiece;
                    initY = validMoveList.ElementAt(indexOfStronkMove1).initY;
                    initX = validMoveList.ElementAt(indexOfStronkMove1).initX;
                    targPiece = validMoveList.ElementAt(indexOfStronkMove1).targPiece;
                    targY = validMoveList.ElementAt(indexOfStronkMove1).targY;
                    targX = validMoveList.ElementAt(indexOfStronkMove1).targX;
                }

                else if (rand == 2)
                {
                    initPiece = validMoveList.ElementAt(indexOfStronkMove2).initPiece;
                    initY = validMoveList.ElementAt(indexOfStronkMove2).initY;
                    initX = validMoveList.ElementAt(indexOfStronkMove2).initX;
                    targPiece = validMoveList.ElementAt(indexOfStronkMove2).targPiece;
                    targY = validMoveList.ElementAt(indexOfStronkMove2).targY;
                    targX = validMoveList.ElementAt(indexOfStronkMove2).targX;
                }

                else if (rand == 3)
                {
                    initPiece = validMoveList.ElementAt(indexOfStronkMove3).initPiece;
                    initY = validMoveList.ElementAt(indexOfStronkMove3).initY;
                    initX = validMoveList.ElementAt(indexOfStronkMove3).initX;
                    targPiece = validMoveList.ElementAt(indexOfStronkMove3).targPiece;
                    targY = validMoveList.ElementAt(indexOfStronkMove3).targY;
                    targX = validMoveList.ElementAt(indexOfStronkMove3).targX;
                }  
            }

            else if (stronkMove1 != 0 && stronkMove2 != 0 && stronkMove3 == 0)
            {
                int rand = r.Next(1, 2);
                if (rand == 1)
                {
                    initPiece = validMoveList.ElementAt(indexOfStronkMove1).initPiece;
                    initY = validMoveList.ElementAt(indexOfStronkMove1).initY;
                    initX = validMoveList.ElementAt(indexOfStronkMove1).initX;
                    targPiece = validMoveList.ElementAt(indexOfStronkMove1).targPiece;
                    targY = validMoveList.ElementAt(indexOfStronkMove1).targY;
                    targX = validMoveList.ElementAt(indexOfStronkMove1).targX;
                }

                else if (rand == 2)
                {
                    initPiece = validMoveList.ElementAt(indexOfStronkMove2).initPiece;
                    initY = validMoveList.ElementAt(indexOfStronkMove2).initY;
                    initX = validMoveList.ElementAt(indexOfStronkMove2).initX;
                    targPiece = validMoveList.ElementAt(indexOfStronkMove2).targPiece;
                    targY = validMoveList.ElementAt(indexOfStronkMove2).targY;
                    targX = validMoveList.ElementAt(indexOfStronkMove2).targX;
                }
            }

            else 
            {
                initPiece = validMoveList.ElementAt(indexOfStronkMove1).initPiece;
                initY = validMoveList.ElementAt(indexOfStronkMove1).initY;
                initX = validMoveList.ElementAt(indexOfStronkMove1).initX;
                targPiece = validMoveList.ElementAt(indexOfStronkMove1).targPiece;
                targY = validMoveList.ElementAt(indexOfStronkMove1).targY;
                targX = validMoveList.ElementAt(indexOfStronkMove1).targX;
            }

            stronkMove1 = 0;
            indexOfStronkMove1 = 0;
            stronkMove2 = 0;
            indexOfStronkMove2 = 0;
            stronkMove3 = 0;
            indexOfStronkMove3 = 0;

            Rules.MakeMove(initPiece, initY, initX, targY, targX, theBoard);
        }
    }
}

//if (Rules.pawnScan(initY, initX, theBoard, true)
//    || Rules.knightScan(initY, initX, theBoard, true)
//    || Rules.bishopScan(initY, initX, theBoard, true)
//    || Rules.rookScan(initY, initX, theBoard, true)
//    || Rules.queenScan(initY, initX, theBoard, true)
//    || Rules.kingScan(initY, initX, theBoard, true))
//{
//    switch (Math.Abs(move.initPiece))
//    {
//        case 0:
//            move.value = 0;
//            break;
//        case 1:
//            move.value += pawnVal;
//            break;
//        case 2:
//            move.value += knightVal;
//            break;
//        case 3:
//            move.value += bishopVal;
//            break;
//        case 4:
//            move.value += rookVal;
//            break;
//        case 5:
//            move.value += queenVal;
//            break;
//        case 6:
//            move.value += kingVal;
//            break;
//        default:
//            break;
//    }
//}

// Ally support scan section
//if (Rules.pawnScan(targY, targX, theBoard, true))
//{
//    move.value += pawnVal;
//}
//if (Rules.knightScan(targY, targX, theBoard, true))
//{
//    move.value += knightVal;
//}
//if (Rules.bishopScan(targY, targX, theBoard, true))
//{
//    move.value += bishopVal;
//}
//if (Rules.rookScan(targY, targX, theBoard, true))
//{
//    move.value += rookVal;
//}
//if (Rules.queenScan(targY, targX, theBoard, true))
//{
//    move.value += queenVal;
//}
//if (Rules.kingScan(targY, targX, theBoard, true))
//{
//    move.value += kingVal;
//}

// Strategic heuristics to break up the attack move monopoly
// Katana must move like wind of bricks
// [...]
