using FECoffe.DTO.Ingredients;
using FECoffe.Request.Ingredients;
using System.Windows;

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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
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
                    MessageBox.Show("Cập nhật thông tin nguyên liệu thành công.");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin nguyên liệu thất bại!");
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
