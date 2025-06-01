using FECoffe.DTO.User;
using FECoffe.Request.User;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class UserIdToUsernameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var username = string.Empty;
            if (value is Guid userId)
            {
                var users = UserRequest.GetUser();
                foreach (var user in users)
                {
                    if(user.ID == userId)
                    {
                        return username=user.username;
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
