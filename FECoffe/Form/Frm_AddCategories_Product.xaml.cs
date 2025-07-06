using FECoffe.DTO.Categories_Product;
using FECoffe.Request.Categories_Product;
using System.Windows;

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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
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
                    MessageBox.Show("Thêm danh mục thực đơn mới thành công!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm danh mục thực đơn mới thất bại!");
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
