using FECoffe.DTO.CategoyMaterial;
using FECoffe.Request.CategoryMaterial;
using System.Windows;

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Categorys_Material.xaml
    /// </summary>
    public partial class Categorys_Material : Window
    {
        public CrudCategoryMaterial _category { get; set; }
        public int id { get; set; }
        public Categorys_Material(CrudCategoryMaterial crud)
        {
            InitializeComponent();
            _category = crud;
            txtCategoryName.Text=crud.CategoryName;
            txtDescription.Text=crud.Description;
            id=crud.CategoryID;
        }

        private async void luu_Click(object sender, RoutedEventArgs e)
        {
            var newcate = new CrudCategoryMaterial()
            {
                CategoryID = id,
                CategoryName = txtCategoryName.Text,
                Description = txtDescription.Text,
            };

            if (CategoryMaterialRequest.updateCategoryMaterial(newcate) == true)
            {
                MessageBox.Show("Sữa Thành Công danh mục hàng hóa ");
                this.Close();
            }else
                MessageBox.Show("Sữa thất bại danh mục hàng hóa ");
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
