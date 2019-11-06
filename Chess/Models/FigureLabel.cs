using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Chess.Models
{
    class FigureLabel : Label
    {
        public Figure Figure { get; set; }

        //public new Thickness Margin
        //{
        //    get => base.Margin;
        //    set
        //    {
        //        Figure.Cell = new Cell((int)value.Left / 70, (int)value.Top / 70);
        //        base.Margin = value;
        //    }
        //}

        public Cell Cell
        {
            get => new Cell((int)Margin.Left / 70, (int)Margin.Top / 70);
            set
            {
                Figure.Cell = value;
                Margin = new Thickness(value.PosX * 70, value.PosY * 70, 0, 0);
            }
        }

        public FigureLabel()
        {
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Height = 70;
            Width = 70;
        }

        public FigureLabel(Figure figure)
        {
            Figure = figure;
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Margin = new Thickness(figure.Cell.PosX * 70, figure.Cell.PosY * 70, 0, 0);

            //Cell = figure.Cell;

            Height = 70;
            Width = 70;

            HorizontalContentAlignment = HorizontalAlignment.Center;
            VerticalContentAlignment = VerticalAlignment.Center;
            Content = figure.Icon;
            FontSize = 45;
        }
        //public new double Width { get; set; } = 70;
       //public new double Height { get; set; } = 70;

    }
}
