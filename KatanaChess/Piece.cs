using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaChess
{
    class Piece
    {
        private int pieceType;
        private int posY;
        private int posX;

        public int PieceType
        {
            get
            {
                return pieceType;
            }
            set
            {
                pieceType = value;
            }
        }
        public int PosX
        {
            get
            {
                return posX;
            }
            set
            {
                posX = value;
            }
        }
        public int PosY 
        {
            get
            {
                return posY;
            }
            set
            {
                posY = value;
            }
        }
    }
}
