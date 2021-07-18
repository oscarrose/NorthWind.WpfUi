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
using NorthWind.WpfUi.Data;
using NorthWind.WpfUi.Models;
namespace NorthWind.WpfUi
{
    /// <summary>
    /// Interaction logic for ModalCustomers.xaml
    /// </summary>
    public partial class ModalCustomers : Window
    {
        public string? id;
        public ModalCustomers(string? id = null)
        {
            this.id = id;
            InitializeComponent();
           
            InputCompanyName.TextChanged += InputCompanyName_TextChanged;
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
            this.Loaded += ModalCustomers_Loaded;
            SaveCustomerButton.Click += SaveCustomerButton_Click;
        }

        

        private void InputCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerCodeError.Visibility = Visibility.Collapsed;
        }

        private void ModalCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            if (id!=null)
            {
                loaddate();
                this.ContexDemoGraphics.IsEnabled = true;
                this.DataGridGraphics.IsEnabled = true;
                this.Contextvergraphics.IsEnabled = true;

                this.ContexDemoGraphics.Visibility = Visibility.Visible;
               this.Contextvergraphics.Visibility = Visibility.Visible;

                LoadCustomerDemoGraphics();


            }
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


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputCompanyName.Text.Trim().Length == 0)
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


            if (isvalid)
            {
                try
                {


                    using (NorthwindContext db = new NorthwindContext())
                    {

                        if (id == null)
                        {
                            //agregar data
                            Customer c = new Customer();
                            c.CustomerId = GenerarIdTerritory();
                            c.CompanyName = InputContactName.Text;
                            c.ContactName = InputContactName.Text;
                            c.ContactTitle = InputContactTitle.Text;
                            c.Address = InputAddress.Text;
                            c.City = InputCity.Text;
                            c.Region = InputRegion.Text;
                            c.PostalCode = InputPostalCode.Text;
                            c.Country = InputCountry.Text;
                            c.Phone = InputPhone.Text;
                            c.Fax = InputFax.Text;


                            db.Customers.Add(c);
                            db.SaveChanges();
                            clearinput();

                        }

                        if (id!= null)
                        {
                            Customer c = db.Customers.Find(id);

                            c.CompanyName = InputCompanyName.Text;
                            c.ContactName = InputContactName.Text;
                            c.ContactTitle = InputContactTitle.Text;
                            c.Address = InputAddress.Text;
                            c.City = InputCity.Text;
                            c.Region = InputRegion.Text;
                            c.PostalCode = InputPostalCode.Text;
                            c.Country = InputCountry.Text;
                            c.Phone = InputPhone.Text;
                            c.Fax = InputFax.Text;



                            var result = MessageBox.Show($"Edit successfully! Customer: {c.CustomerId}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            if (result == MessageBoxResult.OK)
                            {
                                this.Close();
                                db.SaveChanges();
                                

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


        private void SaveCustomerDemoButton_Click(object sender, RoutedEventArgs e)
        {
            //var isvalid = true;

            //if (InputCustomerDesc.Text.Trim().Length == 0)
            //{
            //    EmployeesError.Text = "The employee is required";

            //    EmployeesError.Visibility = Visibility.Visible;
            //    isvalid = false;
            //}

            //if (InputCustomertype.SelectedIndex== 0)
            //{
            //    CustomerIDDemoError.Text = "The customer is required";

            //    CustomerIDDemoError.Visibility = Visibility.Visible;
            //    isvalid = false;
            //}
            //if (isvalid)
            //{
            //    MessageBox.Show("saved");

            //}

        }
        /// <summary>
        /// Para guardar un customer DemoGraphics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                try
                {


                    using (NorthwindContext db = new NorthwindContext())
                    {


                        if (id != null)
                        {
                            CustomerDemographic cdg = new CustomerDemographic();
                            cdg.CustomerTypeId = id;
                            cdg.CustomerDesc = InputCustomerDesc.Text;
                            db.CustomerDemographics.Add(cdg);
                            db.SaveChanges();
                            clearInputGraphics();
                            LoadCustomerDemoGraphics();
                        }

                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show($"{ex} unexpected error", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
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

                   Customer c = db.Customers.Find(id);

                    InputCompanyName.Text = c.CompanyName;
                    InputContactName.Text = c.ContactName;
                    InputContactTitle.Text = c.ContactTitle;
                    InputAddress.Text = c.Address;
                    InputCity.Text = c.City;
                    InputRegion.Text = c.Region;
                    InputPostalCode.Text = c.PostalCode;
                    InputCountry.Text = c.Country;
                    InputPhone.Text = c.Phone;
                    InputFax.Text = c.Fax;

                }
                catch (Exception ex)
                {

                    MessageBox.Show($" {ex},unexpected error", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }




            }
        }

        /// <summary>
        /// Genera el id de los Customer
        /// </summary>
        /// <returns></returns>
        private string GenerarIdTerritory()
        {
         
            try
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random();
                var result = new string(Enumerable.Repeat(chars, 5)
                                                    .Select(s => s[random.Next(s.Length)])
                                                     .ToArray());
                return result;
            }
            catch (Exception)
            {

                return null;
            }


        }
        /// <summary>
        /// Para limpiar los input
        /// </summary>
        private void clearinput()
        {

            InputCompanyName.Clear();
            InputContactName.Clear();
            InputContactTitle.Clear();
             InputAddress.Clear();
             InputCity.Clear();
             InputRegion.Clear();
             InputPostalCode.Clear();
             InputCountry.Clear();
            InputPhone.Clear() ;
            InputFax.Clear(); 
        }



        /// <summary>
        /// Para cargar los datos de los customerDemoGraphics
        /// </summary>
        private void LoadCustomerDemoGraphics()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                //consulta para mostrar data
                var AllCustomerDemographics = from graphics in db.CustomerDemographics
                                              where graphics.CustomerTypeId == id
                                              select new { 
                                                  graphics.CustomerTypeId,
                                                  graphics.CustomerDesc
                                              
                                              };
                // mostrando la data
                DataGridGraphics.ItemsSource = AllCustomerDemographics.ToList();


            }


        }


        /// <summary>
        /// Para limpiar los input de DemoGraphics
        /// </summary>
        private void clearInputGraphics()
        {
            InputCustomerDesc.Clear();
        }


    }
}
