using FECoffe.DTO.OrderDetails;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.OrderDetails
{
    public class OrderDetailsRequest
    {
        public static List<OrderDetailsViewModel> getOrderByBill(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/OrderDetails/GetAllOrderDetailByBillID?id=" + id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<OrderDetailsViewModel>>(url);
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
