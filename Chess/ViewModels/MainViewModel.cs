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
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        //public List<int> vs { get; set; } = new List<int>();
        private List<Figure> figures = new List<Figure>();
        private List<FigureLabel> figureLabels = new List<FigureLabel>();
        List<Label> possibleTurn_Labels = new List<Label>();

        private Views.ChessField field;

        private bool canStart = true;
        private bool isWhiteTurn = true;

        private List<Figure> test;
        public List<Figure> Test
        {
            get { return test; }
            set
            {
                test = value;
                OnProperteyChanged();
            }
        }

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

        FigureLabel bufLabel = null;

        #region Commands
        /// <summary>
        /// Расставляет фигуры на начальные позиции.
        /// </summary>
        public ICommand Start
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    figures.Clear();
                    figureLabels.Clear();
                    Content = null;
                    field = new Views.ChessField();

                    Content = field;
                    foreach (var f in figures)
                    {
                        CreateFigure(f);
                    }

                    canStart = false;
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
                }
                //,(obj) => canStart
                );
            }
        }

        //private DelegateCommand exitCmd;

        /// <summary>
        /// Удаляет с поля метки возможных ходов при нажатии клавиши Escape.
        /// </summary>
        public ICommand EscapeDown
        {
            get
            {
                //return exitCmd ?? (exitCmd = new DelegateCommand(Exit));
                return new DelegateCommand((sender) =>
                {
                    KeyEventArgs args = sender as KeyEventArgs;
                    if (args != null && args.Key == Key.Escape)
                        DeleteMarks();
                });
            }
        }
        #endregion


        //private void TextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    TextBox textBox = (TextBox)sender;
        //    textBox.Text += e.Key.ToString();
        //}

        /// <summary>
        /// Создаёт новую фигуру и добавляет её на поле.
        /// </summary>
        /// <param name="figure">Фигура которую нужно создать.</param>
        public void CreateFigure(Figure figure)
        {
            FigureLabel figureLabel = new FigureLabel(figure);

            figureLabel.Effect = new DropShadowEffect
            {
                Color = new Color { A = 0, R = 150, G = 150, B = 150, },
                ShadowDepth = 2
            };
            #region Flip
            //if (!figure.IsWhite)
            //{
            //    figureLabel.RenderTransformOrigin = new Point(0.5, 0.5);
            //    figureLabel.RenderTransform = new RotateTransform(180);
            //}
            #endregion
            figureLabel.MouseDown += CreateMarks;

            BrushConverter converter = new BrushConverter();
            if (figure.IsWhite)
                figureLabel.Foreground = (Brush)converter.ConvertFromString("#FFFFFFFF");


            field.mainGrid.Children.Add(figureLabel);
            figureLabels.Add(figureLabel);
        }

        
        /// <summary>
        /// Создаёт на поле метки показывающие возможные ходы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMarks(object sender, RoutedEventArgs e)
        {
            DeleteMarks();
            var label = (FigureLabel)sender;

            //if (label.Figure.IsWhite == isWhiteTurn)
            {
                List<Cell> cells = label.Figure.GetPossibleTurns(figures);
                //Test = cells;
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
                        Background = (Brush)converter.ConvertFromString("#FF2A9224"),
                        Opacity = 0.5,
                        BorderThickness = new Thickness(1)
                    };
                    possibleTurn_Label.MouseDown += MoveFigure;
                    if (c.IsCastling)
                    {
                        possibleTurn_Label.MouseDown += (send, a) => 
                        {
                            foreach (var fLabel in figureLabels)
                            {
                                if (fLabel.Figure is Rook && fLabel.Figure == c.RookForCastling)
                                {
                                    fLabel.Cell = ((Rook)fLabel.Figure).CastlingCell;
                                    Test = figures;
                                }
                                //if (f.Figure is Rook && f.Figure.Cell == c.RookForCastling.Cell)
                                //{
                                //    f.Figure.Cell = ((Rook)f.Figure).CastlingCell;
                                //    f.Margin = new Thickness(f.Figure.Cell.PosX * 70, f.Figure.Cell.PosY * 70, 0, 0);
                                //}
                            }
                        };
                    }

                    bufLabel = label;
                    field.mainGrid.Children.Add(possibleTurn_Label);
                    possibleTurn_Labels.Add(possibleTurn_Label);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteMarks()
        {
            foreach (Label l in possibleTurn_Labels)
            {
                field.mainGrid.Children.Remove(l);
            }
        }

        /// <summary>
        /// Перемещает фигуру на выбранную клетку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveFigure(object sender, RoutedEventArgs e)
        {
            Label mark = (Label)sender;
            if (bufLabel != null)
            {
                foreach (FigureLabel figureLabel in figureLabels)
                {
                    if ((mark.Margin.Left / 70 == figureLabel.Figure.Cell.PosX) && (mark.Margin.Top / 70 == figureLabel.Figure.Cell.PosY))
                    {
                        RemoveFigure(figureLabel);
                        if (figureLabel.Figure is King)
                        {
                            MessageBox.Show("Мат!");
                            foreach (var control in field.mainGrid.Children)
                            {
                                if(control is FigureLabel)
                                {
                                    ((FigureLabel)control).MouseDown -= CreateMarks;
                                }
                            }
                            canStart = true;
                        }
                        break;
                    };
                }
                bufLabel.Margin = mark.Margin;
                bufLabel.Figure.Cell = new Cell((int)mark.Margin.Left / 70, (int)mark.Margin.Top / 70);
                //isWhiteTurn = !bufLabel.Figure.IsWhite;
            }
            DeleteMarks();
            bufLabel = null;
            Test = figures;
            //Test = new List<Cell>();
        }

        private void RemoveFigure(FigureLabel figureLabel)
        {
            field.mainGrid.Children.Remove(figureLabel);
            figureLabels.Remove(figureLabel);
            figures.Remove(figureLabel.Figure);
        }

        public static Figure PawnTransformFigure { get; set; }

        private void TransformPawn(Pawn pawn)
        {
            #region s
            //ListView figuresForTransform = new ListView
            //{
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    VerticalAlignment = VerticalAlignment.Top,
            //    Margin = new Thickness(pawn.Cell.PosX * 70 - 10, pawn.Cell.PosY * 70, 0, 0),
            //    Width = 90,
            //    Height = 200,
            //};
            //List<FigureLabel> figuresList = new List<FigureLabel>
            //{
            //    new FigureLabel(new Queen(new Cell(0, 0), pawn.IsWhite)),
            //    new FigureLabel(new Knight(new Cell(0, 0), pawn.IsWhite)),
            //    new FigureLabel(new Rook (new Cell(0, 0), pawn.IsWhite)),
            //    new FigureLabel(new Bishop(new Cell(0, 0), pawn.IsWhite)),

            //};
            //figuresForTransform.ItemsSource = figuresList;
            #endregion
            #region e
            //field.mainGrid.Children.Add(figuresForTransform);
            //MessageBox.Show("Trans!");

            //FigureLabel queenLabel = new FigureLabel(new Queen(new Cell(0, 0), pawn.IsWhite));
            //FigureLabel knightLabel = new FigureLabel(new Knight(new Cell(1, 0), pawn.IsWhite)) { Margin = new Thickness(130,0,0,0)};
            //FigureLabel rookLabel = new FigureLabel(new Rook(new Cell(0, 1), pawn.IsWhite)) { Margin = new Thickness(0, 130, 0, 0) };
            //FigureLabel bishopLabel = new FigureLabel(new Bishop(new Cell(1, 1), pawn.IsWhite)) { Margin = new Thickness(130, 130, 0, 0) };

            //queenLabel.MouseDown += CloseDialogWindow;
            //knightLabel.MouseDown += CloseDialogWindow;
            //rookLabel.MouseDown += CloseDialogWindow;
            //bishopLabel.MouseDown += CloseDialogWindow;

            //dialogWindow.figureGrid.Children.Add(queenLabel);
            //dialogWindow.figureGrid.Children.Add(knightLabel);
            //dialogWindow.figureGrid.Children.Add(rookLabel);
            //dialogWindow.figureGrid.Children.Add(bishopLabel);
            #endregion
            Views.PawnTransformationDialogWindow dialogWindow = new Views.PawnTransformationDialogWindow();
            dialogWindow.ShowDialog();
            PawnTransformFigure.Cell = pawn.Cell;
            PawnTransformFigure.IsWhite = pawn.IsWhite;

            RemoveFigure(bufLabel);

            //figures.Remove(pawn);
            //figureLabels.Remove(bufLabel);
            //field.mainGrid.Children.Remove(bufLabel);

            figures.Add(PawnTransformFigure);
            CreateFigure(PawnTransformFigure);
            PawnTransformFigure = null;
        }
    }
}
