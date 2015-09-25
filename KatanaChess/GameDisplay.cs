﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KatanaChess
{
    public partial class GameDisplay : Form
    {
        public GameDisplay()
        {
            InitializeComponent();
        }

        private void GameDisplay_Load(object sender, EventArgs e)
        {
            
        }
        
        // Undergoing testing [...]
        public void setButtonImage(int yVal, int xVal, int pieceType)
        {
            // Use this array to clean up this frankenstein of a function
            //System.Windows.Forms.Button[,] buttonRefContainer = new System.Windows.Forms.Button[,]
            //    {{button0_0, button0_1, button0_2, button0_3, button0_4, button0_5, button0_6, button0_7},
            //     {button1_0, button1_1, button1_2, button1_3, button1_4, button1_5, button1_6, button1_7},
            //     {button2_0, button2_1, button2_2, button2_3, button2_4, button2_5, button2_6, button2_7},
            //     {button3_0, button3_1, button3_2, button3_3, button3_4, button3_5, button3_6, button3_7},
            //     {button4_0, button4_1, button4_2, button4_3, button4_4, button4_5, button4_6, button4_7},
            //     {button5_0, button5_1, button5_2, button5_3, button5_4, button5_5, button5_6, button5_7},
            //     {button6_0, button6_1, button6_2, button6_3, button6_4, button6_5, button6_6, button6_7},
            //     {button7_0, button7_1, button7_2, button7_3, button7_4, button7_5, button7_6, button7_7}};

            switch (yVal)
            {
                case 0:
                    switch (xVal)
                    {
                        case 0:
                            if (pieceType == 0)
                            {
                                button0_0.BackgroundImage = null;
                            }
                            else if(pieceType == 1)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if(pieceType == -1)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button0_0.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 1:
                            if (pieceType == 0)
                            {
                                button0_1.BackgroundImage = null;
                            }
                            else if(pieceType == 1)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if(pieceType == -1)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button0_1.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 2:
                            if (pieceType == 0)
                            {
                                button0_2.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button0_2.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 3:
                            if (pieceType == 0)
                            {
                                button0_3.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button0_3.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 4:
                            if (pieceType == 0)
                            {
                                button0_4.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button0_4.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 5:
                            if (pieceType == 0)
                            {
                                button0_5.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button0_5.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 6:
                            if (pieceType == 0)
                            {
                                button0_6.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button0_6.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 7:
                            if (pieceType == 0)
                            {
                                button0_7.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button0_7.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        default:
                            
                            break;
                    }    
                    break;
                case 1:
                    switch (xVal)
                    {
                        case 0:
                            if (pieceType == 0)
                            {
                                button1_0.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button1_0.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 1:
                            if (pieceType == 0)
                            {
                                button1_1.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button1_1.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 2:
                            if (pieceType == 0)
                            {
                                button1_2.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button1_2.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 3:
                            if (pieceType == 0)
                            {
                                button1_3.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button1_3.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 4:
                            if (pieceType == 0)
                            {
                                button1_4.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button1_4.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 5:
                            if (pieceType == 0)
                            {
                                button1_5.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button1_5.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 6:
                            if (pieceType == 0)
                            {
                                button1_6.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button1_6.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 7:
                            if (pieceType == 0)
                            {
                                button1_7.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button1_7.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        default:

                            break;
                    }    
                    break;
                case 2:
                    switch (xVal)
                    {
                        case 0:
                            if (pieceType == 0)
                            {
                                button2_0.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button2_0.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 1:
                            if (pieceType == 0)
                            {
                                button2_1.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button2_1.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 2:
                            if (pieceType == 0)
                            {
                                button2_2.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button2_2.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 3:
                            if (pieceType == 0)
                            {
                                button2_3.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button2_3.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 4:
                            if (pieceType == 0)
                            {
                                button2_4.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button2_4.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 5:
                            if (pieceType == 0)
                            {
                                button2_5.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button2_5.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 6:
                            if (pieceType == 0)
                            {
                                button2_6.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button2_6.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 7:
                            if (pieceType == 0)
                            {
                                button2_7.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button2_7.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        default:

                            break;
                    }    
                    break;
                case 3:
                    switch (xVal)
                    {
                        case 0:
                            if (pieceType == 0)
                            {
                                button3_0.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button3_0.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 1:
                            if (pieceType == 0)
                            {
                                button3_1.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button3_1.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 2:
                            if (pieceType == 0)
                            {
                                button3_2.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button3_2.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 3:
                            if (pieceType == 0)
                            {
                                button3_3.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button3_3.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 4:
                            if (pieceType == 0)
                            {
                                button3_4.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button3_4.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 5:
                            if (pieceType == 0)
                            {
                                button3_5.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button3_5.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 6:
                            if (pieceType == 0)
                            {
                                button3_6.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button3_6.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 7:
                            if (pieceType == 0)
                            {
                                button3_7.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button3_7.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        default:

                            break;
                    }    
                    break;
                case 4:
                    switch (xVal)
                    {
                        case 0:
                            if (pieceType == 0)
                            {
                                button4_0.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button4_0.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 1:
                            if (pieceType == 0)
                            {
                                button4_1.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button4_1.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 2:
                            if (pieceType == 0)
                            {
                                button4_2.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button4_2.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 3:
                            if (pieceType == 0)
                            {
                                button4_3.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button4_3.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 4:
                            if (pieceType == 0)
                            {
                                button4_4.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button4_4.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 5:
                            if (pieceType == 0)
                            {
                                button4_5.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button4_5.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 6:
                            if (pieceType == 0)
                            {
                                button4_6.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button4_6.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 7:
                            if (pieceType == 0)
                            {
                                button4_7.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button4_7.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        default:

                            break;
                    }    
                    break;
                case 5:
                    switch (xVal)
                    {
                        case 0:
                            if (pieceType == 0)
                            {
                                button5_0.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button5_0.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 1:
                            if (pieceType == 0)
                            {
                                button5_1.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button5_1.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 2:
                            if (pieceType == 0)
                            {
                                button5_2.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button5_2.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 3:
                            if (pieceType == 0)
                            {
                                button5_3.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button5_3.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 4:
                            if (pieceType == 0)
                            {
                                button5_4.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button5_4.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 5:
                            if (pieceType == 0)
                            {
                                button5_5.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button5_5.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 6:
                            if (pieceType == 0)
                            {
                                button5_6.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button5_6.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 7:
                            if (pieceType == 0)
                            {
                                button5_7.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button5_7.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        default:

                            break;
                    }    
                    break;
                case 6:
                    switch (xVal)
                    {
                        case 0:
                            if (pieceType == 0)
                            {
                                button6_0.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button6_0.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 1:
                            if (pieceType == 0)
                            {
                                button6_1.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button6_1.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 2:
                            if (pieceType == 0)
                            {
                                button6_2.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button6_2.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 3:
                            if (pieceType == 0)
                            {
                                button6_3.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button6_3.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 4:
                            if (pieceType == 0)
                            {
                                button6_4.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button6_4.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 5:
                            if (pieceType == 0)
                            {
                                button6_5.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button6_5.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 6:
                            if (pieceType == 0)
                            {
                                button6_6.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button6_6.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 7:
                            if (pieceType == 0)
                            {
                                button6_7.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button6_7.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        default:

                            break;
                    }    
                    break;
                case 7:
                    switch (xVal)
                    {
                        case 0:
                            if (pieceType == 0)
                            {
                                button7_0.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button7_0.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 1:
                            if (pieceType == 0)
                            {
                                button7_1.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button7_1.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 2:
                            if (pieceType == 0)
                            {
                                button7_2.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button7_2.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 3:
                            if (pieceType == 0)
                            {
                                button7_3.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button7_3.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 4:
                            if (pieceType == 0)
                            {
                                button7_4.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button7_4.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 5:
                            if (pieceType == 0)
                            {
                                button7_5.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button7_5.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 6:
                            if (pieceType == 0)
                            {
                                button7_6.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button7_6.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        case 7:
                            if (pieceType == 0)
                            {
                                button7_7.BackgroundImage = null;
                            }
                            else if (pieceType == 1)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.whitePawn;
                            }
                            else if (pieceType == -1)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.blackPawn;
                            }
                            else if (pieceType == 2)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKnight;
                            }
                            else if (pieceType == -2)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.blackKnight;
                            }
                            else if (pieceType == 3)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.whiteBishop;
                            }
                            else if (pieceType == -3)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.blackBishop;
                            }
                            else if (pieceType == 4)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.whiteRook;
                            }
                            else if (pieceType == -4)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.blackRook;
                            }
                            else if (pieceType == 5)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.whiteQueen;
                            }
                            else if (pieceType == -5)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.blackQueen;
                            }
                            else if (pieceType == 6)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.whiteKing;
                            }
                            else if (pieceType == -6)
                            {
                                button7_7.BackgroundImage = KatanaChess.Properties.Resources.blackKing;
                            }
                            break;
                        default:

                            break;
                    }    
                    break;
                default:
                    
                    break;
            }
        }

        private void button0_0_Click(object sender, EventArgs e)
        {
            Game.onClick(0, 0, this);
        }

        private void button0_1_Click(object sender, EventArgs e)
        {
            Game.onClick(0, 1, this);
        }

        private void button0_2_Click(object sender, EventArgs e)
        {
            Game.onClick(0, 2, this);
        }

        private void button0_3_Click(object sender, EventArgs e)
        {
            Game.onClick(0, 3, this);
        }

        private void button0_4_Click(object sender, EventArgs e)
        {
            Game.onClick(0, 4, this);
        }

        private void button0_5_Click(object sender, EventArgs e)
        {
            Game.onClick(0, 5, this);
        }

        private void button0_6_Click(object sender, EventArgs e)
        {
            Game.onClick(0, 6, this);
        }

        private void button0_7_Click(object sender, EventArgs e)
        {
            Game.onClick(0, 7, this);
        }

        private void button1_0_Click(object sender, EventArgs e)
        {
            Game.onClick(1, 0, this);
        }

        private void button1_1_Click(object sender, EventArgs e)
        {
            Game.onClick(1, 1, this);
        }

        private void button1_2_Click(object sender, EventArgs e)
        {
            Game.onClick(1, 2, this);
        }

        private void button1_3_Click(object sender, EventArgs e)
        {
            Game.onClick(1, 3, this);
        }

        private void button1_4_Click(object sender, EventArgs e)
        {
            Game.onClick(1, 4, this);
        }

        private void button1_5_Click(object sender, EventArgs e)
        {
            Game.onClick(1, 5, this);
        }

        private void button1_6_Click(object sender, EventArgs e)
        {
            Game.onClick(1, 6, this);
        }

        private void button1_7_Click(object sender, EventArgs e)
        {
            Game.onClick(1, 7, this);
        }

        private void button2_0_Click(object sender, EventArgs e)
        {
            Game.onClick(2, 0, this);
        }

        private void button2_1_Click(object sender, EventArgs e)
        {
            Game.onClick(2, 1, this);
        }

        private void button2_2_Click(object sender, EventArgs e)
        {
            Game.onClick(2, 2, this);
        }

        private void button2_3_Click(object sender, EventArgs e)
        {
            Game.onClick(2, 3, this);
        }

        private void button2_4_Click(object sender, EventArgs e)
        {
            Game.onClick(2, 4, this);
        }

        private void button2_5_Click(object sender, EventArgs e)
        {
            Game.onClick(2, 5, this);
        }

        private void button2_6_Click(object sender, EventArgs e)
        {
            Game.onClick(2, 6, this);
        }

        private void button2_7_Click(object sender, EventArgs e)
        {
            Game.onClick(2, 7, this);
        }

        private void button3_0_Click(object sender, EventArgs e)
        {
            Game.onClick(3, 0, this);
        }

        private void button3_1_Click(object sender, EventArgs e)
        {
            Game.onClick(3, 1, this);
        }

        private void button3_2_Click(object sender, EventArgs e)
        {
            Game.onClick(3, 2, this);
        }

        private void button3_3_Click(object sender, EventArgs e)
        {
            Game.onClick(3, 3, this);
        }

        private void button3_4_Click(object sender, EventArgs e)
        {
            Game.onClick(3, 4, this);
        }

        private void button3_5_Click(object sender, EventArgs e)
        {
            Game.onClick(3, 5, this);
        }

        private void button3_6_Click(object sender, EventArgs e)
        {
            Game.onClick(3, 6, this);
        }

        private void button3_7_Click(object sender, EventArgs e)
        {
            Game.onClick(3, 7, this);
        }

        private void button4_0_Click(object sender, EventArgs e)
        {
            Game.onClick(4, 0, this);
        }

        private void button4_1_Click(object sender, EventArgs e)
        {
            Game.onClick(4, 1, this);
        }

        private void button4_2_Click(object sender, EventArgs e)
        {
            Game.onClick(4, 2, this);
        }

        private void button4_3_Click(object sender, EventArgs e)
        {
            Game.onClick(4, 3, this);
        }

        private void button4_4_Click(object sender, EventArgs e)
        {
            Game.onClick(4, 4, this);
        }

        private void button4_5_Click(object sender, EventArgs e)
        {
            Game.onClick(4, 5, this);
        }

        private void button4_6_Click(object sender, EventArgs e)
        {
            Game.onClick(4, 6, this);
        }

        private void button4_7_Click(object sender, EventArgs e)
        {
            Game.onClick(4, 7, this);
        }

        private void button5_0_Click(object sender, EventArgs e)
        {
            Game.onClick(5, 0, this);
        }

        private void button5_1_Click(object sender, EventArgs e)
        {
            Game.onClick(5, 1, this);
        }

        private void button5_2_Click(object sender, EventArgs e)
        {
            Game.onClick(5, 2, this);
        }

        private void button5_3_Click(object sender, EventArgs e)
        {
            Game.onClick(5, 3, this);
        }

        private void button5_4_Click(object sender, EventArgs e)
        {
            Game.onClick(5, 4, this);
        }

        private void button5_5_Click(object sender, EventArgs e)
        {
            Game.onClick(5, 5, this);
        }

        private void button5_6_Click(object sender, EventArgs e)
        {
            Game.onClick(5, 6, this);
        }

        private void button5_7_Click(object sender, EventArgs e)
        {
            Game.onClick(5, 7, this);
        }

        private void button6_0_Click(object sender, EventArgs e)
        {
            Game.onClick(6, 0, this);
        }

        private void button6_1_Click(object sender, EventArgs e)
        {
            Game.onClick(6, 1, this);
        }

        private void button6_2_Click(object sender, EventArgs e)
        {
            Game.onClick(6, 2, this);
        }

        private void button6_3_Click(object sender, EventArgs e)
        {
            Game.onClick(6, 3, this);
        }

        private void button6_4_Click(object sender, EventArgs e)
        {
            Game.onClick(6, 4, this);
        }

        private void button6_5_Click(object sender, EventArgs e)
        {
            Game.onClick(6, 5, this);
        }

        private void button6_6_Click(object sender, EventArgs e)
        {
            Game.onClick(6, 6, this);
        }

        private void button6_7_Click(object sender, EventArgs e)
        {
            Game.onClick(6, 7, this);
        }

        private void button7_0_Click(object sender, EventArgs e)
        {
            Game.onClick(7, 0, this);
        }

        private void button7_1_Click(object sender, EventArgs e)
        {
            Game.onClick(7, 1, this);
        }

        private void button7_2_Click(object sender, EventArgs e)
        {
            Game.onClick(7, 2, this);
        }

        private void button7_3_Click(object sender, EventArgs e)
        {
            Game.onClick(7, 3, this);
        }

        private void button7_4_Click(object sender, EventArgs e)
        {
            Game.onClick(7, 4, this);
        }

        private void button7_5_Click(object sender, EventArgs e)
        {
            Game.onClick(7, 5, this);
        }

        private void button7_6_Click(object sender, EventArgs e)
        {
            Game.onClick(7, 6, this);
        }

        private void button7_7_Click(object sender, EventArgs e)
        {
            Game.onClick(7, 7, this);
        }

        private void boardUpdateButton_Click(object sender, EventArgs e)
        {
            Game.updateBoardView(this);
        }
    }
}
