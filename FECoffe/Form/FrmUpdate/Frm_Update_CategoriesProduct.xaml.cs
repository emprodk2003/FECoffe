using FECoffe.DTO.Categories_Product;
using FECoffe.Request.Categories_Product;
using System.Windows;

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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
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
                    MessageBox.Show("Sửa thông tin danh mục thành công.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin danh mục thất bại!");
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
