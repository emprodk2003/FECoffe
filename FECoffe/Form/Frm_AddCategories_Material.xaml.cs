using FECoffe.DTO.CategoyMaterial;
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

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddCategories_Material.xaml
    /// </summary>
    public partial class Frm_AddCategories_Material : Window
    {
        public Frm_AddCategories_Material()
        {
            InitializeComponent();
        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {
            var name= txtCategoryName.Text;
            var description= txtDescription.Text;

            var category = new CrudCategoryMaterial()
            {
                CategoryName = name,
                Description = description,
            };
            if (CategoryMaterialRequest.createCategoryMaterial(category)==true) {
                MessageBox.Show("Them danh muc hang hoa thanh cong");
                this.Close();
            }
            else
            {
                MessageBox.Show("Them danh muc hang hoa that bai");
            }
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
