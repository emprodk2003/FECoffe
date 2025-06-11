using FECoffe.DTO.Salaries;
using FECoffe.Request.Salaries;
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
    /// Interaction logic for Frm_Update_Salaries.xaml
    /// </summary>
    public partial class Frm_Update_Salaries : Window
    {
        private SalariesViewModel _salaries;
        public Frm_Update_Salaries(SalariesViewModel salaries)
        {
            InitializeComponent();
            _salaries = salaries;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBonus.Text) || string.IsNullOrWhiteSpace(txtMonth.Text) || string.IsNullOrWhiteSpace(txtPenalty.Text)
                || string.IsNullOrWhiteSpace(txtYear.Text) || string.IsNullOrWhiteSpace(txtTotalWorkingHours.Text) || string.IsNullOrWhiteSpace(txtnhanvien.Text))
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            // Kiểm tra tháng
            else if (!int.TryParse(txtMonth.Text, out int month) || month < 1 || month > 12)
            {
                MessageBox.Show("Tháng phải là số nguyên từ 1 đến 12!");
                return;
            }

            // Kiểm tra năm
            else if (!int.TryParse(txtYear.Text, out int year) || year < 2000 || year > 2100)
            {
                MessageBox.Show("Năm phải là số nguyên hợp lệ!");
                return;
            }

            // Kiểm tra bonus
            else if (!decimal.TryParse(txtBonus.Text, out decimal bonus) || bonus < 0)
            {
                MessageBox.Show("Tiền thưởng không hợp lệ!");
                return;
            }

            // Kiểm tra penalty
            else if (!decimal.TryParse(txtPenalty.Text, out decimal penalty) || penalty < 0)
            {
                MessageBox.Show("Tiền phạt không hợp lệ!");
                return;
            }

            // Kiểm tra final salary
            else if (!decimal.TryParse(txtFinalSalary.Text, out decimal finalSalary) || finalSalary < 0)
            {
                MessageBox.Show("Tổng lương không hợp lệ!");
                return;
            }

            // Kiểm tra số giờ làm việc
            else if (!float.TryParse(txtTotalWorkingHours.Text, out float totalHours) || totalHours < 0)
            {
                MessageBox.Show("Tổng giờ làm việc không hợp lệ!");
                return;
            }
            else
            {
                var app = (App)Application.Current;
                var salaries = new SalariesViewModel()
                {
                    SalaryID = _salaries.SalaryID,
                    EmployeeID = _salaries.EmployeeID,
                    Month = int.Parse(txtMonth.Text),
                    Year = int.Parse(txtYear.Text),
                    Bonus = decimal.Parse(txtBonus.Text),
                    TotalWorkingHours = float.Parse(txtTotalWorkingHours.Text),
                    Penalty = decimal.Parse(txtPenalty.Text),
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    FinalSalary = decimal.Parse(txtFinalSalary.Text),
                    UserID = Guid.Parse(app.IdUser)
                };
                if (SalariesRequest.updateSalaries(salaries) == true)
                {
                    MessageBox.Show("Sua thong tin bang luong thanh cong!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sua thong tin bang luong  that bai!");
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(_salaries != null)
            {
                txtnhanvien.Text = _salaries.FullName;
                txtBonus.Text = _salaries.Bonus.ToString();
                txtFinalSalary.Text = _salaries.FinalSalary.ToString();
                txtMonth.Text = _salaries.Month.ToString();
                txtYear.Text = _salaries.Year.ToString();
                txtPenalty.Text = _salaries.Penalty.ToString();
                txtTotalWorkingHours.Text = _salaries.TotalWorkingHours.ToString();
            }
        }
    }
}
