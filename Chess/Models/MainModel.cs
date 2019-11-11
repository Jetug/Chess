using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Chess.Models
{
    static class MainModel
    {
        public static List<Figure> Figures { get; set; } = new List<Figure>();
        public static List<FigureLabel> figureLabels = new List<FigureLabel>();
        public static List<Label> possibleTurn_Labels = new List<Label>();

        public static Views.ChessField field;

        private static bool canStart = true;
        private static bool isWhiteTurn = true;

        public static FigureLabel bufLabel = null;

        /// <summary>
        /// Расставляет фигуры на начальные позиции.
        /// </summary>
        public static void Start()
        {
            figureLabels.Clear();
            isWhiteTurn = true;
            field = new Views.ChessField();
            
            for (int i = 0; i < 8; i++)
            {
                Figures.Add(new Pawn(new Cell(i, 1), false) { SetPawnTransformation = TransformPawn });
                Figures.Add(new Pawn(new Cell(i, 6), true) { SetPawnTransformation = TransformPawn });
            }

            Figures.Add(new Rook(new Cell(0, 0), false));
            Figures.Add(new Rook(new Cell(7, 0), false));
            Figures.Add(new Rook(new Cell(0, 7), true));
            Figures.Add(new Rook(new Cell(7, 7), true));

            Figures.Add(new Knight(new Cell(1, 0), false));
            Figures.Add(new Knight(new Cell(6, 0), false));
            Figures.Add(new Knight(new Cell(1, 7), true));
            Figures.Add(new Knight(new Cell(6, 7), true));

            Figures.Add(new Bishop(new Cell(2, 0), false));
            Figures.Add(new Bishop(new Cell(5, 0), false));
            Figures.Add(new Bishop(new Cell(2, 7), true));
            Figures.Add(new Bishop(new Cell(5, 7), true));

            Figures.Add(new Queen(new Cell(3, 0), false));
            Figures.Add(new Queen(new Cell(3, 7), true));

            Figures.Add(new King(new Cell(4, 0), false));
            Figures.Add(new King(new Cell(4, 7), true));

            foreach (var f in Figures)
            {
                CreateFigure(f);
            }
            canStart = false;
        }

        /// <summary>
        /// Создаёт новую фигуру и добавляет её на поле.
        /// </summary>
        /// <param name="figure">Фигура которую нужно создать.</param>
        public static void CreateFigure(Figure figure)
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

        public static void RemoveFigure(FigureLabel figureLabel)
        {
            field.mainGrid.Children.Remove(figureLabel);
            figureLabels.Remove(figureLabel);
            Figures.Remove(figureLabel.Figure);
        }

        /// <summary>
        /// Создаёт на поле метки показывающие возможные ходы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CreateMarks(object sender, RoutedEventArgs e)
        {
            DeleteMarks();
            var label = (FigureLabel)sender;

            //if (label.Figure.IsWhite == isWhiteTurn)
            {
                List<Cell> cells = label.Figure.GetPossibleTurns(Figures);
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
                                    //Test = figures;
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

        private static int angle = 180;

        private static bool m = true;

        public static void FlipBlackFigures()
        {
            if (angle == 180)
            {
                angle = 0;
            }

            if (angle == 0)
            {
                angle = 180;
            }

            foreach (var figureLabel in figureLabels)
            {
                if (!figureLabel.Figure.IsWhite)
                {
                    figureLabel.RenderTransformOrigin = new Point(0.5, 0.5);
                    if(m)
                        figureLabel.RenderTransform = new RotateTransform(180);
                    else
                        figureLabel.RenderTransform = new RotateTransform(0);
                }
            }
            m = !m;
        }
            /// <summary>
            /// 
            /// </summary>
            public static void DeleteMarks()
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
        private static void MoveFigure(object sender, RoutedEventArgs e)
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
                                if (control is FigureLabel)
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
                isWhiteTurn = !bufLabel.Figure.IsWhite;
            }
            DeleteMarks();
            bufLabel = null;
            //Test = figures;
            //Test = new List<Cell>();
        }

        public static Figure PawnTransformFigure { get; set; }

        public static void TransformPawn(Pawn pawn)
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

            Figures.Add(PawnTransformFigure);
            CreateFigure(PawnTransformFigure);
            PawnTransformFigure = null;
        }
    }
}
