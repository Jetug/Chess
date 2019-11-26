using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Chess.Models;

namespace Chess.ViewModels
{
    class MateWindowViewModel : INotifyPropertyChanged
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
        
        public string Win { get => MainModel.IsWhiteTurn ? "Победа белых" : "Победа чёрных"; }

        /// <summary>
        /// Закрывает окно при нажатии клавиши Escape или Enter.
        /// </summary>
        public ICommand CloseWindow
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    if (obj is KeyEventArgs args && (args.Key == Key.Escape || args.Key == Key.Enter))
                        CloseAction();
                });
            }
        }
    }
}
