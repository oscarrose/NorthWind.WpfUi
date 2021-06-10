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
    /// Interaction logic for ModelAddCustomer.xaml
    /// </summary>
    public partial class ModelAddCustomer : Window
    {
        public ModelAddCustomer()
        {
            InitializeComponent();
        }

        private void BtnCloseCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputCompanyName.Text.Trim().Length == 0)
            {
                CompanyNameError.Text = "C.name is requi..";
                CompanyNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputContactName.Text.Trim().Length == 0)
            {
                ContactNameError.Text = "Cont.n is required";
                ContactNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (InputContactTitle.Text.Trim().Length == 0)
            {
                ContactTitleError.Text = "Cont.title is required";
                ContactTitleError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputAddress.Text.Trim().Length == 0)
            {
                AddressError.Text = "Addr is required";
                AddressError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputCity.Text.Trim().Length == 0)
            {
                CityError.Text = "City is required";
                CityError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputRegion.Text.Trim().Length == 0)
            {
                RegionError.Text = "Region is required";
                RegionError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputZip.Text.Trim().Length == 0)
            {
                ZipError.Text = "Zip is required";
                ZipError.Visibility = Visibility.Visible;
                isvalid = false;
            }



            if (InputCountry.Text.Trim().Length == 0)
            {
                CountryError.Text = "Country is required";
                CountryError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputPhone.Text.Trim().Length == 0)
            {
                PhoneError.Text = "Phone is required";
                PhoneError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputFax.Text.Trim().Length == 0)
            {
                FaxError.Text = "Fax is required";
                FaxError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (isvalid)
            {
                MessageBox.Show("Data Valided");
            }
        }

        private void InputCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CompanyNameError.Visibility = Visibility.Collapsed;
            CompanyNameError.Text = "";
        }

        private void InputContactName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ContactNameError.Visibility = Visibility.Collapsed;
            ContactNameError.Text = "";

        }

        private void InputContactTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ContactTitleError.Visibility = Visibility.Collapsed;
            ContactTitleError.Text = "";
        }

        private void InputAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddressError.Visibility = Visibility.Collapsed;
            AddressError.Text = "";
        }

        private void InputCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            CityError.Visibility = Visibility.Collapsed;
            CityError.Text = "";

        }

        private void InputRegion_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegionError.Visibility = Visibility.Collapsed;
            RegionError.Text= "";
        }

        private void InputZip_TextChanged(object sender, TextChangedEventArgs e)
        {
           ZipError.Visibility = Visibility.Collapsed;
            ZipError.Text = "";
        }

        private void InputCountry_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountryError.Visibility = Visibility.Collapsed;
            CountryError.Text = "";
        }

        private void InputPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhoneError.Visibility = Visibility.Collapsed;
            PhoneError.Text = "";
        }

        private void InputFax_TextChanged(object sender, TextChangedEventArgs e)
        {
            FaxError.Visibility = Visibility.Collapsed;
            FaxError.Text = "";
        }
    }
}
