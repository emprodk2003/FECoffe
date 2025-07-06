using FECoffe.DTO.Shifts;
using FECoffe.Request.Shifts;
using System.Windows;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddShifts.xaml
    /// </summary>
    public partial class Frm_AddShifts : Window
    {
        public Frm_AddShifts()
        {
            InitializeComponent();
        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtShiftName.Text) || dpStartTime.Value?.TimeOfDay == null || dpEndTime.Value?.TimeOfDay == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                var shifts = new CrudShifts()
                {
                    ShiftName = txtShiftName.Text,
                    Description = txtDescription.Text,
                    StartTime = dpStartTime.Value != null ? TimeOnly.FromDateTime(dpStartTime.Value.Value) : TimeOnly.MinValue,
                    EndTime = dpEndTime.Value != null ? TimeOnly.FromDateTime(dpEndTime.Value.Value) : TimeOnly.MinValue
                };
                if (ShiftsRequest.createShifts(shifts) == true)
                {
                    MessageBox.Show("Thêm ca làm mới thành công!");
                    this.DialogResult = true;
                    this.Close();
                }
                else MessageBox.Show("Lỗi khi thêm ca làm mới!");
            }
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
