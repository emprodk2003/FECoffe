using FECoffe.Dashboards;
using FECoffe.DTO.Role;
using FECoffe.DTO.User;
using FECoffe.Request.Role;
using FECoffe.Request.User;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace FECoffe.Form.User
{
    /// <summary>
    /// Interaction logic for EditUserForm.xaml
    /// </summary>
    public partial class EditUserForm : Window
    {
        public GetUser _user {  get; set; }
        Guid userid;
        public EditUserForm(GetUser user)
        {
            InitializeComponent();
            _user = user;
            // Gán dữ liệu lên UI
            txtName.Text = _user.username;
            userid=_user.ID;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var role = RoleRequest.GetRoles();
            if (role != null)
            {
                cbRole.ItemsSource = role;
            }
        }
        private void luu_Click(object sender, RoutedEventArgs e)
        {

                var selectedRole = cbRole.SelectedItem as GetListRole;

            var addRole = new UpdateUser
            {
                userID= userid,
                roleID=selectedRole.Id
            };

            if (UserRequest.AddRolebyUser(addRole) == true)
            {
                MessageBox.Show("Tao Thanh Cong role cho user ");
                this.Close();
            }
            else
                MessageBox.Show("Tao That Bai role cho user");
        }
    }
}
