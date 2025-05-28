using System.Windows.Data;
using System.Windows.Media;
using static FECoffe.AppUsed.TheBagNumber;

namespace FECoffe.DTO
{
    public class TableStatusToColorConverter : IValueConverter
    {
        public Color FreeColor { get; set; }
        public Color OccupiedColor { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is TableStatus status)
            {
                return status switch
                {
                    TableStatus.Free => new SolidColorBrush(FreeColor),
                    TableStatus.Occupied => new SolidColorBrush(OccupiedColor),
                    _ => Brushes.Gray
                };
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
