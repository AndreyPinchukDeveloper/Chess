﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Chess
    {
        public string fen { get; private set; }
        Board board;
        Moves moves;
        List<FigureMoving> allMoves;

        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")//starting position for Chess
        {
            this.fen = fen;
            board = new Board(fen);
            moves = new Moves(board);
        }

        Chess (Board board)
        {
            this.board = board;
            this.fen = board.fen;
        }

        public Chess Move(string move)
        {
            FigureMoving fm = new FigureMoving(move);
            if (!moves.CanMove(fm))
            {
                return this;
            }

            if (board.IsCheckAfterMove(fm))
            {
                return this;
            }

            Board nextBoard = board.Move(fm);
            Chess nextChess = new Chess(nextBoard);
            return nextChess;
        }

        public char GetFigureAt(int x, int y)//that method show where are all figures and pawns right now
        {
            Position position = new Position(x,y);
            Figures f = board.GetFigureAt(position);
            return f == Figures.none ? '.' : (char)f;
        }

        private void FindAllMoves()
        {
            allMoves = new List<FigureMoving>();
            foreach (FigureOnSquare fs in board.YieldFigures())
            {
                foreach (Position to in Position.YieldPositions())
                {
                    FigureMoving fm = new FigureMoving(fs, to);
                    if (moves.CanMove(fm))//!!!!!!!!
                    {
                        if (!board.IsCheckAfterMove(fm))
                        {
                            allMoves.Add(fm);
                        }
                        
                    }
                }
            }
        }

        public List<string> GetAllMoves()
        {
            FindAllMoves();
            List<string> list = new List<String>();
            foreach (FigureMoving fm in allMoves)
            {
                list.Add(fm.ToString());
            }
            return list;
        }
    }
}
