using FECoffe.DTO.Employee;
using FECoffe.DTO.EmployeeSchedules;
using FECoffe.DTO.Positions;
using FECoffe.DTO.Salaries;
using FECoffe.DTO.Shifts;
using FECoffe.DTO.Timekeeping;
using FECoffe.Form;
using FECoffe.Form.FrmUpdate;
using FECoffe.Request.Employee;
using FECoffe.Request.EmployeeSchedules;
using FECoffe.Request.Positions;
using FECoffe.Request.Salaries;
using FECoffe.Request.Shifts;
using FECoffe.Request.Timekeeping;
using System.Windows;
using System.Windows.Controls;

namespace FECoffe.Dashboards
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        public Employee()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthibangluong();
            hienthichamcong();
            hienthichucvu();
            hienthilichlam();
            hienthinhanvien();
            hienthicalam();
        }
        private void hienthinhanvien()
        {
            var listEmployee = EmployeeRequest.GetAllEmloyee();
            if (listEmployee != null)
            {
                dg_Employee.ItemsSource = listEmployee;
                cbFilter_Timekeeping.ItemsSource = listEmployee;
                cbFindnhanvien_salaries.ItemsSource = listEmployee;
            }
            else
            {
                MessageBox.Show("Khong co du lieu cho employee !");
            }
        }
        private void hienthichucvu()
        {
            var lisPosition = PositionsRequest.GetAllPosition();
            if (lisPosition != null)
            {
                dg_position.ItemsSource = lisPosition;
            }
            else
            {
                MessageBox.Show("Khong co du lieu cho position !");
            }
        }
        private void hienthilichlam()
        {
            var listEmployeeSchedules = EmployeeSchedulesRequest.GetAllEmployeeSchedu();
            if (listEmployeeSchedules != null)
            {
                dg_EmployeeSchedules.ItemsSource = listEmployeeSchedules;
            }
            else
            {
                MessageBox.Show("Khong co du lieu cho bang luong nao !");
            }
        }
        private void hienthichamcong()
        {
            var listTimekeeping = TimekeepingRequest.GetAllTimekeeping();
            if (listTimekeeping != null)
            {
                dg_Timekeeping.ItemsSource = listTimekeeping;
            }
            else
            {
                MessageBox.Show("Khong co du lieu cho bang cham cong !");
            }
        }
        private void hienthicalam()
        {
            var listshifts = ShiftsRequest.GetAllShifts();
            if(listshifts != null)
            {
                dg_Shifts.ItemsSource = listshifts;
            }
            else
            {
                MessageBox.Show("Khong co du lieu cho ca lam !");
            }
        }

        private void hienthibangluong()
        {
            var listSlaries = SalariesRequest.GetAllSalaries();
            if (listSlaries != null)
            {
                dg_Salaries.ItemsSource = listSlaries;
            }
            else
            {
                MessageBox.Show("Khong co du lieu cho bang luong nao !");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void Them_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddEmployee frm_AddEmployee = new Frm_AddEmployee();
            var result = frm_AddEmployee.ShowDialog();
            if (result == true)
            {
                hienthinhanvien();
            }
        }

        private void dg_Employee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            hienthibangluong();
            hienthichamcong();
            hienthichucvu();
            hienthilichlam();
            hienthinhanvien();
            hienthicalam();
        }

        private void delete_employee_Click(object sender, RoutedEventArgs e)
        {
            var ep = dg_Employee.SelectedItem as EmployeeViewModel;
            var result = MessageBox.Show(
                 "Bạn có chắc chắn muốn xóa nhân viên này?",
                 "Xác nhận xóa",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning
             );

            if (result == MessageBoxResult.Yes)
            {
                var status = EmployeeRequest.getforenkey(ep.EmployeeID);
                if(status == false)
                {
                    if (EmployeeRequest.deleteEmployee(ep.EmployeeID) == true)
                    {
                        MessageBox.Show("Đã xóa nhân viên.");
                        hienthinhanvien();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Loi khi xoa nhân viên.");
                        return;
                    }
                }
                else if(status == true)
                {
                    MessageBox.Show("Nhân viên có tài khoản lịch làm bảng lương không được xóa!");
                    return;
                }
                else
                {
                    MessageBox.Show("Loi khi xoa nhân viên.");
                    return;
                }
                
            }
            else
            {
                
            }
        }

        private void edit_employee_Click(object sender, RoutedEventArgs e)
        {
            var ep = dg_Employee.SelectedItem as EmployeeViewModel;
            Frm_Update_Employee employee = new Frm_Update_Employee(ep);
            var result = employee.ShowDialog();
            if (result == true)
            {
                hienthinhanvien();
            }
        }

        private void themchucvu_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddPosition frm_AddPosition = new Frm_AddPosition();
            var result = frm_AddPosition.ShowDialog();
            if (result == true)
            {
                hienthichucvu();
            }
        }

        private void edit_position_Click(object sender, RoutedEventArgs e)
        {
            var ps = dg_position.SelectedItem as PositionsViewModel;
            Frm_Update_Position frm_Update_Position = new Frm_Update_Position(ps);
            var result = frm_Update_Position.ShowDialog();
            if (result == true)
            {
                hienthichucvu();
            }
        }

        private void delete_position_Click(object sender, RoutedEventArgs e)
        {
            var position = dg_position.SelectedItem as PositionsViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa chức vụ này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                var ep = PositionsRequest.GetAllPositionByIDEployee(position.PositionID);
                if(ep.Count > 0)
                {
                    MessageBox.Show("Đã có nhân viên thuộc chức vụ này, không thể xóa, vui lòng gỡ chức vụ ra khỏi nhân viên rồi thử lại!");
                    return;
                }
                else
                {
                    if (PositionsRequest.deletePosition(position.PositionID) == true)
                    {
                        MessageBox.Show("Đã xóa chức vụ.");
                        hienthichucvu();
                    }
                    else
                    { 
                        MessageBox.Show("Loi khi xóa chức vụ!");
                        return;
                    }
                }
            }
            else
            {
                
            }
           
        }

        private void themcalamm_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddShifts frm_AddShifts = new Frm_AddShifts();
            var result = frm_AddShifts.ShowDialog();
            if (result == true)
            {
                hienthicalam();
            }
        }

        private void edit_shifts_Click(object sender, RoutedEventArgs e)
        {
            var shifts = dg_Shifts.SelectedItem as ShiftsViewModel;
            Frm_Update_Shifts frm_Update_Shifts = new Frm_Update_Shifts(shifts);
            var result = frm_Update_Shifts.ShowDialog();
            if (result == true)
            {
                hienthicalam();
            }
        }

        private void delete_shifts_Click(object sender, RoutedEventArgs e)
        {
            var shifts = dg_Shifts.SelectedItem as ShiftsViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa ca làm này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (ShiftsRequest.deleteShifts(shifts.ShiftID) == true)
                {
                    MessageBox.Show("Đã xóa ca làm này.");
                    hienthicalam();
                }
                else MessageBox.Show("Lỗi khi xóa ca làm này!");
            }
            else
            {

            }
        }

        private void themlich_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddEmployeeSchedules schedules = new Frm_AddEmployeeSchedules();
            var result = schedules.ShowDialog();
            if (result == true)
            {
                hienthilichlam();
            }
        }

        private void edit_EmployeeSchedules_Click(object sender, RoutedEventArgs e)
        {
            var es = dg_EmployeeSchedules.SelectedItem as EmployeeSchedulesViewModel;
            Frm_Update_EmployeeSchedules frm_Update_EmployeeSchedules = new Frm_Update_EmployeeSchedules(es);
            var result = frm_Update_EmployeeSchedules.ShowDialog();
            if (result == true)
            {
                hienthilichlam();
            }
        }

        private void delete_EmployeeSchedules_Click(object sender, RoutedEventArgs e)
        {
            var es = dg_EmployeeSchedules.SelectedItem as EmployeeSchedulesViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lịch làm này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (EmployeeSchedulesRequest.deleteEmployeeSchedules(es.ScheduleID) == true)
                {
                    MessageBox.Show("Đã xóa lịch làm này.");
                    hienthilichlam();
                }
                else MessageBox.Show("Lỗi khi xóa lịch làm này!");
            }
            else
            {

            }
        }

        private void Themchamcong_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddTimekeeping frm_AddTimekeeping = new Frm_AddTimekeeping();
            var result = frm_AddTimekeeping.ShowDialog();
            if (result == true)
            {
                hienthichamcong();
            }
        }

        private void edit_Timekeeping_Click(object sender, RoutedEventArgs e)
        {
            var tiemk = dg_Timekeeping.SelectedItem as TimekeepingViewModel;
            Frm_Update_Timekeeping frm_Update_Timekeeping = new Frm_Update_Timekeeping(tiemk);
            var result = frm_Update_Timekeeping.ShowDialog();
            if (result == true)
            {
                hienthichamcong();
            }
        }

        private void delete_Timekeeping_Click(object sender, RoutedEventArgs e)
        {
            var tk = dg_Timekeeping.SelectedItem as TimekeepingViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lich lam này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (TimekeepingRequest.deleteTimekeeping(tk.TimekeepingID) == true)
                {
                    MessageBox.Show("Đã xóa chấm công này.");
                    hienthichamcong();
                }
                else MessageBox.Show("Lỗi khi xóa chấm công này!");
            }
            else
            {

            }
        }

        private void thembangluong_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddSalaries frm_AddSalaries = new Frm_AddSalaries();
            var result = frm_AddSalaries.ShowDialog();
            if (result == true)
            {
                hienthibangluong();
            }
        }

        private void edit_Salaries_Click(object sender, RoutedEventArgs e)
        {
            var salaries = dg_Salaries.SelectedItem as SalariesViewModel;
            Frm_Update_Salaries frm_Update_Salaries = new Frm_Update_Salaries(salaries);
            var result = frm_Update_Salaries.ShowDialog();
            if (result == true)
            {
                hienthibangluong();
            }
        }

        private void delete_Salaries_Click(object sender, RoutedEventArgs e)
        {
            var salaries = dg_Salaries.SelectedItem as SalariesViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa bảng lương này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (SalariesRequest.deleteSalaries(salaries.SalaryID) == true)
                {
                    MessageBox.Show("Đã xóa bảng lương này.");
                    hienthibangluong();
                }
                else MessageBox.Show("Lỗi khi xóa bảng lương này!");
            }
            else
            {

            }
        }

        private void find_employee(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txt_findEmployee.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tìm kiếm!");
            }
            else
            {
                var list = EmployeeRequest.GetEmloyeeByName(txt_findEmployee.Text);
                dg_Employee.ItemsSource = list;
            }
        }

        private void FindPosition_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_FindPosition.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tìm kiếm!");
            }
            else
            {
                var list = PositionsRequest.GetPositionByName(txt_FindPosition.Text);
                dg_position.ItemsSource = list;
            }
        }

        private void FindShift_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFind_Shift.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tìm kiếm!");
            }
            else
            {
                var list = ShiftsRequest.GetShiftsByName(txtFind_Shift.Text);
                  dg_Shifts.ItemsSource  = list;
            }
        }

        private void FindTimeKeeping_Click(object sender, RoutedEventArgs e)
        {
            if (dpStar_TimeKeeping.SelectedDate == null)
            {
                MessageBox.Show("Vui òng nhập mốc thời gian bắt đầu!");
            }
            else if (dpEnd_TimeKeeping.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập mốc thời gian đích!");
            }
            else
            {
                var start = DateOnly.FromDateTime(dpStar_TimeKeeping.SelectedDate.Value);
                var end = DateOnly.FromDateTime(dpEnd_TimeKeeping.SelectedDate.Value);
                int? epi = null;
                if (cbFilter_Timekeeping.SelectedValue == null)
                {
                    epi = null;
                }
                else
                {
                    epi = (int)cbFilter_Timekeeping.SelectedValue;
                }
                var list = TimekeepingRequest.GetTimekeepingByFilter(start, end, epi);
                dg_Timekeeping.ItemsSource = list;
            }
        }

        private void FindSalaries_Click(object sender, RoutedEventArgs e)
        {
            if (dpFindEnd_salaries.SelectedDate == null || dpFindStart_salaries.SelectedDate == null) 
            {
                MessageBox.Show("Vui lòng nhập mốc thời gian!");
            }
            else if(cbFindnhanvien_salaries.SelectedValue == null)
            {
                var start = DateOnly.FromDateTime(dpFindStart_salaries.SelectedDate.Value);
                var end = DateOnly.FromDateTime(dpFindEnd_salaries.SelectedDate.Value);
                var list = SalariesRequest.GetSalariesByFilter1(start, end);
                dg_Salaries.ItemsSource = list;
            }
            else
            {
                var start = DateOnly.FromDateTime(dpFindStart_salaries.SelectedDate.Value);
                var end = DateOnly.FromDateTime(dpFindEnd_salaries.SelectedDate.Value);
                var epid = (int)cbFindnhanvien_salaries.SelectedValue;
                var list = SalariesRequest.GetSalariesByFilter2(start, end, epid);
                dg_Salaries.ItemsSource = list;
            }
            
        }

        private void Find_EmployeeSchedules(object sender, RoutedEventArgs e)
        {
            if (dpend_FindEmployeeSchedules.SelectedDate == null || dpstart_FindEmployeeSchedules.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập mốc thời gian!");
            }
            else
            {
                var start = DateOnly.FromDateTime(dpstart_FindEmployeeSchedules.SelectedDate.Value);
                var end = DateOnly.FromDateTime(dpend_FindEmployeeSchedules.SelectedDate.Value);
                var list = EmployeeSchedulesRequest.GetEmployeeScheduByFilter(start, end);
                dg_EmployeeSchedules.ItemsSource = list;
            }
        }
    }
}
