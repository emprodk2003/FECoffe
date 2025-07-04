﻿using FECoffe.Request.Role;
using FECoffe.Request.User;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class RoleIdToRoleNameCoverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var rolename = string.Empty;
            if (value is Guid roleId)
            {
                var roles = RoleRequest.GetRoles();
                foreach (var role in roles)
                {
                    if (role.Id == roleId)
                    {
                        return rolename = role.Name;
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
