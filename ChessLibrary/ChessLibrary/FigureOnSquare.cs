using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    class FigureOnSquare
    {
        public Figures figures { get; private set; }
        public Position position { get; private set; }

        public FigureOnSquare (Figures figures, Position position)
        {
            this.figures = figures;
            this.position = position;
        }
    }
}
