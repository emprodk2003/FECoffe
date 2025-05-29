using FECoffe.DTO.User;
using FECoffe.Form;
using FECoffe.Form.User;
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
            form.Show();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var dsUser = UserRequest.GetUser();
            if (dsUser != null)
            {
                dg_user.ItemsSource = dsUser;
            }
            else MessageBox.Show("Loi khong doc duoc user!!!!!!!");

            var dsRole = RoleRequest.GetRoles();
            if (dsUser != null)
            {
                dg_role.ItemsSource = dsRole;
            }
            else MessageBox.Show("Loi khong doc duoc role!!!!!!!");
        }

        private void Themquyen_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddRole form = new Frm_AddRole();
            form.Show();
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
            }
        }
    }
}
