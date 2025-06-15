using FECoffe.DTO.Ingredients;
using FECoffe.DTO.Product;
using FECoffe.DTO.ProductSize;
using FECoffe.DTO.Recipes;
using FECoffe.Request.Ingredients;
using FECoffe.Request.Recipes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Frm_AddRecipes.xaml
    /// </summary>
    public partial class Frm_AddRecipes : Window
    {
        private ProductViewModel _product;
        private ProductSizeViewModel _ProductSize;
        public ObservableCollection<IngredientsViewModel> Ingredients { get; set; } = new();
        public ObservableCollection<CrudRecipes> CrudRecipes { get; set; } = new();
        public Frm_AddRecipes(ProductViewModel product, ProductSizeViewModel ProductSize)
        {
            InitializeComponent();
            _product = product;
            _ProductSize = ProductSize;
            DataContext = this;
        }
        private void hienthinguyenlieu()
        {
            var list = IngredientsRequest.GetAll();
            if (list != null)
            {
                Ingredients = new ObservableCollection<IngredientsViewModel>(list);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(_product != null || _ProductSize != null)
            {
                txt_nameProduct.Text = _product.ProductName;
                txt_nameProductSize.Text = _ProductSize.SizeName;
            }
            hienthinguyenlieu();
        }
        private void ComboBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                string text = comboBox.Text?.ToLower() ?? "";

                var filtered = Ingredients
                    .Where(m => m.Name.ToLower().Contains(text))
                    .ToList();

                comboBox.ItemsSource = filtered;
                comboBox.IsDropDownOpen = true;
            }

        }

        private void Luu_Click(object sender, RoutedEventArgs e)
        {
            var list = dg_Recipes.ItemsSource.Cast<CrudRecipes>().ToList();
            if (string.IsNullOrWhiteSpace(txt_nameProduct.Text) || string.IsNullOrWhiteSpace(txt_nameProductSize.Text) || list == null)
            {
                MessageBox.Show("Vui long khong de trong thong tin!");
            }
            else
            {
                var Recipes = new List<CrudRecipes>();
                foreach(var item in list)
                {
                   
                    var i = new CrudRecipes()
                    {
                        IngredientsID = item.IngredientsID,
                        ProductSizeID = _ProductSize.ProductSizeID,
                        Quantity = item.Quantity,
                    };
                    Recipes.Add(i);
                }
                foreach (var item in Recipes)
                {
                    if (!RecipesRequest.create(item))
                    {
                        MessageBox.Show("Loi khi them!");
                        break;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Them thanh cong!");
                        this.DialogResult = true;
                        this.Close();
                    }
                }
            }
        }

        private void Huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
