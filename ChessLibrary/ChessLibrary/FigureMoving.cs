using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    class FigureMoving
    {

        public Figures figures { get; private set; }
        public Position from { get; private set; }
        public Position to { get; private set; }
        public Figures promotion { get; private set; }

        public FigureMoving (FigureOnSquare fs, Position to, Figures promotion = Figures.none)
        {
            this.figures = fs.figures;//saving our information about figure
            this.from = fs.position;
            this.to = to;
            this.promotion = promotion;
        }

        public FigureMoving (string move)
        {
            this.figures = (Figures)move[0];//here we're using enum
            this.from = new Position(move.Substring(1, 2));
            this.to = new Position(move.Substring(3, 2));
            this.promotion = (move.Length == 6) ? (Figures)move[5] : Figures.none;//ternary operator
        }

        public int DeltaX { get { return to.x - from.x; } }
        public int DeltaY { get { return to.y - from.y; } }

        public int AbsDeltaX { get { return Math.Abs(DeltaX); } }
        public int AbsDeltaY { get { return Math.Abs(DeltaY); } }

        public int AbsSignX { get { return Math.Sign(DeltaX); } }
        public int AbsSignY { get { return Math.Sign(DeltaY); } }
    }
}
