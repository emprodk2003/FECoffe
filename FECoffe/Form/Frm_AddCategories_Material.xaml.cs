﻿using FECoffe.DTO.CategoyMaterial;
using FECoffe.Request.CategoryMaterial;
using System.Windows;
using System.Xml.Linq;

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
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng không được để trống tên danh mục hàng hóa!");
                return;
            }
            else
            {
                var name = txtCategoryName.Text;
                var description = txtDescription.Text;

                var category = new CrudCategoryMaterial()
                {
                    CategoryName = name,
                    Description = description,
                };
                if (CategoryMaterialRequest.createCategoryMaterial(category) == true)
                {
                    MessageBox.Show("Thêm danh mục hàng hóa thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm danh mục hàng hóa thất bại");
                }
            }
               
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
