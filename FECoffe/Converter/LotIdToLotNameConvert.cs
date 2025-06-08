using FECoffe.Request.Lots;
using FECoffe.Request.User;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class LotIdToLotNameConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var lotname = string.Empty;
            if (value is int lotId)
            {
                var lots = LotsRequest.GetLots();
                foreach (var lot in lots)
                {
                    if (lot.LotID == lotId)
                    {
                        return lotname = lot.LotName;
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
