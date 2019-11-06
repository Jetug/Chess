using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    /// <summary>
    /// Представляет информацию о положении фигуры на поле.
    /// </summary>
    public class Cell
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса Cell и задаёт начальную позицию.
        /// </summary>
        /// <param name="posX">Позиция по горизонтали</param>
        /// <param name="posY">Позиция по вертикали</param>
        public Cell(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }
        public static bool IsNull(Cell value)
        {
            return value == null ? true : false;
        }

        public bool IsCastling { get; set; } = false;
        public Rook RookForCastling { get; set; }
    }
}
