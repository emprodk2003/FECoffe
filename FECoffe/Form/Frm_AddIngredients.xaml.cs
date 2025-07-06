using FECoffe.DTO.Ingredients;
using FECoffe.Request.Ingredients;
using System.Windows;

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
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
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
                    MessageBox.Show("Thêm nguyên liệu thành công.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm nguyên liệu thất bại!");
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
