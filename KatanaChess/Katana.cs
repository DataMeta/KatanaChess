using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace KatanaChess
{
    public static class Katana
    {
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
        private static int stronkMove = 0;
        private static int indexOfStronkMove = 0;

        private static int pawnVal = 10;
        private static int knightVal = 30;
        private static int bishopVal = 30;
        private static int rookVal = 50;
        private static int queenVal = 90;
        private static int kingVal = 40;
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
        static public void swingKatana(int[,] theBoard)
        {
            getMoves(theBoard);
        }

        /* Loops through all legal moves without going out of bounds, 
         * calling validateMove for each one, storing them as Move structs in a list<Move> */
        // Calls evalMoves() to give each move a value
        static public void getMoves(int[,] theBoard)
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
                                Game.validateMove(theBoard[initY, initX], initY, initX, targY, targX))
                            {
                                Move move = new Move();
                                move.initPiece = theBoard[initY, initX];
                                move.initX = initX;
                                move.initY = initY;
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
                                        //move.value = 0;
                                        break;
                                }
                                validMoveList.Add(move);
                            }
                        }
                    }
                }
            }
            chooseMove(theBoard, validMoveList);
        }

        // Assigns all stored moves a value based on heuristics [may not use]
        static public void evalMoves(int[,] theBoard, List<Move> validMoveList)
        {
            // Code for outputting validMoveList
            //string testOutput = "";
            //foreach(Move move in validMoveList)
            //{
            //    testOutput += move.initPiece.ToString() + "  " + move.initX.ToString() + "_" + move.initY.ToString() + " :: " +
            //                  move.targPiece.ToString() + "  " + move.targY.ToString() + "_" + move.targX.ToString() + "\n"; 
            //}
            //MessageBox.Show(testOutput);

            //chooseMove(theBoard, validMoveList);
        }

        // Determines a move to make for a ply
        static public void chooseMove(int[,] theBoard, List<Move> validMoveList)
        {
            //Move theMove = new Move();
            //Random r = new Random();
            //int rand = r.Next(0, validMoveList.Count);

            for (int i = 0; i < validMoveList.Count; i++)
            {
                value = validMoveList.ElementAt(i).value; 
                if (value > stronkMove)
                {
                    stronkMove = value;
                    indexOfStronkMove = i;
                }
            }

            initPiece = validMoveList.ElementAt(indexOfStronkMove).initPiece;
            initY = validMoveList.ElementAt(indexOfStronkMove).initY;
            initX = validMoveList.ElementAt(indexOfStronkMove).initX;
            targPiece = validMoveList.ElementAt(indexOfStronkMove).targPiece;
            targY = validMoveList.ElementAt(indexOfStronkMove).targY;
            targX = validMoveList.ElementAt(indexOfStronkMove).targX;

            Rules.makeMove(initPiece, initY, initX, targY, targX, theBoard);
        }
    }
}

//theMove.initPiece = validMoveList.ElementAt(rand).initPiece;
//theMove.initY = validMoveList.ElementAt(rand).initY;
//theMove.initX = validMoveList.ElementAt(rand).initX;
//theMove.targPiece = validMoveList.ElementAt(rand).targPiece;
//theMove.targY = validMoveList.ElementAt(rand).targY;
//theMove.targX = validMoveList.ElementAt(rand).targX;
