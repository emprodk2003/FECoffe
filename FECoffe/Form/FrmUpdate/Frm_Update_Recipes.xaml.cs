using FECoffe.DTO.Product;
using FECoffe.DTO.ProductSize;
using FECoffe.DTO.Recipes;
using FECoffe.Request.Ingredients;
using FECoffe.Request.Recipes;
using System.Windows;

namespace FECoffe.Form.FrmUpdate
{
    /// <summary>
    /// Interaction logic for Frm_Update_Recipes.xaml
    /// </summary>
    public partial class Frm_Update_Recipes : Window
    {
        private ProductViewModel _product;
        private ProductSizeViewModel _size;
        private RecipesViewModel _recipes;
        public Frm_Update_Recipes(ProductViewModel product, ProductSizeViewModel size,RecipesViewModel recipes)
        {
            InitializeComponent();
            _product = product;
            _size = size;
            _recipes = recipes;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtproduct.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtproductsize.Text) || cbIngredients.SelectedItem == null)
            {
                MessageBox.Show("Số không được để trông thông tin!");
                return;
            }
            else if (!float.TryParse(txtQuantity.Text, out float quantity) || quantity < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }
            else
            {
                var recipes = new RecipesViewModel()
                {
                    RecipeID = _recipes.RecipeID,
                    ProductSizeID = _recipes.ProductSizeID,
                    IngredientsID = (int)cbIngredients.SelectedValue,
                    Quantity = float.Parse(txtQuantity.Text)
                };
                if (RecipesRequest.update(recipes) == true)
                {
                    MessageBox.Show("Cập nhật thông tin thành công .");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại!");
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_size != null)
            {
                txtproductsize.Text = _size.SizeName;
            }
            if(_product != null)
            {
                txtproduct.Text = _product.ProductName;
            }
            if(_recipes != null)
            {
                cbIngredients.SelectedValue = _recipes.IngredientsID;
                txtQuantity.Text = _recipes.Quantity.ToString();
            }
            var list = IngredientsRequest.GetAll();
            if (list != null)
            {
                cbIngredients.ItemsSource = list;
            }         
        }
    }
}
