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
    /// Interaction logic for UserControlTeritory.xaml
    /// </summary>
    public partial class UserControlTerritory : UserControl
    {
        public UserControlTerritory()
        {
            InitializeComponent();
            InputRegionId.SelectionChanged += InputRegionId_SelectionChanged;
            InputterrirtoryDescription.TextChanged += InputterrirtoryDescription_TextChanged;

        }

        private void InputterrirtoryDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            TerritoryDescriptionError.Visibility = Visibility.Visible;
            TerritoryDescriptionError.Text = "";
        }

        private void InputRegionId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RegionIdError.Visibility = Visibility.Visible;
            RegionIdError.Text = "";
            

        }

        private void SaveTerritoryButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputRegionId.Text.Trim()== "Choose region")
            {
                RegionIdError.Text = "The region Id is required";
                RegionIdError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputterrirtoryDescription.Text.Trim().Length == 0)
            {
                TerritoryDescriptionError.Text = "The territory description is required";
                TerritoryDescriptionError.Visibility = Visibility.Visible;
                isvalid = false;
                
            }

            if (isvalid)
            {
                MessageBox.Show("Saved");
            }
        }
    }
}
