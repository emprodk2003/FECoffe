using FECoffe.DTO.Orders;
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
    }
}
