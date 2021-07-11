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
    /// Interaction logic for ModalOrders.xaml
    /// </summary>
    public partial class ModalOrders : Window
    {
        public ModalOrders()
        {
            InitializeComponent();
            InputCustomerId.SelectionChanged += InputCustomerId_SelectionChanged;
            InputEmployeeId.SelectionChanged += InputEmployeeId_SelectionChanged;
            InputRequiredDate.SelectedDateChanged += InputRequiredDate_SelectedDateChanged;
            InputShippedDate.SelectedDateChanged += InputShippedDate_SelectedDateChanged;
            InputProduct.SelectionChanged += InputProduct_SelectionChanged;
            inputQuantity.TextChanged += InputQuantity_TextChanged;
            inputDiscount.TextChanged += InputDiscount_TextChanged;

            //los demas estan de forma automatica desde la ventana de evento de los controles



        }



        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveOrderButton_Click(object sender, RoutedEventArgs e)
        {

                var isvalid = true;

                if (InputCustomerId.SelectedIndex == 0)
                {
                    CustomerIdError.Text = "The customer Id is required";
                    CustomerIdError.Visibility = Visibility.Visible;
                    isvalid = false;
                }


                if (InputEmployeeId.SelectedIndex == 0)
                {
                     EmployeesError.Text = "The employee id is required";
                     EmployeesError.Visibility = Visibility.Visible;
                    isvalid = false;
                }

                if (InputOrderDate.Text.Trim().Length == 0)
                {
                    OrderDateError.Text = "The order date is required";
                    OrderDateError.Visibility = Visibility.Visible;
                    isvalid = false;
                }

                if (InputRequiredDate.Text.Trim().Length == 0)
                {
                    RequiredDateError.Text = "The required date is required";
                    RequiredDateError.Visibility = Visibility.Visible;
                    isvalid = false;
                }

                if (InputShippedDate.Text.Trim().Length == 0)
                {
                    ShippedDateError.Text = "The shipped date is required";
                    ShippedDateError.Visibility = Visibility.Visible;
                    isvalid = false;
                }

                if (InputShipVia.Text.Trim().Length == 0)
                {
                    ShipViaError.Text = "The Ship via is required";
                    ShipViaError.Visibility = Visibility.Visible;
                    isvalid = false;
                }

                if (InputFreight.Text.Trim().Length == 0)
                {
                    FreightError.Text = "The freight is required";
                    FreightError.Visibility = Visibility.Visible;
                    isvalid = false;
                }

                if (InputShipName.Text.Trim().Length == 0)
                {
                    ShipNameError.Text = "The ship name is required";
                    ShipNameError.Visibility = Visibility.Visible;
                    isvalid = false;
                }

                if (inputShipAddress.Text.Trim().Length == 0)
                {
                    ShipAddressError.Text = "The address is required";
                    ShipAddressError.Visibility = Visibility.Visible;
                    isvalid = false;
                }


                if (InputShipCity.Text.Trim().Length == 0)
                {
                    ShipCityError.Text = "The ship city is required";
                    ShipCityError.Visibility = Visibility.Visible;
                    isvalid = false;
                }

                if (InputShipRegion.Text.Trim().Length == 0)
                {
                    ShipRegionError.Text = "The ship region is required";
                    ShipRegionError.Visibility = Visibility.Visible;
                    isvalid = false;
                }

                if (Inputzip.Text.Trim().Length == 0)
                {
                    ShipZipError.Text = "The ship postal code is required";
                    ShipZipError.Visibility = Visibility.Visible;
                    isvalid = false;
                }

                if (inputShipCountry.Text.Trim().Length == 0)
                {
                    ShipCountryError.Text = "The ship country is required";
                    ShipCountryError.Visibility = Visibility.Visible;
                    isvalid = false;
                }


                if (isvalid)
                {
                    MessageBox.Show("data is valided", "info");


                }

            
        }

        private void InputEmployeeId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeesError.Visibility = Visibility.Collapsed;
        }

        private void InputCustomerId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomerIdError.Visibility = Visibility.Collapsed;
        }
        private void inputShipAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipAddressError.Visibility = Visibility.Collapsed;
            ShipAddressError.Text = "";
        }

        private void InputShipName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipNameError.Visibility = Visibility.Collapsed;
            ShipNameError.Text = "";
        }
        private void InputFreight_TextChanged(object sender, TextChangedEventArgs e)
        {
            FreightError.Visibility = Visibility.Collapsed;
            FreightError.Text = "";
        }
        private void InputShipVia_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipViaError.Visibility = Visibility.Collapsed;
            ShipViaError.Text = "";
        }

        private void inputShipCountry_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipCountryError.Visibility = Visibility.Collapsed;
            ShipCountryError.Text = "";
        }

        private void Inputzip_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipZipError.Visibility = Visibility.Collapsed;
            ShipZipError.Text = "";
        }
        private void InputShipRegion_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipRegionError.Visibility = Visibility.Collapsed;
            ShipRegionError.Text = "";
        }
        private void InputShipCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipCityError.Visibility = Visibility.Collapsed;
            ShipCityError.Text = "";
        }

        private void InputRequiredDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RequiredDateError.Visibility = Visibility.Collapsed;
            RequiredDateError.Text = "";

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderDateError.Visibility = Visibility.Collapsed;
            OrderDateError.Text = "";

        }

        private void InputShippedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ShippedDateError.Visibility = Visibility.Collapsed;
            ShippedDateError.Text = "";
        }

        private void InputProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductError.Visibility = Visibility.Collapsed;
            ProductError.Text = "";
        }

        private void InputQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {

            QuantityError.Visibility = Visibility.Collapsed;
            QuantityError.Text = "";
        }

        private void InputDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            DiscountError.Visibility = Visibility.Collapsed;
            DiscountError   .Text = "";
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputProduct.SelectedIndex==0)
            {
                ProductError.Text = "The product is required";
                ProductError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (inputQuantity.Text.Trim().Length==0)
            {
                QuantityError.Text = "The quantity is reqired";
                QuantityError.Visibility = Visibility.Visible;
                isvalid = false;

            }


            if (inputDiscount.Text.Trim().Length == 0)
            {
                DiscountError.Text = "The discount is reqired";
                DiscountError.Visibility = Visibility.Visible;
                isvalid = false;

            }
            if (isvalid)
            {
                //add product
            }
        }




       
    }
}
