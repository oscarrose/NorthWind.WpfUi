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
    /// Interaction logic for ModalCustomers.xaml
    /// </summary>
    public partial class ModalCustomers : Window
    {
        public ModalCustomers()
        {
            InitializeComponent();
            InputCustomerCode.TextChanged += InputCustomerCode_TextChanged;
            InputContactName.TextChanged += InputContactName_TextChanged;
            InputContactTitle.TextChanged += InputContactTitle_TextChanged;
            InputAddress.TextChanged += InputAddress_TextChanged;
            InputCity.TextChanged += InputCity_TextChanged;
            InputRegion.TextChanged += InputRegion_TextChanged;
            InputPostalCode.TextChanged += InputPostalCode_TextChanged;
            InputCountry.TextChanged += InputCountry_TextChanged;
            InputPhone.TextChanged += InputPhone_TextChanged;
            InputFax.TextChanged += InputFax_TextChanged;

            InputCustomerDesc.TextChanged += InputCustomerDesc_TextChanged;
        }

        private void InputCustomerDesc_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerDescError.Visibility = Visibility.Collapsed;
        }

        private void InputFax_TextChanged(object sender, TextChangedEventArgs e)
        {
            FaxError.Visibility = Visibility.Collapsed;
        }

        private void InputPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhoneError.Visibility = Visibility.Collapsed;
        }

        private void InputCountry_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountryError.Visibility = Visibility.Collapsed;
        }

        private void InputPostalCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            PostalCodeError.Visibility = Visibility.Collapsed;
        }

        private void InputRegion_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegionError.Visibility = Visibility.Collapsed;
        }

        private void InputCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            CityError.Visibility = Visibility.Collapsed;
        }

        private void InputAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddressError.Visibility = Visibility.Collapsed;
        }

        private void InputContactTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ContactTitleError.Visibility = Visibility.Collapsed;
        }

        private void InputContactName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ContactNameError.Visibility = Visibility.Collapsed;
        }

        private void InputCustomerCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerCodeError.Visibility = Visibility.Collapsed;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveProductButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputCustomerCode.Text.Trim().Length == 0)
            {
                CustomerCodeError.Text = "The customer code is required";

                CustomerCodeError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputContactName.Text.Trim().Length == 0)
            {
                ContactNameError.Text = "The contact name is required";

                ContactNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputContactTitle.Text.Trim().Length == 0)
            {
                ContactTitleError.Text = "The contact title is required";

                ContactTitleError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputAddress.Text.Trim().Length == 0)
            {
                AddressError.Text = "The address is required";

                AddressError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputCity.Text.Trim().Length == 0)
            {
                CityError.Text = "The city is required";

                CityError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputRegion.Text.Trim().Length == 0)
            {
                RegionError.Text = "The region is required";

                RegionError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputPostalCode.Text.Trim().Length == 0)
            {
                PostalCodeError.Text = "The postal code is required";

                PostalCodeError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputCountry.Text.Trim().Length == 0)
            {
                CountryError.Text = "The country is required";

                CountryError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputPhone.Text.Trim().Length == 0)
            {
                PhoneError.Text = "The phone is required";

                PhoneError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputFax.Text.Trim().Length == 0)
            {
                FaxError.Text = "The fax is required";

                FaxError.Visibility = Visibility.Visible;
                isvalid = false;
            }

         
            if (isvalid)
            {
                MessageBox.Show("saved");
            }
        }

        private void SaveEmployeeTerritoriesButton_Click(object sender, RoutedEventArgs e)
        {

            var isvalid = true;

            if (InputCustomerDesc.Text.Trim().Length == 0)
            {
                CustomerDescError.Text = "The customer desc is required";

                CustomerDescError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (isvalid)
            {
                MessageBox.Show("saved");

            }

        }

        private void SaveCustomerDemoButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputCustomerDesc.Text.Trim().Length == 0)
            {
                EmployeesError.Text = "The employee is required";

                EmployeesError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputCustomertype.SelectedIndex== 0)
            {
                CustomerIDDemoError.Text = "The customer is required";

                CustomerIDDemoError.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (isvalid)
            {
                MessageBox.Show("saved");

            }

        }

        private void SaveCustomerGraphicsButton_Click(object sender, RoutedEventArgs e)
        {

            var isvalid = true;

            if (InputCustomerDesc.Text.Trim().Length == 0)
            {
                CustomerDescError.Text = "The customer descis required";

                CustomerDescError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (isvalid)
            {

            }

        }
    }
}
