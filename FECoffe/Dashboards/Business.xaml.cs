using FECoffe.DTO.Orders;
using FECoffe.Form.FrmDisplay;
using FECoffe.Request.Orders;
using FECoffe.Request.Report;
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

namespace FECoffe.Dashboards
{
    /// <summary>
    /// Interaction logic for Business.xaml
    /// </summary>
    public partial class Business : Window
    {
        public Business()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var time = dp_start.SelectedDate.Value;
            var order = OrderRequest.getAll(time);
            if(order != null)
            {
                dg_Orders.ItemsSource = order;
            }
            var report = ReportRequest.GetByToMonth();
            if(report != null)
            {
                txt_NumberEmployee.Text = report.Number_Employee.ToString();
                txt_NumberOrders.Text = report.Number_Orders.ToString();
                txt_totalprice.Text = report.TotalRevenue.ToString();
                var product = report.Products;
                if(product != null)
                {
                    dgReport.ItemsSource = product;
                }
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            var dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void GetOrderDetail_Click(object sender, MouseButtonEventArgs e)
        {
            var or = dg_Orders.SelectedItem as OrdersViewModel;
            var detail = new DisplayOrder(or);
            detail.ShowDialog();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if(dp_end.SelectedDate == null || dp_start.SelectedDate == null)
            {
                MessageBox.Show("Vui long chon moc thoi gian tim kiem");
            }
            else
            {
                var start = dp_start.SelectedDate.Value;
                var end = dp_end.SelectedDate.Value;
                var list = OrderRequest.getOrderByDate(start, end);
                dg_Orders.ItemsSource = list;
            }
        }

        private void FindReport_Click(object sender, RoutedEventArgs e)
        {
            if(dp_startreport.SelectedDate == null || dp_endReport.SelectedDate == null)
            {
                MessageBox.Show("Vui long chon moc thoi gian tim kiem");
            }
            else
            {
                var start = dp_startreport.SelectedDate.Value;
                var end = dp_endReport.SelectedDate.Value;
                var report = ReportRequest.GetByDate(start, end);
                if(report != null)
                {
                    txt_NumberEmployee.Text = report.Number_Employee.ToString();
                    txt_NumberOrders.Text = report.Number_Orders.ToString();
                    txt_totalprice.Text = report.TotalRevenue.ToString();
                    var product = report.Products;
                    if (product != null)
                    {
                        dgReport.ItemsSource = product;
                    }
                }
            }
        }
    }
}
