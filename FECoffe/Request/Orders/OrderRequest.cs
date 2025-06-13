using FECoffe.DTO.Orders;
using FECoffe.DTO.Positions;
using FECoffe.Enum;
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

        public static string genCodeOrder()
        {
            try
            {
                string url = @"http://localhost:5178/api/Orders/generate-code";
                HttpClient client = new HttpClient();
                var res = client.PostAsync(url,null);
                res.Wait();
                if (res.Result.IsSuccessStatusCode)
                {
                    var readTask = res.Result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    // Giả sử kết quả trả về là JSON: { "code": "ABC123" }
                    // Parse JSON nếu cần
                    var responseContent = readTask.Result;
                    var json = System.Text.Json.JsonDocument.Parse(responseContent);
                    string code = json.RootElement.GetProperty("code").GetString();

                    return code;
                }
                else
                {
                    return "Lỗi: Không thể tạo mã";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return "Lỗi hệ thống";
            }
        }

        public static OrderViewModel GetOrderByCodeOrder(string code)
        {
            try
            {
                string url = @"http://localhost:5178/api/Orders/GetOrderByCodeOrder?code=" + code;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<OrderViewModel>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool UpdateOrderByOrderStatus(int id,bool status)
        {
            try
            {
                string url = @"http://localhost:5178/api/Orders/UpdateOrderByOrderStatus?id=" + id+ "&status="+status;
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url,status);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public static bool BankTransferToCash(int id,TransactionStatus transactionStatus ,bool status)
        {
            try
            {
                string url = @"http://localhost:5178/api/Orders/BankTransferToCash?id=" + id + "&transactionStatus=" + transactionStatus + "&status="+status;
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, status);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

    }
}