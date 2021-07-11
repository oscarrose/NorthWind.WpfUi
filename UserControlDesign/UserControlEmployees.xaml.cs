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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NorthWind.WpfUi.UserControlDesign
{
    /// <summary>
    /// Interaction logic for UserControlEmployees.xaml
    /// </summary>
    public partial class UserControlEmployees : UserControl
    {
        public UserControlEmployees()
        {
            InitializeComponent();
        }

        private void NewEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            //Llamar modal employees
            var ModalEmployees = new ModalEmployees();
            var result = ModalEmployees.ShowDialog();
        }
    }
}
