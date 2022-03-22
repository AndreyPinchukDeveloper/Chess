using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    class Board
    {
        public string fen { get; private set; }
        Figures[,] figures;
        public Color moveColor { get; private set; }
        public int moveNumber { get; private set; }

        public Board(string fen)
        {
            this.fen = fen;
            figures = new Figures[8, 8];
            Init();
        }

        void Init()
        {
            SetFigureAt(new Position("a1"), Figures.whiteKing);
            SetFigureAt(new Position("h8"), Figures.blackKing);
            moveColor = Color.white;
        }

        public Figures GetFigureAt(Position position)
        {
            if (position.OnBoard())
            {
                return figures[position.x, position.y];
            }
            return Figures.none;
        }

        void SetFigureAt(Position position, Figures figure)
        {
            if (position.OnBoard())
            {
                figures[position.x, position.y] = figure;
            }
        }

        public Board Move(FigureMoving fm)
        {
            Board next = new Board(fen);
            next.SetFigureAt(fm.from, Figures.none);
            next.SetFigureAt(fm.to, fm.promotion == Figures.none ? fm.figures : fm.promotion);
            if (moveColor == Color.black)
            {
                next.moveNumber++;
            }
            next.moveColor = moveColor.FlipColor();
            return next;
        } 
    }
}
