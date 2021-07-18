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
    /// Interaction logic for UserControlOrder.xaml
    /// </summary>
    public partial class UserControlOrder : UserControl
    {
        public UserControlOrder()
        {
            InitializeComponent();
            this.Loaded += UserControlOrder_Loaded;
            DeleteOrderButton.Click += DeleteOrderButton_Click;
        }

        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            //int? id = getid();
            //if (id != null)
            //{
            //    try
            //    {
            //        using (NorthwindContext db = new NorthwindContext())
            //        {

            //            try
            //            {

            //                //var ConsultorderDat = db.OrderDetails.Where(o => o.OrderId == id).ToList();

            //                var ConsultorderDateil = (from y in db.OrderDetails
            //                                          where y.OrderId == id
            //                                          select y).ToList();


            //                var ConsultOrder = (from x in db.Orders
            //                                    where x.OrderId == id
            //                                    select x).Single();

            //                var result = MessageBox.Show($"¿Desea eliminar? {ConsultOrder.OrderId}", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);
                              

            //                if (result == MessageBoxResult.Yes)
            //                {
            //                    foreach (var item in ConsultorderDateil)
            //                    {
            //                        db.OrderDetails.Remove(item);

            //                    }
            //                    db.Orders.Remove(ConsultOrder);
            //                    db.SaveChanges();


            //                    LoadOrder();
            //                }
            //            }
            //            catch (Exception ex)
            //            {

            //                MessageBox.Show("unexpected error" + ex, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            //            }

            //        }

            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("unexpected error the connection" + ex, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);

            //    }




            //}
        }


        private void UserControlOrder_Loaded(object sender, RoutedEventArgs e)
        {
            LoadOrder();

        }

        private void NewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var modalorder = new ModalOrders();
                var result = modalorder.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "expected error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            
        }
        /// <summary>
        /// Para cargar las orders
        /// </summary>
        private void LoadOrder()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                //consulta para mostrar data
                var Allorder = from Order in db.Orders
                                   //select order todas
                               select new
                               {
                                   Order.OrderId,
                                   Order.CustomerId,
                                   Order.EmployeeId,
                                   Order.OrderDate,
                                   Order.RequiredDate,
                                   Order.ShippedDate,
                                   Order.ShipVia,
                                   Order.Freight,
                                   Order.ShipName,
                                   Order.ShipAddress,
                                   Order.ShipCity,
                                   Order.ShipRegion,
                                   Order.ShipPostalCode,
                                   Order.ShipCountry

                               };
                // mostrando la data
                DataGridOrders.ItemsSource = Allorder.ToList();


            }


        }

        /// <summary>
        /// obtener id del la order
        /// </summary>
        /// <returns></returns>
        private int? getid()
        {
            try
            {
                var result = ((dynamic)DataGridOrders.SelectedItem);
                return result.OrderId;

            }
            catch
            {
                return null;

            }
        }
    }

}
