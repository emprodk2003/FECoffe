using FECoffe.DTO.Timekeeping;
using FECoffe.Request.Timekeeping;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Frm_Update_Timekeeping.xaml
    /// </summary>
    public partial class Frm_Update_Timekeeping : Window
    {
        private TimekeepingViewModel _timekeeping;
        public Frm_Update_Timekeeping(TimekeepingViewModel timekeeping)
        {
            InitializeComponent();
            _timekeeping = timekeeping;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtgiora.Text) || string.IsNullOrWhiteSpace(txtgiovao.Text) || string.IsNullOrWhiteSpace(txtnhanvien.Text) || dpWorkDate.SelectedDate == null)
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            // Kiểm tra định dạng giờ: hh:mm (24 giờ)
            else if (!Regex.IsMatch(txtgiovao.Text, @"^\d{2}:\d{2}$") ||
                !Regex.IsMatch(txtgiora.Text, @"^\d{2}:\d{2}$"))
            {
                MessageBox.Show("Giờ vào và giờ ra phải có định dạng hh:mm (ví dụ: 08:30)!");
                return;
            }
            else
            {
                TimeSpan spanStart = TimeSpan.ParseExact(txtgiovao.Text, "hh\\:mm", CultureInfo.InvariantCulture);
                TimeSpan spanEnd = TimeSpan.ParseExact(txtgiora.Text, "hh\\:mm", CultureInfo.InvariantCulture);
                // Kiểm tra giờ vào phải trước giờ ra
                if (spanStart >= spanEnd)
                {
                    MessageBox.Show("Giờ vào phải sớm hơn giờ ra!");
                    return;
                }
                TimeSpan duration = spanEnd - spanStart;
                float totalHours = (float)duration.TotalHours;
                var timekeeping = new TimekeepingViewModel()
                {
                    TimekeepingID = _timekeeping.TimekeepingID,
                    EmployeeID = _timekeeping.EmployeeID,
                    CheckInTime = TimeOnly.FromTimeSpan(spanStart),
                    CheckOutTime = TimeOnly.FromTimeSpan(spanEnd),
                    WorkDate = DateOnly.FromDateTime(dpWorkDate.SelectedDate.Value),
                    WorkingHours = totalHours,
                    Note = txtNote.Text
                };
                if (TimekeepingRequest.updateTimekeeping(timekeeping) == true)
                {
                    MessageBox.Show("Sua thong tin bang cham cong thanh cong!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Loi khi sua thong tin bang cham cong moi !");
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_timekeeping != null)
            {
                txtgiora.Text = _timekeeping.CheckOutTime.ToString();
                txtgiovao.Text = _timekeeping.CheckInTime.ToString();
                txtnhanvien.Text = _timekeeping.FullName.ToString();
                txtNote.Text = _timekeeping.Note;
                dpWorkDate.SelectedDate = _timekeeping.WorkDate.ToDateTime(TimeOnly.MinValue);
            }
        }
    }
}
