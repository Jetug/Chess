using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    static class DialogWindowModel
    {
        /// <summary>
        /// Фигура в которую должна превратиться пешка.
        /// </summary>
        public static Figure PawnTransformFigure { get; private set; }

        /// <summary>
        /// Передаёт в PawnTransformFigure фигуру в которую должна превратиться пешка.
        /// </summary>
        /// <param name="icon"></param>
        public static void SetFigure(string icon)
        {
            switch (icon)
            {
                case "♛": PawnTransformFigure = new Queen(new Cell(0, 0), true); break;
                case "♜": PawnTransformFigure = new Rook(new Cell(0, 0), true); break;
                case "♞": PawnTransformFigure = new Knight(new Cell(0, 0), true); break;
                case "♝": PawnTransformFigure = new Bishop(new Cell(0, 0), true); break;
            }
        }
    }
}
