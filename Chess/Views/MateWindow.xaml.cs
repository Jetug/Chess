using System;
using System.Windows;

namespace Chess.Views
{
    /// <summary>
    /// Логика взаимодействия для MateWindow.xaml
    /// </summary>
    public partial class MateWindow : Window
    {
        /// <summary>
        /// Передаёт в ViewModels.MateWindowViewModel.CloseAction метод Close.
        /// </summary>
        public MateWindow()
        {
            InitializeComponent();
            ViewModels.MateWindowViewModel vm = new ViewModels.MateWindowViewModel();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }
    }
}
