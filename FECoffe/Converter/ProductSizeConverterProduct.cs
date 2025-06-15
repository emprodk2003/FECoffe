using FECoffe.Request.Employee;
using FECoffe.Request.Product;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class ProductSizeConverterProduct : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var productname = string.Empty;
            if (value is int SizeID)
            {
                var product = ProductRequest.GetProductBySize(SizeID);
                if(product != null)
                {
                    return productname = product.ProductName;
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
