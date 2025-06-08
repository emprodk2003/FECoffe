using FECoffe.DTO.Positions;
using FECoffe.DTO.Salaries;
using FECoffe.DTO.Shifts;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Salaries
{
    public class SalariesRequest
    {
        public static List<SalariesViewModel> GetAllSalaries()
        {
            try
            {
                string url = @"http://localhost:5178/api/Salaries/GetAllSalaries";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<SalariesViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static List<SalariesViewModel> GetSalariesByFilter1(DateOnly start, DateOnly end)
        {
            try
            {
                string url = @"http://localhost:5178/api/Salaries/GetSalariesByFilter?start=" + start + "&end="+ end ;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<SalariesViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static List<SalariesViewModel> GetSalariesByFilter2(DateOnly start, DateOnly end, int employeeID)
        {
            try
            {
                string url = @"http://localhost:5178/api/Salaries/GetSalariesByFilter?start="+start+"&end="+end+"&employeeID="+employeeID;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<SalariesViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static bool createSalaries(CrudSalaries salaries)
        {
            try
            {
                string url = @"http://localhost:5178/api/Salaries";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, salaries);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool deleteSalaries(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Salaries?id=" + id;
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
        public static bool updateSalaries(SalariesViewModel salaries)

        {
            try
            {
                string url = @"http://localhost:5178/api/Salaries";
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, salaries);
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
