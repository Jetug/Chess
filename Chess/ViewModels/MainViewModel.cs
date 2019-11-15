using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public string FlipIconPath { get => AppDomain.CurrentDomain.BaseDirectory + "Flopp.png"; }

        #region Commands
        public ICommand Start
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Content = null;
                    MainModel.Figures.Clear();
                    //Task.Factory.StartNew();
                    MainModel.Start();
                    Content = MainModel.field;
                });
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
                    if (sender is KeyEventArgs args && args.Key == Key.Escape)
                        MainModel.DeleteMarks();
                });
            }
        }

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
