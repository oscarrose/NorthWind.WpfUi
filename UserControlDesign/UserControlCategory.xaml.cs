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
        }

        private void NewCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            //Para llamar al modelAddCategory

            var ModalCategorys = new ModalCategory();
            var result = ModalCategorys.ShowDialog();



        }
    }
}
