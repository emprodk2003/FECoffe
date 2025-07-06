using FECoffe.DTO.Timekeeping;
using FECoffe.Request.Timekeeping;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;

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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
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
                var tk = TimekeepingRequest.GetByEmployee(timekeeping.EmployeeID, timekeeping.WorkDate, timekeeping.CheckInTime, timekeeping.CheckOutTime);
                if (tk.Count > 0)
                {
                    MessageBox.Show("Chấm công đã tồn tại vui lòng kiểm tra lại thông tin!");
                    return;
                }
                else
                {
                    if (TimekeepingRequest.updateTimekeeping(timekeeping) == true)
                    {
                        MessageBox.Show("Sửa thông tin chấm công thành công.");
                        this.DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi sửa chấm công!");
                        this.Close();
                    }
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
