using FECoffe.DTO.Employee;
using FECoffe.DTO.ProductSize;
using FECoffe.DTO.User;
using FECoffe.Request.Employee;
using FECoffe.Request.User;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace FECoffe.Form.User
{
    /// <summary>
    /// Interaction logic for CreateUpdateFormUser.xaml
    /// </summary>
    public partial class CreateUpdateFormUser : Window
    {
        public static RoutedCommand RegisterCommand = new RoutedCommand();
        public CreateUpdateFormUser()
        {
            InitializeComponent();
            loadEmployess();
        }

        public void loadEmployess()
        {
            var list = EmployeeRequest.GetAllEmloyee();
            if (list != null)
            {
                cbEmployess.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu cho employss");
            }
        }
        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var email = EmailTextBox.Text;
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) || string.IsNullOrWhiteSpace(EmailTextBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Password) == null || string.IsNullOrWhiteSpace(ConfirmPasswordBox.Password) == null)
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin.");
                return;
            }

            else if (Regex.IsMatch(email, pattern) == false)
            {
                MessageBox.Show("Email sai định dạng /n Định dạng chuẩn xxx@gmail.com");
                return;
            }
            else if (string.IsNullOrWhiteSpace(PasswordBox.Password) == null)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(ConfirmPasswordBox.Password) == null)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu xác nhận.");
                return;
            }
            else if (cbEmployess.SelectedItem is EmployeeViewModel selectedEmployss)
            {
                string username = UsernameTextBox.Text;
                string Email = EmailTextBox.Text;
                string pass = PasswordBox.Password;
                string ConfirmPassword = ConfirmPasswordBox.Password;

                var user = new CreateUser
                {
                    UserName = username,
                    Email = Email,
                    Password = pass,
                    EmployeeID = selectedEmployss.EmployeeID,
                    ConfirmPassword = ConfirmPassword,
                };

                if (UserRequest.createUser(user) == true)
                {
                    MessageBox.Show("Thêm tài khoản mới thành công.");
                    this.Close();
                }
                else
                    MessageBox.Show("Lỗi khi thêm tài khoản mới!");
            }
            else
            {
                MessageBox.Show("Chưa chọn employess");
            } 
        }

    }
}
