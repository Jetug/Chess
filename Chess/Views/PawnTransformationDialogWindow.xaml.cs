using System;
using System.Windows;

namespace Chess.Views
{
    /// <summary>
    /// Логика взаимодействия для PawnTransformationDialogWindow.xaml
    /// </summary>
    public partial class PawnTransformationDialogWindow : Window
    {
        /// <summary>
        /// Передаёт в ViewModels.DialogWindowViewModel.CloseAction метод Close.
        /// </summary>
        public PawnTransformationDialogWindow()
        {
            InitializeComponent();
            ViewModels.DialogWindowViewModel vm = new ViewModels.DialogWindowViewModel();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }
    }
}
