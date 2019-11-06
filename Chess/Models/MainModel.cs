using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    static class MainModel
    {
        public static List<Figure> Start()
        {
            List<Figure> figures = new List<Figure>();
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

            figures.Add(PawnTransformFigure);
            CreateFigure(PawnTransformFigure);
            PawnTransformFigure = null;
        }
    }
}
