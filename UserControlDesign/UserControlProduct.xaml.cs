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
using NorthWind.WpfUi.Data;
using NorthWind.WpfUi.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace NorthWind.WpfUi.UserControlDesign
{
    /// <summary>
    /// Interaction logic for UserControlProduct.xaml
    /// </summary>
    public partial class UserControlProduct : UserControl
    {
        public UserControlProduct()
        {
            InitializeComponent();
            LoadDataProduct();
            dtgridproduct.SelectionChanged += Dtgridproduct_SelectionChanged;
            EditProductButton.Click += EditProductButton_Click1;
            DeleteProductButton.Click += DeleteProductButton_Click;
            

        }

        /// <summary>
        /// Para eliminar un product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
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

                            //var ConsultorderDat = db.OrderDetails.Where(o => o.OrderId == id).ToList();

                            var ConsultorderDateil = (from y in db.OrderDetails
                                                      where y.ProductId == id
                                                      select y).ToList();
                     

                            var ConsultProduct = (from x in db.Products
                                                where x.ProductId == id
                                                select x).Single();

                            var result = MessageBox.Show($"¿Desea eliminar? {ConsultProduct.ProductName}", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);


                            if (result == MessageBoxResult.Yes)
                            {
                                foreach (var item in ConsultorderDateil)
                                {
                                    db.OrderDetails.Remove(item);

                                }
                                db.Products.Remove(ConsultProduct);
                                db.SaveChanges();


                                LoadDataProduct();
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
           
        /// <summary>
       /// Obtener el id del items a editar
      /// </summary>
      /// <returns></returns>
        private int? getid()
        {
            try
            {
                var result =((dynamic) dtgridproduct.SelectedItem);
                return result.ProductId;

            }
            catch 
            {
                return null;

            }
        }

        private void EditProductButton_Click1(object sender, RoutedEventArgs e)
        {
            int? id = getid();

            if (id !=null)
            {

                var ModalProducts = new ModalProduct(id);
                ModalProducts.title.Text = "Update product";

                var result = ModalProducts.ShowDialog();
              
            }
            LoadDataProduct();



        }
        /// <summary>
        /// para habilitat los botones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dtgridproduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dtgridproduct. SelectedCells.Count>0)
            {
                EditProductButton.IsEnabled = true;
                DeleteProductButton.IsEnabled = true;
                
            }


        }
        /// <summary>
        /// method fot load date the product
        /// </summary>
        public   void LoadDataProduct()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                //consulta para mostrar data
                var AllProduct = from products in db.Products
                                     //select products;
                                 select new
                                 {
                                     products.ProductId,
                                     products.ProductName,
                                     products.SupplierId,
                                     products.CategoryId,
                                     products.QuantityPerUnit,
                                     products.UnitPrice,
                                     products.UnitsOnOrder,
                                     products.UnitsInStock,
                                     products.ReorderLevel,
                                     products.Discontinued

                                 };
                // mostrando la data
                dtgridproduct.ItemsSource = AllProduct.ToList();


            }
        }

        private void NewProductButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (true)
            {

                var ModalProducts = new ModalProduct();
           

                var result = ModalProducts.ShowDialog();
            }
            LoadDataProduct();

      
        }


    }
}
