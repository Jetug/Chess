using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Chess.Models;

namespace Chess.ViewModels
{
    class DialogWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Возвращает или задаёт метод закрывающий окно.
        /// </summary>
        public Action CloseAction { get; set; }

        /// <summary>
        /// Сохраняет выбранную игроком фигуру, в которую должна превратиться пешка и закрывает окно.
        /// </summary>
        public ICommand CloseWindow
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    DialogWindowModel.SetFigure((string)obj);
                    CloseAction();
                });
            }
        }
    }
}
