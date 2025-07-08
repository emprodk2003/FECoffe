using FECoffe.Dashboards;
using FECoffe.DTO.User;
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

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Frm_Update_User.xaml
    /// </summary>
    public partial class Frm_Update_User : Window
    {
        private GetUser _user { get; set; }
        public Frm_Update_User(GetUser user)
        {
            InitializeComponent();
            _user = user;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            var resutl = new IsActionUser()
            {
                IsAction = chkIsWorking.IsChecked.Value,
            };
            if (UserRequest.updateUser(_user.ID, resutl) == true)
            {
                MessageBox.Show("Cập nhật trạng thái thành công");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái thất bại!");
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
