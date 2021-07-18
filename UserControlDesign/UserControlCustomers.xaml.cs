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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NorthWind.WpfUi.Models;

namespace NorthWind.WpfUi.UserControlDesign
{
    /// <summary>
    /// Interaction logic for UserControlCustomers.xaml
    /// </summary>
    public partial class UserControlCustomers : UserControl
    {
        public UserControlCustomers()
        {
            InitializeComponent();
            this.Loaded += UserControlCustomers_Loaded;
            DeleteCustomerButton.Click += DeleteCustomerButton_Click;
            NewCustomerButton.Click += NewCustomerButton_Click;
            DataGridCustomer.SelectionChanged += DataGridCustomer_SelectionChanged;
            EditCustomerButton.Click += EditCustomerButton_Click;
        }

        private void EditCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            string? id = getid();

            if (id != null)
            {

                var ModalCustomer = new ModalCustomers(id);
                ModalCustomer.title.Text = "Update customers";

                var result = ModalCustomer.ShowDialog();

            }
            LoadCustomer();
        }

        private void NewCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
               
                var ModalCustomer = new ModalCustomers();

                ModalCustomer.ContexDemoGraphics.Visibility = Visibility.Collapsed;
                ModalCustomer.Contextvergraphics.Visibility = Visibility.Collapsed;
                



                var result = ModalCustomer.ShowDialog();

              
            }
            LoadCustomer();
        }

        private void DataGridCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (DataGridCustomer.SelectedCells.Count > 0)
            {
                EditCustomerButton.IsEnabled = true;
               DeleteCustomerButton.IsEnabled = true;

            }
        }

        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            string? id = getid();
            if (id != null)
            {
                try
                {
                    using (NorthwindContext db = new NorthwindContext())
                    {

                        try
                        {


                            var DateailConOrder = (from x in db.OrderDetails
                                                    join y in db.Orders
                                                    on x.OrderId equals y.OrderId
                                                   where y.CustomerId==id
                                                select x).ToList();

                            var OrderConDetail = (from x in db.OrderDetails
                                                   join y in db.Orders
                                                   on x.OrderId equals y.OrderId
                                                   where y.CustomerId == id
                                                   select y).ToList();


                            var ConsultCustomer = (from x in db.Customers
                                                  where x.CustomerId == id
                                                  select x).Single();

                            var result = MessageBox.Show($"¿Desea eliminar? {ConsultCustomer.CompanyName}", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);


                            if (result == MessageBoxResult.Yes)
                            {
                                foreach (var item in DateailConOrder)
                                {
                                    db.OrderDetails.Remove(item);
                                }
                                foreach (var item in OrderConDetail)
                                {
                                    db.Orders.Remove(item);

                                }
                                db.Customers.Remove(ConsultCustomer);
                                db.SaveChanges();


                                LoadCustomer();
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("unexpected error" + ex, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("unexpected error the connection" + ex, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);

                }




            }
        }

        private void UserControlCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomer();
        }


        /// <summary>
        /// Para cargar los datos de los customers
        /// </summary>
        private void LoadCustomer()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                //consulta para mostrar data
                var AllCustomer = from Customer in db.Customers
                                      //select order todas
                                  select new
                                  {
                                     Customer.CustomerId,
                                     Customer.CompanyName,
                                     Customer.ContactName,
                                     Customer.ContactTitle,
                                     Customer.Address,
                                     Customer.City,
                                     Customer.Region,
                 
                                     Customer.PostalCode,
                                     Customer.Country,
                                     Customer.Phone,
                                     Customer.Fax

                                  };
                // mostrando la data
                DataGridCustomer.ItemsSource = AllCustomer.ToList();


            }


        }

        /// <summary>
        /// obtener id del la order
        /// </summary>
        /// <returns></returns>
        private String? getid()
        {
            try
            {
                var result = ((dynamic)DataGridCustomer.SelectedItem);
                return result.CustomerId;

            }
            catch
            {
                return null;

            }
        }

       
    }
   
}
