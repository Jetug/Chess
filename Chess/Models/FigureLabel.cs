using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.Models
{
    /// <summary>
    /// Представляет модифицированный для работы с шахматными фигурами класс Label.
    /// </summary>
    class FigureLabel : Label
    {
        const int cellSize = 70;

        public Figure figure;
        /// <summary>
        /// Задаёт или возвращает экземпляр класса Figure.
        /// </summary>
        public Figure Figure
        {
            get => figure;
            set
            {
                Content = value.Icon;
                figure = value;
            }
        }

        /// <summary>
        /// Задаёт или возвращает положение фигуры на поле.
        /// </summary>
        public Cell Cell
        {
            get => new Cell((int)Margin.Left / cellSize, (int)Margin.Top / cellSize);
            set
            {
                Margin = new Thickness(value.PosX * cellSize, value.PosY * cellSize, 0, 0);
                Figure.Cell = value;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса FigureLabel и задаёт его размер, равный размеру клетки.
        /// </summary>
        public FigureLabel()
        {
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Height = cellSize;
            Width = cellSize;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса FigureLabel, и задаёт его размер, равный размеру клетки и начальное положение на поле.    
        /// </summary>
        public FigureLabel(Figure figure)
        {
            Figure = figure;
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Margin = new Thickness(figure.Cell.PosX * cellSize, figure.Cell.PosY * cellSize, 0, 0);
            Height = cellSize;
            Width = cellSize;
            HorizontalContentAlignment = HorizontalAlignment.Center;
            VerticalContentAlignment = VerticalAlignment.Center;
            FontFamily = new FontFamily("Segoe UI Symbol");
            FontSize = 45;
        }
    }
}
