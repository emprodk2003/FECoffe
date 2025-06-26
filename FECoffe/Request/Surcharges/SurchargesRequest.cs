using FECoffe.DTO.Recipes;
using FECoffe.DTO.Surcharges;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Surcharges
{
    public class SurchargesRequest
    {
        public static List<SurchargesViewModel> GetAll()
        {
            try
            {
                string url = @"http://localhost:5178/api/Surcharges/GetAll";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<SurchargesViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<SurchargesViewModel> GetByName(string name)
        {
            try
            {
                string url = @"http://localhost:5178/api/Surcharges/GetByName?name=" + name;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<SurchargesViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<SurchargesViewModel> GetByStart_End(DateTime start, DateTime end)
        {
            try
            {
                string url = @"http://localhost:5178/api/Surcharges/GetByDateStart_End?start=" + start + "&end=" + end;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<SurchargesViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static SurchargesViewModel GetByToDay(DateTime date)
        {
            try
            {
                string url = @"http://localhost:5178/api/Surcharges/GetByToDay?date=" + date;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<SurchargesViewModel>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool create(CrudSurcharges surcharges)
        {
            try
            {
                string url = @"http://localhost:5178/api/Surcharges";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, surcharges);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool delete(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Surcharges?id=" + id;
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
        public static bool update(SurchargesViewModel surcharges)
        {
            try
            {
                string url = @"http://localhost:5178/api/Surcharges";
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, surcharges);
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
