using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    class Moves
    {
        FigureMoving fm;
        Board board;
        public Moves(Board board)
        {
            this.board = board;
        }

        public bool CanMove(FigureMoving fm)
        {
            this.fm = fm;
            return
                CanMoveFrom() &&
                CanMoveTo() &&
                CanFigureMove();
        }

        private bool CanFigureMove()
        {
            switch (fm.figures)
            {
                case Figures.whiteKing:
                case Figures.blackKing:
                    return CanKingMove();
                case Figures.whiteQueen:
                case Figures.blackQueen:
                    break;
                case Figures.whiteRook:
                case Figures.blackRook:
                    break;
                case Figures.whiteBishop:
                case Figures.blackBishop:
                    break;
                case Figures.whiteKnight:
                case Figures.blackKnight:
                    return CanKnightMove();
                case Figures.whitePawn:
                case Figures.blackPawn:
                    break;
                default:
                    return false;
            }
        }

        private bool CanKingMove()
        {
            if (fm.AbsDeltaX <= 1 && fm.AbsDeltaY<= 1)
            {

            }
        }

        private bool CanKnightMove()
        {
            if (Math.Abs())
            {

            }
        }

        private bool CanMoveTo()
        {
            return fm.to.OnBoard() && fm.from != fm.to && 
                board.GetFigureAt(fm.to).GetColor() != board.moveColor;
        }

        private bool CanMoveFrom()
        {
            return fm.from.OnBoard() && fm.figures.GetColor() == board.moveColor;
        }

    }
}
