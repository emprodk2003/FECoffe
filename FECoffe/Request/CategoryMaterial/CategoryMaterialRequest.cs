using FECoffe.DTO.CategoyMaterial;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.CategoryMaterial
{
    public class CategoryMaterialRequest
    {
        public static bool createCategoryMaterial(CrudCategoryMaterial user)
        {
            try
            {
                string url = @"http://localhost:5178/api/Categories_Material";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, user);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static List<CrudCategoryMaterial> GetCategoryMaterial()
        {
            try
            {
                string url = @"http://localhost:5178/api/Categories_Material/GetAllCategory";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudCategoryMaterial>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool updateCategoryMaterial(CrudCategoryMaterial user)
        {
            try
            {
                string url = @"http://localhost:5178/api/Categories_Material/"; // Giả sử `Id` là khoá chính
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, user);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
        public static bool deleteCategoryMaterial(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Categories_Material?id=" + id;
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

        public static List<CrudCategoryMaterial> GetCategoriesMaterialByName(string name)
        {
            try
            {
                string url = @"http://localhost:5178/api/Categories_Material/GetCategoriesMaterialByName?name="+name;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudCategoryMaterial>>(url);
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
