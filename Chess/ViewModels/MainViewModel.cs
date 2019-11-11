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

        #region Commands
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
