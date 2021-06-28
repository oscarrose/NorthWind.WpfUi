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

namespace NorthWind.WpfUi
{
    /// <summary>
    /// Interaction logic for UserControlShippers.xaml
    /// </summary>
    public partial class UserControlShippers : UserControl
    {
        public UserControlShippers()
        {
            InitializeComponent();

            InputCompanyName.TextChanged += InputCompanyName_TextChanged;
            InputPhone.TextChanged += InputPhone_TextChanged;
            
        }

        private void InputPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhoneError.Visibility=Visibility.Visible;
            PhoneError.Text = "";
          
        }

        private void InputCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CompanyNameError.Visibility = Visibility.Visible;
            CompanyNameError.Text = "";
        }

        private void SaveShippersButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputCompanyName.Text.Trim().Length==0)
            {
                CompanyNameError.Text = "The company name is required";
                
                CompanyNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputPhone.Text.Trim().Length==0)
            {
                PhoneError.Text = "The phone is required";
                PhoneError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (isvalid)
            {
                MessageBox.Show("Saved");

            }
        }
    }
}
