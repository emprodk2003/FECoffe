using FECoffe.DTO.Positions;
using FECoffe.DTO.Shifts;
using FECoffe.Request.Positions;
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
                MessageBox.Show("Vui long nhap day du thong tin!");
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
                    MessageBox.Show("Them ca lam moi thanh cong!");
                    this.DialogResult = true;
                    this.Close();
                }
                else MessageBox.Show("Loi khi them ca lam moi !");
            }
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
