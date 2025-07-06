using FECoffe.DTO.OrderNumbertag;
using FECoffe.DTO.Orders;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Table
{
    public class TableRequest
    {
        public static List<TableViewModel> GetAllTable()
        {
            try
            {
                string url = @"http://localhost:5178/api/OrderNumberTag/GetAllOrderNumberTag";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<TableViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<OrdersViewModel> GetBillByID(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/OrderNumberTag/GetForenkeyToDelete?id="+id;
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

        public static List<TableViewModel> GetTableByName(string name)
        {
            try
            {
                string url = @"http://localhost:5178/api/OrderNumberTag/GetOrderNumberTagByName?name="+ name;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<TableViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool createTable(CrudTable table)
        {
            try
            {
                string url = @"http://localhost:5178/api/OrderNumberTag";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, table);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool deleteTable(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/OrderNumberTag?id=" + id;
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
        public static bool updateTable(TableViewModel table)
        {
            try
            {
                string url = @"http://localhost:5178/api/OrderNumberTag";
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, table);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool updateTableByStatus(int id,int status)
        {
            try
            {
                string url = @"http://localhost:5178/api/OrderNumberTag/UpdateOrderNumberTagStatus?idban="+id+ "&status="+status;
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, status);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static TableViewModel GetTableById(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/OrderNumberTag/GetOrderNumberTagByID?id=" + id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<TableViewModel>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<TableViewModel> GetOrderNumberTagByStatus(int status)
        {
            try
            {
                string url = @"http://localhost:5178/api/OrderNumberTag/GetOrderNumberTagByStatus?status=" + status;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<TableViewModel>>(url);
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
