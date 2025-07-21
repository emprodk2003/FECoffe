using FECoffe.DTO.OrderDetails;
using FECoffe.DTO.OrderNumbertag;
using FECoffe.DTO.Orders;
using FECoffe.DTO.OrderToppingDetails;
using FECoffe.DTO.Product;
using FECoffe.DTO.Surcharges;
using FECoffe.Form;
using FECoffe.Form.FrmDisplay;
using FECoffe.Request.Employee;
using FECoffe.Request.Orders;
using FECoffe.Request.Positions;
using FECoffe.Request.Product;
using FECoffe.Request.Surcharges;
using FECoffe.Request.Table;
using FECoffe.Request.Topping;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

namespace FECoffe.AppUsed
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        string userID;
        public SurchargesViewModel surcharges { get; set; } = new SurchargesViewModel();
        public TableViewModel ViewModel { get; set; }
        public CreateOrderDTO CreateOrderDTO { get; set; }
        public CreateOrderDetailsDTO CreateOrderDetailsDTO{ get; set; }
        public CreateOrderToppingDetail CreateOrderToppingDetail { get; set; }
        public ObservableCollection<CartItem> CartItems { get; set; } = new ObservableCollection<CartItem>();

        public Order(TableViewModel tableView)
        {
            InitializeComponent();
            ViewModel = tableView;
            LoadMenuItems();
            CartItemsList.ItemsSource = CartItems;
            var app = (App)Application.Current;
            userID = app.IdUser;

        }
        public void LoadMenuItems()
        {
            var list = ProductRequest.GetAllProductIsVailable();
            var view = CollectionViewSource.GetDefaultView(list);//CollectionView là một lớp cung cấp các tính năng như lọc (filter), sắp xếp (sorting),
                                                                 //và phân trang (grouping) khi hiển thị dữ liệu trong giao diện (UI).
            view.GroupDescriptions.Add(new PropertyGroupDescription("Category_Name")); // group theo danh mục của sản phẩm
            MenuItemsList.ItemsSource = view;
            MenuItemsList.Items.Refresh();
        }



        private void UpdateTotalAmount()
        {
            decimal total = CartItems.Sum(item => item.Total);

            // Nếu có discount, xử lý luôn ở đây nếu muốn
            TotalAmount.Text = $"{total:N0} đ";
            decimal discount = 0;
            decimal.TryParse(txtDiscount.Text.Replace("%", ""), out discount);

            decimal thanhtien = total + (total * discount / 100);
            TotalAmountFinal.Text = thanhtien.ToString("N0");
        }

        private void addSizeProduct_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as FrameworkElement;
            var selectedProduct = item.DataContext as ProductViewModel;
            if (selectedProduct != null)
            {
                var opensize = new Frm_AddSizeToOrder(selectedProduct);
                bool? result = opensize.ShowDialog();
                if (result == true 
                    && opensize.ProductSizeViewModel != null
                    && opensize.QuantitySize > 0)

                {
                    //  Nhận lại size đã chọn
                    var selectedSize = opensize.ProductSizeViewModel;
                    var sizeQuantity = opensize.QuantitySize;
                    var listtopping = opensize.CreateOrderToppingDetails;



                    // Tính tổng giá topping
                    decimal totalToppingPrice = 0;
                    string toppingNames = "";
                    foreach (var topping in listtopping)
                    {
                        // Giả sử bạn có phương thức lấy topping theo ID
                        var toppingInfo = ToppingRequest.GetToppingById(topping.ToppingID);
                        var toppingTotal = topping.Quantity * toppingInfo.Price;

                        totalToppingPrice += toppingTotal;
                        toppingNames += $"{toppingInfo.ToppingName} ({topping.Quantity})\n";
                    }
                    if (toppingNames.EndsWith("\n"))
                        toppingNames = toppingNames[..^1];


                    // Giá mỗi phần: size + topping
                    decimal pricePerItem = selectedSize.AdditionalPrice + totalToppingPrice + selectedProduct.Price;
                    decimal total = pricePerItem * sizeQuantity;
                    var cartItem = new CartItem
                    {
                        Name = $"{selectedProduct.ProductName} - Size {selectedSize.SizeName}",
                        Topping = toppingNames,
                        Quantity = sizeQuantity,
                        Price = selectedProduct.Price,
                        Total = total,
                        ProductID = selectedProduct.ProductID,
                        ProductSizeID = selectedSize.ProductSizeID,
                        Toppings = listtopping.ToList()
                    };

                    CartItems.Add(cartItem);
                    //MessageBox.Show(message, "Thông tin đã chọn");
                    UpdateTotalAmount();
                }
            }
        }

        private void CheckoutBtn_Click(object sender, RoutedEventArgs e)
        {
           if(CartItems.Count > 0)
            {
                var employess = EmployeeRequest.GetEmloyeeByUserId(Guid.Parse(userID));
                var cartItems = CartItemsList.ItemsSource as IEnumerable<CartItem>;
                var listOrderDetail = new List<CreateOrderDetailsDTO>();

                foreach (var item in cartItems)
                {
                    var detail = new CreateOrderDetailsDTO
                    {
                        SizeID = item.ProductSizeID,
                        Quantity = item.Quantity,
                        OrderToppingDetails = item.Toppings,
                        ProductID = item.ProductID,
                    };

                    listOrderDetail.Add(detail);
                }

                decimal discount = 0;
                decimal.TryParse(txtDiscount.Text.Replace("%", ""), out discount);

                var codeOrder = OrderRequest.genCodeOrder();

                var neworder = new CreateOrderDTO()
                {
                    Discount = discount,
                    EmployeeID = employess.EmployeeID,
                    OrderDate = DateTime.Now,
                    orderDetails = listOrderDetail,
                    PaymentStatus = 1,
                    TableNumberID = ViewModel.TableID,
                    CodeOrder=codeOrder,
                };

                if (OrderRequest.createOrder(neworder) == true)
                {
                    var window = new InvoicePreviewWindow(cartItems, employess.FullName, discount);
                    window.ShowDialog();
                    MessageBox.Show("Thanh toán thành công.");
                    var table = TableRequest.GetTableById(ViewModel.TableID);
                    var updatetable = TableRequest.updateTableByStatus(table.TableID, 1);
                    var theBagWindow = new TheBagNumber();
                    theBagWindow.Show();

                    this.Close();
                }
                else
                    MessageBox.Show("Thanh toán đơn hàng thất bại!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món để thanh toán!");         
            }

        }

        private void exit_CLick(object sender, RoutedEventArgs e)
        {
           
        }

        private void Delete_ProductClick(object sender, RoutedEventArgs e)
        {
            var item = CartItemsList.SelectedItem as CartItem;
            if(item == null)
            {
                MessageBox.Show("Vui lòng chọn món để xóa!");
            }
            else
            {
                CartItems.Remove(item);
                CartItemsList.ItemsSource = CartItems;
            }
        }

        private void ThanhTienBtn_Click(object sender, RoutedEventArgs e)
        {
            decimal total = CartItems.Sum(item => item.Total);

            decimal discount = 0;
            decimal.TryParse(txtDiscount.Text.Replace("%", ""), out discount);
           
            decimal thanhtien = total + (total*discount/100);
            TotalAmountFinal.Text = thanhtien.ToString();
        }

        private void TaoQRBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CartItems.Count > 0)
            {
                var employess = EmployeeRequest.GetEmloyeeByUserId(Guid.Parse(userID));
                var cartItems = CartItemsList.ItemsSource as IEnumerable<CartItem>;
                var listOrderDetail = new List<CreateOrderDetailsDTO>();

                foreach (var item in cartItems)
                {
                    var detail = new CreateOrderDetailsDTO
                    {
                        SizeID = item.ProductSizeID,
                        Quantity = item.Quantity,
                        OrderToppingDetails = item.Toppings,
                        ProductID = item.ProductID,
                    };

                    listOrderDetail.Add(detail);
                }
                decimal total = CartItems.Sum(item => item.Total);
                decimal discount = 0;
                decimal.TryParse(txtDiscount.Text.Replace("%", ""), out discount);

                decimal thanhtien = total + (total * discount / 100);
                var codeOrder = OrderRequest.genCodeOrder();
                var neworder = new CreateOrderDTO()
                {
                    Discount = discount,
                    EmployeeID = employess.EmployeeID,
                    OrderDate = DateTime.Now,
                    orderDetails = listOrderDetail,
                    PaymentStatus = 0,
                    TableNumberID = ViewModel.TableID,
                    CodeOrder = codeOrder,
                };
              


                if (OrderRequest.createOrder(neworder) == true)
                {
                    MessageBox.Show("Xác nhận khách hàng chuyển khoản và tạo mã QR. ");
                    var frm = new Frm_CreateQR(neworder, thanhtien,ViewModel);
                    var resuft = frm.ShowDialog();
                    if(resuft == true)
                    {
                        var window = new InvoicePreviewWindow(cartItems, employess.FullName, discount);
                        window.ShowDialog();
                        var theBagWindow = new TheBagNumber();
                        theBagWindow.Show();
                    }
                    else if (resuft == false)
                    {
                        var theBagWindow = new TheBagNumber();
                        theBagWindow.Show();
                        this.Close();
                        MessageBox.Show("Đã hủy đơn hàng.");
                    }
                    
                }
                else
                    MessageBox.Show("Thanh toán đơn hàng thất bại! ");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món để thanh toán!");
            }
          
        }

        private void BackToHome_Click(object sender, RoutedEventArgs e)
        {
            var tag = new TheBagNumber();
            this.Close();
            tag.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var date = DateTime.Now;
            var sur = SurchargesRequest.GetByToDay(date);
            if(sur != null)
            {
                txtDiscount.Text = sur.SurchargesValue.ToString()+"%";
            }
        }
    }
}
