using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Models;

namespace Chess.Models
{
    abstract class Figure
    {
        public bool isWhite { get; private set; }
        public Cell cell;
        public abstract string Icon{ get; }

        public abstract List<Cell> GetPossibleTurns(List<Figure> cells);

        protected Figure(Cell cell, bool isWhite)
        {
            this.cell = cell;
            this.isWhite = isWhite;
        }
    }

    class Pawn : Figure
    {
        public Pawn(Cell cell, bool isWhite) : base(cell, isWhite)
        {
        }

        public override List<Cell> GetPossibleTurns(List<Figure> cells)
        {
            return new List<Cell>();
        }

        public override string Icon => "♟";
    }

    class King : Figure
    {
        public King(Cell cell, bool isWhite) : base(cell, isWhite)
        {

        }

        public override List<Cell> GetPossibleTurns(List<Figure> cells)
        {
            List<Cell> turns = new List<Cell>();
            return turns;
        }

        public override string Icon => "♚";
    }

    class Queen : Figure
    {
        public Queen(Cell cell, bool isWhite) : base(cell, isWhite)
        {
        }

        public override List<Cell> GetPossibleTurns(List<Figure> cells)
        {
            List<Cell> turns = new List<Cell>();
            turns.AddRange(new Rook(cell, isWhite).GetPossibleTurns(cells));
            turns.AddRange(new Bishop(cell, isWhite).GetPossibleTurns(cells));
            return turns;
        }

        public override string Icon => "♛";
    }

    class Rook : Figure
    {
        public Rook(Cell cell, bool isWhite) : base(cell, isWhite)
        {
        }

        public override List<Cell> GetPossibleTurns(List<Figure> figures)
        {
            List<Cell> turns = new List<Cell>();
            for(int i = cell.PosX + 1; i < 8; i++)
            {
                bool canMove = true;
                foreach (var figure in figures)
                {
                    if ((i == figure.cell.PosX) && (cell.PosY == figure.cell.PosY))
                    {
                        canMove = false;
                        if (isWhite != figure.isWhite){
                            turns.Add(new Cell(i, cell.PosY));
                        }
                        break;
                    }  
                }
                if (canMove)
                {
                    turns.Add(new Cell(i, cell.PosY));
                }
                else break;
            }

            for (int i = cell.PosX - 1; i >= 0; i--)
            {
                bool canMove = true;
                foreach (var figure in figures)
                {
                    if ((i == figure.cell.PosX) && (cell.PosY == figure.cell.PosY))
                    {
                        canMove = false;
                        if (isWhite != figure.isWhite)
                        {
                            turns.Add(new Cell(i, cell.PosY));
                        }
                        break;
                    }  
                }
                if (canMove)
                {
                    turns.Add(new Cell(i, cell.PosY));
                }
                else break;
            }

            for (int i = cell.PosY + 1; i < 8; i++)
            {
                bool canMove = true;
                foreach (var figure in figures)
                {
                    if ((cell.PosX == figure.cell.PosX) && (i == figure.cell.PosY))
                    {
                        canMove = false;
                        if (isWhite != figure.isWhite)
                        {
                            turns.Add(new Cell(cell.PosX, i));
                        }
                        break;
                    }
                }
                if (canMove)
                {
                    turns.Add(new Cell(cell.PosX, i));
                }
                else break;
            }

            for (int i = cell.PosY - 1; i >= 0; i--)
            {
                bool canMove = true;
                foreach (var figure in figures)
                {
                    if ((cell.PosX == figure.cell.PosX) && (i == figure.cell.PosY))
                    {
                        canMove = false;
                        if (isWhite != figure.isWhite)
                        {
                            turns.Add(new Cell(cell.PosX, i));
                        }
                        break;
                    }
                }
                if (canMove)
                {
                    turns.Add(new Cell(cell.PosX, i));
                }
                else break;
            }

            return turns;
        }
        public override string Icon => "♜";
    }

    class Bishop : Figure
    {
        public Bishop(Cell cell, bool isWhite) : base(cell, isWhite)
        {
        }

        //private void Test(int x, int y, List<Figure> figures)
        //{
        //    Cell turn;
        //    bool canMove = true;
        //    foreach (var figure in figures)
        //    {
        //        if ((x == figure.cell.PosX) && (y == figure.cell.PosY))
        //        {
        //            canMove = false;
        //            if (isWhite != figure.isWhite)
        //            {
        //                turn = new Cell(x, y);
        //            }
        //            break;
        //        }
        //    }
        //    if (canMove)
        //    {
        //        turn = new Cell(x, y);
        //    }
        //    else break;
        //}

        public override List<Cell> GetPossibleTurns(List<Figure> figures)
        {
            List<Cell> turns = new List<Cell>();
            
            int x = cell.PosX, y = cell.PosY;
            while (x < 7 && y < 7)
            {
                x++;
                y++;
                bool canMove = true;
                foreach (var figure in figures)
                {
                    if ((x == figure.cell.PosX) && (y == figure.cell.PosY))
                    {
                        canMove = false;
                        if (isWhite != figure.isWhite)
                        {
                            turns.Add(new Cell(x, y));
                        }
                        break;
                    }
                }
                if (canMove)
                {
                    turns.Add(new Cell(x, y));
                }
                else break;
            }

            x = cell.PosX; y = cell.PosY;
            while (x > 0 && y < 7)
            {
                x--;
                y++;
                bool canMove = true;
                foreach (var figure in figures)
                {
                    if ((x == figure.cell.PosX) && (y == figure.cell.PosY))
                    {
                        canMove = false;
                        if (isWhite != figure.isWhite)
                        {
                            turns.Add(new Cell(x, y));
                        }
                        break;
                    }
                }
                if (canMove)
                {
                    turns.Add(new Cell(x, y));
                }
                else break;
            }

            x = cell.PosX; y = cell.PosY;
            while (x < 7 && y > 0)
            {
                x++;
                y--;
                bool canMove = true;
                foreach (var figure in figures)
                {
                    if ((x == figure.cell.PosX) && (y == figure.cell.PosY))
                    {
                        canMove = false;
                        if (isWhite != figure.isWhite)
                        {
                            turns.Add(new Cell(x, y));
                        }
                        break;
                    }
                }
                if (canMove)
                {
                    turns.Add(new Cell(x, y));
                }
                else break;
            }

            x = cell.PosX; y = cell.PosY;
            while (x > 0 && y > 0)
            {
                x--;
                y--;
                bool canMove = true;
                foreach (var figure in figures)
                {
                    if ((x == figure.cell.PosX) && (y == figure.cell.PosY))
                    {
                        canMove = false;
                        if (isWhite != figure.isWhite)
                        {
                            turns.Add(new Cell(x, y));
                        }
                        break;
                    }
                }
                if (canMove)
                {
                    turns.Add(new Cell(x, y));
                }
                else break;
            }

            return turns;
        }

        public override string Icon => "♝";
    }

    class Knight : Figure
    {
        public Knight(Cell cell, bool isWhite) : base(cell, isWhite)
        {
        }

        public override List<Cell> GetPossibleTurns(List<Figure> cells)
        {
            List<Cell> turns = new List<Cell>();
            
            return new List<Cell>();
        }

        public override string Icon => "♞";
    }

}