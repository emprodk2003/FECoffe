using FECoffe.DTO.User;
using FECoffe.Request.User;
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
        }



        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            string username= UsernameTextBox.Text;
            string Email= EmailTextBox.Text;
            string pass= PasswordBox.Password;
            string ConfirmPassword= ConfirmPasswordBox.Password;

            var user = new CreateUser
            {
                UserName = username,
                Email= Email,
                Password=pass,
                ConfirmPassword=ConfirmPassword,
            };

            if (UserRequest.createUser(user) == true)
            {
                MessageBox.Show("Tao Thanh Cong User Moi");
            }
            else
                MessageBox.Show("Tao That Bai User Moi");
        }
    }
}
