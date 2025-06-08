using FECoffe.DTO.Categories_Product;
using FECoffe.DTO.OrderNumbertag;
using FECoffe.DTO.Product;
using FECoffe.DTO.ProductSize;
using FECoffe.DTO.Topping;
using FECoffe.Form;
using FECoffe.Form.FrmUpdate;
using FECoffe.Request.Categories_Product;
using FECoffe.Request.Employee;
using FECoffe.Request.Product;
using FECoffe.Request.ProductSize;
using FECoffe.Request.Table;
using FECoffe.Request.Topping;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FECoffe.Dashboards
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        public Product()
        {
            InitializeComponent();
        }
        private void hienthicategories_product()
        {
            var list = Categories_ProductRequest.GetAllCategories_Product();
            if (list != null)
            {
                dgCategories_Product.ItemsSource = list;
                cbCategories.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("Khong co du lieu cho danh muc thuc don!");
            }
        }
        private void hienthiproduct()
        {
            var list = ProductRequest.GetAllProduct();
            if (list != null)
            {
                dg_Product.ItemsSource = list;
                cb_Productsize.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("Khong co du lieu cho thuc don!");
            }
        }
        private void hienthitable()
        {
            var list = TableRequest.GetAllTable();
            if (list != null)
            {
                dg_Table.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("Khong co du lieu cho the order!");
            }
        }
        private void hienthitopping()
        {
            var list = ToppingRequest.GetAllTopping();
            if (list != null)
            {
                dg_Topping.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("Khong co du lieu cho topping!");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthicategories_product();
            hienthiproduct();
            hienthitable();
            hienthitopping();
        }

        private void edit_cateproduct_Click(object sender, RoutedEventArgs e)
        {
            var cate = dgCategories_Product.SelectedItem as Categories_ProductViewModel;
            Frm_Update_CategoriesProduct frm_Update_CategoriesProduct = new Frm_Update_CategoriesProduct(cate);
            frm_Update_CategoriesProduct.ShowDialog();
        }

        private void delete_cateproduct_Click(object sender, RoutedEventArgs e)
        {
            var cate = dgCategories_Product.SelectedItem as Categories_ProductViewModel;
            var result = MessageBox.Show(
                 "Bạn có chắc chắn muốn xóa danh muc thuc don này?",
                 "Xác nhận xóa",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning
             );

            if (result == MessageBoxResult.Yes)
            {
                if (Categories_ProductRequest.deleteCategories_Product(cate.CategoryID) == true)
                {
                    MessageBox.Show("Đã xóa danh muc thuc don.");
                }
                else MessageBox.Show("Loi khi xoa danh muc thuc don.");
            }
            else
            {

            }
        }

        private void edit_cProduct_Click(object sender, RoutedEventArgs e)
        {
            var pr = dg_Product.SelectedItem as ProductViewModel;
            Frm_Update_Product frm_Update_Product = new Frm_Update_Product(pr);
            frm_Update_Product.ShowDialog();
        }

        private void delete_Product_Click(object sender, RoutedEventArgs e)
        {
            var pro = dg_Product.SelectedItem as ProductViewModel;
            var result = MessageBox.Show(
                 "Bạn có chắc chắn muốn xóa thuc don này?",
                 "Xác nhận xóa",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning
             );

            if (result == MessageBoxResult.Yes)
            {
                if (ProductRequest.deleteProduct(pro.ProductID) == true)
                {
                    MessageBox.Show("Đã xóa thuc don.");
                }
                else MessageBox.Show("Loi khi xoa thuc don.");
            }
            else
            {

            }
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            hienthicategories_product();
            hienthiproduct();
            hienthitable();
            hienthitopping();
        }

        private void themCateProduct_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddCategories_Product frm_AddCategories_Product = new Frm_AddCategories_Product();
            frm_AddCategories_Product.ShowDialog();
        }

        private void themProduct_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddProduct frm_AddProduct = new Frm_AddProduct();
            frm_AddProduct.ShowDialog();
        }

        private void ThemTopping_CLick(object sender, RoutedEventArgs e)
        {
            Frm_AddTopping frm_AddTopping = new Frm_AddTopping();
            frm_AddTopping.ShowDialog();
        }

        private void delete_Topping_Click(object sender, RoutedEventArgs e)
        {
            var top = dg_Topping.SelectedItem as ToppingViewModel;
            var result = MessageBox.Show(
                 "Bạn có chắc chắn muốn xóa topping này?",
                 "Xác nhận xóa",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning
             );

            if (result == MessageBoxResult.Yes)
            {
                if (ToppingRequest.deleteTopping(top.ToppingID) == true)
                {
                    MessageBox.Show("Đã xóa topping.");
                }
                else MessageBox.Show("Loi khi xoa topping.");
            }
            else
            {

            }
        }

        private void edit_Topping_Click(object sender, RoutedEventArgs e)
        {
            var tp = dg_Topping.SelectedItem as ToppingViewModel;
            Frm_Update_Topping frm_Update_Topping = new Frm_Update_Topping(tp);
            frm_Update_Topping.ShowDialog();
        }

        private void themTable_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddOrderNumberTag frm_AddOrderNumberTag = new Frm_AddOrderNumberTag();
            frm_AddOrderNumberTag.ShowDialog();
        }

        private void delete_Table_Click(object sender, RoutedEventArgs e)
        {
            var top = dg_Table.SelectedItem as TableViewModel;
            var result = MessageBox.Show(
                 "Bạn có chắc chắn muốn xóa so the order này?",
                 "Xác nhận xóa",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning
             );

            if (result == MessageBoxResult.Yes)
            {
                if (TableRequest.deleteTable(top.TableID) == true)
                {
                    MessageBox.Show("Đã xóa so the order.");
                }
                else MessageBox.Show("Loi khi xoa so the order .");
            }
            else
            {

            }
        }

        private void edit_Table_Click(object sender, RoutedEventArgs e)
        {
            var table = dg_Table.SelectedItem as TableViewModel;
            Frm_Update_OrderNumberTag frm_Update_OrderNumberTag = new Frm_Update_OrderNumberTag(table);
            frm_Update_OrderNumberTag.ShowDialog();
        }

        private void GetSizeByProduct_Click(object sender, RoutedEventArgs e)
        {
            var pr = cb_Productsize.SelectedItem as ProductViewModel;
            if(pr == null)
            {
                MessageBox.Show("Vui long chon mon!");
                return;
            }
            else
            {
                var size = ProductSizeRequest.GetByProduct(pr.ProductID);
                dg_ProductSize.ItemsSource = size;
            }
        }

        private void themSize_Click(object sender, RoutedEventArgs e)
        {
            var pr = cb_Productsize.SelectedItem as ProductViewModel;
            if (pr == null)
            {
                MessageBox.Show("Vui long chon mon!");
                return;
            }
            else
            {
                Frm_AddProductSize _AddProductSize = new Frm_AddProductSize(pr);
                _AddProductSize.ShowDialog();
            }
        }

        private void edit_ProductSize_Click(object sender, RoutedEventArgs e)
        {
            var size = dg_ProductSize.SelectedItem as ProductSizeViewModel;
            Frm_Update_ProductSize frm_Update_ProductSize = new Frm_Update_ProductSize(size);
            frm_Update_ProductSize.ShowDialog();
        }

        private void delete_ProductSize_Click(object sender, RoutedEventArgs e)
        {
            var size = dg_ProductSize.SelectedItem as ProductSizeViewModel;
            var result = MessageBox.Show(
                 "Bạn có chắc chắn muốn xóa size này?",
                 "Xác nhận xóa",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning
             );

            if (result == MessageBoxResult.Yes)
            {
                if (ProductSizeRequest.deleteProduct(size.ProductSizeID) == true)
                {
                    MessageBox.Show("Đã xóa size cho mon.");
                }
                else MessageBox.Show("Loi khi xoa size cho mon .");
            }
            else
            {

            }
        }

        private void LoadData_Size_Click(object sender, RoutedEventArgs e)
        {
            var pr = cb_Productsize.SelectedItem as ProductViewModel;
            if (pr == null)
            {
                MessageBox.Show("Vui long chon mon!");
                return;
            }
            else
            {
                var size = ProductSizeRequest.GetByProduct(pr.ProductID);
                dg_ProductSize.ItemsSource = size;
            }
        }

        private void FindProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_FindName_Product.Text) && cbCategories.SelectedValue == null)
            {
                MessageBox.Show("Vui long nhap ten thuc don can tim");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txt_FindName_Product.Text) && cbCategories.SelectedValue != null)
            {
                var id = (int)cbCategories.SelectedValue;
                var list = ProductRequest.GetProductByCate(id);
                dg_Product.ItemsSource = list;
            }
            else if (!string.IsNullOrWhiteSpace(txt_FindName_Product.Text) && cbCategories.SelectedValue == null)
            {
                var name = txt_FindName_Product.Text;
                var list = ProductRequest.GetProductByName(name);
                dg_Product.ItemsSource = list;
            }
            else
            {
                var name = txt_FindName_Product.Text;
                var id = (int)cbCategories.SelectedValue;
                var list = ProductRequest.GetProductByCateandName(name, id);
                dg_Product.ItemsSource = list;
            }
        }

        private void FindCate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_FindCate.Text))
            {
                MessageBox.Show("Vui long nhap ten danh muc can tim");
                return;
            }
            else 
            {
                var name = txt_FindCate.Text;
                var list = Categories_ProductRequest.GetCategories_ProductByName(name);
                dgCategories_Product.ItemsSource = list;
            }
        }

        private void FindTable_CLick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_FindTable.Text))
            {
                MessageBox.Show("Vui long nhap ten ban can tim");
                return;
            }
            else
            {
                var name = txt_FindTable.Text;
                var list = TableRequest.GetTableByName(name);
                dg_Table.ItemsSource = list;
            }
        }

        private void FindTopping_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_FindTopping.Text))
            {
                MessageBox.Show("Vui long nhap ten topping can tim");
                return;
            }
            else
            {
                var name = txt_FindTopping.Text;
                var list = ToppingRequest.GetToppingByName(name);
                dg_Topping.ItemsSource = list;
            }
        }
    }
}
