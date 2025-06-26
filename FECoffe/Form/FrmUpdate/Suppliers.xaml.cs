using FECoffe.DTO.CategoyMaterial;
using FECoffe.DTO.Suppliers;
using FECoffe.Request.CategoryMaterial;
using FECoffe.Request.Supplier;
using System.Text.RegularExpressions;
using System.Windows;

namespace FECoffe.Form.FrmUpdate
{
    public partial class Suppliers : Window
    {
        public CrudSuppliers _suppliers {  get; set; }
        public int id { get; set; }
        public DateTime createat { get;set; }
        public Suppliers(CrudSuppliers suppliers)
        {
            InitializeComponent();
            _suppliers = suppliers;
            txtSupplierName.Text = suppliers.SupplierName;
            txtPhone.Text = suppliers.Phone;
            txtEmail.Text = suppliers.Email;
            txtAddress.Text = suppliers.Address;
            id=suppliers.SupplierID;
            createat=suppliers.CreatedAt;

        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var name = txtSupplierName.Text;
            var email = txtEmail.Text;
            if (Regex.IsMatch(email, pattern) == false)
            {
                MessageBox.Show("Email sai định dạng /n Định dạng chuẩn xxx@gmail.com");
                return;
            }
            var address = txtAddress.Text;
            var phone = txtPhone.Text;
            if (phone.Length < 10 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Sai số điện thoại . Chỉ có 10 số và viết bằng số ");
                return;
            }
            var newsuppliers = new CrudSuppliers()
            {
               SupplierID = id,
               SupplierName=txtSupplierName.Text,
               Phone=txtPhone.Text,
               Email=txtEmail.Text,
               Address=txtAddress.Text,
               CreatedAt = createat,
               UpdatedAt = DateTime.Now
            };

            if (SupplierRequest.updateSupplier(newsuppliers) == true)
            {
                MessageBox.Show("Sữa Thành Công nhà cung cấp ");
                this.Close();
            }
            else
                MessageBox.Show("Sữa thất bại nhà cung cấp ");
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
