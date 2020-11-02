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
    /// Interaction logic for ModifyCheckWindow.xaml
    /// </summary>
    public partial class ModifyCheckWindow : Window
    {
        public ModifyCheckWindow(Check selectedCheck)
        {
            InitializeComponent();
            //DatePicker.SelectedDate = selectedCheck.Datetime.Date;
            DataContext = new ModifyCheckViewModel(selectedCheck) { Window = this };
        }
    }
}
