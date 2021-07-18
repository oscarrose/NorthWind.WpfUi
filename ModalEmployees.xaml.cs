using NorthWind.WpfUi.Data;
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
using NorthWind.WpfUi.Models;

namespace NorthWind.WpfUi
{
    /// <summary>
    /// Interaction logic for ModalEmployees.xaml
    /// </summary>
    public partial class ModalEmployees : Window
    {
        public int? id;
        public ModalEmployees(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            InputLastName.TextChanged += InputLastName_TextChanged;
            InputFristName.TextChanged += InputFristName_TextChanged;
            InputTitle.TextChanged += InputTitle_TextChanged;
            InputTitleOfCountry.TextChanged += InputTitleOfCountry_TextChanged;
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
            InputHireDate.SelectedDateChanged += InputHireDate_SelectedDateChanged;
            InputBirthDate.SelectedDateChanged += InputBirthDate_SelectedDateChanged;
            this.Loaded += ModalEmployees_Loaded;
            //InputEmployees.SelectionChanged += InputEmployees_SelectionChanged;
            //InputTerritory.SelectionChanged += InputTerritory_SelectionChanged;
        }

        private void ModalEmployees_Loaded(object sender, RoutedEventArgs e)
        {

            if (id != null)
            {
                loaddate();
            }
        }

        private void InputBirthDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BirthDateError.Visibility = Visibility.Collapsed;
        }

        private void InputHireDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            HireBirthError.Visibility = Visibility.Collapsed;
        }



        //private void InputTerritory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    TerritoryEmployeeError.Visibility = Visibility.Collapsed;
        //}

        //private void InputEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    EmployeesError.Visibility = Visibility.Collapsed;
        //}

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

            if (InputHireDate.Text.ToString().Trim().Length == 0)
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
                try
                {


                    using (NorthwindContext db = new NorthwindContext())
                    {

                        if (id == null)
                        {
                            //agregar data
                            Employee ep = new Employee();
                            ep.LastName = InputLastName.Text;
                            ep.FirstName = InputFristName.Text;
                            ep.Title = InputTitle.Text;
                            ep.TitleOfCourtesy = InputTitleOfCountry.Text;
                            ep.BirthDate = InputBirthDate.SelectedDate;
                            ep.HireDate = InputHireDate.SelectedDate;
                            ep.Address = InputAddress.Text;
                            ep.City = InputCity.Text;
                            ep.Region = InputRegion.Text;
                            ep.PostalCode = InputPostalcode.Text;
                            ep.Country = InputCountry.Text;
                            ep.HomePhone = InputHomePhone.Text;
                            ep.Extension = InputExtension.Text;
                            ep.Notes = InputNotes.Text;
                            ep.ReportsTo = Convert.ToInt32(InputReports.Text);
                            ep.PhotoPath = InputPhotoPath.Text;
                            db.Employees.Add(ep);
                            db.SaveChanges();
                            clearinput();

                        }
                        if (id != null)
                        {
                            Employee ep = db.Employees.Find(id);
                            ep.LastName = InputLastName.Text;
                            ep.FirstName = InputFristName.Text;
                            ep.Title = InputTitle.Text;
                            ep.TitleOfCourtesy = InputTitleOfCountry.Text;
                            ep.BirthDate = InputBirthDate.SelectedDate;
                            ep.HireDate = InputHireDate.SelectedDate;
                            ep.Address = InputAddress.Text;
                            ep.City = InputCity.Text;
                            ep.Region = InputRegion.Text;
                            ep.PostalCode = InputPostalcode.Text;
                            ep.Country = InputCountry.Text;
                            ep.HomePhone = InputHomePhone.Text;
                            ep.Extension = InputExtension.Text;
                            ep.Notes = InputNotes.Text;
                            ep.ReportsTo = Convert.ToInt32(InputReports.Text);
                            ep.PhotoPath = InputPhotoPath.Text;
                            db.SaveChanges();

                            var result = MessageBox.Show($"Edit successfully! employees Id: {ep.EmployeeId}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            if (result == MessageBoxResult.OK)
                            {
                                this.Close();

                            }


                        }

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        /// <summary>
        /// Para buscar los id y cargar los datos en el datagrid para editar
        /// </summary>
        private void loaddate()
        {
            using (NorthwindContext db = new NorthwindContext())
            {

                try
                {

                    Employee ep = db.Employees.Find(id);

                   InputLastName.Text=ep.LastName;
                    InputFristName.Text=ep.FirstName;
                     InputTitle.Text=ep.Title;
                    InputTitleOfCountry.Text=ep.TitleOfCourtesy;
                     InputBirthDate.SelectedDate = Convert.ToDateTime(ep.BirthDate);
                    InputHireDate.SelectedDate = (DateTime)ep.HireDate; 
                    InputAddress.Text=ep.Address;
                    InputCity.Text=ep.City;
                    InputRegion.Text=ep.Region;
                   InputPostalcode.Text=ep.PostalCode;
                      InputCountry.Text=ep.Country;
                   InputHomePhone.Text=ep.HomePhone;
                    InputExtension.Text=ep.Extension;
                     InputNotes.Text=ep.Notes;
                     InputReports.Text=Convert.ToString(ep.ReportsTo);
                     InputPhotoPath.Text=ep.PhotoPath;
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"unexpected error {ex}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }




            }



        }

        private void clearinput()
        {
            InputLastName.Clear();
            InputFristName.Clear();
            InputTitle.Clear();
             InputTitle.Clear();
           
            
            InputAddress.Clear();
            InputCity.Clear();
            InputRegion.Clear();
            InputPostalcode.Clear();
            InputCountry.Clear(); ;
            InputHomePhone.Clear();
            InputExtension.Clear(); ;
            InputReports.Clear();
            InputNotes.Clear();

            InputPhotoPath.Clear();

        }

        private void SaveEmployeeTerritoriesButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;


            //if (InputEmployees.SelectedIndex == 0)
            //{
            //    EmployeesError.Text = "The employee is required";
            //    EmployeesError.Visibility = Visibility.Visible;
            //    isvalid = false;
            //}


            //if (InputTerritory.SelectedIndex == 0)
            //{
            //    TerritoryEmployeeError.Text = "The territory is required";
            //    TerritoryEmployeeError.Visibility = Visibility.Visible;
            //    isvalid = false;
            //}


            if (isvalid)
            {
                MessageBox.Show("saved");
            }

        }
    }
}
