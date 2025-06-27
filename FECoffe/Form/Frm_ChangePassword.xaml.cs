using FECoffe.DTO.Topping;
using FECoffe.DTO.User;
using FECoffe.Request.Topping;
using FECoffe.Request.User;
using System.Windows;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_ChangePassword.xaml
    /// </summary>
    public partial class Frm_ChangePassword : Window
    {
        private GetUser _user {  get; set; }
        public Frm_ChangePassword(GetUser user)
        {
            InitializeComponent();
            _user = user;   
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpass.Text))
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            else
            {
                var top = new ChangePassword()
                {
                    NewPassword = txtpass.Text,
                };
                if (UserRequest.changePassword(top,_user.ID) == true)
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!");
                    this.Close();
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
