using FECoffe.DTO.Role;
using FECoffe.Request.Role;
using System.Windows;

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
                MessageBox.Show("Tạo thành công quyền mới");
            }
            else
                MessageBox.Show("Tao quyền thất bại!");
        
        }
    }
}
