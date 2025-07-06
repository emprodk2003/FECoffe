using FECoffe.DTO.EmployeeSchedules;
using FECoffe.Request.EmployeeSchedules;
using FECoffe.Request.Shifts;
using System.Windows;

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Frm_Update_EmployeeSchedules.xaml
    /// </summary>
    public partial class Frm_Update_EmployeeSchedules : Window
    {
        private EmployeeSchedulesViewModel _employeeSchedules;
        public Frm_Update_EmployeeSchedules(EmployeeSchedulesViewModel employeeSchedules)
        {
            InitializeComponent();
            _employeeSchedules = employeeSchedules;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtnhanvien.Text) || cbShifts.SelectedValue == null || dpWorkDate.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                var es = new EmployeeSchedulesViewModel()
                {
                    EmployeeID = _employeeSchedules.EmployeeID,
                    ScheduleID = _employeeSchedules.ScheduleID,
                    Note = txtNote.Text,
                    WorkDate = DateOnly.FromDateTime(dpWorkDate.SelectedDate.Value),
                    IsWorking = chkIsWorking.IsChecked.Value,
                    ShiftID = (int)cbShifts.SelectedValue
                };
                if (EmployeeSchedulesRequest.updateEmployeeSchedules(es) == true)
                {
                    MessageBox.Show("Cập nhật thông tin lịch làm thành công.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin lịch làm thất bại vui lòng thử lại!");
                    this.Close();
                }
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void hienthicalam()
        {
            var listshifts = ShiftsRequest.GetAllShifts();
            if (listshifts != null)
            {
                cbShifts.ItemsSource = listshifts;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu cho ca làm việc!");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthicalam();
            if(_employeeSchedules != null)
            {
                txtnhanvien.Text = _employeeSchedules.FullName;
                txtNote.Text = _employeeSchedules.Note;
                cbShifts.SelectedValue = _employeeSchedules.EmployeeID;
                dpWorkDate.SelectedDate = _employeeSchedules.WorkDate.ToDateTime(TimeOnly.MinValue);
                chkIsWorking.IsChecked = _employeeSchedules.IsWorking;
            }
        }
    }
}
