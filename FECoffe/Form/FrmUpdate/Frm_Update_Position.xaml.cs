using FECoffe.DTO.Positions;
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

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Frm_Update_Position.xaml
    /// </summary>
    public partial class Frm_Update_Position : Window
    {
        private PositionsViewModel _positions;
        public Frm_Update_Position(PositionsViewModel positions)
        {
            InitializeComponent();
            _positions = positions;
        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPositionName.Text))
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            else
            {
                var ps = new PositionsViewModel()
                {
                    PositionID = _positions.PositionID,
                    PositionName = txtPositionName.Text,
                    Description = txtDescription.Text,
                    UpdatedAt = DateTime.Now,
                };
                if(PositionsRequest.updatePosition(ps) == true)
                {
                    MessageBox.Show("Sua thong tin chuc vu thanh cong!");
                    this.DialogResult = true;
                    this.Close();
                }
                else MessageBox.Show("Loi khi sua thong tin chuc vu !");
            }
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_positions != null)
            {
                txtPositionName.Text = _positions.PositionName;
                txtDescription.Text = _positions.Description;
            }
        }
    }
}
