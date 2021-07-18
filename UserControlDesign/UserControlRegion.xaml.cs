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
    /// Interaction logic for UserControlRegion.xaml
    /// </summary>
    public partial class UserControlRegion : UserControl

    {
        public UserControlRegion()
        {
            InitializeComponent();

            //Evento de ocultar mensaje de error
            InputRegionDescription.TextChanged += InputRegionDescription_TextChanged;
            this.Loaded += UserControlRegion_Loaded;
            DataGridRegion.SelectionChanged += DataGridRegion_SelectionChanged;
            NewRegionButton.Click += NewRegionButton_Click;
            DataGridRegion.SelectionChanged += DataGridRegion_SelectionChanged1;
            EditRegionButton.Click += EditRegionButton_Click;
            DeleteRegionButton.Click += DeleteRegionButton_Click;
        }

        private void DeleteRegionButton_Click(object sender, RoutedEventArgs e)
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

                            var ConsultTerritory = (from t in db.Territories
                                                     join r in db.Regions on t.RegionId equals r.RegionId
                                                     where t.RegionId == getid()
                                                     select r).ToList();


                            var employeeterritory = (from ep in db.EmployeeTerritories
                                                      join t in db.Territories on ep.TerritoryId equals t.TerritoryId
                                                      where t.RegionId == getid()
                                                      select t).ToList();

                            var ConsultRegion = (from r in db.Regions
                                                   where r.RegionId == id
                                                   select r).Single();

                            var result = MessageBox.Show($"¿Desea eliminar Region: ? {ConsultRegion.RegionId}", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);


                            if (result == MessageBoxResult.Yes)
                            {
                                foreach (var item in ConsultTerritory)
                                {
                                    //db.Territories.Remove(item);
                                }
                                foreach (var item in employeeterritory)
                                {
                                    //db.EmployeeTerritories.Remove(item);

                                }
                               
                                db.Regions.Remove(ConsultRegion);
                                db.SaveChanges();


                                LoadRegions();
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

        private void DataGridRegion_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            int? id = getid();

            if (id != null)
            {

                LoadDateEdit();

            }
        }

        private void NewRegionButton_Click(object sender, RoutedEventArgs e)
        {
            clearinput();
            EditRegionButton.IsEnabled = false;
            DeleteRegionButton.IsEnabled = false;
            SaveRegionButton.IsEnabled = true;
        }

        private void clearinput()
        {
            InputRegionDescription.Clear();
        }

        private void DataGridRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridRegion.SelectedCells.Count > 0)
            {
                EditRegionButton.IsEnabled = true;
                DeleteRegionButton.IsEnabled = true;

            }
            SaveRegionButton.IsEnabled = false;
            NewRegionButton.IsEnabled = true;
        }

        private void UserControlRegion_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRegions();
        }

        private void InputRegionDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegionDescriptionError.Visibility = Visibility.Collapsed;



        }

        private void SaveRegionButton_Click(object sender, RoutedEventArgs e)
        {
            var isvalid = true;

            if (InputRegionDescription.Text.Trim().Length == 0)
            {
                RegionDescriptionError.Text = "The region description Id is required";
                RegionDescriptionError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (isvalid)
            {
                try
                {

                    using (NorthwindContext db = new NorthwindContext())
                    { 
                        

                        //agregar data
                        Region r = new Region();
                        r.RegionDescription = InputRegionDescription.Text.ToString();
                        r.RegionId = GetRegionID();

                        db.Regions.Add(r);
                         db.SaveChanges();
                        clearinput();
                        LoadRegions();
                            

                        
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }

        private void EditRegionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (NorthwindContext db = new NorthwindContext())
                {


                    //edit data
                    Region r = db.Regions.Find(getid());
                    r.RegionDescription = InputRegionDescription.Text.ToString();
                  
                    db.SaveChanges();
                    clearinput();
                    LoadRegions();



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LoadRegions()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                //consulta para mostrar data
                var AllRegions = from Region in db.Regions
                                      
                                  select new
                                  {
                                     Region.RegionId,
                                     Region.RegionDescription

                                  };
                // mostrando la data
                DataGridRegion.ItemsSource = AllRegions.ToList();


            }


        }
       /// <summary>
       /// obtener id de los datos
       /// </summary>
       /// <returns></returns>
        private int? getid()
        {
            try
            {
                var result = ((dynamic)DataGridRegion.SelectedItem);
                return result.RegionId;

            }
            catch
            {
                return null;

            }
        }
        /// <summary>
        /// Genera un numero entre 10 y 1001
        /// </summary>
        /// <returns></returns>
        private int GetRegionID()
        {
           
            Random random = new Random();
            var RegionID = random.Next(10, 1001);
            return RegionID;


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
                    Region r = new Region();

                    r = db.Regions.Find(getid());

                   InputRegionDescription.Text = r.RegionDescription.ToString();
                  

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"unexpected error {ex}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }




            }



        }




    }

}
