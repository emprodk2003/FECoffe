using FECoffe.DTO.CategoyMaterial;
using FECoffe.DTO.Suppliers;
using FECoffe.Request.CategoryMaterial;
using FECoffe.Request.Supplier;
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
            var name = txtSupplierName.Text;
            var email = txtEmail.Text;
            var address= txtAddress.Text;
            var phone=txtPhone.Text;

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
                MessageBox.Show("Them nhà cung cấp thanh cong");
                this.Close();
            }
            else
            {
                MessageBox.Show("Them nhà cung cấp that bai");
            }
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
