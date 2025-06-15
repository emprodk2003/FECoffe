using Data.DTO.Report;
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

namespace FECoffe.Form.FrmDisplay
{
    /// <summary>
    /// Interaction logic for DisplayProductDetail_IngredientsReport.xaml
    /// </summary>
    public partial class DisplayProductDetail_IngredientsReport : Window
    {
        private List<ProductDetailReport> _productDetails;
        public DisplayProductDetail_IngredientsReport(List<ProductDetailReport> productDetails)
        {
            InitializeComponent();
            _productDetails = productDetails;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_productDetails != null)
            {
                dg_ProductDetailReport.ItemsSource = _productDetails;
            }
        }
    }
}
