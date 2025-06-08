using FECoffe.Converter;
using FECoffe.DTO.CategoyMaterial;
using FECoffe.DTO.ExportReceipts;
using FECoffe.DTO.ImportReceipts;
using FECoffe.DTO.Material;
using FECoffe.DTO.Suppliers;
using FECoffe.Form;
using FECoffe.Form.FrmDisplay;
using FECoffe.Form.FrmUpdate;
using FECoffe.Request.CategoryMaterial;
using FECoffe.Request.ExportReceipts;
using FECoffe.Request.ImportReceipts;
using FECoffe.Request.Lots;
using FECoffe.Request.Material;
using FECoffe.Request.Supplier;
using System.Windows;
using System.Windows.Controls;

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
            Frm_AddCategories_Material frm = new Frm_AddCategories_Material();
            frm.ShowDialog();
            loaddsCate();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loaddsCate();
            loaddsSuppliers();
            loaddsMarerial();
            loaddsImport();
            loaddsExport();
            loadLotDetails();
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

        public void loaddsImport()
        {
            var dsImportReceipts = ImportReceiptsRequest.GetImportReceipts();
            if (dsImportReceipts != null)
            {
                dgImportReceipts.ItemsSource = dsImportReceipts;
            }
            else MessageBox.Show("Loi khong doc duoc ImportReceipts!!!!!!!");
        }

        public void loaddsExport()
        {
            var dsExportReceipts = ExportReceiptsRequest.GetExportReceipts();
            if (dsExportReceipts != null)
            {
                dgExportReceipts.ItemsSource = dsExportReceipts;
            }
            else MessageBox.Show("Loi khong doc duoc dsExportReceipts!!!!!!!");
        }
        public void loadLotDetails()
        {
            var dsLotDetails = LotsRequest.GetLotDetails();
            if (dsLotDetails != null)
            {
                dgInventoryLogs.ItemsSource = dsLotDetails;
            }
            else MessageBox.Show("Loi khong doc duoc dsLotDetails!!!!!!!");
        }
        private void BackToHome_Click(object sender, RoutedEventArgs e)
        {
            Dashboard home = new Dashboard();
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
                if (CategoryMaterialRequest.deleteCategoryMaterial(selectedCate.CategoryID) == true)
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

        private void addImport_Click(object sender, RoutedEventArgs e)
        {
            Frm_AddImportReceipts frm = new Frm_AddImportReceipts();
            frm.ShowDialog();
            loaddsImport();
        }

        private void dgMaterials_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedMaterial = dgMaterials.SelectedItem as CrudMaterial;
            DisplayLot frm = new DisplayLot(selectedMaterial);
            frm.ShowDialog();
        }

        private void AddExport_Click(object sender, RoutedEventArgs e)
        {
            var frm = new Frm_AddExportReceipts();
            frm.ShowDialog();
            loaddsExport();
        }

        private void importDetail_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            var selectedImport = button.DataContext as CrudImportReceipts;

            if (selectedImport != null)
            {
                // Truyền dữ liệu sang window mới
                var frm = new DisplayImportDetails(selectedImport);
                frm.ShowDialog(); // hoặc Show()

            }
        }

        private void detailexport_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            var selectedExport = button.DataContext as CrudExportReceipts;

            if (selectedExport != null)
            {
                // Truyền dữ liệu sang window mới
                var frm = new DisplayExportDetails(selectedExport);
                frm.ShowDialog(); // hoặc Show()

            }
        }

        private void btnfindcategorymaterials_Click(object sender, RoutedEventArgs e)
        {
            var list = CategoryMaterialRequest.GetCategoriesMaterialByName(txtfindcategorymaterials.Text);
            if (list != null)
            {
                dg_categorymaterial.ItemsSource = list;
            }
            else
                dg_categorymaterial.ItemsSource = null;

        }

        private void loadcategorymaterial_Click(object sender, RoutedEventArgs e)
        {
            loaddsCate();
        }

        private void searchMaterials_Click(object sender, RoutedEventArgs e)
        {
            var list = MaterialRequest.GetMaterialByName(txtSearchMaterials.Text);
            if (list != null)
            {
                dgMaterials.ItemsSource = list;
            }
            else
                dgMaterials.ItemsSource = null;
        }

        private void loadmaterial_Click(object sender, RoutedEventArgs e)
        {
            loaddsMarerial();
        }

        private void searchImport_Click(object sender, RoutedEventArgs e)
        {
            var text = txtImportIDFilter.Text;
           
            if (text != "")
            {

                var import = ImportReceiptsRequest.GetImportReceiptsById(int.Parse(txtImportIDFilter.Text));
                if (import != null)
                {
                    dgImportReceipts.ItemsSource = new List<CrudImportReceipts> { import };
                    return;
                }
                else
                {
                    MessageBox.Show("Khong tim thay Import" +text);
                    dgImportReceipts.ItemsSource = null;
                    return;
                }
            }
            var today = dpToDate.SelectedDate.Value;
            var fromday = dpFromDate.SelectedDate.Value;
            if (fromday != null && today != null)
            {
                var imports = ImportReceiptsRequest.GetImportReceiptsByDay(fromday, today);
                if (imports != null)
                {
                    dgImportReceipts.ItemsSource = imports ?? new List<CrudImportReceipts>();
                    return;
                }
                else
                {
                    dgImportReceipts.ItemsSource = null;
                    return;
                }
            }

        }

        private void loadimport_Click(object sender, RoutedEventArgs e)
        {
            loaddsImport();
        }

        private void searchExport_Click(object sender, RoutedEventArgs e)
        {
            var text = txtExportIDFilter.Text;

            if (text != "")
            {

                var export = ExportReceiptsRequest.GetExportReceiptsById(int.Parse(txtExportIDFilter.Text));
                if (export != null)
                {
                    dgExportReceipts.ItemsSource = new List<CrudExportReceipts> { export };
                    return;
                }
                else
                {
                    MessageBox.Show("Khong tim thay Import" + text);
                    dgExportReceipts.ItemsSource = null;
                    return;
                }
            }
            var today = dpExportToDate.SelectedDate.Value.Date;
            var fromday = dpExportFromDate.SelectedDate.Value.Date;
            if (fromday != null && today != null)
            {
                var export = ExportReceiptsRequest.GetExportReceiptsByDay(fromday, today);
                if (export != null)
                {
                    dgExportReceipts.ItemsSource = export ?? new List<CrudExportReceipts>();
                    return;
                }
                else
                {
                    dgExportReceipts.ItemsSource = null;
                    return;
                }
            }
        }

        private void loadexport_Click(object sender, RoutedEventArgs e)
        {
            loaddsExport();
        }

        private void searchSuppliers_Click(object sender, RoutedEventArgs e)
        {
            var list = SupplierRequest.GetSuppliersByName(txtSearchSuppliers.Text);
            if (list != null)
            {
                dgSuppliers.ItemsSource = list;
            }
            else
                dgSuppliers.ItemsSource = null;
        }

        private void loadesuppliers_Click(object sender, RoutedEventArgs e)
        {
            loaddsSuppliers();
        }

        private void loadlotdetails_Click(object sender, RoutedEventArgs e)
        {
            loadLotDetails();
          

        }

        private void searchLotDetails_Click(object sender, RoutedEventArgs e)
        {
            var fromday = dpLogFromDate.SelectedDate.Value;
            var today = dpLogToDate.SelectedDate.Value;
            if (fromday != null && today != null)
            {
                var lotdetail = LotsRequest.GetLotDetailsByDay(fromday, today);
                if (lotdetail != null)
                {
                    dgInventoryLogs.ItemsSource = lotdetail;
                    return;
                }
                else
                {
                    dgExportReceipts.ItemsSource = null;
                    return;
                }
            }
        }
    }
}
