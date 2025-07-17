using FECoffe.DTO.OrderDetails;
using FECoffe.DTO.Product;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Product
{
    public class ProductRequest
    {
        public static List<ProductViewModel> GetAllProduct()
        {
            try
            {
                string url = @"http://localhost:5178/api/Products/GetAllProducts";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ProductViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<ProductViewModel> GetAllProductIsVailable()
        {
            try
            {
                string url = @"http://localhost:5178/api/Products/GetAllProductsIsAvailable";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ProductViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<OrderDetailsViewModel> GetBillByID(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Products/GetForenkeyToDelete?id="+id;
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

        public static ProductViewModel GetProductBySize(int size)
        {
            try
            {
                string url = @"http://localhost:5178/api/Products/GetProductsBySize?sizeID=" + size;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<ProductViewModel>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<ProductViewModel> GetProductByName(string name)
        {
            try
            {
                string url = @"http://localhost:5178/api/Products/GetProductsByName?name="+ name;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ProductViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<ProductViewModel> GetProductByCate(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Products/GetByCategory?id=" + id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ProductViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<ProductViewModel> GetProductByCateandName(string name, int id)
        {
            try
            { 
                string url = @"http://localhost:5178/api/Products/GetProductsByNameandCate?name=" + name + "&id=" + id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ProductViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool createProduct(CrudProduct product)
        {
            try
            {
                string url = @"http://localhost:5178/api/Products";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, product);
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
                string url = @"http://localhost:5178/api/Products?id=" + id;
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
        public static bool updateProduct(ProductViewModel Product)
        {
            try
            {
                string url = @"http://localhost:5178/api/Products"; // Giả sử `Id` là khoá chính
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, Product);
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
