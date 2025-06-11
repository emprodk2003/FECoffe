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

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Frm_Update_CategoriesProduct.xaml
    /// </summary>
    public partial class Frm_Update_CategoriesProduct : Window
    {
        private Categories_ProductViewModel _categories;
        public Frm_Update_CategoriesProduct(Categories_ProductViewModel categories)
        {
            InitializeComponent();
            _categories = categories;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui long nhap day du thong tin!");
            }
            else
            {
                var cate = new Categories_ProductViewModel()
                {
                    CategoryID = _categories.CategoryID,
                    Description = txtDescription.Text,
                    CategoryName = txtCategoryName.Text
                };
                if (Categories_ProductRequest.updateCategories_Product(cate) == true)
                {
                    MessageBox.Show("Sua thong danh muc thanh cong!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sua thong danh muc that bai!");
                    this.Close();
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(_categories != null)
            {
                txtCategoryName.Text = _categories.CategoryName;
                txtDescription.Text = _categories.Description;
            }
        }
    }
}
