using FECoffe.DTO.Role;
using FECoffe.DTO.User;
using FECoffe.Request.Role;
using FECoffe.Request.User;
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

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddRole.xaml
    /// </summary>
    public partial class Frm_AddRole : Window
    {
        public Frm_AddRole()
        {
            InitializeComponent();
        }

        private void Luu_Click(object sender, RoutedEventArgs e)
        {
           
            string name = txtName.Text;
            string description = txtDescription.Text;

            var role = new CreateRole
            {
                RoleName = name,
                Description = description,
            };

            if (RoleRequest.createRole(role) == true)
            {
                MessageBox.Show("Tao Thanh Cong User Moi");
            }
            else
                MessageBox.Show("Tao That Bai User Moi");
        
        }
    }
}
