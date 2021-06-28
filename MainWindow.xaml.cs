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
           
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

            DragMove();
        }

        private void BtnMinimized_Click(object sender, RoutedEventArgs e)
        {
            //for close of windows
            this.WindowState = WindowState.Minimized;
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
                    GridOfUserControl.Children.Add(new OrdersControl());
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

                case 7:
                    GridOfUserControl.Children.Clear();
                    GridOfUserControl.Children.Add(new UserControlShippers());
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
