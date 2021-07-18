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
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;



namespace NorthWind.WpfUi
{
    /// <summary>
    /// Interaction logic for ModalProduct.xaml
    /// </summary>
    public partial class ModalProduct : Window
    {
       
        public int? id;
        Product p = null;
        public ModalProduct(int? id = null)
        {

            InitializeComponent();
            this.id = id;

            //Eventos de los objetos
            InputProductName.TextChanged += InputProductName_TextChanged;
            InputSupplierID.SelectionChanged += InputSupplierID_SelectionChanged;
            InputCategoriesID.SelectionChanged += InputCategoriesID_SelectionChanged;
            InputQuanity.TextChanged += InputQuanity_TextChanged;
            InputUnitprice.TextChanged += InputUnitprice_TextChanged;
            InputUnitStock.TextChanged += InputUnitStock_TextChanged;
            InputUnitsorder.TextChanged += InputUnitsorder_TextChanged;

            InputRecorderLevel.TextChanged += InputRecorderLevel_TextChanged;
            InputSupplierID.SelectionChanged += InputSupplierID_SelectionChanged1;
            

            Loaded += ModalProduct_Loaded;




        }

        private void InputSupplierID_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
           
        }

        /// <summary>
        /// Para buscar los id y cargar los datos en el datagrid para editar
        /// </summary>
        private void loaddate() {
            using (NorthwindContext db = new NorthwindContext()) {

                try
                {
                   
                      p = db.Products.Find(id);

                    InputProductName.Text = p.ProductName.ToString();

                    InputSupplierID.SelectedValue =p.SupplierId.ToString();
                    InputCategoriesID.SelectedValue= p.CategoryId.ToString();

                    InputQuanity.Text = p.QuantityPerUnit;
                    InputUnitprice.Text = p.UnitPrice.ToString();
                    InputUnitStock.Text = p.UnitsInStock.ToString();
                    InputUnitsorder.Text = p.UnitsOnOrder.ToString();
                    InputRecorderLevel.Text = p.ReorderLevel.ToString();
                    InputDiscontinued.IsChecked = p.Discontinued;
             
                }
                catch (Exception ex)
                {

                  MessageBox.Show($"unexpected error {ex}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
               
                
            
            
            }

        }

        /// <summary>
        /// Para limpiar los inputs
        /// </summary>
        private void clearinput() {
            InputProductName.Clear();
            InputCategoriesID.Items.Clear();
            InputSupplierID.Items.Clear();
            InputQuanity.Clear();
            InputUnitprice.Clear();
            InputUnitStock.Clear();
            InputRecorderLevel.Clear();
            InputDiscontinued.IsChecked = false;
            InputUnitsorder.Clear();

        }

        private void ModalProduct_Loaded(object sender, RoutedEventArgs e)
        {
            llenacomboboxDeProduct();


            if (id!= null)
            {
                loaddate();
            }


        }

        private void InputRecorderLevel_TextChanged(object sender, TextChangedEventArgs e)
        {
            RecorderLevelError.Visibility = Visibility.Collapsed;
        }

        private void InputUnitsorder_TextChanged(object sender, TextChangedEventArgs e)
        {
            UnitsorderError .Text = "";
            UnitsorderError.Visibility = Visibility.Collapsed;
        }

        private void InputUnitStock_TextChanged(object sender, TextChangedEventArgs e)
        {
           UnitstockError.Text = "";
            UnitstockError.Visibility = Visibility.Collapsed;
        }

        private void InputUnitprice_TextChanged(object sender, TextChangedEventArgs e)
        {
            UnitpriceError.Text = "";
            UnitpriceError.Visibility = Visibility.Collapsed;
        }

        private void InputQuanity_TextChanged(object sender, TextChangedEventArgs e)
        {
            QuanityError.Text = "";
            QuanityError.Visibility = Visibility.Collapsed;
        }

        private void InputCategoriesID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CategoriesidError.Text = "";
            CategoriesidError.Visibility = Visibility.Collapsed;
        }

        private void InputSupplierID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SupplieridError.Text = "";
            SupplieridError.Visibility = Visibility.Collapsed;
        }

