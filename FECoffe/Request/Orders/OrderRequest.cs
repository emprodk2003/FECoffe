using FECoffe.DTO.Orders;
using FECoffe.DTO.Product;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Orders
{
    public class OrderRequest
    {
        public static bool createOrder(CreateOrderDTO order)
        {
            try
            {
                string url = @"http://localhost:5178/api/Orders";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, order);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
        public static List<OrdersViewModel> getOrderByDate(DateTime start, DateTime end)
        {
            try
            {
                string url = @"http://localhost:5178/api/Orders/GetOrderByDate?start=" + start + "&end=" + end;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<OrdersViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static List<OrdersViewModel> getAll(DateTime start)
        {
            try
            {
                string url = @"http://localhost:5178/api/Orders/GetAllOrderByMonth?start=" + start;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<OrdersViewModel>>(url);
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
