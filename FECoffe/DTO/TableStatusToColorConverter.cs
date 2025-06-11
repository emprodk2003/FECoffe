using FECoffe.Enum;
using System.Windows.Data;
using System.Windows.Media;


namespace FECoffe.DTO
{
    public class TableStatusToColorConverter : IValueConverter
    {
        public Color AvailableColor { get; set; }
        public Color OccupiedColor { get; set; }
        public Color OutOfServiceColor { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is TableStatus status)
            {
                return status switch
                {
                    TableStatus.Available => new SolidColorBrush(AvailableColor),
                    TableStatus.Occupied => new SolidColorBrush(OccupiedColor),
                    TableStatus.OutOfService => new SolidColorBrush(OutOfServiceColor),
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
