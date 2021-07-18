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
    /// Interaction logic for UserControlTeritory.xaml
    /// </summary>
    public partial class UserControlTerritory : UserControl
    {
        public UserControlTerritory()
        {
            InitializeComponent();
            InputRegionId.SelectionChanged += InputRegionId_SelectionChanged;
            InputterrirtoryDescription.TextChanged += InputterrirtoryDescription_TextChanged;
            this.Loaded += UserControlTerritory_Loaded;
            DataGridTerritory.SelectionChanged += DataGridTerritory_SelectionChanged;
            NewTerritoryButton.Click += NewTerritoryButton_Click;
            DataGridTerritory.SelectionChanged += DataGridTerritory_SelectionChanged1;
            EditTerritoryButton.Click += EditTerritoryButton_Click;
            DeleteTerritoryButton.Click += DeleteTerritoryButton_Click;

        }

        private void DeleteTerritoryButton_Click(object sender, RoutedEventArgs e)
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

                            var EmployeeTerritories = (from et in db.EmployeeTerritories
                                                    join t in db.Territories on et.TerritoryId equals t.TerritoryId
                                                    where et.TerritoryId == getid()
                                                    select et).ToList();


               

                            var ConsultTerritory = (from t in db.Territories
                                                 where t.TerritoryId == id
                                                 select t).Single();

                            var result = MessageBox.Show($"¿Desea eliminar territory: ? {ConsultTerritory.TerritoryId}", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);


                            if (result == MessageBoxResult.Yes)
                            {
                                foreach (var item in EmployeeTerritories)
                                {
                                    db.EmployeeTerritories.Remove(item);
                                }
                             

                                db.Territories.Remove(ConsultTerritory);
                                db.SaveChanges();


                                LoadDataTerritory();
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

        private void EditTerritoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (NorthwindContext db = new NorthwindContext())
                {


                    //edit data
                    Territory t = db.Territories.Find(getid());
                    t.RegionId = Convert.ToInt32(InputRegionId.SelectedValue);
                    t.TerritoryDescription = InputterrirtoryDescription.Text;
                    db.SaveChanges();
                    clearinput();
                    LoadDataTerritory();



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DataGridTerritory_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            string? id = getid();
            llenacomboboxDeRegions();

            if (id != null)
            {
               
                LoadDateEdit();

            }
        }

        private void NewTerritoryButton_Click(object sender, RoutedEventArgs e)
        {
            clearinput();
            llenacomboboxDeRegions();
            EditTerritoryButton.IsEnabled = false;
            DeleteTerritoryButton.IsEnabled = false;
            SaveTerritoryButton.IsEnabled = true;
        }

        private void clearinput()
        {
           
            InputRegionId.Items.Clear();
            InputterrirtoryDescription.Clear();
        }

        private void DataGridTerritory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridTerritory.SelectedCells.Count > 0)
            {
                EditTerritoryButton. IsEnabled = true;
                DeleteTerritoryButton.IsEnabled = true;

            }
            SaveTerritoryButton.IsEnabled = false;
            NewTerritoryButton.IsEnabled = true;
        }

        private void UserControlTerritory_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataTerritory();
            llenacomboboxDeRegions();
            
        }

        private void InputterrirtoryDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            TerritoryDescriptionError.Visibility = Visibility.Visible;
            TerritoryDescriptionError.Text = "";
        }

        private void InputRegionId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RegionIdError.Visibility = Visibility.Visible;
            RegionIdError.Text = "";
            

        }

        private void SaveTerritoryButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputRegionId.Text.Trim()== "Choose region")
            {
                RegionIdError.Text = "The region Id is required";
                RegionIdError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputterrirtoryDescription.Text.Trim().Length == 0)
            {
                TerritoryDescriptionError.Text = "The territory description is required";
                TerritoryDescriptionError.Visibility = Visibility.Visible;
                isvalid = false;
                
            }

            if (isvalid)
            {
                try
                {

                    using (NorthwindContext db = new NorthwindContext())
                    {


                        //agregar data
                        Territory t = new Territory();
                        t.TerritoryId = GenerarIdTerritory();
                        t.RegionId = Convert.ToInt32(InputRegionId.SelectedValue);
                        t.TerritoryDescription = InputterrirtoryDescription.Text;

                        db.Territories.Add(t);
                        db.SaveChanges();
                        clearinput();
                        LoadDataTerritory();

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }


        private void LoadDataTerritory()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                //consulta para mostrar data
                var AllTerritory = from Territory in db.Territories
                                          orderby Territory.TerritoryId ascending
                                          select new
                                           {
                                            Territory.TerritoryId,
                                           Territory.TerritoryDescription,
                                            Territory.RegionId
                                          };



                // mostrando la data
                DataGridTerritory .ItemsSource = AllTerritory.ToList();


            }
        }


        /// <summary>
        /// Para llenar los combobox de los productos desde sql
        /// </summary>
        public void llenacomboboxDeRegions()
        {
            using (NorthwindContext db = new NorthwindContext())
            {


                var consultarTerritory = (from Region in db.Regions
                                          join Territory in db.Regions
                               on Region.RegionId equals Territory.RegionId
                                          select new { Territory.RegionId, Region.RegionDescription}).ToList().Distinct();


                foreach (var item in consultarTerritory)
                {
                    InputRegionId.SelectedValue = item.RegionId;

                    InputRegionId.Items.Add(item);
                    InputRegionId.DisplayMemberPath = ("RegionDescription");
                    InputRegionId.SelectedValuePath = ("RegionId");


                }

            }

        }
        /// <summary>
        /// Genera el id de los territory
        /// </summary>
        /// <returns></returns>
        private string GenerarIdTerritory()
        {
            Random rand = new Random();

            int numero = rand.Next(0,1000);

            string letra = (string) (((string)"01") + numero);
            return letra;


        }

        /// <summary>
        /// Obtener los id del datagrid
        /// </summary>
        /// <returns></returns>
        private string? getid()
        {
            try
            {
                var result = ((dynamic)DataGridTerritory.SelectedItem);
                return result.TerritoryId;

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
                    Territory t = new Territory();

                    t = db.Territories.Find(getid());

                    InputRegionId.SelectedValue = t.RegionId.ToString();
                    InputterrirtoryDescription.Text =t.TerritoryDescription.ToString();


                }
                catch (Exception ex)
                {

                    MessageBox.Show($"unexpected error {ex}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }




            }





        }


    }


}
