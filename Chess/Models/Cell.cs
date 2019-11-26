namespace Chess.Models
{
    /// <summary>
    /// Представляет информацию о положении фигуры на поле.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Позиция по горизонтали.
        /// </summary>
        public int PosX { get; set; }
        /// <summary>
        /// Позиция по вертикали.
        /// </summary>
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

        /// <summary>
        /// Возвращает true если объект типа Cell имеет значение null, в противном случае возвращает false.
        /// </summary>>
        /// <param name="value">Объект который надо проверить.</param>
        /// <returns></returns
        public static bool IsNull(Cell value)
        {
            return value == null ? true : false;
        }


        /// <summary>
        /// Проверяет совпадают ли позиции двух клеток.
        /// </summary>
        /// <param name="cellA">Первая сравниваемая клетка.</param>
        /// <param name="cellB">Вторая сравниваемая клетка.</param>
        /// <returns>
        /// Значение true, если позиции двух клеток равны, в противном случае — значение false.
        /// </returns>
        public static bool IsEqual(Cell cellA, Cell cellB)
        {
            return cellA.PosX == cellB.PosX && cellA.PosY == cellB.PosY;
        }

        public bool IsCastling { get; set; } = false;
        public Rook RookForCastling { get; set; }
    }
}
