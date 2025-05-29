using FECoffe.DTO.CategoyMaterial;
using FECoffe.DTO.Suppliers;
using FECoffe.DTO.User;
using FECoffe.Form;
using FECoffe.Form.FrmUpdate;
using FECoffe.Form.User;
using FECoffe.Request.CategoryMaterial;
using FECoffe.Request.Supplier;
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

namespace FECoffe.Dashboards
{
    /// <summary>
    /// Interaction logic for Warehouse.xaml
    /// </summary>
    public partial class Warehouse : Window
    {
        public Warehouse()
        {
            InitializeComponent();
        }

        private void addcategorymaterial_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddCategories_Material frm= new Frm_AddCategories_Material();
            frm.ShowDialog();
            loaddsCate();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loaddsCate();
            loaddsSuppliers();
        }
        public void loaddsCate()
        {
            var dsCategoryMaterial = CategoryMaterialRequest.GetCategoryMaterial();
            if (dsCategoryMaterial != null)
            {
                dg_categorymaterial.ItemsSource = dsCategoryMaterial;
            }
            else MessageBox.Show("Loi khong doc duoc CategoryMaterial!!!!!!!");
        }
        public void loaddsSuppliers()
        {
            var dsSuppliers = SupplierRequest.GetSupplier();
            if (dsSuppliers != null)
            {
                dgSuppliers.ItemsSource = dsSuppliers;
            }
            else MessageBox.Show("Loi khong doc duoc CategoryMaterial!!!!!!!");
        }
        private void BackToHome_Click(object sender, RoutedEventArgs e)
        {
            Dashboard home= new Dashboard();
            home.Show();
            this.Close();
        }

        private void editcategory_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            var selectedCate = button.DataContext as CrudCategoryMaterial;

            if (selectedCate != null)
            {
                // Truyền dữ liệu sang window mới
                var addrole = new Categorys_Material(selectedCate);
                addrole.ShowDialog(); // hoặc Show()
                loaddsCate();
            }
        }

        private void deletecategory_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            var selectedCate = button.DataContext as CrudCategoryMaterial;

            if (selectedCate != null)
            {
                // Truyền dữ liệu sang window mới
               if(CategoryMaterialRequest.deleteCategoryMaterial(selectedCate.CategoryID)==true)
                {
                    MessageBox.Show("Xóa Thành Công danh mục hàng hóa ");
                    loaddsCate();
                }
                else MessageBox.Show("Xóa Thất Bại danh mục hàng hóa ");

            }
        }

        private void editsuppliers_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            var selectedSuppliers = button.DataContext as CrudSuppliers;

            if (selectedSuppliers != null)
            {
                // Truyền dữ liệu sang window mới
                var frm = new Suppliers(selectedSuppliers);
                frm.ShowDialog(); // hoặc Show()
                loaddsSuppliers();
            }
        }

        private void deletesuppliers_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            var selectedSuppliers = button.DataContext as CrudSuppliers;

            if (selectedSuppliers != null)
            {
                // Truyền dữ liệu sang window mới
                if (SupplierRequest.deleteSupplier(selectedSuppliers.SupplierID) == true)
                {
                    MessageBox.Show("Xóa Thành Công nhà cung cấp ");
                    loaddsSuppliers();
                }
                else MessageBox.Show("Xóa Thất Bại nhà cung cấp ");

            }
        }

        private void addsuppliers_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddSuppliers frm = new Frm_AddSuppliers();
            frm.ShowDialog();
            loaddsSuppliers();
        }
    }
}
