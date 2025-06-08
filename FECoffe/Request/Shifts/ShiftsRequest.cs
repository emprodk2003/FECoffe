using FECoffe.DTO.Positions;
using FECoffe.DTO.Shifts;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Shifts
{
    public class ShiftsRequest
    {
        public static List<ShiftsViewModel> GetAllShifts()
        {
            try
            {
                string url = @"http://localhost:5178/api/Shifts/GetAllShifts";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ShiftsViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static List<ShiftsViewModel> GetShiftsByName(string name)
        {
            try
            {
                string url = @"http://localhost:5178/api/Shifts/GetShiftsByName?name=" + name;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ShiftsViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static bool createShifts(CrudShifts shifts)
        {
            try
            {
                string url = @"http://localhost:5178/api/Shifts";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, shifts);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool deleteShifts(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Shifts?id=" + id;
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
        public static bool updateShifts(ShiftsViewModel shifts)

        {
            try
            {
                string url = @"http://localhost:5178/api/Shifts";
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, shifts);
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