        private void InputProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductNameError.Text = "";
            ProductNameError.Visibility = Visibility.Collapsed;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveProductButton_Click(object sender, RoutedEventArgs e)
        {
          
            var isvalid = true;

            if (InputProductName.Text.Trim().Length == 0)
            {
                ProductNameError.Text = "The product name is required";

                ProductNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputSupplierID.Text.ToString().Trim().Length==0)
            {
                SupplieridError.Text = "The supplier is required";
                SupplieridError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputCategoriesID.Text.ToString().Trim().Length == 0)
            {
                CategoriesidError.Text = "The categories is required";
                CategoriesidError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputQuanity.Text.Trim().Length == 0)
            {
                QuanityError.Text = "The quanity per unit is required";

                QuanityError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputUnitprice.Text.Trim().Length == 0)
            {
                UnitpriceError.Text = "The unit price is required";

                UnitpriceError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputUnitStock.Text.Trim().Length == 0)
            {
                UnitstockError.Text = "The unit stock is required";

                UnitstockError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputUnitsorder.Text.Trim().Length == 0)
            {
               UnitsorderError.Text = "The unit order is required";

                UnitsorderError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputRecorderLevel.Text.Trim().Length == 0)
            {
                RecorderLevelError.Text = "The Recorder level is required";

                RecorderLevelError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (isvalid)
            {
                try
                {


                    using (NorthwindContext db = new NorthwindContext())
                    {

                        if (id==null)
                        {
                            //agregar data
                            Product p = new Product();
                            p.ProductName= InputProductName.Text;
                            p.SupplierId = Convert.ToInt32(InputSupplierID.SelectedValue);
                            p.CategoryId = Convert.ToInt32(InputCategoriesID.SelectedValue);
                            p.QuantityPerUnit = InputQuanity.Text;
                            p.UnitPrice = Convert.ToDecimal(InputUnitprice.Text);
                            p.UnitsInStock = Convert.ToInt16(InputUnitStock.Text);
                            p.ReorderLevel = Convert.ToInt16(InputRecorderLevel.Text);
                            p.UnitsOnOrder = Convert.ToInt16(InputUnitsorder.Text);
                            p.Discontinued = InputDiscontinued.IsChecked.Value;


                            db.Products.Add(p);
                            db.SaveChanges();

                            var result = MessageBox.Show($"Saved successfully! Produc: {p.ProductName}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            if (result==MessageBoxResult.OK)
                            {
                               
                                clearinput();
                                llenacomboboxDeProduct();
                            }

                        }

                        if (id!=null)
                        {
                            Product p = db.Products.Find(id);

                            p.ProductName = InputProductName.Text;
                            p.SupplierId = Convert.ToInt32(InputSupplierID.SelectedValue);
                            p.CategoryId = Convert.ToInt32(InputCategoriesID.SelectedValue);
                            p.QuantityPerUnit = InputQuanity.Text;
                            p.UnitPrice = Convert.ToDecimal(InputUnitprice.Text);
                            p.UnitsInStock = Convert.ToInt16(InputUnitStock.Text);
                            p.ReorderLevel = Convert.ToInt16(InputRecorderLevel.Text);
                            p.UnitsOnOrder = Convert.ToInt16(InputUnitsorder.Text);
                            p.Discontinued = InputDiscontinued.IsChecked.Value;
                            db.SaveChanges();

                            var result = MessageBox.Show($"Edit successfully! product Id: {p.ProductId}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            if (result==MessageBoxResult.OK)
                            {
                                this.Close();
                                 
                            }


                        }


                       
                    }

                   
                }
                catch (Exception ex)
                {

                   MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK,MessageBoxImage.Error);
                }


            }
        }

        /// <summary>
        /// Para llenar los combobox de los productos desde sql
        /// </summary>
        public void llenacomboboxDeProduct()
        {
            using (NorthwindContext db=new NorthwindContext())
            {


                            var consultSuppplierID = (from Product in db.Products
                                                      join Supplier in db.Suppliers
                                           on Product.SupplierId equals Supplier.SupplierId
                                        select new{ Supplier.CompanyName, Product.SupplierId}).ToList().Distinct();

                
                            foreach (var item in consultSuppplierID)
                            {
                                InputSupplierID.SelectedValue = item.SupplierId;
                    
                                InputSupplierID.Items.Add(item);
                                InputSupplierID.DisplayMemberPath = ("CompanyName");
                                InputSupplierID.SelectedValuePath= ("SupplierId");
                   

                            }


                      var consultCategoriesID = (from Category in db.Categories
                                       join Product in db.Products
                                       on Category.CategoryId equals Product.CategoryId
                               select new { Category.CategoryName,Product.CategoryId}).ToList().Distinct();

                            foreach (var item in consultCategoriesID)
                            {
                                InputCategoriesID.SelectedValue = item.CategoryId;

                                InputCategoriesID.Items.Add(item);
                                InputCategoriesID.DisplayMemberPath = ("CategoryName");
                                InputCategoriesID.SelectedValuePath = ("CategoryId");

                            }


                
                //if (id != null)
                //{
                //    loaddate();
                //}

            }

        }


    }
}
