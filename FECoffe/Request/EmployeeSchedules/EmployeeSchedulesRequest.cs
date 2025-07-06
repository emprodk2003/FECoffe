using FECoffe.DTO.EmployeeSchedules;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.EmployeeSchedules
{
    public class EmployeeSchedulesRequest
    {
        public static List<EmployeeSchedulesViewModel> GetAllEmployeeSchedu()
        {
            try
            {
                string url = @"http://localhost:5178/api/EmployeeSchedules/GetAllEmployeeSchedules";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<EmployeeSchedulesViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static List<EmployeeSchedulesViewModel> GetEmployeeScheduByFilter(DateOnly start, DateOnly end)
        {
            try
            {
                string url = @"http://localhost:5178/api/EmployeeSchedules/GetEmployeeSchedulesByFilter?start=" + start + "&end=" + end;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<EmployeeSchedulesViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool createEmployeeSchedules(EmployeeSchedulesTemp employee)
        {
            try
            {
                string url = @"http://localhost:5178/api/EmployeeSchedules";
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

        public static bool deleteEmployeeSchedules(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/EmployeeSchedules?id=" + id;
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
        public static bool updateEmployeeSchedules(EmployeeSchedulesViewModel employee)
        {
            try
            {
                string url = @"http://localhost:5178/api/EmployeeSchedules"; // Giả sử `Id` là khoá chính
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
    }
}
