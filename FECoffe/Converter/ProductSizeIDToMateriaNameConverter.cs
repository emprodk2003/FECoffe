using FECoffe.Request.Lots;
using FECoffe.Request.ProductSize;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class ProductSizeIDToMateriaNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sizename = string.Empty;
            if (value is int sizeId)
            {
                var sizes = ProductSizeRequest.GetAll();
                foreach (var item in sizes)
                {
                    if (item.ProductSizeID == sizeId)
                    {
                        return sizename = item.SizeName;
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
