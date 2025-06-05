using FECoffe.DTO.Employee;
using FECoffe.DTO.Positions;
using FECoffe.DTO.Timekeeping;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Timekeeping
{
    public class TimekeepingRequest
    {
        public static List<TimekeepingViewModel> GetAllTimekeeping()
        {
            try
            {
                string url = @"http://localhost:5178/api/Timekeeping/GetAllTimekeeping";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<TimekeepingViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static List<TimekeepingViewModel> GetTimekeepingByFilter(DateOnly start, DateOnly end, int employeeID)
        {
            try
            {
                string url = @"http://localhost:5178/api/Timekeeping/GetTimekeepingByFilter?start=" + start + "&end=" + end + "&EmployeeId=" + employeeID;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<TimekeepingViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool createTimekeeping(CrudTimekeeping timekeeping)
        {
            try
            {
                string url = @"http://localhost:5178/api/Timekeeping";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, timekeeping);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool deleteTimekeeping(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Timekeeping?id=" + id;
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
        public static bool updateTimekeeping(TimekeepingViewModel timekeeping)
        {
            try
            {
                string url = @"http://localhost:5178/api/Timekeeping"; 
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, timekeeping);
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
