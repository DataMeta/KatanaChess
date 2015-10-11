using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaChess
{
    /// <summary>
    /// * NAME 
    ///     Game.cs
    /// 
    /// * DESCRIPTION
    ///     This class holds the data structure responsible for keeping track of the state of the board.
    ///     It handles user input, turn order, validates the player move by determining 
    ///     the appropriate validation method from Rule.cs to call
    ///     It updates the board by looping through the board and passing
    ///     the appropriate parameters for each square to GameDisplay::SetButtonImage
    /// 
    /// * AUTHOR
    ///     Daniel Melnikov
    /// 
    /// * DATE
    ///     9/12/15
    /// </summary>
    public static class Game
    { 
        /// <summary>
        /// The integer value corresponding to a type of piece
        /// </summary>
        private static int pieceType;

        /// <summary>
        /// Keeps track of amount of clicks made to allow the two-case method Game::OnClick to operate
        /// </summary>
        private static int clickcount = 0;

        /// <summary>
        /// Used in the switch statement in Game::OnClick
        /// </summary>
        private static int clickvalue;

        /// <summary>
        /// Y coordinate of the initial square, used by Game::OnClick()
        /// </summary>
        private static int alphaY;

        /// <summary>
        /// X coordinate of the initial square, used by Game::OnClick()
        /// </summary>
        private static int alphaX;

        /// <summary>
        /// Y coordinate of the target square, used by Game::OnClick()
        /// </summary>
        private static int betaY;

        /// <summary>
        /// X coordinate of the target square, used by Game::OnClick()
        /// </summary>
        private static int betaX;

        /// <summary>
        /// Defines each type of piece as an positive integer value
        /// </summary>
        public enum pieceID
        {
            Pawn = 1, // -1/1
            Knight = 2, // -2/2
            Bishop = 3, // -3/3
            Rook = 4, // -4/4
            Queen = 5, // -5/5
            King = 6 // -6/6
        };

        /// <summary>
        /// A two-dimensional array that holds the game's board state information
        /// It keeps track of piece location and piece type
        /// Black pieces are defined as follows: 
        ///     pawn = -1, knight = -2, bishop = -3, rook = -4, queen = -5, king = -6
        /// White pieces are defined as follows:
        ///     pawn = 1, knight = 2, bishop = 3, rook = 4, queen = 5, king = 6
        /// </summary>
        private static int[,] theBoard = new int[,] { {-4, -2, -3, -5, -6, -3, -2, -4},
                                                      {-1, -1, -1, -1, -1, -1, -1, -1},
                                                      { 0,  0,  0,  0,  0,  0,  0,  0},
                                                      { 0,  0,  0,  0,  0,  0,  0,  0},
                                                      { 0,  0,  0,  0,  0,  0,  0,  0},
                                                      { 0,  0,  0,  0,  0,  0,  0,  0},
                                                      { 1,  1,  1,  1,  1,  1,  1,  1},
                                                      { 4,  2,  3,  5,  6,  3,  2,  4}};
        
        /// <summary>
        /// * NAME
        ///     Game::ValidateMove()
        ///     
        /// * SYNOPSIS
        ///     public static bool Game::ValidateMove(int pieceType, int initY, int initX, int targY, int targX)
        ///     
        ///     pieceType   --> An integer value corresponding to a type of chess piece
        ///     initY       --> The Y coordinate of the square of the piece whose move is under validation (initiating square)
        ///     initX       --> The X coordinate of the initiating square
        ///     targY       --> The Y coordinate of the target square to which the initiating piece is to move to
        ///     targX       --> The X coordinate of the target square
        ///     
        /// * DESCRIPTION 
        ///     Determines the appropriate Rule class method needed to check the legality and validity of a move, and calls it
        /// 
        /// * RETURNS
        ///     Returns true if the move is legal and valid according to the current board state
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/16/15
        ///  
        /// </summary>
        /// <param name="pieceType"></param>
        /// <param name="initY"></param>
        /// <param name="initX"></param>
        /// <param name="targY"></param>
        /// <param name="targX"></param>
        /// <returns name="isValid"></returns>
        public static bool ValidateMove(int pieceType, int initY, int initX, int targY, int targX)
        {
            bool isValid;
            pieceID switchID = (pieceID)Math.Abs(pieceType);
            switch (switchID)
            {
                // Call the appropriate move validation method based on pieceID
                case pieceID.Pawn:
                    isValid = Rules.IsPawnMoveValid(initY, initX, targY, targX, theBoard, pieceType);
                    break;
                case pieceID.Knight:
                    isValid = Rules.IsKnightMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.Bishop:
                    isValid = Rules.IsBishopMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.Rook:
                    isValid = Rules.IsRookMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.Queen:
                    isValid = Rules.IsQueenMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                case pieceID.King:
                    isValid = Rules.IsKingMoveValid(initY, initX, targY, targX, theBoard);
                    break;
                default:
                    isValid = false;
                    break;
            }
            return isValid;
        }

        /// <summary>
        /// * NAME
        ///     Game::UpdateBoardView()
        ///     
        /// * SYNOPSIS
        ///     public static void Game::UpdateBoardView(GameDisplay boardView)
        ///     
        ///     boardView   --> An object of type GameDisplay that is passed from GameDisplay in the event of a button press
        ///                     that allows Game::UpdateBoardView to call GameDisplay::SetButtonImage corresponding to each square index
        /// 
        /// * DESCRIPTION
        ///     Updates the board display based on board state while retaining Model-View separation.
        ///     That is - the board state lives in Game.cs, while the GUI and its controls live in GameDisplay.cs
        ///     
        /// * RETURNS
        ///     This method returns nothing
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/25/15
        ///     
        /// </summary>
        /// <param name="boardView"></param>
        public static void UpdateBoardView(GameDisplay boardView)
        {
            pieceID switchID;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switchID = (pieceID)Math.Abs(theBoard[i, j]);
                    pieceType = theBoard[i, j];
                    switch (switchID)
                    {
                        case pieceID.Pawn:
                            if (pieceType == 1)
                            {
                                boardView.SetButtonImage(i, j, 1); 
                            }
                            else if (pieceType == -1)
                            {
                                boardView.SetButtonImage(i, j, -1);
                            }
                            break;
                        case pieceID.Knight:
                            if (pieceType == 2)
                            {
                                boardView.SetButtonImage(i, j, 2);
                            }
                            else if (pieceType == -2)
                            {
                                boardView.SetButtonImage(i, j, -2);
                            }
                            break;
                        case pieceID.Bishop:
                            if (pieceType == 3)
                            {
                                boardView.SetButtonImage(i, j, 3);
                            }
                            else if (pieceType == -3)
                            {
                                boardView.SetButtonImage(i, j, -3);
                            }
                            break;
                        case pieceID.Rook:
                            if (pieceType == 4)
                            {
                                boardView.SetButtonImage(i, j, 4);
                            }
                            else if (pieceType == -4)
                            {
                                boardView.SetButtonImage(i, j, -4);
                            }
                            break;
                        case pieceID.Queen:
                            if (pieceType == 5)
                            {
                                boardView.SetButtonImage(i, j, 5);
                            }
                            else if (pieceType == -5)
                            {
                                boardView.SetButtonImage(i, j, -5);
                            }
                            break;
                        case pieceID.King:
                            if (pieceType == 6)
                            {
                                boardView.SetButtonImage(i, j, 6);
                            }
                            else if (pieceType == -6)
                            {
                                boardView.SetButtonImage(i, j, -6);
                            }
                            break;
                        default:
                            boardView.SetButtonImage(i, j, 0);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// * NAME
        ///     Game::OnClick()
        ///     
        /// * SYNOPSIS
        ///     public static void Game::OnClick(int yVal, int xVal, GameDisplay boardView)
        ///     
        ///     yVal        --> The Y coordinate of the square whose button was clicked
        ///     xVal        --> The X coordinate of the square whose button was clicked
        /// 
        /// * DESCRIPTION
        ///     Handles user input from the chessboard GUI by grabbing the appropriate data to pass
        ///     to Game::ValidateMove() and Rules::MakeMove()
        ///     Validates the player move and makes it if valid, initiates the AI master method so it can take its turn
        ///     Checks for pawn conversion after both the player and AI moves
        ///     Calls Game::UpdateBoardView() after both the player and AI moves
        ///     
        /// * RETURNS
        ///     This method returns nothing
        ///     
        /// * AUTHOR
        ///     Daniel Melnikov
        ///     
        /// * DATE
        ///     9/23/15
        ///     
        /// </summary>
        /// <param name="yVal"></param>
        /// <param name="xVal"></param>
        /// <param name="boardView"></param>
        public static void OnClick(int yVal, int xVal, GameDisplay boardView)
        {
		    clickvalue = clickcount % 2;
            clickcount++;
		
            // When clickvalue is even, case 0 is used; when odd, case 1 is used
            // Effectively, the player's first click (selecting the moving piece) triggers case 0
            // While the second click (selecting the target square or piece) triggers case 1
		    switch(clickvalue)
		    {
			    case 0:
                    alphaY = yVal;
                    alphaX = xVal;
                    pieceType = theBoard[alphaY, alphaX];
                    
                    break;
                case 1:
                    betaY = yVal;
                    betaX = xVal;

                    if(ValidateMove(pieceType, alphaY, alphaX, betaY, betaX))
                    {
                        Rules.MakeMove(pieceType, alphaY, alphaX, betaY, betaX, theBoard);
                        Rules.CheckPawnConvert(theBoard);
                        UpdateBoardView(boardView);
                        Katana.SwingKatana(theBoard);
                        Rules.CheckPawnConvert(theBoard);
                        UpdateBoardView(boardView);
                    }
                    break;
            }
        }
    }
}
