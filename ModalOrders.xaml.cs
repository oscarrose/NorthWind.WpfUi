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
    /// Interaction logic for ModalOrders.xaml
    /// </summary>
    public partial class ModalOrders : Window
    {
        public ModalOrders()
        {
            InitializeComponent();
            InputCustomerId.SelectionChanged += InputCustomerId_SelectionChanged;
            InputEmployeeId.SelectionChanged += InputEmployeeId_SelectionChanged;
            InputRequiredDate.SelectedDateChanged += InputRequiredDate_SelectedDateChanged;
            InputShippedDate.SelectedDateChanged += InputShippedDate_SelectedDateChanged;
            InputProduct.SelectionChanged += InputProduct_SelectionChanged;
            inputQuantity.TextChanged += InputQuantity_TextChanged;
            inputDiscount.TextChanged += InputDiscount_TextChanged;
            this.Loaded += ModalOrders_Loaded;
            AddProductButton.Click += AddProductButton_Click1;
            InputProduct.SelectionChanged += InputProduct_SelectionChanged1;

            //los demas estan de forma automatica desde la ventana de evento de los controles



        }

        private void InputProduct_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            using (NorthwindContext db =new NorthwindContext())
            {

                var ConsultPrecio = (from x in db.OrderDetails
                                       join y in db.Products
                                       on x.ProductId equals y.ProductId
                                       select new { x.ProductId, y.UnitPrice }).ToList().Distinct();

                foreach (var item in ConsultPrecio)
                {
        
                    decimal? precios = (decimal)item.UnitPrice;

                }



            }


        }

        private void AddProductButton_Click1(object sender, RoutedEventArgs e)
        {
            ItemsOrderDatail();

            //generate_columns();
        }

        private void ModalOrders_Loaded(object sender, RoutedEventArgs e)
        {
            llenacomboboxDeOrder();

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveOrderButton_Click(object sender, RoutedEventArgs e)
        {

            var isvalid = true;

            if (InputCustomerId.SelectedIndex == 0 && InputCustomerId.Text.Trim().Length == 0)
            {
                CustomerIdError.Text = "The customer Id is required";
                CustomerIdError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputEmployeeId.SelectedIndex == 0 && InputEmployeeId.Text.Trim().Length == 0)
            {
                EmployeesError.Text = "The employee id is required";
                EmployeesError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputOrderDate.Text.Trim().Length == 0)
            {
                OrderDateError.Text = "The order date is required";
                OrderDateError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputRequiredDate.Text.Trim().Length == 0)
            {
                RequiredDateError.Text = "The required date is required";
                RequiredDateError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputShippedDate.Text.Trim().Length == 0)
            {
                ShippedDateError.Text = "The shipped date is required";
                ShippedDateError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputShipVia.Text.Trim().Length == 0)
            {
                ShipViaError.Text = "The Ship via is required";
                ShipViaError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputFreight.Text.Trim().Length == 0)
            {
                FreightError.Text = "The freight is required";
                FreightError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputShipName.Text.Trim().Length == 0)
            {
                ShipNameError.Text = "The ship name is required";
                ShipNameError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (inputShipAddress.Text.Trim().Length == 0)
            {
                ShipAddressError.Text = "The address is required";
                ShipAddressError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (InputShipCity.Text.Trim().Length == 0)
            {
                ShipCityError.Text = "The ship city is required";
                ShipCityError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (InputShipRegion.Text.Trim().Length == 0)
            {
                ShipRegionError.Text = "The ship region is required";
                ShipRegionError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (Inputzip.Text.Trim().Length == 0)
            {
                ShipZipError.Text = "The ship postal code is required";
                ShipZipError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (inputShipCountry.Text.Trim().Length == 0)
            {
                ShipCountryError.Text = "The ship country is required";
                ShipCountryError.Visibility = Visibility.Visible;
                isvalid = false;
            }


            if (isvalid)
            {
                try
                {
                    using (NorthwindContext db =new NorthwindContext())
                    {

                        using (var DbContextTransicion=db.Database.BeginTransaction())
                        {

                            try
                            {
                                Order DataOrder = new Order();
                                DataOrder.OrderId = generarId();
                                DataOrder.CustomerId = InputCustomerId.SelectedValue.ToString();
                                DataOrder.EmployeeId = Convert.ToInt32(InputEmployeeId.SelectedValue);
                                DataOrder.OrderDate = InputOrderDate.SelectedDate;
                                DataOrder.RequiredDate = InputRequiredDate.SelectedDate;
                                DataOrder.ShippedDate = InputShippedDate.SelectedDate;
                                DataOrder.ShipVia = Convert.ToInt32(InputShipVia.Text);
                                DataOrder.Freight = Convert.ToDecimal(InputFreight.Text);
                                DataOrder.ShipName = InputShipName.Text;
                                DataOrder.ShipAddress = inputShipAddress.Text;
                                DataOrder.ShipCity = InputShipCity.Text;
                                DataOrder.ShipRegion = InputShipRegion.Text;
                                DataOrder.ShipPostalCode = Inputzip.Text;
                                DataOrder.ShipCountry = inputShipCountry.Text;

                                db.Orders.Add(DataOrder);
                                int orderid = Convert.ToInt32( DataOrder.OrderId);

                                //OrderDetail dtadatail = new OrderDetail();
                                //dtadatail.OrderId = orderid;
                                //dtadatail.


                                DbContextTransicion.Commit();

                                //foreach (var item in DataOrder.OrderDetails)
                                //{
                                //    item.OrderId = orderid;

                                //}
                                //db.OrderDetails.Add(dtadatail);
                                //var dt = db.OrderDetails
                                //  .OrderBy(b => b.UnitPrice)
                                //   .ToList();
                                //   

                                //DataOrder.OrderDetails = DataOrder.OrderDetails.Select(od => new OrderDetail
                                //{
                                //    OrderId=orderid,
                                //    Quantity = od.Quantity,
                                //    UnitPrice = od.UnitPrice,
                                //    Discount = (float)od.Discount
                                //}).ToList();




                            }
                            catch (Exception)

                            {
                              

                                DbContextTransicion.RollbackToSavepoint("Unexpected error in the data");

                             
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

        private void InputEmployeeId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeesError.Visibility = Visibility.Collapsed;
        }

        private void InputCustomerId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomerIdError.Visibility = Visibility.Collapsed;
        }
        private void inputShipAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipAddressError.Visibility = Visibility.Collapsed;
            ShipAddressError.Text = "";
        }

        private void InputShipName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipNameError.Visibility = Visibility.Collapsed;
            ShipNameError.Text = "";
        }
        private void InputFreight_TextChanged(object sender, TextChangedEventArgs e)
        {
            FreightError.Visibility = Visibility.Collapsed;
            FreightError.Text = "";
        }
        private void InputShipVia_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipViaError.Visibility = Visibility.Collapsed;
            ShipViaError.Text = "";
        }

        private void inputShipCountry_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipCountryError.Visibility = Visibility.Collapsed;
            ShipCountryError.Text = "";
        }

        private void Inputzip_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipZipError.Visibility = Visibility.Collapsed;
            ShipZipError.Text = "";
        }
        private void InputShipRegion_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipRegionError.Visibility = Visibility.Collapsed;
            ShipRegionError.Text = "";
        }
        private void InputShipCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShipCityError.Visibility = Visibility.Collapsed;
            ShipCityError.Text = "";
        }

        private void InputRequiredDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RequiredDateError.Visibility = Visibility.Collapsed;
            RequiredDateError.Text = "";

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderDateError.Visibility = Visibility.Collapsed;
            OrderDateError.Text = "";

        }

        private void InputShippedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ShippedDateError.Visibility = Visibility.Collapsed;
            ShippedDateError.Text = "";
        }

        private void InputProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductError.Visibility = Visibility.Collapsed;
            ProductError.Text = "";
        }

        private void InputQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {

            QuantityError.Visibility = Visibility.Collapsed;
            QuantityError.Text = "";
        }

        private void InputDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            DiscountError.Visibility = Visibility.Collapsed;
            DiscountError.Text = "";
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            //CreateOrderDetailItem();
            var isvalid = true;

            if (InputProduct.SelectedIndex == 0 && InputProduct.SelectedItem.ToString().Trim().Length == 0)
            {
                ProductError.Text = "The product is required";
                ProductError.Visibility = Visibility.Visible;
                isvalid = false;
            }

            if (inputQuantity.Text.Trim().Length == 0)
            {
                QuantityError.Text = "The quantity is reqired";
                QuantityError.Visibility = Visibility.Visible;
                isvalid = false;

            }


            if (inputDiscount.Text.Trim().Length == 0)
            {
                DiscountError.Text = "The discount is reqired";
                DiscountError.Visibility = Visibility.Visible;
                isvalid = false;

            }
            if (isvalid)
            {
                //add product
            }
        }

        /// <summary>
        /// Llenar los comboxbox a utilizar
        /// </summary>
        public void llenacomboboxDeOrder()
        {
            using (NorthwindContext db = new NorthwindContext())
            {


                var ConsultCustomerId = (from x in db.Orders
                                         join y in db.Customers
                              on x.CustomerId equals y.CustomerId
                                         select new { x.CustomerId, y.CompanyName }).ToList().Distinct();


                foreach (var item in ConsultCustomerId)
                {
                    InputCustomerId.SelectedValue = item.CustomerId;

                    InputCustomerId.Items.Add(item);
                    InputCustomerId.DisplayMemberPath = ("CompanyName");
                    InputCustomerId.SelectedValuePath = ("CustomerId");


                }


                var ConsultEmployeeId = (from x in db.Orders
                                         join y in db.Employees
                                         on x.EmployeeId equals y.EmployeeId
                                         select new { x.EmployeeId, NameCompleto = y.LastName + " " + y.FirstName }).ToList().Distinct();

                foreach (var item in ConsultEmployeeId)
                {
                    InputEmployeeId.SelectedValue = item.EmployeeId;

                    InputEmployeeId.Items.Add(item);
                    InputEmployeeId.DisplayMemberPath = ("NameCompleto");
                    InputEmployeeId.SelectedValuePath = ("EmployeeId");

                }

                var ConsultPrductId = (from x in db.OrderDetails
                                       join y in db.Products
                                       on x.ProductId equals y.ProductId
                                       select new { x.ProductId, y.ProductName,y.UnitPrice }).ToList().Distinct();

                foreach (var item in ConsultPrductId)
                {
                    InputProduct.SelectedValue = item.ProductId;

                    InputProduct.Items.Add(item);
                    InputProduct.DisplayMemberPath = ("ProductName");
                    InputProduct.SelectedValuePath = ("ProductId");
                    

                }

                

                //if (id != null)
                //{
                //    loaddate();
                //}

            }

        }
        /// <summary>
        /// get Precio del producto seleccionado
        /// </summary>
        /// <returns></returns>
        private decimal? getprecio()
        {
            try
            {
                using (NorthwindContext db =new NorthwindContext())
                {
                    int getvalue = (int)InputProduct.SelectedValue;

                    var result = (from x in db.OrderDetails
                                  where x.ProductId == getvalue
                                  select x.UnitPrice).Distinct().FirstOrDefault();
                    return Convert.ToDecimal( result);
                }

            }
            catch
            {
                return null;

            }
        }

        public decimal Amount { get; set; }
        /// <summary>
        /// para agregar los valores de el datail
        /// </summary>
        private void ItemsOrderDatail()
        {
         
            using (NorthwindContext db = new NorthwindContext())
            {
                List<OrderDetail> details = new List<OrderDetail>();
                details.Add(new OrderDetail
                {
                    ProductId = Convert.ToInt32(InputProduct.SelectedValue),
                    Quantity = Convert.ToInt16(inputQuantity.Text),
                    Discount = float.Parse((inputDiscount.Text)),
                    UnitPrice = (decimal)getprecio(),

                    //Amount = (decimal)getamount()

                });

                DataGridOrderDatail.Items.Add(details);
               
            }





        }
        /// <summary>
        /// obtener calculos de amount
        /// </summary>
        private decimal? getamount()
        {
            try
            {

                decimal GetAmount = (decimal)getprecio() * Convert.ToDecimal(inputQuantity.Text);
                if (Convert.ToDouble(inputDiscount.Text )== 0)
                {

                    
                    return GetAmount;

                }
                else
                {
                    decimal Getdiscoun = ((Convert.ToDecimal(inputDiscount.Text)/ 100) * GetAmount);
                    return GetAmount=GetAmount - Getdiscoun;

                }
            }
            catch (Exception)
            {

                return 0;
            }
            
        }

        public void InsertDetail(NorthwindContext db, OrderDetail item)
        {
            //using ( NorthwindContext db=new NorthwindContext())
            //{
             

            //    InsertDetail(db, null, item);
            //}
        }

        private int generarId()
        {

            Random random = new Random();
            var ID = random.Next(100, 10001);
            return ID;


        }




    }

}
