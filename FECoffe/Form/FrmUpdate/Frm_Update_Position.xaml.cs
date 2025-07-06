using FECoffe.DTO.Positions;
using FECoffe.Request.Positions;
using System.Windows;

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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
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
                    MessageBox.Show("Sửa thông tin chức vụ thành công.");
                    this.DialogResult = true;
                    this.Close();
                }
                else MessageBox.Show("Lỗi khi sửa thông tin chức vụ!");
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
