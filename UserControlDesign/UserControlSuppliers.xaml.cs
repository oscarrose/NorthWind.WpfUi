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
    /// Interaction logic for UserControlSuppliers.xaml
    /// </summary>
    public partial class UserControlSuppliers : UserControl
    {
        public UserControlSuppliers()
        {
            InitializeComponent();
           
            this.Loaded += UserControlSuppliers_Loaded;
            NewSupplierButton.Click += NewSupplierButton_Click;
            DataGridSuppliers.SelectionChanged += DataGridSuppliers_SelectionChanged;
            EditSupplierButton.Click += EditSupplierButton_Click;
            DeleteSupplierButton.Click += DeleteSupplierButton_Click;
        }

        private void DeleteSupplierButton_Click(object sender, RoutedEventArgs e)
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

                            var DetailConSupplier = (from p in db.Products
                                                     join od in db.OrderDetails on p.ProductId equals od.ProductId
                                                     join o in db.Orders on od.OrderId equals o.OrderId
                                                     where p.SupplierId == getid()
                                                     select od).ToList();


                            var orderConShipper = (from p in db.Products
                                                   join od in db.OrderDetails on p.ProductId equals od.ProductId
                                                   join o in db.Orders on od.OrderId equals o.OrderId
                                                   where p.SupplierId == getid()
                                                   select o).ToList();

                            var SupplierConProduct = (from p in db.Products
                                                   join s in db.Suppliers on p.SupplierId equals s.SupplierId  
                                                   where p.SupplierId == getid()
                                                   select p).ToList();

                            var ConsultSupplier = (from s in db.Suppliers
                                                  where s.SupplierId == id
                                                  select s).Single();

                            var result = MessageBox.Show($"¿Desea eliminar Supplier: ? {ConsultSupplier.CompanyName}", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);


                            if (result == MessageBoxResult.Yes)
                            {
                                foreach (var item in DetailConSupplier)
                                {
                                    db.OrderDetails.Remove(item);
                                }
                                foreach (var item in orderConShipper)
                                {
                                    db.Orders.Remove(item);

                                }
                                foreach (var item in SupplierConProduct)
                                {
                                    db.Products.Remove(item);

                                }
                                db.Suppliers.Remove(ConsultSupplier);
                                db.SaveChanges();


                                LoadSuppliers();
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

        private void EditSupplierButton_Click(object sender, RoutedEventArgs e)
        {

            int? id = getid();

            if (id != null)
            {
                var ModalSupplier = new ModalSuppliers(id);

                ModalSupplier.title.Text = "Update suppliers";

      
                var result = ModalSupplier.ShowDialog();
            }
            LoadSuppliers();
        }

        private void DataGridSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (DataGridSuppliers.SelectedCells.Count > 0)
            {
                EditSupplierButton.IsEnabled = true;
                DeleteSupplierButton.IsEnabled = true;

            }
        }

        private void NewSupplierButton_Click(object sender, RoutedEventArgs e)
        {

            if (true)
            {

                var ModalSupplier = new ModalSuppliers();


                var result = ModalSupplier.ShowDialog();
            }
            LoadSuppliers();
        }

        private void UserControlSuppliers_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                //consulta para mostrar data
                var AllSupplier = from Supplier in db.Suppliers
                                   //select order todas
                               select new
                               {
                                  Supplier.SupplierId,
                                  Supplier.CompanyName,
                                  Supplier.ContactName,
                                  Supplier.ContactTitle,
                                  Supplier.Address,
                                  Supplier.City,
                                  Supplier.Region,
                                  Supplier.PostalCode,
                                  Supplier.Country,
                                  Supplier.Phone,
                                  Supplier.Fax,
                     
                               };
                // mostrando la data
                DataGridSuppliers.ItemsSource = AllSupplier.ToList();


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
                var result = ((dynamic)DataGridSuppliers.SelectedItem);
                return result.SupplierId;

            }
            catch
            {
                return null;

            }
        }




    }





}

