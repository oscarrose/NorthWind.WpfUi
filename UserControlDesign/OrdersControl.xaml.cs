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
    /// Interaction logic for OrdersControl.xaml
    /// </summary>
    public partial class OrdersControl : UserControl
    {
        public OrdersControl()
        {
            InitializeComponent();
            SaveButton.Click += SaveButton_Click_1;
            inputCustomerId.TextChanged += inputCustomerId_TextChanged;
            InputEmployeeId.TextChanged += InputEmployeeId_TextChanged;
            InputOrderDate.SelectedDateChanged += DatePicker_SelectedDateChanged;
            InputRequiredDate.SelectedDateChanged += InputRequiredDate_SelectedDateChanged;
            //los demas estan de forma automatica desde la ventana de evento de los controles
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
        private void InputShippedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ShippedDateError.Visibility = Visibility.Collapsed;
            ShippedDateError.Text = "";

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

        private void InputEmployeeId_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmployeeIdError.Visibility = Visibility.Collapsed;
            EmployeeIdError.Text = "";
        }

        private void inputCustomerId_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerIdError.Visibility = Visibility.Collapsed;
            CustomerIdError.Text = "";
        }


        //para validar si los campos estan llenos a
       
        private void SaveButton_Click_1(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (inputCustomerId.Text.Trim().Length==0)
            {
                CustomerIdError.Text = "The customer Id is required";
                CustomerIdError.Visibility = Visibility.Visible;
                 isvalid = false;
            }


            if (InputEmployeeId.Text.Trim().Length == 0)
            {
                EmployeeIdError.Text = "The employee id is required";
                EmployeeIdError.Visibility = Visibility.Visible;
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
                ShipNameError.Text = "The freight is required";
                ShipNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (inputShipAddress.Text.Trim().Length == 0)
            {
                ShipAddressError.Text = "The freight is required";
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
                ShipCountryError.Text = "The ship country code is required";
                ShipCountryError.Visibility = Visibility.Visible;
                isvalid = false;
            }




            if (isvalid)
            {
                MessageBox.Show("data is valided","info");
              

            }



        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            //Para llamar al modelAddCustomer
            var FormAddCustomer =  new ModelAddCustomer();
            var result = FormAddCustomer.ShowDialog();
        }


    }
}
