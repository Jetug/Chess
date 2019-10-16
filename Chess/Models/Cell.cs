using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    public class Cell
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public Cell(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }
    }
}
