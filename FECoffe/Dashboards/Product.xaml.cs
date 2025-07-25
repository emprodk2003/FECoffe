﻿using FECoffe.DTO.Categories_Product;
using FECoffe.DTO.Ingredients;
using FECoffe.DTO.OrderNumbertag;
using FECoffe.DTO.Product;
using FECoffe.DTO.ProductSize;
using FECoffe.DTO.Recipes;
using FECoffe.DTO.Surcharges;
using FECoffe.DTO.Topping;
using FECoffe.Form;
using FECoffe.Form.FrmUpdate;
using FECoffe.Request.Categories_Product;
using FECoffe.Request.Employee;
using FECoffe.Request.Ingredients;
using FECoffe.Request.Product;
using FECoffe.Request.ProductSize;
using FECoffe.Request.Recipes;
using FECoffe.Request.Surcharges;
using FECoffe.Request.Table;
using FECoffe.Request.Topping;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                MessageBox.Show("Không có dữ liệu cho danh mục thực đơn!");
            }
        }
        private void hienthiproduct()
        {
            var list = ProductRequest.GetAllProduct();
            if (list != null)
            {
                dg_Product.ItemsSource = list;
                cb_Productsize.ItemsSource = list;
                cbFind_Product_Recieps.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu cho tực đơn!");
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
                MessageBox.Show("Không có dữ liệu cho thẻ order!");
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
                MessageBox.Show("Không có dữ liệu cho topping!");
            }
        }
        private void hienthiproductsize()
        {
            var size = ProductSizeRequest.GetAll();
            
            if (size != null)
            {
                dg_ProductSize.ItemsSource = size;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu cho product size!");
            }
        }

        private void hienthinguyenlieu()
        {
            var list = IngredientsRequest.GetAll();

            if (list != null)
            {
                dg_Ingredients.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu chho nguyên liệu!");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthicategories_product();
            hienthiproduct();
            hienthitable();
            hienthitopping();
            hienthiproductsize();
            hienthinguyenlieu();
            hienthiphuthu();
        }

        private void edit_cateproduct_Click(object sender, RoutedEventArgs e)
        {
            var cate = dgCategories_Product.SelectedItem as Categories_ProductViewModel;
            Frm_Update_CategoriesProduct frm_Update_CategoriesProduct = new Frm_Update_CategoriesProduct(cate);
            var result = frm_Update_CategoriesProduct.ShowDialog();
            if(result == true)
            {
                hienthicategories_product();
            }
        }

        private void delete_cateproduct_Click(object sender, RoutedEventArgs e)
        {
            var cate = dgCategories_Product.SelectedItem as Categories_ProductViewModel;
            var result = MessageBox.Show(
                 "Bạn có chắc chắn muốn xóa danh mục thực đơn này?",
                 "Xác nhận xóa",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning
             );

            if (result == MessageBoxResult.Yes)
            {
                var pr = Categories_ProductRequest.GetProductByID(cate.CategoryID);
                if(pr.Count == 0)
                {
                    if (Categories_ProductRequest.deleteCategories_Product(cate.CategoryID) == true)
                    {
                        MessageBox.Show("Đã xóa danh mục thực đơn.");
                        hienthicategories_product();
                    }
                    else MessageBox.Show("Lỗi khi xóa danh mục thực đơn!");
                }
                else
                {
                    MessageBox.Show("Đã có món thuộc danh mục này không thể xóa!");
                    return;
                }
               
            }
            else
            {

            }
        }

        private void edit_cProduct_Click(object sender, RoutedEventArgs e)
        {
            var pr = dg_Product.SelectedItem as ProductViewModel;
            Frm_Update_Product frm_Update_Product = new Frm_Update_Product(pr);
            var result = frm_Update_Product.ShowDialog();
            if(result == true)
            {
                hienthiproduct();
            }
        }

        private void delete_Product_Click(object sender, RoutedEventArgs e)
        {
            var pro = dg_Product.SelectedItem as ProductViewModel;
            var result = MessageBox.Show(
                 "Bạn có chắc chắn muốn xóa thực đơn này?",
                 "Xác nhận xóa",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning
             );

            if (result == MessageBoxResult.Yes)
            {
                var bill = ProductRequest.GetBillByID(pro.ProductID);
                if(bill.Count == 0)
                {
                    if (ProductRequest.deleteProduct(pro.ProductID) == true)
                    {
                        MessageBox.Show("Đã xóa thực đơn.");
                        hienthiproduct();
                    }
                    else MessageBox.Show("Lỗi khi xóa thực đơn!");
                }
                else
                {
                    MessageBox.Show("Món đã tồn tại trong đơn hàng nên không thể xóa món!");
                }
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
            hienthinguyenlieu();
            hienthitopping();
            hienthiphuthu();
        }

        private void themCateProduct_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddCategories_Product frm_AddCategories_Product = new Frm_AddCategories_Product();
            var result = frm_AddCategories_Product.ShowDialog();
            if (result == true)
            {
                hienthicategories_product();
            }
        }

        private void themProduct_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddProduct frm_AddProduct = new Frm_AddProduct();
            var result = frm_AddProduct.ShowDialog();
            if (result == true)
            {
                hienthiproduct();
            }
        }

        private void ThemTopping_CLick(object sender, RoutedEventArgs e)
        {
            Frm_AddTopping frm_AddTopping = new Frm_AddTopping();
            var result = frm_AddTopping.ShowDialog();
            if(result == true)
            {
                hienthitopping();
            }
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
                var bill = ToppingRequest.GetBillByID(top.ToppingID);
                if(bill.Count == 0)
                {
                    if (ToppingRequest.deleteTopping(top.ToppingID) == true)
                    {
                        MessageBox.Show("Đã xóa topping.");
                        hienthitopping();
                    }
                    else MessageBox.Show("Lỗi khi xóa topping!");
                }
                else
                {
                    MessageBox.Show("Topping đã tồn tại trong đơn hàng nên không thể xóa topping!");
                }
                
            }
            else
            {

            }
        }

        private void edit_Topping_Click(object sender, RoutedEventArgs e)
        {
            var tp = dg_Topping.SelectedItem as ToppingViewModel;
            Frm_Update_Topping frm_Update_Topping = new Frm_Update_Topping(tp);
            var result = frm_Update_Topping.ShowDialog();
            if (result == true)
            {
                hienthitopping();
            }
        }

        private void themTable_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddOrderNumberTag frm_AddOrderNumberTag = new Frm_AddOrderNumberTag();
            var result = frm_AddOrderNumberTag.ShowDialog();
            if(result == true)
            {
                hienthitable();
            }
        }

        private void delete_Table_Click(object sender, RoutedEventArgs e)
        {
            var top = dg_Table.SelectedItem as TableViewModel;
            var result = MessageBox.Show(
                 "Bạn có chắc chắn muốn xóa số thẻ orders này?",
                 "Xác nhận xóa",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning
             );

            if (result == MessageBoxResult.Yes)
            {
                var table = TableRequest.GetBillByID(top.TableID);
                if(table.Count == 0)
                {
                    if (top.Status == Enum.TableStatus.Occupied)
                    {
                        MessageBox.Show("Thẻ đang sử dụng không được xóa!.");
                    }
                    else if (TableRequest.deleteTable(top.TableID) == true)
                    {
                        MessageBox.Show("Đã xóa số thẻ orders này.");
                        hienthitable();
                    }
                    else MessageBox.Show("Lỗi khi xóa số thẻ orders.");
                }
                else
                {
                    MessageBox.Show("Thẻ đax tồn tại trong đơn hàng nên không được xóa!.");
                    return;
                }
            }
            else
            {

            }
        }

        private void edit_Table_Click(object sender, RoutedEventArgs e)
        {
            var table = dg_Table.SelectedItem as TableViewModel;
            Frm_Update_OrderNumberTag frm_Update_OrderNumberTag = new Frm_Update_OrderNumberTag(table);
            var result = frm_Update_OrderNumberTag.ShowDialog();
            if (result == true)
            {
                hienthitable();
            }
        }

        private void GetSizeByProduct_Click(object sender, RoutedEventArgs e)
        {
            if(cb_Productsize.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn món!");
                return;
            }
            else
            {
                var pr = (int)cb_Productsize.SelectedValue;
                var list = ProductSizeRequest.GetByProduct(pr);
                if(list != null)
                {
                    dg_ProductSize.ItemsSource = list;
                }
            }
        }

        private void themSize_Click(object sender, RoutedEventArgs e)
        {
            var pr = cb_Productsize.SelectedItem as ProductViewModel;
            if (pr == null)
            {
                MessageBox.Show("Vui lòng chọn món!");
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
            var result = frm_Update_ProductSize.ShowDialog();
            if(result == true)
            {
                hienthiproductsize();
            }
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
                    MessageBox.Show("Đã xóa kích cỡ món thành công.");
                    hienthiproductsize();
                }
                else MessageBox.Show("Lỗi khi xóa kích cỡ món!");
            }
            else
            {

            }
        }

        private void LoadData_Size_Click(object sender, RoutedEventArgs e)
        {
            hienthiproductsize();
        }

        private void FindProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_FindName_Product.Text) && cbCategories.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập tên món cần tìm!");
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
                MessageBox.Show("Vui lòng nhập tên danh mục cần tìm!");
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
                MessageBox.Show("Vui lòng nhập tên số thẻ cần tìm!");
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
                MessageBox.Show("Vui longf nhập tên topping cần tìm!");
                return;
            }
            else
            {
                var name = txt_FindTopping.Text;
                var list = ToppingRequest.GetToppingByName(name);
                dg_Topping.ItemsSource = list;
            }
        }

        private void Back_main_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Close();
            dashboard.Show();
        }

        private void FindIngredients_Click(object sender, RoutedEventArgs e)
        {
            var name = txt_FindIngredients.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên nguyên liệu!");
            }
            else
            {
                var list = IngredientsRequest.GetByName(name);
                if (list != null)
                {
                    dg_Ingredients.ItemsSource = list;
                }
            }           
        }

        private void ThemIngredients_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddIngredients frm_AddIngredients = new Frm_AddIngredients();
            var result = frm_AddIngredients.ShowDialog();
            if(result == true)
            {
                hienthinguyenlieu();
            }
        }

        private void delete_Ingredients_Click(object sender, RoutedEventArgs e)
        {
            var item = dg_Ingredients.SelectedItem as IngredientsViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa nguyên liệu này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (IngredientsRequest.delete(item.Id) == true)
                {
                    MessageBox.Show("Đã xóa nguyên liệu.");
                    hienthinguyenlieu();
                }
                else MessageBox.Show("Lỗi khi xóa nguyên liệu .");
            }
            else
            {

            }
        }

        private void edit_Ingredients_Click(object sender, RoutedEventArgs e)
        {
            var item = dg_Ingredients.SelectedItem as IngredientsViewModel;
            Frm_Update_Ingredients frm_Update_Ingredients = new Frm_Update_Ingredients(item);
            var result = frm_Update_Ingredients.ShowDialog();
            if(result == true)
            {
                hienthinguyenlieu();
            }
        }

        private void cbFind_Product_Recieps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbFind_Product_Recieps.SelectedValue != null){
                var pr = (int)cbFind_Product_Recieps.SelectedValue;
                var size = ProductSizeRequest.GetByProduct(pr);
                if (size != null)
                {
                    cbFind_ProductSize_Recieps.ItemsSource = size;
                }
            }
        }

        private void edit_Recipes_Click(object sender, RoutedEventArgs e)
        {
            var pr = cbFind_Product_Recieps.SelectedItem as ProductViewModel;
            var size = cbFind_ProductSize_Recieps.SelectedItem as ProductSizeViewModel;
            var recipes = dg_Recipes.SelectedItem as RecipesViewModel;
            if (pr == null || size == null)
            {
                MessageBox.Show("Vui lòng chọn món và kích thước!");
            }
            else
            {
                Frm_Update_Recipes frm_Update_Recipes = new Frm_Update_Recipes(pr, size, recipes);
                var result = frm_Update_Recipes.ShowDialog();
                if(result == true)
                {
                    Load_Recipes();
                }
            }
        }

        private void delete_Recipes_Click(object sender, RoutedEventArgs e)
        {
            var item = dg_Recipes.SelectedItem as RecipesViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa định lượng này của thực đơn?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (RecipesRequest.delete(item.RecipeID) == true)
                {
                    MessageBox.Show("Đã xóa định lượng này của thực đơn.");
                    Load_Recipes();
                }
                else MessageBox.Show("Loi khi xóa định lượng này của thực đơn .");
            }
            else
            {

            }
        }

        private void Find_Recipes(object sender, RoutedEventArgs e)
        {
            Load_Recipes();
        }
        private void Load_Recipes()
        {
            if (cbFind_Product_Recieps.SelectedItem == null || cbFind_ProductSize_Recieps.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn món và kích thước!");
            }
            else
            {
                int pr = (int)cbFind_Product_Recieps.SelectedValue;
                int size = (int)cbFind_ProductSize_Recieps.SelectedValue;
                var list = RecipesRequest.GetByProduct(size);
                if (list != null)
                {
                    dg_Recipes.ItemsSource = list;
                }
            }
        }

        private void Them_Recieps(object sender, RoutedEventArgs e)
        {
            var pr = cbFind_Product_Recieps.SelectedItem as ProductViewModel;
            var size = cbFind_ProductSize_Recieps.SelectedItem as ProductSizeViewModel;
            if(pr == null || size == null){
                MessageBox.Show("Vui lòng chọn món và kích thước!");
            }
            Frm_AddRecipes frm_AddRecipes = new Frm_AddRecipes(pr,size);
            var result = frm_AddRecipes.ShowDialog();
            if(result == true)
            {
                Load_Recipes();
            }
        }

        private void hienthiphuthu()
        {
            var list = SurchargesRequest.GetAll();
            if(list != null)
            {
                dg_Surcharges.ItemsSource = list;
            }
        }

        private void FindSurcharges_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_FindSurcharges.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khoác tìm kiếm!");
                return;
            }
            else
            {
                var list = SurchargesRequest.GetByName(txt_FindSurcharges.Text);
                if(list != null)
                {
                    dg_Surcharges.ItemsSource = list;
                }
            }
        }

        private void ThemSurcharges_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddSurcharges frm_Add = new Frm_AddSurcharges();
            var resuft = frm_Add.ShowDialog();
            if(resuft == true)
            {
                hienthiphuthu();
            }
        }

        private void edit_Surcharges_Click(object sender, RoutedEventArgs e)
        {
            var sur = dg_Surcharges.SelectedItem as SurchargesViewModel;
            Frm_Update_Surcharges frm_Update_ = new Frm_Update_Surcharges(sur);
            var resuft = frm_Update_.ShowDialog();
            if(resuft == true)
            {
                hienthiphuthu();
            }
        }

        private void delete_Surcharges_Click(object sender, RoutedEventArgs e)
        {
            var item = dg_Surcharges.SelectedItem as SurchargesViewModel;
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa loại phụ thu này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                if (SurchargesRequest.delete(item.ID) == true)
                {
                    MessageBox.Show("Đã xóa loại phụ thu này.");
                    hienthiphuthu();
                }
                else MessageBox.Show("Lỗi khi xóa loại phụ thu.");
            }
            else
            {

            }
        }
    }
}
