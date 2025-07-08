using FECoffe.DTO.Product;
using FECoffe.DTO.ProductSize;
using FECoffe.DTO.Recipes;
using FECoffe.DTO.Role;
using FECoffe.DTO.User;
using FECoffe.Form;
using FECoffe.Form.FrmUpdate;
using FECoffe.Form.User;
using FECoffe.Request.Recipes;
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

namespace FECoffe.Dashboards
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
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

        private void btn_them_Click(object sender, RoutedEventArgs e)
        {
            CreateUpdateFormUser form = new CreateUpdateFormUser();
            form.ShowDialog();
            loadUser();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadUser();
            loadRole();
        }
        public void loadUser()
        {
            var dsUser = UserRequest.GetUser();
            foreach (var user in dsUser)
            {
                var roles = UserRequest.GetRolesByUserID(user.ID);
                user.roles = roles;
            }
            if (dsUser != null)
            {
                dg_user.ItemsSource = dsUser;
            }
            else MessageBox.Show("Lỗi không đọc được user!!!!!!!");
        }
        public void loadRole()
        {
            var dsRole = RoleRequest.GetRoles();
            if (dsRole != null)
            {
                dg_role.ItemsSource = dsRole;
            }
            else MessageBox.Show("Lỗi không đọc được role!!!!!!!");
        }
        private void Themquyen_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddRole form = new Frm_AddRole();
            form.ShowDialog();
            loadRole();
        }


        private void addrole_Click_1(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            var selectedRole = button.DataContext as GetUser;

            if (selectedRole != null)
            {
                // Truyền dữ liệu sang window mới
                var addrole = new EditUserForm(selectedRole);
                addrole.ShowDialog(); // hoặc Show()
                this.Close();
                loadUser();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var home = new Dashboard();
            home.Show();
            this.Close();
        }

        private void editrole_Click(object sender, RoutedEventArgs e)
        {
            var recipes = dg_role.SelectedItem as GetListRole;
            Frm_Update_Role frm_Update_Role = new Frm_Update_Role(recipes);
            var result = frm_Update_Role.ShowDialog();
            if (result == true)
            {
                loadRole();
            }

        }

        private void deleterole_Click(object sender, RoutedEventArgs e)
        {
            var item = dg_role.SelectedItem as GetListRole;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa quyền này không?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (RoleRequest.deleteRole(item.Id) == true)
                {
                    MessageBox.Show("Đã xóa quyền thành công.");
                    loadRole();
                }
                else MessageBox.Show("Quyền hạn này đã sử lên cho tài khoản");
            }
            else
            {

            }

        }

        private void Doipass_Click(object sender, RoutedEventArgs e)
        {
            var user = dg_user.SelectedItem as GetUser;
            Frm_ChangePassword frm_changepassword = new Frm_ChangePassword(user);
            var result = frm_changepassword.ShowDialog();
            if (result == true)
            {
                loadUser();
            }
        }

        private void editUser_Click(object sender, RoutedEventArgs e)
        {
            var user = dg_user.SelectedItem as GetUser;
            Frm_Update_User frm_updateUser = new Frm_Update_User(user);
            var result = frm_updateUser.ShowDialog();
            if (result == true)
            {
                loadUser();
            }
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            var item = dg_user.SelectedItem as GetUser;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa quyền này không?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (RoleRequest.deleteUser(item.ID) == true)
                {
                    MessageBox.Show("Đã xóa tài khoản thành công thành công.");
                    loadUser();
                }
                else MessageBox.Show("Tài Khoản có quyền hạn nên không thể xóa");
            }
            else
            {

            }
        }
    }
}
