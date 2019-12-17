using System.Collections.Generic;

namespace Chess.Models
{
    /// <summary>
    /// Базовый класс для всех шахматных фигур.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Взвращает или задаёт цвет фигуры. Значение true - белый цвет, значение false - чёрный.
        /// </summary>
        public bool IsWhite { get; set; }
        protected Cell cell;
        /// <summary>
        /// Возвращает или задаёт позицию фигуры на поле.
        /// </summary>
        public abstract Cell Cell { get; set; }

        /// <summary>
        /// Возвращает символ данной фигуры.
        /// </summary>
        public abstract string Icon{ get; }

        /// <summary>
        /// Возвращает все возможные ходы для данной фигуры.
        /// </summary>
        /// <param name="figures">Список всех фирур находящихся на поле.</param>
        /// <returns></returns>
        public abstract List<Cell> GetPossibleTurns(List<Figure> figures);

        /// <summary>
        /// Инициализирует новый экземпляр класса Figure.
        /// </summary>
        protected Figure(){}
        /// <summary>
        /// Инициализирует новый экземпляр класса Figure и задаёт начальную поцицию и цвет фигуры.
        /// </summary>
        protected Figure(Cell cell, bool isWhite)
        {
            this.cell = cell;
            this.IsWhite = isWhite;
        }
    }

    /// <summary>
    /// Представляет фигуру "Король".
    /// </summary>
    public class King : Figure
    {
        public override string Icon => "♚";
        public bool FirstMove { get; set; } = true;

        /// <summary>
        /// Взвращает или задаёт позицию короля на поле.
        /// </summary>
        public override Cell Cell
        {
            get => cell;
            set
            {
                FirstMove = false;
                cell = value;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса King и задаёт начальную поцицию и цвет фигуры.
        /// </summary>
        public King(Cell cell, bool isWhite) : base(cell, isWhite){}

        private Cell GetCastling(int x, int y, List<Figure> figures)
        {
            if (FirstMove)
            {
                bool isClear = true;
                foreach (var figure in figures)
                {
                    if(x==2)
                    {
                        if ( (figure.Cell.PosX == cell.PosX - 1 || figure.Cell.PosX == cell.PosX - 2 || figure.Cell.PosX == cell.PosX - 3) && figure.Cell.PosY == y)
                        {
                            isClear = false;
                            break;
                        }
                    }
                    else if (x == 6)
                    {
                        if ((figure.Cell.PosX == cell.PosX + 1 || figure.Cell.PosX == cell.PosX + 2) && figure.Cell.PosY == y)
                        {
                            isClear = false;
                            break;
                        }
                    }
                }
                if (isClear)
                {
                    Rook rook = new Rook();
                    bool canCastling = false;
                    foreach (var figure in figures)
                    {
                        bool u = x == 2 ? figure.Cell.PosX == cell.PosX - 4 : figure.Cell.PosX == cell.PosX + 3;
                        if ( figure is Rook && figure.IsWhite == this.IsWhite && ((Rook)figure).FirstMove && u )
                        {
                            canCastling = true;
                            rook = (Rook)figure;
                            break;
                        }
                    }
                    if (canCastling)
                    {
                        rook.CastlingCell = new Cell(x == 2 ? 3 : 5, y);
                        return new Cell(x, y) { IsCastling = true, RookForCastling = rook};
                    }
                    else return null;
                }
            }
            return null;
        }

        private Cell GetTurn(int x, int y, List<Figure> figures)
        {
            bool canMove = true;
            if (x >= 0 && 7 >= x && y >= 0 && 7 >= y)
            {
                foreach (var figure in figures)
                {

                    if ( (x == figure.Cell.PosX && y == figure.Cell.PosY) )
                    {
                        canMove = false;
                        if (IsWhite != figure.IsWhite)
                            return new Cell(x, y);
                        break;
                    }
                }
                return canMove ? new Cell(x, y) : null;
            }
            return null;
        }

        /// <summary>
        /// Возвращает все возможные для короля ходы.
        /// </summary>
        /// <param name="figures">Список всех фирур находящихся на поле.</param>
        /// <returns></returns>
        public override List<Cell> GetPossibleTurns(List<Figure> figures)
        {
            List<Cell> turns = new List<Cell>
            {
                GetTurn(Cell.PosX, Cell.PosY + 1, figures),
                GetTurn(Cell.PosX, Cell.PosY - 1, figures),
                GetTurn(Cell.PosX + 1, Cell.PosY, figures),
                GetTurn(Cell.PosX - 1, Cell.PosY, figures),
                GetTurn(Cell.PosX + 1, Cell.PosY + 1, figures),
                GetTurn(Cell.PosX - 1, Cell.PosY + 1, figures),
                GetTurn(Cell.PosX + 1, Cell.PosY - 1, figures),
                GetTurn(Cell.PosX - 1, Cell.PosY - 1, figures)
            };
            if (FirstMove)
            {
                turns.Add(GetCastling(2, IsWhite ? 7 : 0, figures));
                turns.Add(GetCastling(6, IsWhite ? 7 : 0, figures));
            }
            turns.RemoveAll(Cell.IsNull);

            return turns;
        }

    }

    /// <summary>
    /// Представляет фигуру "Ферзь".
    /// </summary>
    public class Queen : Figure
    {
        public override string Icon => "♛";
        /// <summary>
        /// Взвращает или задаёт позицию ферзя на поле.
        /// </summary>
        public override Cell Cell { get => cell; set => cell = value; }
        /// <summary>
        /// Инициализирует новый экземпляр класса Queen и задаёт начальную поцицию и цвет фигуры.
        /// </summary>
        public Queen(Cell cell, bool isWhite) : base(cell, isWhite){}

        /// <summary>
        /// Возвращает все возможные для ферзя ходы.
        /// </summary>
        /// <param name="figures">Список всех фирур находящихся на поле.</param>
        /// <returns></returns>
        public override List<Cell> GetPossibleTurns(List<Figure> cells)
        {
            List<Cell> turns = new List<Cell>();
            turns.AddRange(new Rook(Cell, IsWhite).GetPossibleTurns(cells));
            turns.AddRange(new Bishop(Cell, IsWhite).GetPossibleTurns(cells));
            return turns;
        }
    }

    /// <summary>
    ///  Представляет фигуру "Пешка".
    /// </summary>
    public class Pawn : Figure
    {
        public override string Icon => "♟";
        /// <summary>
        /// Возвращает или задаёт является ли данный ход для пешки первым.
        /// </summary>
        public bool FirstMove { get; set; } = true;
        public delegate void PawnTransformationEventHandler(Pawn pawn);

        /// <summary>
        /// Срабатывает когда пешка доходит до конца поля.
        /// </summary>
        public event PawnTransformationEventHandler PawnTransformation;
        public PawnTransformationEventHandler SetPawnTransformation { set { PawnTransformation += value; } }

        /// <summary>
        /// Взвращает или задаёт позицию пешки на поле
        /// </summary>
        public override Cell Cell
        {
            get => cell;
            set
            {
                FirstMove = false;
                cell = value;
                if ((IsWhite && Cell.PosY == 0) || (!IsWhite && Cell.PosY == 7))
                {
                    PawnTransformation?.Invoke(this);
                }
            }
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса Pawn и задаёт начальную поцицию и цвет фигуры.
        /// </summary>
        public Pawn(Cell cell, bool isWhite) : base(cell, isWhite) { }

        private Cell GetMoveTurn(int x, int y, List<Figure> figures)
        {
            bool canMove = true;
            foreach (var figure in figures)
            {
                if (Cell.PosX == figure.Cell.PosX && y == figure.Cell.PosY || x < 0 || 7 < x || y < 0 || 7 < y)
                {
                    canMove = false;
                    break;
                }
            }
            if (canMove)
            {
                return new Cell(x, y);
            }
            else
                return null;
        }

        private Cell GetEatTurn(int x, int y, List<Figure> figures)
        {
            foreach (var figure in figures)
            {
                if (x == figure.Cell.PosX && y == figure.Cell.PosY && IsWhite != figure.IsWhite)
                {
                    return new Cell(x, y);
                }
            }
            return null;
        }

        /// <summary>
        /// Возвращает все возможные для пешки ходы.
        /// </summary>
        /// <param name="figures">Список всех фирур находящихся на поле.</param>
        /// <returns></returns>
        public override List<Cell> GetPossibleTurns(List<Figure> figures)
        {
            List<Cell> turns = new List<Cell>();

            int x = Cell.PosX;
            int y = IsWhite ? Cell.PosY - 1 : Cell.PosY + 1;

            turns.Add(GetMoveTurn(x, y, figures));

            bool can = true;
            foreach (var f in figures)
            {
                if (f.Cell.PosX == x && f.Cell.PosY == y)
                {
                    can = false;
                }
            }

            if (can && FirstMove)
            {
                y = IsWhite ? Cell.PosY - 2 : Cell.PosY + 2;
                turns.Add(GetMoveTurn(x, y, figures));
            }

            y = IsWhite ? Cell.PosY - 1 : Cell.PosY + 1;
            x = Cell.PosX + 1;
            turns.Add(GetEatTurn(x, y, figures));

            x = Cell.PosX - 1;
            turns.Add(GetEatTurn(x, y, figures));

            turns.RemoveAll(Cell.IsNull);
            return turns;
        }
    }

    /// <summary>
    /// Представляет фигуру "Ладья".
    /// </summary>
    public class Rook : Figure
    {
        public override string Icon => "♜";
        /// <summary>
        /// Взвращает или задаёт позицию ладьи на поле.
        /// </summary>
        public override Cell Cell
        {
            get => cell;
            set
            {
                FirstMove = false;
                cell = value;
            }
        }
        public Cell CastlingCell { get; set; }
        public bool FirstMove { get; set; } = true;
        public Rook() { }
        public Rook(Cell cell, bool isWhite) : base(cell, isWhite){}

        private Cell GetTurn(int x, int y, List<Figure> figures, ref bool canMove)
        {
            foreach (var figure in figures)
            {
                if ((x == figure.Cell.PosX) && (y == figure.Cell.PosY))
                {
                    canMove = false;
                    if (IsWhite != figure.IsWhite)
                    {
                        return new Cell(x, y);
                    }
                    break;
                }
            }
            return canMove ? new Cell(x, y) : null;
        }

        /// <summary>
        /// Возвращает все возможные для ладьи ходы.
        /// </summary>
        /// <param name="figures">Список всех фирур находящихся на поле.</param>
        /// <returns></returns>
        public override List<Cell> GetPossibleTurns(List<Figure> figures)
        {
            List<Cell> turns = new List<Cell>();
            for(int i = Cell.PosX + 1; i < 8; i++)
            {
                bool canMove = true;
                turns.Add(GetTurn(i, Cell.PosY, figures, ref canMove));
                if (!canMove) break;
            }

            for (int i = Cell.PosX - 1; i >= 0; i--)
            {
                bool canMove = true;
                turns.Add(GetTurn(i, Cell.PosY, figures, ref canMove));
                if (!canMove) break;
            }

            for (int i = Cell.PosY + 1; i < 8; i++)
            {
                bool canMove = true;
                turns.Add(GetTurn(Cell.PosX, i, figures, ref canMove));
                if (!canMove) break;
            }

            for (int i = Cell.PosY - 1; i >= 0; i--)
            {
                bool canMove = true;
                turns.Add(GetTurn(Cell.PosX, i, figures, ref canMove));
                if (!canMove) break;
            }
            turns.RemoveAll(Cell.IsNull);
            return turns;
        }
       
    }

    /// <summary>
    /// Представляет фигуру "Слон".
    /// </summary>
    public class Bishop : Figure
    {
        public override string Icon => "♝";
        /// <summary>
        /// Взвращает или задаёт позицию слона на поле.
        /// </summary>
        public override Cell Cell { get => cell; set => cell = value; }
        public Bishop(Cell cell, bool isWhite) : base(cell, isWhite){} 
        private Cell GetTurn(int x, int y, List<Figure> figures, ref bool canMove)
        {
            foreach (var figure in figures)
            {
                if ((x == figure.Cell.PosX) && (y == figure.Cell.PosY))
                {
                    canMove = false;
                    if (IsWhite != figure.IsWhite)
                    {
                        return new Cell(x, y);
                    }
                    break;
                }
            }
            return canMove ? new Cell(x, y) : null;
        }

        /// <summary>
        /// Возвращает все возможные для слона ходы.
        /// </summary>
        /// <param name="figures">Список всех фирур находящихся на поле.</param>
        /// <returns></returns>
        public override List<Cell> GetPossibleTurns(List<Figure> figures)
        {
            List<Cell> turns = new List<Cell>();

            int x = Cell.PosX, y = Cell.PosY;
            while (x < 7 && y < 7)
            {
                x++;
                y++;
                bool canMove = true;
                turns.Add(GetTurn(x, y, figures, ref canMove));
                if(!canMove) break;
            }

            x = Cell.PosX; y = Cell.PosY;
            while (x > 0 && y < 7)
            {
                x--;
                y++;
                bool canMove = true;
                turns.Add(GetTurn(x, y, figures, ref canMove));
                if (!canMove) break;
            }

            x = Cell.PosX; y = Cell.PosY;
            while (x < 7 && y > 0)
            {
                x++;
                y--;
                bool canMove = true;
                turns.Add(GetTurn(x, y, figures, ref canMove));
                if (!canMove) break;
            }

            x = Cell.PosX; y = Cell.PosY;
            while (x > 0 && y > 0)
            {
                x--;
                y--;
                bool canMove = true;
                turns.Add(GetTurn(x, y, figures, ref canMove));
                if (!canMove) break;
            }
            turns.RemoveAll(Cell.IsNull);
            return turns;
        }
    }

    /// <summary>
    /// Представляет фигуру "Конь".
    /// </summary>
    public class Knight : Figure
    {
        public override string Icon => "♞";
        /// <summary>
        /// Взвращает или задаёт позицию коня на поле.
        /// </summary>
        public override Cell Cell { get => cell; set => cell = value; }
        public Knight(Cell cell, bool isWhite) : base(cell, isWhite){}
        private Cell GetTurn(int x, int y, List<Figure> figures)
        {
            bool canMove = true;
            if (x >= 0 && 7 >= x && y >= 0 && 7 >= y)
            {
                foreach (var figure in figures)
                {
                    if (x == figure.Cell.PosX && y == figure.Cell.PosY)
                    {
                        canMove = false;
                        if (IsWhite != figure.IsWhite)
                            return new Cell(x, y);
                        break;
                    }
                }
                return canMove ? new Cell(x, y) : null;
            }
            return null;
        }

        /// <summary>
        /// Возвращает все возможные для коня ходы.
        /// </summary>
        /// <param name="figures">Список всех фирур находящихся на поле.</param>
        /// <returns></returns>
        public override List<Cell> GetPossibleTurns(List<Figure> figures)
        {
            List<Cell> turns = new List<Cell>();
            turns.Add(GetTurn(Cell.PosX + 2, Cell.PosY + 1, figures));
            turns.Add(GetTurn(Cell.PosX + 1, Cell.PosY + 2, figures));
            turns.Add(GetTurn(Cell.PosX - 2, Cell.PosY + 1, figures));
            turns.Add(GetTurn(Cell.PosX - 1, Cell.PosY + 2, figures));
            turns.Add(GetTurn(Cell.PosX - 2, Cell.PosY - 1, figures));
            turns.Add(GetTurn(Cell.PosX - 1, Cell.PosY - 2, figures));
            turns.Add(GetTurn(Cell.PosX + 2, Cell.PosY - 1, figures));
            turns.Add(GetTurn(Cell.PosX + 1, Cell.PosY - 2, figures));
            turns.RemoveAll(Cell.IsNull);
            return turns;
        }    
    }
}