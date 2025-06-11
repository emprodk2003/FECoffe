using FECoffe.Dashboards;
using FECoffe.DTO.ProductSize;
using FECoffe.Request.ProductSize;
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
    /// Interaction logic for Frm_Update_ProductSize.xaml
    /// </summary>
    public partial class Frm_Update_ProductSize : Window
    {
        private ProductSizeViewModel _size;
        public Frm_Update_ProductSize(ProductSizeViewModel size)
        {
            InitializeComponent();
            _size = size;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSizeName.Text) || string.IsNullOrWhiteSpace(txtAdditionalPrice.Text))
            {
                MessageBox.Show("Vui long dien thong tin!");
            }
            else if (!decimal.TryParse(txtAdditionalPrice.Text, out decimal AdditionalPrice) || AdditionalPrice < 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!");
                return;
            }
            else
            {
                var size = new ProductSizeViewModel()
                {
                    ProductID = _size.ProductID,
                    ProductSizeID = _size.ProductSizeID,
                    SizeName = txtSizeName.Text,
                    AdditionalPrice = decimal.Parse(txtAdditionalPrice.Text)
                };
                if (ProductSizeRequest.updateProduct(size) == true)
                {
                    MessageBox.Show("Sua thong tin size cho" + _size.ProductName + "thanh cong.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sua thong tin size cho" + _size.ProductName + "that bai.");
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
            if (_size != null)
            {
                txtAdditionalPrice.Text = _size.AdditionalPrice.ToString();
                txtProduct.Text = _size.ProductName;
                txtSizeName.Text = _size.SizeName;
            }
        }
    }
}
