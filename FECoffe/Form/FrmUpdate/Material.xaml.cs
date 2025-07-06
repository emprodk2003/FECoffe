using FECoffe.DTO.Material;
using FECoffe.Request.CategoryMaterial;
using FECoffe.Request.Material;
using FECoffe.Request.Supplier;
using System.Windows;

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Material.xaml
    /// </summary>
    public partial class Material : Window
    {
        public CrudMaterial crudMaterial {  get; set; }
        public int id { get; set; }
        public string userId { get; set; }
        public Material(CrudMaterial material)
        {
            InitializeComponent();
            crudMaterial = material;
            txtMaterialName.Text=material.MaterialName;
            txtUnit.Text = material.Unit;
            txtPurchasePrice.Text=(material.PurchasePrice).ToString();
            txtMinStock.Text=(material.MinStock).ToString();
            cbCategory.SelectedItem=material.CategoryID;
            cbSupplier.SelectedItem = material.SupplierID;
            id=material.MaterialID;
            
            var app = (App)Application.Current;
            userId = app.IdUser;
        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtMinStock.Text, out int quantity) || quantity > 0)
            {
                var newMaterial = new CrudMaterial()
                {
                    MaterialName = txtMaterialName.Text,
                    Unit = txtUnit.Text,
                    MaterialID = id,
                    MinStock = int.Parse(txtMinStock.Text),
                    CategoryID = int.Parse(cbCategory.Text),
                    SupplierID = int.Parse(cbSupplier.Text),
                    UserID = Guid.Parse(userId),
                    UpdatedAt = DateTime.Now,
                };

                if (MaterialRequest.updateMaterial(newMaterial) == true)
                {
                    MessageBox.Show("Sua Thành Công hang hoa ");
                    this.Close();
                }
                else
                    MessageBox.Show("Sửa hàng hóa thất bại!");
            }
            else
            {
                MessageBox.Show("Số lượng tồn kho phải lớn hơn 0");
            }
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var categoryMaterial = CategoryMaterialRequest.GetCategoryMaterial();
            if (categoryMaterial != null)
            {
                cbCategory.ItemsSource = categoryMaterial;
            }

            var supplier = SupplierRequest.GetSupplier();
            if (supplier != null)
            {
                cbSupplier.ItemsSource = supplier;
            }
        }
    }
}
