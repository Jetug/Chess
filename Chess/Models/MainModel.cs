using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Chess.Models
{
    static class MainModel
    {
        private static List<Figure> figures = new List<Figure>();
        private static List<FigureLabel> figureLabels = new List<FigureLabel>();
        private static List<Label> possibleTurn_Labels = new List<Label>();

        const int cellSize = 70;

        /// <summary>
        /// Возвращает игровое поле.
        /// </summary>
        public static Views.ChessField Field { get; private set; } = new Views.ChessField();
        
        /// <summary>
        /// Возвращает значение true если ход белых, значение false если ход чёрных.
        /// </summary>
        public static bool IsWhiteTurn { get; private set; } = true;

        private static FigureLabel bufLabel = null;

        public static event Action Update;
        public static Action SetUpdate { set { Update += value; } }

        /// <summary>
        /// Расставляет фигуры на начальные позиции.
        /// </summary>
        public static void Start()
        {
            Field = null;
            Field = new Views.ChessField();

            figures.Clear();
            figureLabels.Clear();
            IsWhiteTurn = true;
            Field = new Views.ChessField();

            angle = 180;

            Update?.Invoke();

            for (int i = 0; i < 8; i++)
            {
                figures.Add(new Pawn(new Cell(i, 1), false) { SetPawnTransformation = TransformPawn });
                figures.Add(new Pawn(new Cell(i, 6), true) { SetPawnTransformation = TransformPawn });
            }

            figures.Add(new Rook(new Cell(0, 0), false));
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

            foreach (var f in figures)
            {
                CreateFigure(f);
            }
        }

        /// <summary>
        /// Создаёт новую фигуру и добавляет её на поле.
        /// </summary>
        /// <param name="figure">Фигура которую нужно создать.</param>
        private static void CreateFigure(Figure figure)
        {
            FigureLabel figureLabel = new FigureLabel(figure)
            {
                Effect = new DropShadowEffect
                {
                    Color = new Color { A = 0, R = 150, G = 150, B = 150, },
                    ShadowDepth = 2
                }
            };
            figureLabel.MouseDown += CreateMarks;

            BrushConverter converter = new BrushConverter();
            if (figure.IsWhite)
                figureLabel.Foreground = (Brush)converter.ConvertFromString("#FFFFFFFF");


            Field.mainGrid.Children.Add(figureLabel);
            figureLabels.Add(figureLabel);
        }

        /// <summary>
        /// Удаляет фигуру с поля.
        /// </summary>
        /// <param name="figureLabel"></param>
        private static void RemoveFigure(FigureLabel figureLabel)
        {
            Field.mainGrid.Children.Remove(figureLabel);
            figureLabels.Remove(figureLabel);
            figures.Remove(figureLabel.Figure);
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

            if (label.Figure.IsWhite == IsWhiteTurn)
            {
                List<Cell> cells = label.Figure.GetPossibleTurns(figures);
                foreach (Cell c in cells)
                {
                    BrushConverter converter = new BrushConverter();
                    Label possibleTurn_Label = new Label
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(c.PosX * cellSize, c.PosY * cellSize, 0, 0),
                        Height = cellSize,
                        Width = cellSize,
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
                                }
                            }
                        };
                    }

                    bufLabel = label;
                    Field.mainGrid.Children.Add(possibleTurn_Label);
                    possibleTurn_Labels.Add(possibleTurn_Label);
                }
            }
        }

        /// <summary>
        /// Удаляет с поля метки показывающие возможные ходы.
        /// </summary>
        public static void DeleteMarks()
        {
            foreach (Label l in possibleTurn_Labels)
            {
                Field.mainGrid.Children.Remove(l);
            }
        }

        /// <summary>
        /// Перемещает фигуру на выбранную клетку.
        /// </summary>
        private static void MoveFigure(object sender, RoutedEventArgs e)
        {
            Label mark = (Label)sender;
            if (bufLabel != null)
            {
                foreach (FigureLabel figureLabel in figureLabels)
                {
                    if ((mark.Margin.Left / cellSize == figureLabel.Figure.Cell.PosX) && (mark.Margin.Top / cellSize == figureLabel.Figure.Cell.PosY))
                    {
                        if (figureLabel.Figure is King)
                        {
                            foreach (var control in Field.mainGrid.Children)
                            {
                                if (control is FigureLabel)
                                {
                                    ((FigureLabel)control).MouseDown -= CreateMarks;
                                }
                            }

                            new Views.MateWindow().ShowDialog();
                            DeleteMarks();
                            return;
                        }
                        RemoveFigure(figureLabel);
                        break;
                    };
                }
                bufLabel.Margin = mark.Margin;
                bufLabel.Figure.Cell = new Cell((int)mark.Margin.Left / cellSize, (int)mark.Margin.Top / cellSize);
                IsWhiteTurn = !bufLabel.Figure.IsWhite;
            }
            DeleteMarks();
            bufLabel = null;
        }

        private static int angle;

        /// <summary>
        /// Переворачивает чёрные фигуры на 180 градусов.
        /// </summary>
        public static void FlipBlackFigures()
        {
            foreach (var figureLabel in figureLabels)
            {
                if (!figureLabel.Figure.IsWhite)
                {
                    figureLabel.RenderTransformOrigin = new Point(0.5, 0.5);
                    figureLabel.RenderTransform = new RotateTransform(angle);
                }
            }
            if (angle == 0) angle = 180;
            else angle = 0;
        }

        /// <summary>
        /// Создёт диалоговое окно с выбором фигуры в которую нужно превратить пешку.
        /// </summary>
        /// <param name="pawn">Пешка которую нужно превратить в выбранную игроком фигуру.</param>
        public static void TransformPawn(Pawn pawn)
        {
            new Views.PawnTransformationDialogWindow().ShowDialog();
            Figure PawnTransformFigure = DialogWindowModel.PawnTransformFigure;
            PawnTransformFigure.Cell = pawn.Cell;
            PawnTransformFigure.IsWhite = pawn.IsWhite;

            RemoveFigure(bufLabel);

            figures.Add(PawnTransformFigure);
            CreateFigure(PawnTransformFigure);
        }
    }
}
