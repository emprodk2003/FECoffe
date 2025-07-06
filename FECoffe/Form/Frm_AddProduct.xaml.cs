using FECoffe.DTO.Product;
using FECoffe.Request.Categories_Product;
using FECoffe.Request.Product;
using System.Windows;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddProduct.xaml
    /// </summary>
    public partial class Frm_AddProduct : Window
    {
        public Frm_AddProduct()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtCostPrice.Text) || string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtProductName.Text) || cbCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
            else if (!decimal.TryParse(txtCostPrice.Text, out decimal costPrice) || costPrice < 0)
            {
                MessageBox.Show("Giá vốn không hợp lệ!");
            }
            else if (!decimal.TryParse(txtPrice.Text, out decimal price) || costPrice < 0)
            {
                MessageBox.Show("Giá bán không hợp lệ!");
            }
            else
            {
                var pro = new CrudProduct()
                {
                    ProductName = txtProductName.Text,
                    CategoryID = (int)cbCategory.SelectedValue,
                    CostPrice = decimal.Parse(txtCostPrice.Text),
                    Price = decimal.Parse(txtPrice.Text),
                    Description = txtDescription.Text,
                    IsAvailable = chkIsAvailable.IsChecked.Value,
                    UrlImg = txtUrlImg.Text
                };
                if (ProductRequest.createProduct(pro) == true)
                {
                    MessageBox.Show("Thêm món mới thành công!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm món mới thất bại!");
                    this.Close();
                }
            }
        }
        private void hienthicategories_product()
        {
            var list = Categories_ProductRequest.GetAllCategories_Product();
            if (list != null)
            {
                cbCategory.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nào cho danh mục thực đơn!");
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthicategories_product();
        }
    }
}
