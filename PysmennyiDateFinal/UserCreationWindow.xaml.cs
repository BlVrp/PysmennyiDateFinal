using PysmennyiDateFinal.ViewModels;
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

namespace PysmennyiDateFinal
{
    /// <summary>
    /// Interaction logic for UserCreationWindow.xaml
    /// </summary>
    public partial class UserCreationWindow : Window
    {
        public UserCreationWindow(PersonCreationViewModel vm)
        {

            InitializeComponent();

            vm.RequestClose += (s, e) =>
            {
                this.Close();
            };
            this.DataContext = vm;
        }
    }
}
