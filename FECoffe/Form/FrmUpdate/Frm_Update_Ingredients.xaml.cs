using FECoffe.DTO.Ingredients;
using FECoffe.Request.Ingredients;
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
    /// Interaction logic for Frm_Update_Ingredients.xaml
    /// </summary>
    public partial class Frm_Update_Ingredients : Window
    {
        private IngredientsViewModel _ingredients;
        public Frm_Update_Ingredients(IngredientsViewModel ingredients)
        {
            InitializeComponent();
            _ingredients = ingredients;
        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var unit = txtUnit.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(unit))
            {
                MessageBox.Show("Vui long dien day du thong tin!");
            }
            else
            {
                var result = new IngredientsViewModel()
                {
                    Id = _ingredients.Id,
                    Name = name,
                    Unit = unit
                };
                if (IngredientsRequest.update(result) == true)
                {
                    MessageBox.Show("Cap nhat thong tin nguyen lieu thanh cong.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cap nhat thong tin nguyen lieu that bai!");
                    this.Close();
                }
            }
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(_ingredients != null)
            {
                txtName.Text = _ingredients.Name;
                txtUnit.Text = _ingredients.Unit;
            }
        }
    }
}
