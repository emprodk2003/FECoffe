using FECoffe.DTO.Suppliers;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Supplier
{
    public class SupplierRequest
    {
        public static bool createSupplier(CrudSuppliers suppliers)
        {
            try
            {
                string url = @"http://localhost:5178/api/Suppliers";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, suppliers);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static List<CrudSuppliers> GetSupplier()
        {
            try
            {
                string url = @"http://localhost:5178/api/Suppliers/GetAllSuppliers";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudSuppliers>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool updateSupplier(CrudSuppliers suppliers)
        {
            try
            {
                string url = @"http://localhost:5178/api/Suppliers"; // Giả sử `Id` là khoá chính
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, suppliers);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
        public static bool deleteSupplier(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Suppliers?id=" + id;
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
    }
}
