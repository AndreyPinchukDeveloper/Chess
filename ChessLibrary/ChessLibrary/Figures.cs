using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    enum Figures
    {
        none,
        whiteKing = 'K',
        whiteQueen = 'Q',
        whiteRook = 'R',
        whiteBishop = 'B',
        whiteKnight ='N',
        whitePawn = 'P',

        blackKing = 'k',
        blackQueen = 'q',
        blackRook = 'r',
        blackBishop = 'b',
        blackKnight = 'n',
        blackPawn = 'p'
    }

   static class FigureMethods
   {
        public static Color GetColor(this Figures figure)
        {
            if (figure == Figures.none)
            {
                return Color.none;
            }
            return (figure == Figures.whiteKing ||
                    figure == Figures.whiteQueen ||
                    figure == Figures.whiteRook ||
                    figure == Figures.whiteBishop ||
                    figure == Figures.whiteKnight ||
                    figure == Figures.whitePawn) ? Color.white : Color.black;
        }
   }
}
