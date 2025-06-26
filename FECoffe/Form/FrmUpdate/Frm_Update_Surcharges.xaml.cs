using FECoffe.DTO.Surcharges;
using FECoffe.Request.Surcharges;
using System.Windows;

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Frm_Update_Surcharges.xaml
    /// </summary>
    public partial class Frm_Update_Surcharges : Window
    {
        private SurchargesViewModel _surcharges;
        public Frm_Update_Surcharges(SurchargesViewModel surcharges)
        {
            InitializeComponent();
            _surcharges = surcharges;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_surcharges != null)
            {
                txtName.Text = _surcharges.SurchargesName;
                txtValue.Text = _surcharges.SurchargesValue.ToString();
                dp_end.SelectedDate = _surcharges.EndDate;
                dp_start.SelectedDate = _surcharges.StartDate;
            }
        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtValue.Text) || dp_end.SelectedDate == null || dp_start.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng không được để trống thông tin!");
                return;
            }
            else if (!int.TryParse(txtValue.Text, out int value) || value < 0)
            {
                MessageBox.Show("Mức phụ thu nhập không hợp lệ vui lòng nhập lại( không được nhập chữ kí tự và >= 0)!");
                return;
            }
            else
            {
                var sur = new SurchargesViewModel()
                {
                    ID = _surcharges.ID,
                    SurchargesName = txtName.Text,
                    SurchargesValue = int.Parse(txtValue.Text),
                    StartDate = dp_start.SelectedDate.Value,
                    EndDate = dp_end.SelectedDate.Value
                };
                var list = SurchargesRequest.GetByStart_End(sur.StartDate, sur.EndDate);
                if (list != null)
                {
                    MessageBox.Show("Sửa loại phụ thu không thành công, thời gian phụ thu bị trùng với loại phụ thu khác vui lòng kiểm tra lại!");
                    return;
                }
                if (SurchargesRequest.update(sur) == true)
                {
                    MessageBox.Show("Sửa thông tin thành công.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sửa loại phụ thu không thành công!");
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
