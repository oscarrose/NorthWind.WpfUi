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

namespace NorthWind.WpfUi
{
    /// <summary>
    /// Interaction logic for ModalCategory.xaml
    /// </summary>
    public partial class ModalCategory : Window
    {
        public ModalCategory()
        {
            InitializeComponent();
            InputCompanyName.TextChanged += InputCompanyName_TextChanged;
            InputDescription.TextChanged += InputDescription_TextChanged;
            
        }

        private void InputDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            DescriptionError.Visibility = Visibility.Collapsed;
            DescriptionError.Text = "";
        }

        private void InputCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CompanyNameError.Visibility = Visibility.Collapsed;
            CompanyNameError.Text = "";
        }

        private void Image_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
         

        }

        private void SaveCategoriesButton_Click(object sender, RoutedEventArgs e)
        {

            var isvalid = true;

            if (InputCompanyName.Text.Trim().Length == 0)
            {
                CompanyNameError.Text = "Company name is required";
                CompanyNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }
         

            if (InputDescription.Text.Trim().Length == 0)
            {
                DescriptionError.Text = "The description is required";
                DescriptionError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (isvalid)
            {
                //
            }
        }
    }
}
