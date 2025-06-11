using FECoffe.DTO.EmployeeSchedules;
using FECoffe.Request.EmployeeSchedules;
using FECoffe.Request.Shifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

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
                MessageBox.Show("Vui long nhap day du thong tin!");
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
                    MessageBox.Show("Cap nhat thong tin lich lam thanh cong!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cap nhat thong tin lich lam that bai vui long thu lai!");
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
                MessageBox.Show("Khong co du lieu cho ca lam !");
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
