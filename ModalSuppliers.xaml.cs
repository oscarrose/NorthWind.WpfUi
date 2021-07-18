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
    /// Interaction logic for ModalSuppliers.xaml
    /// </summary>
    public partial class ModalSuppliers : Window
    {

        public int? id;
        public ModalSuppliers(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            inputCompanyName.TextChanged += InputCompanyName_TextChanged;
            inputContactName.TextChanged += InputContactName_TextChanged;
            inputContactTile.TextChanged += InputContactTile_TextChanged;
            InputAddress.TextChanged += InputAddress_TextChanged;
            InputCity.TextChanged += InputCity_TextChanged;
           
            InputZip.TextChanged += InputZip_TextChanged;
            Inputcountry.TextChanged += Inputcountry_TextChanged;
            InputPhone.TextChanged += InputPhone_TextChanged;
           
           
            ButtonBack.Click += ButtonBack_Click;
            this.Loaded += ModalSuppliers_Loaded;
            SaveSupppliersButton.Click += SaveSupppliersButton_Click;
        }

        private void SaveSupppliersButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (inputCompanyName.Text.Trim().Length == 0)
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

            


            if (isvalid)
            {
                try
                {


                    using (NorthwindContext db = new NorthwindContext())
                    {

                        if (id == null)
                        {
                            //agregar data
                            Supplier s = new Supplier();
                            s.CompanyName = inputCompanyName.Text;
                            s.ContactName = inputContactName.Text;
                            s.ContactTitle = inputContactTile.Text;
                            s.Address = InputAddress.Text;
                            s.City = InputCity.Text;
                            s.Region = InputRegion.Text;
                            s.PostalCode = InputZip.Text;
                            s.Country = Inputcountry.Text;
                            s.Phone = InputPhone.Text;
                            s.Fax = InputFax.Text;
                            s.HomePage = InputHomepage.Text;


                            db.Suppliers.Add(s);
                            db.SaveChanges();

                            var result = MessageBox.Show($"Saved successfully! suppliers: {s.CompanyName}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            if (result == MessageBoxResult.OK)
                            {

                                clearinput();

                            }

                        }

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

            if (id != null)
            {
                try
                {
                    using (NorthwindContext db = new NorthwindContext())
                    {
                        Supplier s = db.Suppliers.Find(id);

                        s.CompanyName = inputCompanyName.Text;
                        s.ContactName = inputContactName.Text;
                        s.ContactTitle = inputContactTile.Text;
                        s.Address = InputAddress.Text;
                        s.City = InputCity.Text;
                        s.Region = InputRegion.Text;
                        s.PostalCode = InputZip.Text;
                        s.Country = Inputcountry.Text;
                        s.Phone = InputPhone.Text;
                        s.Fax = InputFax.Text;
                        s.HomePage = InputHomepage.Text;

                        db.SaveChanges();

                        var result = MessageBox.Show($"Edit successfully! supplier Id : {s.SupplierId}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (result == MessageBoxResult.OK)
                        {
                            this.Close();

                        }

                    }
                      
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               


            }

        }

        private void ModalSuppliers_Loaded(object sender, RoutedEventArgs e)
        {
            if (id != null)
            {
                loaddate();
            }

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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


        private void clearinput()
        {
            inputCompanyName.Clear();
            inputContactName.Clear();
            inputContactTile.Clear();
            InputAddress.Clear();
            InputCity.Clear();
            InputRegion.Clear();
            InputZip.Clear();
            Inputcountry.Clear();
            InputPhone.Clear();
            InputFax.Clear();
            InputHomepage.Clear();
        }

        private void loaddate()
        {
            using (NorthwindContext db = new NorthwindContext())
            {

                try
                {

                   Supplier s = db.Suppliers.Find(id);
                    inputCompanyName.Text = s.CompanyName.ToString();
                    inputContactName.Text = s.ContactName.ToString();
                    inputContactTile.Text = s.ContactTitle.ToString();
                    InputAddress.Text = s.Address.ToString();
                    InputCity.Text = s.City.ToString();
    
                    if (s.Region==null)
                    {
                       
                    }
                    else
                    {
                        InputRegion.Text = s.Region.ToString();
                    }
                    InputZip.Text = s.PostalCode.ToString();
                    Inputcountry.Text = s.Country.ToString();
                    InputPhone.Text = s.Phone.ToString();
                    if (s.Fax==null)
                    {

                    }
                    else
                    {
                        InputFax.Text = s.Fax.ToString();
                    }
                   
                    InputHomepage.Text = s.ToString();


                }
                catch (Exception ex)
                {

                    MessageBox.Show($"unexpected error {ex}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }




            }



        }
    }
}
