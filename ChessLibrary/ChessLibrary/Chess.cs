using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Chess
    {
        public string fen;
        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")//starting position for Chess
        {
            this.fen = fen;
        }

        public Chess Move(string move)
        {
            Chess nextChess = new Chess(fen);
            return nextChess;
        }

        public char GetFigureAt(int x, int y)//that method show where are all figures and pawns right now
        {
            return '.';
        }
    }
}
