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

        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")//starting position for Chess
        {
            this.fen = fen;
            board = new Board(fen);
        }

        Chess (Board board)
        {
            this.board = board;
        }

        public Chess Move(string move)
        {
            FigureMoving fm = new FigureMoving(move);
            Board nextBoard = board.Move(fm);
            Chess nextChess = new Chess(nextBoard);
            return nextChess;
        }

        public char GetFigureAt(int x, int y)//that method show where are all figures and pawns right now
        {
            Position position = new Position();

        }
    }
}
