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
    /// Interaction logic for ModalCategory.xaml
    /// </summary>
    /// 
    public partial class ModalCategory : Window
    {
        public int? id;
        Category c= null;
        public ModalCategory(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            InputCompanyName.TextChanged += InputCompanyName_TextChanged;
            InputDescription.TextChanged += InputDescription_TextChanged;
            this.Loaded += ModalCategory_Loaded;


            
          
           
        }

        /// <summary>
        /// Para buscar los id y cargar los datos en los componentes para editar
        /// </summary>
        private void loaddata()
        {
            using (NorthwindContext db = new NorthwindContext())
            {

                try
                {
                   

                    c= db.Categories.Find(id);
                    InputCompanyName.Text = c.CategoryName.ToString();
                    InputDescription.Text = c.Description.ToString();


                }
                catch (Exception ex)
                {

                    MessageBox.Show($"unexpected error {ex}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }




            }



        }
        private void ModalCategory_Loaded(object sender, RoutedEventArgs e)
        {
            if (id != null)
            {
                loaddata();
            }
        }

        private void InputDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            DescriptionError.Visibility = Visibility.Collapsed;
            DescriptionError.Text = "";
        }

        private void InputCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CompanyNameError.Visibility = Visibility.Collapsed;
            CompanyNameError.Text = "";
        }

        private void Image_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
         

        }

        private void SaveCategoriesButton_Click(object sender, RoutedEventArgs e)
        {

            var isvalid = true;

            if (InputCompanyName.Text.Trim().Length == 0)
            {
                CompanyNameError.Text = "Company name is required";
                CompanyNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputDescription.Text.Trim().Length == 0)
            {
                DescriptionError.Text = "The description is required";
                DescriptionError.Visibility = Visibility.Visible;
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
                            Category c = new Category();
                            c.CategoryName = InputCompanyName.Text;
                            c.Description = InputDescription.Text;


                            db.Categories.Add(c);
                            db.SaveChanges();
                            var result = MessageBox.Show($"Saved successfully! Categories: {c.CategoryName}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            if (result == MessageBoxResult.OK)
                            {

                                clearinput();


                            }

                        }
                        if (id!= null)
                        {
                            //editar data
                            
                           Category c = db.Categories.Find(id);

                                
                          c.CategoryName = InputCompanyName.Text;
                           c.Description = InputDescription.Text;

                           db.SaveChanges();
                
                           var result = MessageBox.Show($"Edit successfully! categories Id: {c.CategoryId}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                         
                            if (result==MessageBoxResult.OK)
                            {
                                this.Close();

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

        /// <summary>
        /// Para limpiar los input
        /// </summary>
        private void clearinput() {
            InputDescription.Clear();
            InputCompanyName.Clear();
        }


    }

}
