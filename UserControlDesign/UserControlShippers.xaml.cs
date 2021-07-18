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

namespace NorthWind.WpfUi
{
    /// <summary>
    /// Interaction logic for UserControlShippers.xaml
    /// </summary>
    public partial class UserControlShippers : UserControl
    {
        
        public UserControlShippers()
        {
            InitializeComponent();
           

            InputCompanyName.TextChanged += InputCompanyName_TextChanged;
            InputPhone.TextChanged += InputPhone_TextChanged;
            this.Loaded += UserControlShippers_Loaded;
            DataGridShippers.SelectionChanged += DataGridShippers_SelectionChanged;
            DataGridShippers.SelectionChanged += DataGridShippers_SelectionChanged1;
            NewShippersButton.Click += NewShippersButton_Click;
            EditShippersButton.Click += EditShippersButton_Click;
            DeleteShippersButton.Click += DeleteShippersButton_Click;
           

        }

        private void DeleteShippersButton_Click(object sender, RoutedEventArgs e)
        {
            int? id = getid();
            if (id != null)
            {
                try
                {
                    using (NorthwindContext db = new NorthwindContext())
                    {

                        try
                        {

                            var DetailConShipper = (from s in db.Shippers
                                                     join o in db.Orders on s.ShipperId equals o.ShipVia
                                                     join od in db.OrderDetails on o.OrderId equals od.OrderId
                                                     where s.ShipperId == getid()
                                                     select od).ToList();


                            var orderConShipper = (from s in db.Shippers
                                                     join o in db.Orders on s.ShipperId equals o.ShipVia
                                                     where s.ShipperId == getid()
                                                     select o).ToList();

                            var ConsultShipper = (from s in db.Shippers
                                                   where s.ShipperId == id
                                                   select s).Single();

                            var result = MessageBox.Show($"¿Desea eliminar shippers: ? {ConsultShipper.CompanyName}", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);


                            if (result == MessageBoxResult.Yes)
                            {
                                foreach (var item in DetailConShipper)
                                {
                                    db.OrderDetails.Remove(item);
                                }
                                foreach (var item in orderConShipper)
                                {
                                    db.Orders.Remove(item);

                                }
                               

                                db.Shippers.Remove(ConsultShipper);
                                db.SaveChanges();


                                LoadDataShipper();
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

        private void NewShippersButton_Click(object sender, RoutedEventArgs e)
        {
            clearinput();
            EditShippersButton.IsEnabled = false;
            DeleteShippersButton.IsEnabled = false;
            SaveShippersButton.IsEnabled = true;
            
        }

        private void DataGridShippers_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            int? id = getid();

            if (id != null)
            {
                
                LoadDateEdit();

            }
            
        }

        private void DataGridShippers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridShippers.SelectedCells.Count > 0)
            {
                EditShippersButton.IsEnabled = true;
                DeleteShippersButton.IsEnabled = true;

            }
            SaveShippersButton.IsEnabled = false;
            NewShippersButton.IsEnabled = true; 
        }

        private void UserControlShippers_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataShipper();
        }

        private void InputPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhoneError.Visibility = Visibility.Visible;
            PhoneError.Text = "";

        }

        private void InputCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CompanyNameError.Visibility = Visibility.Visible;
            CompanyNameError.Text = "";
        }

        private void SaveShippersButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputCompanyName.Text.Trim().Length == 0)
            {
                CompanyNameError.Text = "The company name is required";

                CompanyNameError.Visibility = Visibility.Visible;
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
                    using (NorthwindContext db =new NorthwindContext())
                    {
                        Shipper dataShipper = new Shipper();
                        dataShipper.CompanyName = InputCompanyName.Text;
                        dataShipper.Phone = InputPhone.Text;
                        db.Shippers.Add(dataShipper);
                        db.SaveChanges();
                            clearinput();
                            LoadDataShipper();
                        


                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }




        }

        private void EditShippersButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NorthwindContext db = new NorthwindContext())
                {
                   
                    Shipper dataShipper = db.Shippers.Find(getid());
                    dataShipper.CompanyName = InputCompanyName.Text;
                    dataShipper.Phone = InputPhone.Text;
                   
                    db.SaveChanges();
                    clearinput();
                    LoadDataShipper();


                  
                   
                }
               


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void clearinput()
        {
            InputPhone.Clear();
            InputCompanyName.Clear();
        }


        /// <summary>
        /// method para cargar los datos
        /// </summary>
        private void LoadDataShipper()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                //consulta para mostrar data
                var AllShipper = from Shipper in db.Shippers
                                     //select products;
                                 select new
                                 {
                                     Shipper.ShipperId,
                                     Shipper.CompanyName,
                                     Shipper.Phone

                                 };
                // mostrando la data
                DataGridShippers.ItemsSource = AllShipper.ToList();


            }
        }


        /// <summary>
        /// Obtener el id del items a editar
        /// </summary>
        /// <returns></returns>
        private int? getid()
        {
            try
            {
                var result = ((dynamic)DataGridShippers.SelectedItem);
                return result.ShipperId;

            }
            catch
            {
                return null;

            }
        }

        /// <summary>
        /// Para buscar los id y cargar los datos en el datagrid para editar
        /// </summary>
        private void LoadDateEdit()
        {
            using (NorthwindContext db = new NorthwindContext())
            {

                try
                {
                    Shipper s = new Shipper();

                    s = db.Shippers.Find(getid());

                    InputCompanyName.Text = s.CompanyName.ToString();
                    InputPhone.Text = s.Phone.ToString();

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"unexpected error {ex}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }




            }



        }
    }
}
