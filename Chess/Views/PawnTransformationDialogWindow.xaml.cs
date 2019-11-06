using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chess.Views
{
    /// <summary>
    /// Логика взаимодействия для PawnTransformationDialogWindow.xaml
    /// </summary>
    public partial class PawnTransformationDialogWindow : Window
    {
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
