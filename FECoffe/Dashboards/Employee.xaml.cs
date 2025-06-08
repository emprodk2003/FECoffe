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
            frm_AddEmployee.ShowDialog();

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
                if (EmployeeRequest.deleteEmployee(ep.EmployeeID) == true)
                {
                    MessageBox.Show("Đã xóa nhân viên.");
                }
                else MessageBox.Show("Loi khi xoa nhân viên.");
            }
            else
            {
                
            }
        }

        private void edit_employee_Click(object sender, RoutedEventArgs e)
        {
            var ep = dg_Employee.SelectedItem as EmployeeViewModel;
            Frm_Update_Employee employee = new Frm_Update_Employee(ep);
            employee.ShowDialog();
        }

        private void themchucvu_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddPosition frm_AddPosition = new Frm_AddPosition();
            frm_AddPosition.ShowDialog();
        }

        private void edit_position_Click(object sender, RoutedEventArgs e)
        {
            var ps = dg_position.SelectedItem as PositionsViewModel;
            Frm_Update_Position frm_Update_Position = new Frm_Update_Position(ps);
            frm_Update_Position.ShowDialog();
        }

        private void delete_position_Click(object sender, RoutedEventArgs e)
        {
            var position = dg_position.SelectedItem as PositionsViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa chuc vu này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (PositionsRequest.deletePosition(position.PositionID) == true)
                {
                    MessageBox.Show("Đã xóa chuc vu.");
                }
                else MessageBox.Show("Loi khi xoa chuc vu!");
            }
            else
            {
                
            }
           
        }

        private void themcalamm_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddShifts frm_AddShifts = new Frm_AddShifts();
            frm_AddShifts.ShowDialog();
        }

        private void edit_shifts_Click(object sender, RoutedEventArgs e)
        {
            var shifts = dg_Shifts.SelectedItem as ShiftsViewModel;
            Frm_Update_Shifts frm_Update_Shifts = new Frm_Update_Shifts(shifts);
            frm_Update_Shifts.ShowDialog();
        }

        private void delete_shifts_Click(object sender, RoutedEventArgs e)
        {
            var shifts = dg_Shifts.SelectedItem as ShiftsViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa ca lam này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (ShiftsRequest.deleteShifts(shifts.ShiftID) == true)
                {
                    MessageBox.Show("Đã xóa ca lam nay.");
                }
                else MessageBox.Show("Loi khi xoa ca lam nay!");
            }
            else
            {

            }
        }

        private void themlich_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddEmployeeSchedules schedules = new Frm_AddEmployeeSchedules();
            schedules.ShowDialog();
        }

        private void edit_EmployeeSchedules_Click(object sender, RoutedEventArgs e)
        {
            var es = dg_EmployeeSchedules.SelectedItem as EmployeeSchedulesViewModel;
            Frm_Update_EmployeeSchedules frm_Update_EmployeeSchedules = new Frm_Update_EmployeeSchedules(es);
            frm_Update_EmployeeSchedules.ShowDialog();
        }

        private void delete_EmployeeSchedules_Click(object sender, RoutedEventArgs e)
        {
            var es = dg_EmployeeSchedules.SelectedItem as EmployeeSchedulesViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lich lam này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (EmployeeSchedulesRequest.deleteEmployeeSchedules(es.ScheduleID) == true)
                {
                    MessageBox.Show("Đã xóa lich lam nay.");
                }
                else MessageBox.Show("Loi khi xoa lich lam nay!");
            }
            else
            {

            }
        }

        private void Themchamcong_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddTimekeeping frm_AddTimekeeping = new Frm_AddTimekeeping();
            frm_AddTimekeeping.ShowDialog();
        }

        private void edit_Timekeeping_Click(object sender, RoutedEventArgs e)
        {
            var tiemk = dg_Timekeeping.SelectedItem as TimekeepingViewModel;
            Frm_Update_Timekeeping frm_Update_Timekeeping = new Frm_Update_Timekeeping(tiemk);
            frm_Update_Timekeeping.ShowDialog();
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
                    MessageBox.Show("Đã xóa cham cong nay.");
                }
                else MessageBox.Show("Loi khi xoa cham cong nay!");
            }
            else
            {

            }
        }

        private void thembangluong_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddSalaries frm_AddSalaries = new Frm_AddSalaries();
            frm_AddSalaries.ShowDialog();
        }

        private void edit_Salaries_Click(object sender, RoutedEventArgs e)
        {
            var salaries = dg_Salaries.SelectedItem as SalariesViewModel;
            Frm_Update_Salaries frm_Update_Salaries = new Frm_Update_Salaries(salaries);
            frm_Update_Salaries.ShowDialog();
        }

        private void delete_Salaries_Click(object sender, RoutedEventArgs e)
        {
            var salaries = dg_Salaries.SelectedItem as SalariesViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa bang luong này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (SalariesRequest.deleteSalaries(salaries.SalaryID) == true)
                {
                    MessageBox.Show("Đã xóa bang luong nay.");
                }
                else MessageBox.Show("Loi khi xoa bang luong nay!");
            }
            else
            {

            }
        }

        private void find_employee(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txt_findEmployee.Text))
            {
                MessageBox.Show("Vui long nhap ten tim kiem");
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
                MessageBox.Show("Vui long nhap ten tim kiem");
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
                MessageBox.Show("Vui long nhap ten tim kiem");
            }
            else
            {
                var list = ShiftsRequest.GetShiftsByName(txtFind_Shift.Text);
                  dg_Shifts.ItemsSource  = list;
            }
        }

        private void FindTimeKeeping_Click(object sender, RoutedEventArgs e)
        {
            if(dpStar_TimeKeeping.SelectedDate == null)
            {
                MessageBox.Show("Vui long chon moc thoi gian bat dau!");
            }
            else if(dpEnd_TimeKeeping.SelectedDate == null)
            {
                MessageBox.Show("Vui long chon moc thoi gian dich!");
            }
            else if(cbFilter_Timekeeping.SelectedValue == null)
            {
                MessageBox.Show("Vui long chon nhan vien can xem!");
            }
            else
            {
                var start = DateOnly.FromDateTime(dpStar_TimeKeeping.SelectedDate.Value);
                var end = DateOnly.FromDateTime(dpEnd_TimeKeeping.SelectedDate.Value);
                var epid = (int)cbFilter_Timekeeping.SelectedValue;
                var list = TimekeepingRequest.GetTimekeepingByFilter(start, end, epid);
                dg_Timekeeping.ItemsSource = list;
            }
        }

        private void FindSalaries_Click(object sender, RoutedEventArgs e)
        {
            if (dpFindEnd_salaries.SelectedDate == null || dpFindStart_salaries.SelectedDate == null) 
            {
                MessageBox.Show("Vui long chon moc thoi gian!");
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
                MessageBox.Show("Vui long chon moc thoi gian!");
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
