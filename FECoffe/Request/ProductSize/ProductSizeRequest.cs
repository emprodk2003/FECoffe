using FECoffe.DTO.Product;
using FECoffe.DTO.ProductSize;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.ProductSize
{
    public class ProductSizeRequest
    {
        public static List<ProductSizeViewModel> GetAll()
        {
            try
            {
                string url = @"http://localhost:5178/api/ProductSizes/GetAllProductSizes";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ProductSizeViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        } 
        public static List<ProductSizeViewModel> GetByProduct(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/ProductSizes/GetAllProductSizes?id=" + id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ProductSizeViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }


        public static bool createProduct(CrudProductSize size)
        {
            try
            {
                string url = @"http://localhost:5178/api/ProductSizes";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, size);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool deleteProduct(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/ProductSizes?id=" + id;
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
        public static bool updateProduct(ProductSizeViewModel size)
        {
            try
            {
                string url = @"http://localhost:5178/api/ProductSizes"; 
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, size);
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
