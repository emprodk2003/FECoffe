using FECoffe.DTO.Suppliers;
using FECoffe.Request.Supplier;
using System.Text.RegularExpressions;
using System.Windows;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddSuppliers.xaml
    /// </summary>
    public partial class Frm_AddSuppliers : Window
    {
        public Frm_AddSuppliers()
        {
            InitializeComponent();
        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var name = txtSupplierName.Text;
            var email = txtEmail.Text;
            if(Regex.IsMatch(email, pattern)==false)
            {
                MessageBox.Show("Email sai định dạng /n Định dạng chuẩn xxx@gmail.com");
                return;
            }    
            var address= txtAddress.Text;
            var phone=txtPhone.Text;
            if(phone.Length<10 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Sai số điện thoại . Chỉ có 10 số và viết bằng số ");
                return;
            }    

            var suppliers = new CrudSuppliers()
            {
                SupplierName = name,
                Phone=phone,
                Address=address,
                Email=email,
                CreatedAt=DateTime.Now,
                UpdatedAt=DateTime.Now,
            };
            if (SupplierRequest.createSupplier(suppliers) == true)
            {
                MessageBox.Show("Thêm nhà cung cấp thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại");
            }
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
