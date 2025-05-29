using LiveCharts;
using LiveCharts.Wpf;
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
    }
}
