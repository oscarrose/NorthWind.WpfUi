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
    /// Interaction logic for UserControlSuppliers.xaml
    /// </summary>
    public partial class UserControlSuppliers : UserControl
    {
        public UserControlSuppliers()
        {
            InitializeComponent();
            inputCompanyName.TextChanged += InputCompanyName_TextChanged;
            inputContactName.TextChanged += InputContactName_TextChanged;
            inputContactTile.TextChanged += InputContactTile_TextChanged;
            InputAddress.TextChanged += InputAddress_TextChanged;
            InputCity.TextChanged += InputCity_TextChanged;
            InputRegion.TextChanged += InputRegion_TextChanged;
            InputZip.TextChanged += InputZip_TextChanged;
            Inputcountry.TextChanged += Inputcountry_TextChanged;
            InputPhone.TextChanged += InputPhone_TextChanged;
            InputFax.TextChanged += InputFax_TextChanged;
            InputHomepage.TextChanged += InputHomepage_TextChanged;
        }

        private void InputHomepage_TextChanged(object sender, TextChangedEventArgs e)
        {

            HomepageError.Text = "";
            HomepageError.Visibility = Visibility.Collapsed;
        }

        private void InputFax_TextChanged(object sender, TextChangedEventArgs e)
        {
            FaxError.Text = "";
            FaxError.Visibility = Visibility.Collapsed;
        }

        private void InputPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhoneError.Text = "";
            PhoneError.Visibility = Visibility.Collapsed;
        }

        private void Inputcountry_TextChanged(object sender, TextChangedEventArgs e)
        {
            countryError.Text = "";
            countryError.Visibility = Visibility.Collapsed;
        }

        private void InputZip_TextChanged(object sender, TextChangedEventArgs e)
        {
            zipError.Text = "";
            zipError.Visibility = Visibility.Collapsed;
        }

        private void InputRegion_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegionError.Text = "";
            RegionError.Visibility = Visibility.Collapsed;
        }

        private void InputCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            CityError.Text = "";
            CityError.Visibility = Visibility.Collapsed;

        }

        private void InputAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddressError.Text = "";
            AddressError.Visibility = Visibility.Collapsed;
        }

        private void InputContactTile_TextChanged(object sender, TextChangedEventArgs e)
        {
            ContactTitleError.Text = "";
            ContactTitleError.Visibility = Visibility.Collapsed;
        }

        private void InputContactName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ContactNameError.Text = "";
            ContactNameError.Visibility = Visibility.Collapsed;
        }

        private void InputCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CompanyNameError.Text = "";
            CompanyNameError.Visibility = Visibility.Collapsed;
        }

        private void SaveShippliersButton_Click_1(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (inputCompanyName.Text.Trim().Length==0)
            {
                CompanyNameError.Text = "The company name is required";
                CompanyNameError.Visibility = Visibility.Visible;
                isvalid = false;

            }
            if (inputContactName.Text.Trim().Length == 0)
            {
                ContactNameError.Text = "The contact name is required";
                ContactNameError.Visibility = Visibility.Visible;
                isvalid = false;

            }

            if (inputContactTile.Text.Trim().Length == 0)
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

            if (InputZip.Text.Trim().Length == 0)
            {
                zipError.Text = "The postal code is required";
                zipError.Visibility = Visibility.Visible;
                isvalid = false;

            }

            if (Inputcountry.Text.Trim().Length == 0)
            {
                countryError.Text = "The country is required";
                countryError.Visibility = Visibility.Visible;
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

            if (InputHomepage.Text.Trim().Length == 0)
            {
                HomepageError.Text = "The home page is required";
                HomepageError.Visibility = Visibility.Visible;
                isvalid = false;

            }
            if (isvalid)
            {
                //saved

            }

        }
    }





}

