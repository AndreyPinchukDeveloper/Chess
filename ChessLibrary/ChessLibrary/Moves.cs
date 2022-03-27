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
                    return CanQueenMove();

                case Figures.whiteRook:
                case Figures.blackRook:
                    return CanRookMove();

                case Figures.whiteBishop:
                case Figures.blackBishop:
                    return CanBishopMove();

                case Figures.whiteKnight:
                case Figures.blackKnight:
                    return CanKnightMove();

                case Figures.whitePawn:
                case Figures.blackPawn:
                    return CanPawnMove();

                default:return false;
            }
        }

        private bool CanStraightMove()
        {
            Position at = fm.from;
            do
            {
                at = new Position(at.x + fm.SignX, at.y + fm.SignY);
                if (at == fm.to)
                {
                    return true;
                }
            } while (at.OnBoard() && board.GetFigureAt(at) == Figures.none);
            return false;
        }

        private bool CanBishopMove()
        {
            throw new NotImplementedException();
        }

        private bool CanPawnMove()
        {
            throw new NotImplementedException();
        }

        private bool CanRookMove()
        {
            throw new NotImplementedException();
        }

        private bool CanQueenMove()
        {
            CanStraightMove();
        }

        private bool CanKingMove()
        {
            if (fm.AbsDeltaX <= 1 && fm.AbsDeltaY<= 1)
            {
                return true;
            }
            return false;
        }

        private bool CanKnightMove()
        {
            if (fm.AbsDeltaX == 1 && fm.AbsDeltaY == 2) return true;
            if (fm.AbsDeltaX == 2 && fm.AbsDeltaY == 1) return true;
            return false;
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
