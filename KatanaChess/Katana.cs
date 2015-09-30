using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            public int valMove;
        }

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
         * calling the appropriate isMoveValid for each move */
        /* Gets all valid moves for a single piece, square or possibly ply (implementation details), 
         * and stores them in a Tree */
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
                                validMoveList.Add(move);
                            }
                        }
                    }
                }
            }
            evalMoves(theBoard, validMoveList);
        }

        // Assigns all stored moves a value based on heuristics
        static public void evalMoves(int[,] theBoard, List<Move> validMoveList)
        {
            // Before implementing this, print out validMoveList to the screen [...]
            // There should be 20 possible moves at start
            string testOutput = "";
            foreach(Move move in validMoveList)
            {
                testOutput += move.initPiece.ToString() + "  " + move.initX.ToString() + "_" + move.initY.ToString() + " :: " +
                              move.targPiece.ToString() + "  " + move.targY.ToString() + "_" + move.targX.ToString() + "\n"; 
            }
            //MessageBox.Show(testOutput);
            chooseMove(theBoard, validMoveList);
        }

        // Determines a move to make for a ply
        static public void chooseMove(int[,] theBoard, List<Move> validMoveList)
        {
            Move theMove = new Move();
            Random r = new Random();
            int rand = r.Next(0, validMoveList.Count);
            //theMove.initPiece = validMoveList.ElementAt(rand).initPiece;
            //theMove.initY = validMoveList.ElementAt(rand).initY;
            //theMove.initX = validMoveList.ElementAt(rand).initX;
            //theMove.targPiece = validMoveList.ElementAt(rand).targPiece;
            //theMove.targY = validMoveList.ElementAt(rand).targY;
            //theMove.targX = validMoveList.ElementAt(rand).targX;
            int initPiece = validMoveList.ElementAt(rand).initPiece;
            int initY = validMoveList.ElementAt(rand).initY;
            int initX = validMoveList.ElementAt(rand).initX;
            int targPiece = validMoveList.ElementAt(rand).targPiece;
            int targY = validMoveList.ElementAt(rand).targY;
            int targX = validMoveList.ElementAt(rand).targX;
            Rules.makeMove(initPiece, initY, initX, targY, targX, theBoard);
        }
    }
}
