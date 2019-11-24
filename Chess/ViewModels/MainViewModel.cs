using System;
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

        //public List<int> vs { get; set; } = new List<int>();

        //private List<Figure> test;
        //public List<Figure> Test
        //{
        //    get { return test; }
        //    set
        //    {
        //        test = value;
        //        OnProperteyChanged();
        //    }
        //}

        private Control content = MainModel.field;
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
        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                OnProperteyChanged();
            }
        }

        //public string FlipIconPath { get => AppDomain.CurrentDomain.BaseDirectory + "Flopp.png"; }

        #region Commands
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
                    MainModel.Figures.Clear();
                    MainModel.Start();
                    Content = MainModel.field;
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
        #endregion
    }
}
