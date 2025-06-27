using FECoffe.Dashboards;
using FECoffe.DTO.Product;
using FECoffe.DTO.ProductSize;
using FECoffe.DTO.Recipes;
using FECoffe.DTO.Role;
using FECoffe.Request.Ingredients;
using FECoffe.Request.Recipes;
using FECoffe.Request.Role;
using System;
using System.Collections.Generic;
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

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Frm_Update_Role.xaml
    /// </summary>
    public partial class Frm_Update_Role : Window
    {
        private GetListRole _roles;

        public Frm_Update_Role(GetListRole roles)
        {
            InitializeComponent();
            _roles = roles;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (_roles != null)
            {
                txtName.Text = _roles.Name;
                txtDescription.Text = _roles.Description;
            }
        }

        private void Luu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text) == null)
            {
                MessageBox.Show("Không được để trông thông tin!");
                return;
            }
            else
            {
                var role = new CreateRole()
                {
                   RoleName = txtName.Text,
                   Description = txtDescription.Text,
                };
                if (RoleRequest.updateShifts(role,_roles.Id) == true)
                {
                    MessageBox.Show("Cập nhật thông tin thành công .");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại!");
                    this.Close();
                }
            }

        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
