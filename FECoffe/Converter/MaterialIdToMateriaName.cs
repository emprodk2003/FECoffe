using FECoffe.Request.Material;
using FECoffe.Request.User;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class MaterialIdToMateriaName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var materialname = string.Empty;
            if (value is int materialId)
            {
                var materials = MaterialRequest.GetMaterial();
                foreach (var material in materials)
                {
                    if (material.MaterialID == materialId)
                    {
                        return materialname = material.MaterialName;
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
