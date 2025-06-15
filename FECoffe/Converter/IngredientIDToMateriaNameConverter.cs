using FECoffe.Request.Ingredients;
using FECoffe.Request.Lots;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class IngredientIDToMateriaNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Ingredientname = string.Empty;
            if (value is int IngredientId)
            {
                var Ingredients = IngredientsRequest.GetAll();
                foreach (var item in Ingredients)
                {
                    if (item.Id == IngredientId)
                    {
                        return Ingredientname = item.Name+" ("+item.Unit+") ";
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
