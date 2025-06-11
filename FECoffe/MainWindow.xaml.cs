using FECoffe.AppUsed;
using FECoffe.Dashboards;
using FECoffe.DTO.Auth;
using FECoffe.Request.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            btnLogin.IsEnabled = false;
            btnText.Text = "Loading...";
            await Task.Delay(2);
            var handler = new JwtSecurityTokenHandler();
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            string email = txtUsername.Text;
            string pass = txtPassword.Password;
            var resultAuth = new AuthAdmin();
            if (Regex.IsMatch(email, pattern))
            {
                AuthAdmin login = new AuthAdmin
                {
                    Email = email,
                    UserName="",
                    Password = pass
                };
                resultAuth=login;
                btnText.Text = "Login";
                btnLogin.IsEnabled = true;
            }
            else
            {
                AuthAdmin login = new AuthAdmin
                {
                    Email="",
                    UserName = email,
                    Password = pass
                };
                resultAuth = login;
                btnText.Text = "Login";
                btnLogin.IsEnabled = true;
            }

            var result = AuthAdminRequest.login(resultAuth);
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

                if (roleClaim != null && roleClaim.Value.Equals("User", StringComparison.OrdinalIgnoreCase))
                {
                    var app = (App)Application.Current;
                    app.RawToken = result.Token;
                    app.JwtToken = jwt;

                    TheBagNumber dashboard = new TheBagNumber();
                    dashboard.Show();
                    this.Close(); // đóng cửa sổ đăng nhập nếu muốn
                }

            }
            else
            {
                btnText.Text = "Login";
                btnLogin.IsEnabled = true;
                MessageBox.Show("Đăng nhập thất bại.");

            }
        }
    }
}