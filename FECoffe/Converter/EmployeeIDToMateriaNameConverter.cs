using FECoffe.Request.Employee;
using FECoffe.Request.Table;
using System.Globalization;
using System.Windows.Data;

namespace FECoffe.Converter
{
    public class EmployeeIDToMateriaNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var employeename = string.Empty;
            if (value is int EmployeeID)
            {
                var employees = EmployeeRequest.GetAllEmloyee();
                foreach (var item in employees)
                {
                    if (item.EmployeeID == EmployeeID)
                    {
                        return employeename = item.FullName;
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
