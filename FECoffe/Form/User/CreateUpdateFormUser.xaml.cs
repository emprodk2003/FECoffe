using FECoffe.DTO.Employee;
using FECoffe.DTO.ProductSize;
using FECoffe.DTO.User;
using FECoffe.Request.Employee;
using FECoffe.Request.User;
using System.Drawing;
using System.Windows;
using System.Windows.Input;

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
                MessageBox.Show("Khoong co du lieu employss");
            }
        }
        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            if (cbEmployess.SelectedItem is EmployeeViewModel selectedEmployss)
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
                    EmployeeID=selectedEmployss.EmployeeID,
                    ConfirmPassword = ConfirmPassword,
                };

                if (UserRequest.createUser(user) == true)
                {
                    MessageBox.Show("Tao Thanh Cong User Moi");
                    this.Close();
                }
                else
                    MessageBox.Show("Tao That Bai User Moi");
            }
            else
            {
                MessageBox.Show("Chua chon employess");
            }
               
        }

    }
}
