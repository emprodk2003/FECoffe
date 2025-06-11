using FECoffe.DTO.Employee;
using FECoffe.Request.Employee;
using FECoffe.Request.Positions;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Frm_Update_Employee : Window
    {
        private EmployeeViewModel _employee;
        public Frm_Update_Employee(EmployeeViewModel employee)
        {
            InitializeComponent();
            _employee = employee;
        }
        private void hienthichucvu()
        {
            var list_position = PositionsRequest.GetAllPosition();
            cbPosition.ItemsSource = list_position;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthichucvu();
            if (_employee != null)
            {
                    txtFullName.Text = _employee.FullName;
                    txtAddress.Text = _employee.Address;
                    txtPhone.Text = _employee.Phone;
                    txtEmail.Text = _employee.Email;

                    dpBirthDate.SelectedDate = _employee.BirthDate.ToDateTime(TimeOnly.MinValue);
                    dpStartDate.SelectedDate = _employee.StartDate.ToDateTime(TimeOnly.MinValue);

                    txtSalaryBase.Text = _employee.SalaryBase.ToString();

                    chkStatus.IsChecked = _employee.Status;
                    foreach (ComboBoxItem item in cbGender.Items)
                    {
                        if (item.Tag != null && item.Tag.ToString().ToLower() == _employee.Gender.ToString().ToLower())
                        {
                            cbGender.SelectedItem = item;
                            break;
                        }
                    }

                    foreach (ComboBoxItem item in cbEmploymentType.Items)
                    {
                        if (item.Tag != null && item.Tag.ToString().ToLower() == _employee.EmploymentType.ToString().ToLower())
                        {
                            cbEmploymentType.SelectedItem = item;
                            break;
                        }
                    }
                cbPosition.SelectedValue = _employee.PositionID;
                } 
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtSalaryBase.Text) ||
                cbGender.SelectedItem == null ||
                cbPosition.SelectedValue == null ||
                dpBirthDate.SelectedDate == null ||
                dpStartDate.SelectedDate == null ||
                cbEmploymentType.SelectedItem == null) 
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
                var employ = new EmployeeViewModel
                {   
                    EmployeeID = _employee.EmployeeID,
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
                if (EmployeeRequest.updateEmployee(employ) == true)
                {
                    MessageBox.Show("Sua thong tin nhan vien thanh cong!");
                    this.DialogResult = true;
                    this.Close();
                }
                else MessageBox.Show("Loi khi sua thong tin nhan vien !");
            }
        }
        

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
