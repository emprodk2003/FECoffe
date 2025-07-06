using FECoffe.DTO.Timekeeping;
using FECoffe.Request.Employee;
using FECoffe.Request.Timekeeping;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddTimekeeping.xaml
    /// </summary>
    public partial class Frm_AddTimekeeping : Window
    {
        public Frm_AddTimekeeping()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtgiora.Text) || string.IsNullOrWhiteSpace(txtgiovao.Text) || cbnhanvien.SelectedValue == null || dpWorkDate.SelectedDate == null)
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
                var timekeeping = new CrudTimekeeping()
                {
                    EmployeeID = (int)cbnhanvien.SelectedValue,
                    CheckInTime = TimeOnly.FromTimeSpan(spanStart),
                    CheckOutTime = TimeOnly.FromTimeSpan(spanEnd),
                    WorkDate = DateOnly.FromDateTime(dpWorkDate.SelectedDate.Value),
                    WorkingHours = totalHours,
                    Note = txtNote.Text

                };
                var tk = TimekeepingRequest.GetByEmployee(timekeeping.EmployeeID, timekeeping.WorkDate,timekeeping.CheckInTime,timekeeping.CheckOutTime);
                if(tk.Count > 0)
                {
                    MessageBox.Show("Chấm công đã tồn tại vui lòng kiểm tra lại thông tin!");
                    return;
                }
                else
                {
                    if (TimekeepingRequest.createTimekeeping(timekeeping) == true)
                    {
                        MessageBox.Show("Thêm chấm công thành công.");
                        this.DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm chấm công!");
                        this.Close();
                    }
                }
                
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void hienthinhanvien()
        {
            var listEmployee = EmployeeRequest.GetAllEmloyee();
            if (listEmployee != null)
            {
                cbnhanvien.ItemsSource = listEmployee;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu cho employee !");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthinhanvien();
        }
    }
}
