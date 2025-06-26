using FECoffe.Request.Auth;
using FECoffe.Request.Report;
using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json.Linq;
using System.Windows;
using System.Windows.Input;

namespace FECoffe.Dashboards
{
    /// <summary>
    /// Interaction logic for Dashboards.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public SeriesCollection SeriesCollection1 { get; set; }
        public string[] Labels1 { get; set; }
        public Dashboard()
        {
            InitializeComponent();

            //dang nhap thanh cong se co token chua thong tin lien quan cach lay chung nhu sau
            var app = (App)Application.Current;
            var jwt = app.JwtToken;
            string email = app.UserEmail;
            string role = app.UserRole;
            Title = $"Xin chào {email} - ({role})";
            SeriesCollection1 = new SeriesCollection
            {
                 new LineSeries
                  {
                     Title = "Tong so don",
                     Values = new ChartValues<double> { 100, 150, 200, 180, 220, 250 }
                  }
             };

            Labels1 = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6" };
            SeriesCollection = new SeriesCollection
            {
                 new LineSeries
                  {
                     Title = "Doanh thu",
                     Values = new ChartValues<double> { 100, 150, 200, 180, 220, 250 }
                  }
             };

            Labels = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6" };

            DataContext = this;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)//kiem tra co phai nhan nut chuot bang chuot trai hay khong???
            {
                this.DragMove();//nhan chuot de di chuyen khung hinh 
            }
        }
        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) //Khi nhan 2 lan chuot trai thi giao dien se phong max khung hinh
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }
        }

        private void OpenUser_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Show();
            this.Close();
        }

        private void openkho_Click(object sender, RoutedEventArgs e)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.Show();
            this.Close();
        }

        private void openEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Close();
        }

        private void opentProductManager_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var report = ReportRequest.GetByToDay();
            if(report != null)
            {
                txt_Number_employee.Text = report.Number_Employee.ToString() + " nhân viên";
                txt_Number_Order.Text = report.Number_Orders.ToString() + " đơn hàng";
                txt_Report_TotalRevenues.Text = report.TotalRevenue.ToString() +" VND";
            }
        }

        private void opentBusiness_Click(object sender, RoutedEventArgs e)
        {
            var business = new Business();
            business.Show();
            this.Close();
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            var status = AuthAdminRequest.log_out();
            if(status == true)
            {
                ((App)Application.Current).Logout();
                main.Show();
                this.Close();
            }
        }
    }
}
