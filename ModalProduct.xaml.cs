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
    /// Interaction logic for ModalProduct.xaml
    /// </summary>
    public partial class ModalProduct : Window
    {
        public ModalProduct()
        {
            InitializeComponent();
            InputProductName.TextChanged += InputProductName_TextChanged;
            InputSupplierID.SelectionChanged += InputSupplierID_SelectionChanged;
            InputCategoriesID.SelectionChanged += InputCategoriesID_SelectionChanged;
            InputQuanity.TextChanged += InputQuanity_TextChanged;
            InputUnitprice.TextChanged += InputUnitprice_TextChanged;
            InputUnitStock.TextChanged += InputUnitStock_TextChanged;
            InputUnitsorder.TextChanged += InputUnitsorder_TextChanged;
            InputDiscontinued.TextChanged += InputDiscontinued_TextChanged;
            InputRecorderLevel.TextChanged += InputRecorderLevel_TextChanged;
        }

        private void InputRecorderLevel_TextChanged(object sender, TextChangedEventArgs e)
        {
            RecorderLevelError.Visibility = Visibility.Collapsed;
        }

        private void InputDiscontinued_TextChanged(object sender, TextChangedEventArgs e)
        {
           //DiscontinuedError.Text = "";
            DiscontinuedError.Visibility = Visibility.Collapsed;
        }

        private void InputUnitsorder_TextChanged(object sender, TextChangedEventArgs e)
        {
            UnitsorderError .Text = "";
            UnitsorderError.Visibility = Visibility.Collapsed;
        }

        private void InputUnitStock_TextChanged(object sender, TextChangedEventArgs e)
        {
           UnitstockError.Text = "";
            UnitstockError.Visibility = Visibility.Collapsed;
        }

        private void InputUnitprice_TextChanged(object sender, TextChangedEventArgs e)
        {
            UnitpriceError.Text = "";
            UnitpriceError.Visibility = Visibility.Collapsed;
        }

        private void InputQuanity_TextChanged(object sender, TextChangedEventArgs e)
        {
            QuanityError.Text = "";
            QuanityError.Visibility = Visibility.Collapsed;
        }

        private void InputCategoriesID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CategoriesidError.Text = "";
            CategoriesidError.Visibility = Visibility.Collapsed;
        }

        private void InputSupplierID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SupplieridError.Text = "";
            SupplieridError.Visibility = Visibility.Collapsed;
        }

        private void InputProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductNameError.Text = "";
            ProductNameError.Visibility = Visibility.Collapsed;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveProductButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputProductName.Text.Trim().Length == 0)
            {
                ProductNameError.Text = "The product name is required";

                ProductNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputSupplierID.SelectedIndex==0)
            {
                SupplieridError.Text = "The supplier is required";
                SupplieridError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputCategoriesID.SelectedIndex==0)
            {
                CategoriesidError.Text = "The categories is required";
                CategoriesidError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputQuanity.Text.Trim().Length == 0)
            {
                QuanityError.Text = "The quanity per unit is required";

                QuanityError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputUnitprice.Text.Trim().Length == 0)
            {
                UnitpriceError.Text = "The unit price is required";

                UnitpriceError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputUnitStock.Text.Trim().Length == 0)
            {
                UnitstockError.Text = "The unit stock is required";

                UnitstockError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputUnitsorder.Text.Trim().Length == 0)
            {
               UnitsorderError.Text = "The unit order is required";

                UnitsorderError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputRecorderLevel.Text.Trim().Length == 0)
            {
                RecorderLevelError.Text = "The Recorder level is required";

                RecorderLevelError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputDiscontinued.Text.Trim().Length == 0)
            {
                DiscontinuedError .Text = "The Discontinued is required";

                DiscontinuedError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (isvalid)
            {
                MessageBox.Show("Saved");

            }
        }
    }
}
