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
using NorthWind.WpfUi.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace NorthWind.WpfUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
      

        //Para controlar maximizar y minimizar
        bool isvalid = true;
        public MainWindow()
        {
            
            InitializeComponent();

            Getbasedata.LoadSetting();
            Getbasedata.Getconnectiondb();
            
        }

      

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           
        }
        public void Minimized()
        {
            this.WindowState = WindowState.Minimized;

        }
        private void BtnMinimized_Click(object sender, RoutedEventArgs e)
        {
            //for close of windows
            Minimized();
        }
        public void FullScreen()
        {
            //Metodo para poner pantalla completa solo cubra el area de trabajo
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

        }


        private void ListMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Para obtener el indice
            int ValueIndex = ListMenu.SelectedIndex;


            MoveArrowMenu(ValueIndex);

            switch (ValueIndex)
            {
                case 0:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new HomeControl());
                    break;

                case 1:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new ListOrdersControl());
                    break;

                case 2:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new UserControlDesign.UserControlOrder());
                    break;


                case 3:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new UserControlDesign.UserControlCustomers());
                     break;

                case 4:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new UserControlDesign.UserControlProduct());
                    break;


                case 6:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new UserControlDesign.UserControlEmployees());
                    break;

                case 9:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new UserControlRegion());
                    break;
                case 10:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new UserControlTerritory());
                    break;
                case 8:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new UserControlSuppliers());
                    break;
                case 5:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new UserControlDesign.UserControlCategory());
                    break;
                case 7:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new UserControlShippers());
                    break;
                case 11:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new HomeControl());

                    Application.Current.Shutdown();

                    break;
                default:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new HomeControl());
                    break;
            }
        }

        /// <summary>
        /// Metodo para mover la flecha del menu
        /// </summary>
        /// <param name="index"> recibe un int como parametro</param>
        private void MoveArrowMenu(int index)
        {
            TrainsitionOfCOnteent.OnApplyTemplate();
            Arrow.Margin = new Thickness(0, (50 + (70 * index)), 0, 0);
        }

        
        private void Btnsize_Click_1(object sender, RoutedEventArgs e)
        {
            

            switch (isvalid)
            {
                case true:

                    FullScreen();
                    this.WindowState = WindowState.Maximized;
                    isvalid = false;


                    break;

                case false:

                    this.WindowState = WindowState.Normal;
                    isvalid = true;
                    break;
            }

        }
    }
}
