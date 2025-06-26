using FECoffe.Dashboards;
using FECoffe.DTO.Material;
using FECoffe.Request.CategoryMaterial;
using FECoffe.Request.Material;
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

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddMaterials.xaml
    /// </summary>
    public partial class Frm_AddMaterials : Window
    {
        public string userId { get; set; }
        public Frm_AddMaterials()
        {
            InitializeComponent();
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
                    MinStock = int.Parse(txtMinStock.Text),
                    CategoryID = (int)cbCategory.SelectedValue,
                    SupplierID = (int)cbSupplier.SelectedValue,
                    UpdatedAt = DateTime.Now,
                    UserID = Guid.Parse(userId),
                    CreatedAt = DateTime.Now,
                };

                if (MaterialRequest.createMaterial(newMaterial) == true)
                {
                    MessageBox.Show("Them Thành Công hang hoa ");
                    this.Close();
                }
                else
                    MessageBox.Show("Them thất bại hang hoa ");
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
