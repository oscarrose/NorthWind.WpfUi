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
            Arrow.Margin = new Thickness(0, (100 + (80 * index)), 0, 0);
        }

       

        
    }
}
