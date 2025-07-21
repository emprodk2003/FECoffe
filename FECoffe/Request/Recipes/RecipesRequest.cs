using FECoffe.DTO.Recipes;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Recipes
{
    public class RecipesRequest
    {
        public static List<RecipesViewModel> GetAll()
        {
            try
            {
                string url = @"http://localhost:5178/api/Recipes/GetAllRecipes";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<RecipesViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool CheckWhenAdd(int size, int ingre)
        {
            try
            {
                string url = @"http://localhost:5178/api/Recipes/CheckWhenAdd?size="+size+"&ingre="+ingre;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<bool>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return false;
            }
        }

        public static List<RecipesViewModel> GetByProduct(int size)
        {
            try
            {
                string url = @"http://localhost:5178/api/Recipes/GetRecipesByProduct?sizeID=" + size;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<RecipesViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static bool create(CrudRecipes recipes)
        {
            try
            {
                string url = @"http://localhost:5178/api/Recipes";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, recipes);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool delete(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Recipes?id=" + id;
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
        public static bool update(RecipesViewModel recipes)
        {
            try
            {
                string url = @"http://localhost:5178/api/Recipes"; 
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, recipes);
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
