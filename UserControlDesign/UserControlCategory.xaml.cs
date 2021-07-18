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
    /// Interaction logic for UserControlCategory.xaml
    /// </summary>
    public partial class UserControlCategory : UserControl
    {
        public UserControlCategory()
        {
            InitializeComponent();
            this.Loaded += UserControlCategory_Loaded;
            DataGriCategories.SelectionChanged += DataGriCategories_SelectionChanged;
            EditCategoryButton.Click += EditCategoryButton_Click;
            DeleteCategoryButton.Click += DeleteCategoryButton_Click;
            
            
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
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

                            var DetailConCategory = (from p in db.Products
                                                   join od in db.OrderDetails on p.ProductId equals od.ProductId
                                                
                                                   where p.CategoryId==getid()  
                                                   select od).ToList();


                            var orderConCategory = (from p in db.Products
                                                    join od in db.OrderDetails on p.ProductId equals od.ProductId
                                                    join o in db.Orders on od.OrderId equals o.OrderId
                                                   where p.CategoryId == getid()
                                                   select o).ToList();

                            var ProductConCategory = (from p in db.Products
                                                  join od in db.OrderDetails on p.ProductId equals od.ProductId
                                                  join o in db.Orders on od.OrderId equals o.OrderId
                                                  where p.CategoryId == getid()
                                                  select p).ToList();


                            var ConsultCategory = (from x in db.Categories
                                                   where x.CategoryId == id
                                                   select x).Single();

                            var result = MessageBox.Show($"¿Desea eliminar? {ConsultCategory.CategoryName}", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);


                            if (result == MessageBoxResult.Yes)
                            {
                                foreach (var item in DetailConCategory)
                                {
                                    db.OrderDetails.Remove(item);
                                }
                                foreach (var item in orderConCategory)
                                {
                                    db.Orders.Remove(item);

                                }
                                foreach (var item in ProductConCategory)
                                {
                                    db.Products.Remove(item);

                                }
                                db.Categories.Remove(ConsultCategory);
                                db.SaveChanges();


                                LoadDataCategories();
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

        private void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            int? id = getid();

            if (id!= null)
            {

                var modalcategories = new ModalCategory (id);
                modalcategories.TitleOfForms.Text = "Update categories";

                var result = modalcategories.ShowDialog();
            }
            LoadDataCategories();
        }

        /// <summary>
        /// Para habilitar los botones de editar y eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGriCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGriCategories.SelectedCells.Count > 0)
            {
                EditCategoryButton.IsEnabled = true;
                DeleteCategoryButton.IsEnabled = true;

            }
            else
            {
                EditCategoryButton.IsEnabled = false;
                DeleteCategoryButton.IsEnabled = false;
            }
        }

        private void UserControlCategory_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataCategories();
        }

        private void NewCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            //Para llamar al modelAddCategory
            if (true)
            {
                var ModalCategorys = new ModalCategory();
                var result = ModalCategorys.ShowDialog();

            }
            LoadDataCategories();


        }

        public void LoadDataCategories()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                //consulta para mostrar data
                var AllCategory = from Category in db.Categories
                                      //select products;

                                  select new
                                  {
                                      Category.CategoryId,
                                      Category.CategoryName,
                                      Category.Description  
                               
                                  };
                // mostrando la data
                DataGriCategories.ItemsSource = AllCategory.ToList();


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
                var result = ((dynamic)DataGriCategories.SelectedItem);
                return result.CategoryId;

            }
            catch
            {
                return null;

            }
        }

    }



}
