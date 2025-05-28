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

namespace FECoffe.AppUsed
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public class MenuItem
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string ImagePath { get; set; } // Đường dẫn hình ảnh
            public string Category { get; set; }
        }

        public class CartItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal Total => Quantity * Price;
        }

        private List<MenuItem> menuItems = new List<MenuItem>();
        private List<CartItem> cartItems = new List<CartItem>();
        public Order()
        {
            InitializeComponent();
            LoadMenuItems();
            MenuItemsList.ItemsSource = menuItems;
            CartItemsList.ItemsSource = cartItems;
        }
        private void LoadMenuItems()
        {
            // Thêm các món vào menu với hình ảnh
            menuItems.Add(new MenuItem { Name = "Cà phê đen", Category = "Cà phê", Price = 20000, ImagePath = "/Images/hinh-anh-ly-cafe-den-da-dep-5.jpg" });
            menuItems.Add(new MenuItem { Name = "Cà phê đen", Category = "Cà phê", Price = 20000, ImagePath = "/Images/hinh-anh-ly-cafe-den-da-dep-5.jpg" });
            menuItems.Add(new MenuItem { Name = "Cà phê đen", Category = "Cà phê", Price = 20000, ImagePath = "/Images/hinh-anh-ly-cafe-den-da-dep-5.jpg" });
            menuItems.Add(new MenuItem { Name = "Cà phê đen", Category = "Cà phê", Price = 20000, ImagePath = "/Images/hinh-anh-ly-cafe-den-da-dep-5.jpg" });
            menuItems.Add(new MenuItem { Name = "Cà phê đen", Category = "Tea", Price = 20000, ImagePath = "/Images/tradao.jpg" });
            menuItems.Add(new MenuItem { Name = "Cà phê đen", Category = "Tea", Price = 20000, ImagePath = "/Images/tradao.jpg" });
            menuItems.Add(new MenuItem { Name = "Cà phê đen", Category = "Tea", Price = 20000, ImagePath = "/Images/tradao.jpg" });
            menuItems.Add(new MenuItem { Name = "Cà phê đen", Category = "Tea", Price = 20000, ImagePath = "/Images/tradao.jpg" });
            menuItems.Add(new MenuItem { Name = "Cà phê đen", Category = "Tea", Price = 20000, ImagePath = "/Images/tradao.jpg" });

            var view = CollectionViewSource.GetDefaultView(menuItems);
            view.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            MenuItemsList.ItemsSource = view;
            MenuItemsList.Items.Refresh();
        }


        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (var item in cartItems)
            {
                total += item.Total;
            }
            TotalAmount.Text = total.ToString("C0");
        }

        private void AddToCartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MenuItemsList.SelectedItem is MenuItem selectedItem)
            {
                var existingItem = cartItems.Find(i => i.Name == selectedItem.Name);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    cartItems.Add(new CartItem
                    {
                        Name = selectedItem.Name,
                        Price = selectedItem.Price,
                        Quantity = 1
                    });
                }
                CartItemsList.Items.Refresh();
                UpdateTotal();
            }
        }

        private void ClearCartBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearCart();
        }

        private void ClearCart()
        {
            cartItems.Clear();
            CartItemsList.Items.Refresh();
            TotalAmount.Text = "0 đ";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
