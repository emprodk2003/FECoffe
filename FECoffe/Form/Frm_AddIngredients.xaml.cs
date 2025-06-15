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

namespace FECoffe.Form
{
    /// <summary>
    /// Interaction logic for Frm_AddIngredients.xaml
    /// </summary>
    public partial class Frm_AddIngredients : Window
    {
        public Frm_AddIngredients()
        {
            InitializeComponent();
        }

        private void luu_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var unit = txtUnit.Text;
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(unit))
            {
                MessageBox.Show("Vui long dien day du thong tin!");
            }
            else
            {
                var result = new CrudIngredients()
                {
                    Name = name,
                    Unit = unit
                };
                if (IngredientsRequest.create(result) == true)
                {
                    MessageBox.Show("Them nguyen lieu thanh cong.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Them nguyen lieu that bai!");
                    this.Close();
                }
            }
        }

        private void huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
