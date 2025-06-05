using FECoffe.Dashboards;
using FECoffe.DTO.Employee;
using FECoffe.DTO.Positions;
using FECoffe.Request.Employee;
using FECoffe.Request.Positions;
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
    /// Interaction logic for Frm_AddPosition.xaml
    /// </summary>
    public partial class Frm_AddPosition : Window
    {
        public Frm_AddPosition()
        {
            InitializeComponent();
        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPositionName.Text))
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            else
            {
                var app = (App)Application.Current;
                var position = new CrudPosition()
                {
                    PositionName = txtPositionName.Text,
                    Description = txtDescription.Text,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserID = Guid.Parse(app.IdUser),
                };
                if (PositionsRequest.createPosition(position) == true)
                {
                    MessageBox.Show("Them chuc vu moi thanh cong!");
                    this.Close();
                }
                else MessageBox.Show("Loi khi them chuc vu moi !");
            }
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
