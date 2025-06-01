using FECoffe.DTO.Role;
using FECoffe.Request.Role;
using FECoffe.Request.User;
using System.Data;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class RoleIdToRoleNameCoverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            var listuser = UserRequest.GetUser();
            if (value is Guid userId)
            {
                foreach (var user in listuser)
                {
                    var infouser = UserRequest.GetUserByID(user.ID);
                    return infouser.Roles;        
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
