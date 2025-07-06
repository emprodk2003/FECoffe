using FECoffe.DTO.Surcharges;
using FECoffe.Request.Surcharges;
using System.Windows;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddSurcharges.xaml
    /// </summary>
    public partial class Frm_AddSurcharges : Window
    {
        public Frm_AddSurcharges()
        {
            InitializeComponent();
        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtValue.Text) || dp_end.SelectedDate == null || dp_start.SelectedDate == null)
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
                var sur = new CrudSurcharges()
                {
                    SurchargesName = txtName.Text,
                    SurchargesValue = int.Parse(txtValue.Text),
                    StartDate = dp_start.SelectedDate.Value.Date,
                    EndDate = dp_end.SelectedDate.Value.Date
                };
                var list = SurchargesRequest.GetByStart_End(sur.StartDate, sur.EndDate);
                if(list != null && list.Count > 0)
                {
                    MessageBox.Show("Thêm loại phụ thu không thành công, thời gian phụ thu bị trùng với loại phụ thu khác vui lòng kiểm tra lại!");
                    return;
                }
                if(SurchargesRequest.create(sur) == true)
                {
                    MessageBox.Show("Thêm thành công.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm loại phụ thu không thành công, có thể tên loại phụ đã tồn tại vui lòng thử lại!!");
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
