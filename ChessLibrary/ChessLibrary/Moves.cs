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
            return (fm.SignX != 0 && fm.SignY != 0) && CanStraightMove();
        }

        private bool CanPawnMove()
        {
            if (fm.from.y < 1 || fm.from.y > 6)
            {
                return false;
            }
            int stepY = fm.figure.GetColor() == ConsoleColor.White ? 1 : -1;
            return CanPawnGo(stepY) || CanPawnJump(steY) || CanPawnCapture(stepY);
        }

        private bool CanPawnGo(int stepY)
        {
            if (board.GetFigureAt(fm.to) == Figures.none)
            {
                if (fm.DeltaX == 0)
                {
                    if (fm.DeltaY == stepY)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CanPawnJump(int stepY)
        {
            if (board.GetFigureAt(fm.to) == Figures.none)
            {
                if (fm.DeltaX == 0)
                {
                    if (fm.DeltaY == 2 * stepY)
                    {
                        if (fm.from.y == 1 || fm.from.y == 6)
                        {
                            if (board.GetFigureAt(new Position(fm.from.x, fm.from.y + stepY)) == Figures.none)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool CanPawnCapture(int stepY)
        {
            if (board.GetFigureAt(fm.to) != Figures.none)
            {
                if (fm.AbsDeltaX == 1)
                {
                    if (fm.DeltaY == stepY)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CanRookMove()
        {
            return (fm.SignX == 0 || fm.SignY == 0) && CanStraightMove();
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
