using FECoffe.DTO.Shifts;
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

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Frm_Update_Shifts.xaml
    /// </summary>
    public partial class Frm_Update_Shifts : Window
    {
        private ShiftsViewModel _shifts;
        public Frm_Update_Shifts(ShiftsViewModel shifts)
        {
            InitializeComponent();
            _shifts = shifts;
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShiftName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text) || dpStartTime.Value?.TimeOfDay == null || dpEndTime.Value?.TimeOfDay == null)
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            else
            {
                var shifts = new ShiftsViewModel()
                {
                    ShiftID = _shifts.ShiftID,
                    ShiftName = txtShiftName.Text,
                    Description = txtDescription.Text,
                    StartTime = dpStartTime.Value != null ? TimeOnly.FromDateTime(dpStartTime.Value.Value) : TimeOnly.MinValue,
                    EndTime = dpEndTime.Value != null ? TimeOnly.FromDateTime(dpEndTime.Value.Value) : TimeOnly.MinValue
                };
                if (ShiftsRequest.updateShifts(shifts) == true)
                {
                    MessageBox.Show("Them ca lam moi thanh cong!");
                    this.DialogResult = true;
                    this.Close();
                }
                else MessageBox.Show("Loi khi them ca lam moi !");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_shifts != null)
            {
                txtShiftName.Text = _shifts.ShiftName;
                txtDescription.Text = _shifts.Description;
                dpStartTime.Value = DateTime.Today.Add(_shifts.StartTime.ToTimeSpan());
                dpEndTime.Value = DateTime.Today.Add(_shifts.EndTime.ToTimeSpan());
            }
        }
    }
}
