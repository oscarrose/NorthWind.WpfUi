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
    /// Interaction logic for ModalEmployees.xaml
    /// </summary>
    public partial class ModalEmployees : Window
    {
        public ModalEmployees()
        {
            InitializeComponent();
            InputLastName.TextChanged += InputLastName_TextChanged;
            InputFristName.TextChanged += InputFristName_TextChanged;
            InputTitle.TextChanged += InputTitle_TextChanged;
            InputTitleOfCountry.TextChanged += InputTitleOfCountry_TextChanged;
            InputBirthDate.TextChanged += InputBirthDate_TextChanged;
            InputHireBirth.TextChanged += InputHireBirth_TextChanged;
            InputAddress.TextChanged += InputAddress_TextChanged;
            InputCity.TextChanged += InputCity_TextChanged;
            InputRegion.TextChanged += InputRegion_TextChanged;
            InputPostalcode.TextChanged += InputPostalcode_TextChanged;
            InputCountry.TextChanged += InputCountry_TextChanged;
            InputHomePhone.TextChanged += InputHomePhone_TextChanged;
            InputExtension.TextChanged += InputExtension_TextChanged;
            InputNotes.TextChanged += InputNotes_TextChanged;
            InputReports.TextChanged += InputReports_TextChanged;
            InputPhotoPath.TextChanged += InputPhotoPath_TextChanged;
            InputEmployees.SelectionChanged += InputEmployees_SelectionChanged;
            InputTerritory.SelectionChanged += InputTerritory_SelectionChanged;
        }

        private void InputTerritory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TerritoryEmployeeError.Visibility = Visibility.Collapsed;
        }

        private void InputEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeesError.Visibility = Visibility.Collapsed;
        }

        private void InputPhotoPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhotoPathError.Visibility = Visibility.Collapsed;
        }

        private void InputReports_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReportsError.Visibility = Visibility.Collapsed;
        }

        private void InputNotes_TextChanged(object sender, TextChangedEventArgs e)
        {
            NotesError.Visibility = Visibility.Collapsed;
        }

        private void InputExtension_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExtensionError.Visibility = Visibility.Collapsed;
        }

        private void InputHomePhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            HomePhoneError.Visibility = Visibility.Collapsed;
        }

        private void InputCountry_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountryError.Visibility = Visibility.Collapsed;
        }

        private void InputPostalcode_TextChanged(object sender, TextChangedEventArgs e)
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

        private void InputHireBirth_TextChanged(object sender, TextChangedEventArgs e)
        {
            HireBirthError.Visibility = Visibility.Collapsed;
        }

        private void InputBirthDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            BirthDateError.Visibility = Visibility.Collapsed;
        }

        private void InputTitleOfCountry_TextChanged(object sender, TextChangedEventArgs e)
        {
            TitleOfCountryError.Visibility = Visibility.Collapsed;
        }

        private void InputTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            TitleError.Visibility = Visibility.Collapsed;
        }

        private void InputFristName_TextChanged(object sender, TextChangedEventArgs e)
        {
            FristNameError.Visibility = Visibility.Collapsed;
        }

        private void InputLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LastNameError.Visibility = Visibility.Collapsed;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputLastName.Text.Trim().Length == 0)
            {
                LastNameError.Text = "The last name is required";

                LastNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputFristName.Text.Trim().Length == 0)
            {
                FristNameError.Text = "The frist name is required";

                FristNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputTitle.Text.Trim().Length == 0)
            {
                TitleError.Text = "The title is required";

                TitleError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputTitleOfCountry.Text.Trim().Length == 0)
            {
                TitleOfCountryError.Text = "The title of country is required";

                TitleOfCountryError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputBirthDate.Text.Trim().Length == 0)
            {
                BirthDateError.Text = "The birth date is required";

                BirthDateError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputHireBirth.Text.Trim().Length == 0)
            {
                HireBirthError.Text = "The hire birth is required";

                HireBirthError.Visibility = Visibility.Visible;
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

            if (InputPostalcode.Text.Trim().Length == 0)
            {
                PostalCodeError.Text = "The postal code is required";

                PostalCodeError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputRegion.Text.Trim().Length == 0)
            {
                RegionError.Text = "The region is required";

                RegionError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputCountry.Text.Trim().Length == 0)
            {
                CountryError.Text = "The country is required";

                CountryError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputHomePhone.Text.Trim().Length == 0)
            {
                HomePhoneError.Text = "The home phone is required";

                HomePhoneError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputExtension.Text.Trim().Length == 0)
            {
                ExtensionError.Text = "The extension is required";

                ExtensionError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputReports.Text.Trim().Length == 0)
            {
                ReportsError.Text = "The reports is required";

                ReportsError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputNotes.Text.Trim().Length == 0)
            {
                NotesError.Text = "The notes is required";

                NotesError.Visibility = Visibility.Visible;
                isvalid = false;
            }



            if (InputPhotoPath.Text.Trim().Length == 0)
            {
                PhotoPathError.Text = "The photo path is required";

                PhotoPathError.Visibility = Visibility.Visible;
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


            if (InputEmployees.SelectedIndex == 0)
            {
                EmployeesError.Text = "The employee is required";
                EmployeesError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputTerritory.SelectedIndex == 0)
            {
                TerritoryEmployeeError.Text = "The territory is required";
                TerritoryEmployeeError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (isvalid)
            {
                MessageBox.Show("saved");
            }

        }
    }
}
