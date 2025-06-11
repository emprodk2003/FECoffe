using FECoffe.DTO.ExportDetail;
using FECoffe.DTO.ImportDetail;
using FECoffe.DTO.Lots;
using FECoffe.DTO.OrderToppingDetails;
using FECoffe.DTO.Product;
using FECoffe.DTO.ProductSize;
using FECoffe.DTO.Topping;
using FECoffe.Request.ProductSize;
using FECoffe.Request.Topping;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Frm_AddSizeToOrder.xaml
    /// </summary>
    public partial class Frm_AddSizeToOrder : Window
    {
        public ObservableCollection<CreateOrderToppingDetail> CreateOrderToppingDetails = new ObservableCollection<CreateOrderToppingDetail>();
        public ObservableCollection<OrderToppingDisplayModel> OrderToppingDisplayList { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
        public ProductSizeViewModel ProductSizeViewModel { get; set; }
        public int QuantitySize { get; set; }

        public Frm_AddSizeToOrder(ProductViewModel product)
        {
            InitializeComponent();
            ProductViewModel = product;
            txtProductName.Text=ProductViewModel.ProductName;
            OrderToppingDisplayList= new ObservableCollection<OrderToppingDisplayModel>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var list = ProductSizeRequest.GetByProduct(ProductViewModel.ProductID);
            if (list != null)
            {
                cbSize.ItemsSource = list;
            }
            else
                MessageBox.Show("Khong tim thay size");

            var toppings =ToppingRequest.GetAllTopping();
            if (toppings != null)
            {
                cbTopping.ItemsSource = toppings;
            }
            else
                MessageBox.Show("khong tim thay toppings");
            dgToppingDetails.ItemsSource = OrderToppingDisplayList;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (cbSize.SelectedItem is ProductSizeViewModel selectedSize)
            {
                if (int.TryParse(txtquantityprodutsize.Text, out int quantitySize) && quantitySize > 0)
                {
                    ProductSizeViewModel = selectedSize;
                    QuantitySize = quantitySize;

                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng size hợp lệ (> 0).");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn size.");
            }
        }

        private void Huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void luuTopping_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbTopping.SelectedItem is ToppingViewModel selectedTopping)
                {
                    if (int.TryParse(txtquantitytopping.Text, out int quantity))
                    {
                        var detail = new CreateOrderToppingDetail
                        {
                            ToppingID = selectedTopping.ToppingID,
                            Quantity = quantity,
                        };
                        CreateOrderToppingDetails.Add(detail);

                        var display = new OrderToppingDisplayModel
                        {
                            ToppingID = selectedTopping.ToppingID,
                            ToppingName = selectedTopping.ToppingName,
                            UnitPrice = selectedTopping.Price,
                            Quantity = quantity,
                            TotalPrice= quantity* selectedTopping.Price
                        };
                        OrderToppingDisplayList.Add(display);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đúng định dạng số cho số lượng .");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nguyên vật liệu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
