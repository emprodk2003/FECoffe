using FECoffe.Request.Employee;
using FECoffe.Request.Product;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class ProductIDToMateriaNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var productname = string.Empty;
            if (value is int ProductID)
            {
                var products = ProductRequest.GetAllProduct();
                foreach (var item in products)
                {
                    if (item.ProductID == ProductID)
                    {
                        return productname = item.ProductName;
                    }
                }
                return "N/A";
            }
            return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
