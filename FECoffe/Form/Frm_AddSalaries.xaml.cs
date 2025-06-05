using FECoffe.DTO.Salaries;
using FECoffe.Request.Employee;
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

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddSalaries.xaml
    /// </summary>
    public partial class Frm_AddSalaries : Window
    {
        public Frm_AddSalaries()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtBonus.Text) || string.IsNullOrWhiteSpace(txtMonth.Text) || string.IsNullOrWhiteSpace(txtPenalty.Text) 
                || string.IsNullOrWhiteSpace(txtYear.Text) || string.IsNullOrWhiteSpace(txtTotalWorkingHours.Text) || cbnhanvien.SelectedValue == null)
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
                var salaries = new CrudSalaries()
                {
                    EmployeeID = (int)cbnhanvien.SelectedValue,
                    Month = int.Parse(txtMonth.Text),
                    Year = int.Parse(txtYear.Text),
                    Bonus = decimal.Parse(txtBonus.Text),
                    TotalWorkingHours = float.Parse(txtTotalWorkingHours.Text),
                    Penalty = decimal.Parse(txtPenalty.Text),
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    FinalSalary = decimal.Parse(txtFinalSalary.Text),
                    UserID = Guid.Parse(app.IdUser)
                };
                if(SalariesRequest.createSalaries(salaries) == true)
                {
                    MessageBox.Show("Them bang luong moi thanh cong!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Them bang luong moi that bai!");
                    this.Close();
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
                MessageBox.Show("Khong co du lieu cho employee !");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthinhanvien();
        }
    }
}
