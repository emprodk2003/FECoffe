using FECoffe.DTO.Positions;
using FECoffe.Request.Positions;
using System.Windows;

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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                var position = new CrudPosition()
                {
                    PositionName = txtPositionName.Text,
                    Description = txtDescription.Text,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                if (PositionsRequest.createPosition(position) == true)
                {
                    MessageBox.Show("Thêm chức vụ mới thành công!");
                    this.DialogResult = true;
                    this.Close();
                }
                else MessageBox.Show("Lỗi khi thêm chức vụ!");
            }
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
