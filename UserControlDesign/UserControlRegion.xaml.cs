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
    /// Interaction logic for UserControlRegion.xaml
    /// </summary>
    public partial class UserControlRegion : UserControl

    {
        public UserControlRegion()
        {
            InitializeComponent();

            //Evento de ocultar mensaje de error
            InputRegionDescription.TextChanged += InputRegionDescription_TextChanged;

        }

        private void InputRegionDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegionDescriptionError.Visibility = Visibility.Collapsed;



        }

        private void SaveRegionButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputRegionDescription.Text.Trim().Length == 0)
            {
                RegionDescriptionError.Text = "The region description Id is required";
                RegionDescriptionError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (isvalid)
            {
                //Saved
    
                MessageBox.Show("data is valided", "info");
            }

        }
    }
}
