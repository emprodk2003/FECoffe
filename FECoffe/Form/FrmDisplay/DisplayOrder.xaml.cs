using FECoffe.AppUsed;
using FECoffe.DTO.Orders;
using FECoffe.Request.OrderDetails;
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

namespace FECoffe.Form.FrmDisplay
{
    /// <summary>
    /// Interaction logic for DisplayOrder.xaml
    /// </summary>
    public partial class DisplayOrder : Window
    {
        private OrdersViewModel _orders;
        public DisplayOrder(OrdersViewModel orders)
        {
            InitializeComponent();
            _orders = orders;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_OrderDate.Text = _orders.OrderDate.ToString();
            txt_OrderID.Text = _orders.OrderID.ToString();
            txt_TotalProce.Text = _orders.FinalAmount.ToString();
            var list = OrderDetailsRequest.getOrderByBill(_orders.OrderID);
            if (list != null)
            {
                dgOrderDetails.ItemsSource = list;
            }
        }
    }
}
