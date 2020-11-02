using Common.Models;
using RVAProjekat.ViewModel;
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

namespace RVAProjekat.Views
{
    /// <summary>
    /// Interaction logic for AddGateWindow.xaml
    /// </summary>
    public partial class AddGateWindow : Window
    {
        public AddGateWindow(bool isChange, Gate SelectedGate)
        {
            InitializeComponent();
            DataContext = new AddGateViewModel(isChange, SelectedGate) { Window = this };
        }
    }
}
