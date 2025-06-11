using FECoffe.DTO.Employee;
using FECoffe.Request.Employee;
using FECoffe.Request.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.Primitives;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddEmployee.xaml
    /// </summary>
    public partial class Frm_AddEmployee : Window
    {
        public Frm_AddEmployee()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var list_position = PositionsRequest.GetAllPosition();
            cbPosition.ItemsSource = list_position;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if(txtFullName.Text == null || txtAddress.Text == null || txtEmail.Text == null || txtPhone.Text == null || txtSalaryBase.Text == null || cbGender.SelectedItem == null || cbEmploymentType.SelectedItem == null || cbPosition.SelectedValue == null || dpBirthDate.SelectedDate.Value == null || dpStartDate.SelectedDate.Value == null)
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            // Kiểm tra định dạng số điện thoại (10 chữ số)
            else if (!Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!");
                return;
            }
            // Kiểm tra định dạng email
            else if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!");
                return;
            }
            // Kiểm tra số tiền có hợp lệ không
            else if (!decimal.TryParse(txtSalaryBase.Text, out decimal salaryBase) || salaryBase < 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!");
                return;
            }
            else
            {
                var selectedItem1 = cbGender.SelectedItem as ComboBoxItem;
                bool gender = false;
                if (selectedItem1 != null && selectedItem1.Tag != null)
                {
                    gender = bool.Parse(selectedItem1.Tag.ToString());
                }

                var selectedItem2 = cbEmploymentType.SelectedItem as ComboBoxItem;
                bool type = false;
                if (selectedItem2 != null && selectedItem2.Tag != null)
                {
                    type = bool.Parse(selectedItem2.Tag.ToString());
                }
                var employ = new CrudEmployee
                {
                    FullName = txtFullName.Text,
                    Address = txtAddress.Text,
                    BirthDate = DateOnly.FromDateTime(dpBirthDate.SelectedDate.Value),
                    PositionID = (int)cbPosition.SelectedValue,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    SalaryBase = decimal.Parse(txtSalaryBase.Text),
                    Gender = gender,
                    EmploymentType = type,
                    StartDate = DateOnly.FromDateTime(dpStartDate.SelectedDate.Value),
                    Status = chkStatus.IsChecked.Value,
                };
                if (EmployeeRequest.createEmployee(employ) == true)
                {
                    MessageBox.Show("Them nhan vien moi thanh cong!");
                    this.DialogResult = true;
                    this.Close();
                }
                else MessageBox.Show("Loi khi them nhan vien moi!");                
            }
        }
    }
}
