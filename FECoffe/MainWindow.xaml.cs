using FECoffe.Dashboards;
using FECoffe.DTO.Auth;
using FECoffe.Request.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Windows;
using System.Windows.Input;

namespace FECoffe
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
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //kiem tra co phai nhan nut chuot bang chuot trai hay khong???
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var handler = new JwtSecurityTokenHandler();
            string email = txtUsername.Text;
            string pass= txtPassword.Password;

            AuthAdmin login = new AuthAdmin
            {
                Email = email,
                Password = pass
            };

            
            var result=  AuthAdminRequest.login(login);
            if (result != null && !string.IsNullOrEmpty(result.Token))
            {
                var jwt = handler.ReadJwtToken(result.Token);
                var roleClaim = jwt.Claims.FirstOrDefault(c => c.Type == "role" || c.Type == "roles");

                if (roleClaim != null && roleClaim.Value.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    var app = (App)Application.Current;
                    app.RawToken = result.Token;
                    app.JwtToken = jwt;

                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Close(); // đóng cửa sổ đăng nhập nếu muốn
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập.");
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại.");
            }
        }
    }
}