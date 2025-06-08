using FECoffe.DTO.CategoyMaterial;
using FECoffe.DTO.Material;
using FECoffe.DTO.Suppliers;
using FECoffe.Form;
using FECoffe.Form.FrmUpdate;
using FECoffe.Request.CategoryMaterial;
using FECoffe.Request.Material;
using FECoffe.Request.Supplier;
using System.Windows;
using FECoffe.Converter;

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
            loaddsMarerial();
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
            else MessageBox.Show("Loi khong doc duoc GetSupplier!!!!!!!");
        }
        public void loaddsMarerial()
        {
            var dsMarerial = MaterialRequest.GetMaterial();
            if (dsMarerial != null)
            {
                dgMaterials.ItemsSource = dsMarerial;
            }
            else MessageBox.Show("Loi khong doc duoc Material!!!!!!!");
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

        private void addMaterial_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddMaterials frm = new Frm_AddMaterials();
            frm.ShowDialog();
            loaddsMarerial();
        }

        private void deleteMaterial_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            var selectedMaterial = button.DataContext as CrudMaterial;

            if (selectedMaterial != null)
            {
                // Truyền dữ liệu sang window mới
                if (MaterialRequest.deleteMaterial(selectedMaterial.MaterialID) == true)
                {
                    MessageBox.Show("Xóa Thành Công Hang Hoa ");
                    loaddsMarerial();
                }
                else MessageBox.Show("Xóa Thất Bại Hang Hoa ");
            }

        }

        private void editMaterial_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            var selectedMaterial = button.DataContext as CrudMaterial;

            if (selectedMaterial != null)
            {
                // Truyền dữ liệu sang window mới
                var frm = new Material(selectedMaterial);
                frm.ShowDialog(); // hoặc Show()
                loaddsMarerial();
            }
        }
    }
}
