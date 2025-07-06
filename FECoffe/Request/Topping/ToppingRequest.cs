using FECoffe.DTO.OrderToppingDetails;
using FECoffe.DTO.Topping;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Topping
{
    public class ToppingRequest
    {
        public static List<ToppingViewModel> GetAllTopping()
        {
            try
            {
                string url = @"http://localhost:5178/api/Toppings/GetAllToppings";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ToppingViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<OrderToppingDisplayModel> GetBillByID(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Toppings/GetForenkeyToDelete?id="+id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<OrderToppingDisplayModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<ToppingViewModel> GetToppingByName(string name)
        {
            try
            {
                string url = @"http://localhost:5178/api/Toppings/GetToppingsByName?name=" + name;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ToppingViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static ToppingViewModel GetToppingById(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Toppings/GetToppingsByID?id=" + id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<ToppingViewModel>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool createTopping(CrudTopping topping)
        {
            try
            {
                string url = @"http://localhost:5178/api/Toppings";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, topping);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool deleteTopping(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Toppings?id=" + id;
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
        public static bool updateTopping(ToppingViewModel topping)
        {
            try
            {
                string url = @"http://localhost:5178/api/Toppings";
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, topping);
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
