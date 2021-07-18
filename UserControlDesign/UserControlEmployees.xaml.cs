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
    /// Interaction logic for UserControlEmployees.xaml
    /// </summary>
    public partial class UserControlEmployees : UserControl
    {
        public UserControlEmployees()
        {
            InitializeComponent();
            this.Loaded += UserControlEmployees_Loaded;
            DeleteEmployeeButton.Click += DeleteEmployeeButton_Click;
            NewEmployeeButton.Click += NewEmployeeButton_Click;
            EditEmployeeButton.Click += EditEmployeeButton_Click;
                
           
        }

        private void EditEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            int? id = getid();

            if (id != null)
            {

                var ModalEmployee = new ModalEmployees(id);
                ModalEmployee.TitleEmployee.Text = "Update employees";

                var result = ModalEmployee.ShowDialog();

            }
            LoadDataEmployees();
        }

        private void NewEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

            if (true)
            {

                var ModalEmployee = new ModalEmployees();


                var result = ModalEmployee.ShowDialog();
            }
            LoadDataEmployees();
        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
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

                            var DetailConEmployee = (from y in db.Employees
                                                     join o in db.Orders on y.EmployeeId equals o.EmployeeId
                                                     join od in db.OrderDetails on o.OrderId equals od.OrderId
                                                     where y.EmployeeId == getid()
                                                     select od).ToList();


                            var orderConEmployees= (from y in db.Employees
                                                    join o in db.Orders on y.EmployeeId equals o.EmployeeId
                                                    where y.EmployeeId == getid()
                                                    select o).ToList();

                            var territoryEmployee = (from y in db.Employees
                                                     join te in db.EmployeeTerritories on y.EmployeeId equals te.EmployeeId
                                                     where y.EmployeeId == getid()
                                                     select te).ToList();


                            var ConsultEmployee = (from x in db.Employees
                                                   where x.EmployeeId == id
                                                   select x).Single();

                            var result = MessageBox.Show($"¿Desea eliminar EmployeeId: ? {ConsultEmployee.EmployeeId}", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information);


                            if (result == MessageBoxResult.Yes)
                            {
                                foreach (var item in DetailConEmployee)
                                {
                                    db.OrderDetails.Remove(item);
                                }
                                foreach (var item in orderConEmployees)
                                {
                                    db.Orders.Remove(item);

                                }
                                foreach (var item in territoryEmployee)
                                {
                                    db.EmployeeTerritories.Remove(item);

                                }

                                db.Employees.Remove(ConsultEmployee);
                                db.SaveChanges();


                                LoadDataEmployees();
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

        private void UserControlEmployees_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataEmployees();
        }

   

        public void LoadDataEmployees()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                //consulta para mostrar data
                var AllEmployees = from Employee in db.Employees
                                   select new
                                   {
                                       Employee.EmployeeId,
                                       Employee.LastName,
                                       Employee.FirstName,
                                       Employee.Title,
                                       Employee.TitleOfCourtesy,
                                       Employee.BirthDate,
                                       Employee.HireDate,
                                       Employee.Address,
                                       Employee.City,
                                       Employee.Region,
                                       Employee.PostalCode,
                                       Employee.Country,
                                       Employee.HomePhone,
                                       Employee.Extension,
                                       Employee.Photo,
                                       Employee.Notes,
                                       Employee.ReportsTo,

                                      Employee.PhotoPath

                

                                   };

                                
                // mostrando la data
                DataGridEmployees.ItemsSource = AllEmployees.ToList();


            }
        }

        /// <summary>
        /// obtener id del employees
        /// </summary>
        /// <returns></returns>
        private int? getid()
        {
            try
            {
                var result = ((dynamic)DataGridEmployees.SelectedItem);
                return result.EmployeeId;

            }
            catch
            {
                return null;

            }
        }

       
    }
}
