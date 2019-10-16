using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Data.Linq;
using Chess.Models;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Chess.ViewModels
{
    class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        private List<Figure> figures = new List<Figure>();
        private List<FigureLabel> figureLabels = new List<FigureLabel>();


        /// <summary>
        /// Расставляет фигуры на начальные позиции.
        /// </summary>
        public ICommand Start
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    //for (int i = 0; i < 8; i++)
                    //{
                    //    figures.Add(new Pawn(new Cell(i, 1), false));
                    //    figures.Add(new Pawn(new Cell(i, 6), true));
                    //}

                    figures.Add(new Rook(new Cell(0, 2), false));
                    figures.Add(new Rook(new Cell(7, 0), false));
                    figures.Add(new Rook(new Cell(0, 7), true));
                    figures.Add(new Rook(new Cell(7, 7), true));

                    figures.Add(new Knight(new Cell(1, 0), false));
                    figures.Add(new Knight(new Cell(6, 0), false));
                    figures.Add(new Knight(new Cell(1, 7), true));
                    figures.Add(new Knight(new Cell(6, 7), true));

                    figures.Add(new Bishop(new Cell(2, 0), false));
                    figures.Add(new Bishop(new Cell(5, 0), false));
                    figures.Add(new Bishop(new Cell(2, 7), true));
                    figures.Add(new Bishop(new Cell(5, 7), true));
                      
                    figures.Add(new Queen(new Cell(3, 0), false));
                    figures.Add(new Queen(new Cell(3, 7), true));

                    figures.Add(new King(new Cell(4, 0), false));
                    figures.Add(new King(new Cell(4, 7), true));

                    Content = field;
                    foreach (var f in figures)
                    { 
                        CreateFigure(f);
                    }

                    #region TextBox
                    //TextBox text = new TextBox
                    //{
                    //    HorizontalAlignment = HorizontalAlignment.Left,
                    //    VerticalAlignment = VerticalAlignment.Top,
                    //    Margin = new Thickness(10, 10, 0, 0),
                    //};
                    //text.KeyDown += TextBox_KeyDown;
                    //field.mainGrid.Children.Add(text);
                    #endregion
                });
            }
        }

        public ICommand EscapeDown
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    DeleteMarks();
                });
            }
        }

        //private void TextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    TextBox textBox = (TextBox)sender;
        //    textBox.Text += e.Key.ToString();
        //}

        private Views.GridField field = new Views.GridField();

        private Control content;
        public Control Content
        {
            get { return content; }
            set
            {
                content = value;
                OnProperteyChanged();
            }
        }

        private List<Cell> test;
        public List<Cell> Test
        {
            get { return test; }
            set
            {
                test = value;
                OnProperteyChanged();
            }
        }

        
        public void CreateFigure(Figure figure)
        {
            FigureLabel figureLabel = new FigureLabel
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(figure.cell.PosX * 70, figure.cell.PosY * 70, 0, 0),
                Height = 70,
                Width = 70,

                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Content = figure.Icon,
                FontSize = 45,
                Figure = figure
            };

            figureLabel.Effect = new DropShadowEffect
            {
                Color = new Color { A = 0, R = 150, G = 150, B = 150, },
                ShadowDepth = 2
            };
            figureLabel.MouseDown += Mark_Click;
            //figureLabel.KeyDown += EscapeDown;
            //figureLabel.MouseLeave += DeleteMarks;

            BrushConverter converter = new BrushConverter();
            if (figure.isWhite)
                figureLabel.Foreground = (Brush)converter.ConvertFromString("#FFFFFFFF");
            

            field.mainGrid.Children.Add(figureLabel);
            figureLabels.Add(figureLabel);
        }
        
        List<Label> possibleTurn_Labels = new List<Label>();

        FigureLabel bufLabel = null;

        private void Mark_Click(object sender, RoutedEventArgs e)
        {
            DeleteMarks();
            var label = (FigureLabel)sender;
            List<Cell> cells = label.Figure.GetPossibleTurns(figures);
            Test = cells;
            foreach (Cell c in cells)
            {
                BrushConverter converter = new BrushConverter();
                Label possibleTurn_Label = new Label
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(c.PosX * 70, c.PosY * 70, 0, 0),
                    Height = 70,
                    Width = 70,

                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    FontSize = 45,
                    Background = (Brush)converter.ConvertFromString("#FF2A9224"),
                    Opacity = 0.5,
                    BorderThickness = new Thickness(1)
                };
                possibleTurn_Label.MouseDown += MoveFigure;
                //possibleTurn_Label.KeyDown += EscapeDown;

                bufLabel = label;
                field.mainGrid.Children.Add(possibleTurn_Label);
                possibleTurn_Labels.Add(possibleTurn_Label);
            }
        }

        //private void DeleteMarks(object sender, RoutedEventArgs e)
        //{
        //    foreach (Label l in possibleTurn_Labels)
        //    {
        //        field.mainGrid.Children.Remove(l);
        //    }
        //}

        public void DeleteMarks()
        {
            foreach (Label l in possibleTurn_Labels)
            {
                field.mainGrid.Children.Remove(l);
            }
        }

        private void MoveFigure(object sender, RoutedEventArgs e)
        {
            Label label = (Label)sender;
            if (bufLabel != null)
            {
                foreach(FigureLabel f in figureLabels)
                {
                    if ((label.Margin.Left / 70 == f.Figure.cell.PosX) && (label.Margin.Top / 70 == f.Figure.cell.PosY))
                    {
                        field.mainGrid.Children.Remove(f);
                        figureLabels.Remove(f);
                        figures.Remove(f.Figure);
                        break;
                    };
                }
                bufLabel.Margin = label.Margin;
                bufLabel.Figure.cell = new Cell((int)label.Margin.Left / 70, (int)label.Margin.Top / 70);
            }
            DeleteMarks();
            bufLabel = null;
            Test = new List<Cell>();
        }
        
        
    }
}
