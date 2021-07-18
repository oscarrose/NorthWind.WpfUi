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
    /// Interaction logic for ListOrdersControl.xaml
    /// </summary>
    public partial class ListOrdersControl : UserControl
    {
        public ListOrdersControl()
        {
            InitializeComponent();
            this.Loaded += ListOrdersControl_Loaded;
        }

        private void ListOrdersControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadOrder();
        }

        private void LoadOrder() {
            using (NorthwindContext db = new NorthwindContext())
            {
                //consulta para mostrar data
                var Allorder = from Order in db.Orders
                                   //select order todas
                               select new{ 
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
                               
                               } ;
                // mostrando la data
                DataListOrders.ItemsSource = Allorder.ToList();


            }







        }
    
    
    }


}
