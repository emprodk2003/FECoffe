using FECoffe.DTO.Categories_Product;
using FECoffe.Request.Categories_Product;
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
    /// Interaction logic for Frm_AddCategories_Product.xaml
    /// </summary>
    public partial class Frm_AddCategories_Product : Window
    {
        public Frm_AddCategories_Product()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            else
            {
                var cate = new CrudCategories_Product()
                {
                    CategoryName = txtCategoryName.Text,
                    Description = txtDescription.Text
                };
                if (Categories_ProductRequest.createCategories_Product(cate) == true)
                {
                    MessageBox.Show("Them danh muc thuc don moi thanh cong!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Them danh muc thuc don moi that bai!");
                    this.Close();
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
