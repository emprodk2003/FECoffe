using FECoffe.DTO.Categories_Product;
using FECoffe.DTO.Employee;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Categories_Product
{
    public class Categories_ProductRequest
    {
        public static List<Categories_ProductViewModel> GetAllCategories_Product()
        {
            try
            {
                string url = @"http://localhost:5178/api/Categories_Products/GetAllCategories_Products";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<Categories_ProductViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<Categories_ProductViewModel> GetCategories_ProductByName(string name)
        {
            try
            {
                string url = @"http://localhost:5178/api/Categories_Products/GetAllCategories_ProductsByName?name=" + name;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<Categories_ProductViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool createCategories_Product(CrudCategories_Product crudCategories_)
        {
            try
            {
                string url = @"http://localhost:5178/api/Categories_Products";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, crudCategories_);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool deleteCategories_Product(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Categories_Products?id=" + id;
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
        public static bool updateCategories_Product(Categories_ProductViewModel categories_Product)
        {
            try
            {
                string url = @"http://localhost:5178/api/Categories_Products"; // Giả sử `Id` là khoá chính
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, categories_Product);
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
