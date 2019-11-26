using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Chess.Models;
using System.Windows.Controls;

namespace Chess.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperteyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private Control content = MainModel.Field;
        /// <summary>
        /// Возвращает или задаёт содержимое главного окна.
        /// </summary>
        public Control Content
        {
            get { return content; }
            set
            {
                content = value;
                OnProperteyChanged();
            }
        }

        private Visibility visibility = Visibility.Hidden;
        /// <summary>
        /// Возвращает или задаёт видимость контрола.
        /// </summary>
        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                OnProperteyChanged();
            }
        }

        /// <summary>
        /// Обновляет игровое поле и расставляет фигуры на начальные позиции.
        /// </summary>
        public ICommand Start
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Content = null;
                    MainModel.Start();
                    Content = MainModel.Field;
                    Visibility = Visibility.Visible;
                });
            }
        }

        /// <summary>
        /// Удаляет с поля метки возможных ходов при нажатии клавиши Escape.
        /// </summary>
        public ICommand EscapeDown
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    if (obj is KeyEventArgs args && args.Key == Key.Escape)
                        MainModel.DeleteMarks();
                });
            }
        }

        /// <summary>
        /// Переворачивает чёрные фигуры на 180 градусов.
        /// </summary>
        public ICommand Flip
        {
            get
            {
                return new DelegateCommand((sender) =>
                {
                    MainModel.FlipBlackFigures();
                });
            }
        }
    }
}
