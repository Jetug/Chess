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
    class DialogWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public Action CloseAction { get; set; }

        //public Figure PawnTransformFigure { get; set; }

        public ICommand CloseWindow
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    //MessageBox.Show((string)((Label)obj).Content);
                    string icon = (string)((Label)obj).Content;
                    switch (icon)
                    {
                        case "♛": MainModel.PawnTransformFigure = new Queen(new Cell(0, 0), true); break;
                        case "♜": MainModel.PawnTransformFigure = new Rook(new Cell(0, 0), true); break;
                        case "♞": MainModel.PawnTransformFigure = new Knight(new Cell(0, 0), true); break;
                        case "♝": MainModel.PawnTransformFigure = new Bishop(new Cell(0, 0), true); break;
                    }
                    CloseAction();
                });
            }
        }
    }
}
