using FECoffe.DTO.Product;
using FECoffe.Request.Categories_Product;
using FECoffe.Request.Product;
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
    /// Interaction logic for Frm_Update_Product.xaml
    /// </summary>
    public partial class Frm_Update_Product : Window
    {
        private ProductViewModel _product;
        public Frm_Update_Product(ProductViewModel product)
        {
            InitializeComponent();
            _product = product;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCostPrice.Text) || string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtProductName.Text) || cbCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui long dien day du thong tin!");
            }
            else if (!decimal.TryParse(txtCostPrice.Text, out decimal costPrice))
            {
                MessageBox.Show("Giá vốn không hợp lệ!");
            }
            else if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá bán không hợp lệ!");
            }
            else
            {
                var pro = new ProductViewModel()
                {
                    ProductID = _product.ProductID,
                    ProductName = txtProductName.Text,
                    CategoryID = (int)cbCategory.SelectedValue,
                    CostPrice = decimal.Parse(txtCostPrice.Text),
                    Price = decimal.Parse(txtPrice.Text),
                    Description = txtDescription.Text,
                    IsAvailable = chkIsAvailable.IsChecked.Value,
                    UrlImg = txtUrlImg.Text
                };
                if (ProductRequest.updateProduct(pro) == true)
                {
                    MessageBox.Show("Sua thong tin thuc don moi thanh cong!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sua thong tin thuc don moi that bai!");
                    this.Close();
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                MessageBox.Show("Khong co du lieu cho danh muc thuc don!");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthicategories_product();
            if(_product != null)
            {
                txtCostPrice.Text = _product.CostPrice.ToString();
                txtDescription.Text = _product.Description;
                txtPrice.Text = _product.Price.ToString();
                txtProductName.Text = _product.ProductName;
                txtUrlImg.Text = _product.UrlImg;
                cbCategory.SelectedValue = _product.CategoryID;
                chkIsAvailable.IsChecked = _product.IsAvailable;
            }
        }
    }
}
