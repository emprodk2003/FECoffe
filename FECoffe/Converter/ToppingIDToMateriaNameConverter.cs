using FECoffe.Request.Topping;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class ToppingIDToMateriaNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var toppingname = string.Empty;
            if (value is int toppingID)
            {
                var toppings = ToppingRequest.GetAllTopping();
                foreach (var item in toppings)
                {
                    if (item.ToppingID == toppingID)
                    {
                        return toppingname = item.ToppingName;
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
