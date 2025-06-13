using FECoffe.Request.Lots;
using FECoffe.Request.Table;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class TableIDToMateriaNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tablename = string.Empty;
            if (value is int tableID)
            {
                var tables = TableRequest.GetAllTable();
                foreach (var item in tables)
                {
                    if (item.TableID == tableID)
                    {
                        return tablename = item.TableName;
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
