using FECoffe.DTO.CategoyMaterial;
using FECoffe.DTO.User;
using FECoffe.Request.CategoryMaterial;
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
