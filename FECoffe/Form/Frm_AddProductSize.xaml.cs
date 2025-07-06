using FECoffe.DTO.Product;
using FECoffe.DTO.ProductSize;
using FECoffe.Request.ProductSize;
using System.Windows;

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddProductSize.xaml
    /// </summary>
    public partial class Frm_AddProductSize : Window
    {
        private ProductViewModel _product;
        public Frm_AddProductSize(ProductViewModel product)
        {
            InitializeComponent();
            _product = product;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtSizeName.Text) || string.IsNullOrWhiteSpace(txtAdditionalPrice.Text))
            {
                MessageBox.Show("Vui lòng điền đẩy đủ thông tin!");
            }
            else if (!decimal.TryParse(txtAdditionalPrice.Text, out decimal AdditionalPrice) || AdditionalPrice < 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!");
                return;
            }
            else
            {
                var size = new CrudProductSize()
                {
                    ProductID = _product.ProductID,
                    SizeName = txtSizeName.Text,
                    AdditionalPrice = decimal.Parse(txtAdditionalPrice.Text)
                };
                if (ProductSizeRequest.createProduct(size) == true)
                {
                    MessageBox.Show("Thêm size cho" + _product.ProductName + "thành công.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm size cho" + _product.ProductName + "thất bại.");
                    this.Close();
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_product != null)
            {
                txtProduct.Text = _product.ProductName;
            }
        }
    }
}
