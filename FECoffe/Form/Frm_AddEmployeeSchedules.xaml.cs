using FECoffe.Dashboards;
using FECoffe.DTO.Employee;
using FECoffe.DTO.EmployeeSchedules;
using FECoffe.DTO.ExportDetail;
using FECoffe.DTO.Shifts;
using FECoffe.Request.Employee;
using FECoffe.Request.EmployeeSchedules;
using FECoffe.Request.Shifts;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddEmployeeSchedules.xaml
    /// </summary>
    public partial class Frm_AddEmployeeSchedules : Window
    {
        public ObservableCollection<ShiftsViewModel> shiftsViews { get; set; } = new();
        public ObservableCollection<CrudEmployeeSchedules> CrudEmployeeSchedules { get; set; } = new();
        private void hienthicalam()
        {
            var listshifts = ShiftsRequest.GetAllShifts();
            if (listshifts != null)
            {
                shiftsViews = new ObservableCollection<ShiftsViewModel>(listshifts);
            }
            else
            {
                MessageBox.Show("Khong co du lieu cho ca lam !");
            }
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
                MessageBox.Show("Khong co du lieu cho employee !");
            }
        }
        public Frm_AddEmployeeSchedules()
        {
            InitializeComponent();
            hienthicalam();
            hienthinhanvien();
            CrudEmployeeSchedules.Add(new CrudEmployeeSchedules());
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                string text = comboBox.Text?.ToLower() ?? "";

                var filtered = shiftsViews
                    .Where(m => m.ShiftName.ToLower().Contains(text))
                    .ToList();

                comboBox.ItemsSource = filtered;
                comboBox.IsDropDownOpen = true;
            }
        
        }

        private void Luu_Click(object sender, RoutedEventArgs e)
        {
            var list = dgEmployeeSchedules.ItemsSource.Cast<CrudEmployeeSchedules>().ToList();
            
            if (cbnhanvien.SelectedItem == null || list == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!");
            }
            else
            {
                var emloyee = (int)cbnhanvien.SelectedValue;
                List<EmployeeSchedulesTemp> dses = new List<EmployeeSchedulesTemp>();
                foreach (var item in list)
                {
                    var es = new EmployeeSchedulesTemp();
                    es.EmployeeID = emloyee;
                    es.ShiftID = item.ShiftID;
                    es.WorkDate = DateOnly.FromDateTime(item.WorkDate);
                    es.IsWorking = item.IsWorking;
                    es.Note = item.Note;
                    dses.Add(es);
                }
                foreach (var item in dses)
                {
                    var ep = EmployeeSchedulesRequest.GetAllEmployeeSchedu();
                    var eps = ep.Where(x => x.WorkDate == item.WorkDate && x.ShiftID == item.ShiftID).ToList();
                    if(eps != null)
                    {
                        MessageBox.Show("Lịch làm đã tồn tại vui lòng kiểm tra lại thông tin và chọn lại!!");
                        break;
                        this.Close();
                    }
                    if (!EmployeeSchedulesRequest.createEmployeeSchedules(item))
                    {
                        MessageBox.Show("Lỗi khi thêm lịch làm. Vui lòng kiểm tra lại thông tin làm việc nhân viên!!");
                        break;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Them lich lam thanh cong!");
                        this.DialogResult = true;
                        this.Close();
                    }
                }
            }
        }

        private void Huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
