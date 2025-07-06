using FECoffe.DTO.Employee;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Employee
{
    public class EmployeeRequest
    {
        public static List<EmployeeViewModel> GetAllEmloyee()
        {
            try
            {
                string url = @"http://localhost:5178/api/Employees/GetAllEmployees";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<EmployeeViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<EmployeeViewModel> GetEmloyeeByName(string name)
        {
            try
            {
                string url = @"http://localhost:5178/api/Employees/GetEmployeesByName?name=" + name;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<EmployeeViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static bool? getforenkey(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Employees/GetAllEmployeesByID?id="+id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<bool>(url);
                res.Wait();
                return res.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return null;
            }
        }
        public static bool createEmployee(CrudEmployee employee)
        {
            try
            {
                string url = @"http://localhost:5178/api/Employees";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, employee);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool deleteEmployee(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Employees?id=" + id;
                HttpClient client = new HttpClient();
                var res = client.DeleteAsync(url);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
        public static bool updateEmployee(EmployeeViewModel employee)
        {
            try
            {
                string url = @"http://localhost:5178/api/Employees"; // Giả sử `Id` là khoá chính
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, employee);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
        public static EmployeeViewModel GetEmloyeeByUserId(Guid id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Employees/GetEmployeByID?id=" + id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<EmployeeViewModel>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

    }
}
