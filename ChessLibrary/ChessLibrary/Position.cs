using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    struct Position
    {
        public static Position none = new Position(-1, -1);
        public int x { get; private set; }
        public int y { get; private set; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Position(string e2)
        {
            if (e2.Length == 2 &&
                e2[0] >= 'a' &&
                e2[0] <= 'h' &&
                e2[1] >= '1' &&
                e2[1] <= '8' )
            {
                x = e2[0] - 'a';
                y = e2[1] - '1';
            }
            else
            {
                this = none;
            }
        }

        public bool OnBoard()//Is that position on the board ?
        {
            return x >= 0 && x < 8 &&
                   y >= 0 && y < 8;
        }
    }
}
