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
            string[] parts = fen.Split();
            if (parts.Length!=6)
            {
                return;
            }
            InitFigures(parts[0]);
            moveColor = (parts[1] == "b") ? Color.black : Color.white;
            moveNumber = int.Parse(parts[5]);
        }

        private void InitFigures(string data)
        {
            for (int i = 8; i >=2; i--)
            {
                data = data.Replace(i.ToString(), (i - 1).ToString() + "1");
            }

            data = data.Replace("1", ".");

            string[] lines = data.Split('/');

            for (int y = 7; y >=0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    figures[x, y] = lines[7-y][x] == '.' ? Figures.none : (Figures)lines[7 - y][x];
                }
            }
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
            next.GenerateFEN();
            return next;
        }

        private void GenerateFEN()
        {
            fen = FenFigures() + " " + 
                (moveColor == Color.white ? "w" : "b") + 
                " - - 0 " + moveNumber.ToString(); 
        }

        private string FenFigures()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 7; y >=0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    sb.Append(figures[x, y] == Figures.none ? '1' : (char)figures[[x, y]);
                }
                if (y > 0)
                {
                    sb.Append('/');
                }
            }
            string eight = "11111111";
            for (int j = 8; j >=2; j--)
            {
                sb.Replace(eight.Substring(0, j), j.ToString());
            }
            return sb.ToString();
        }
    }
}
