using FECoffe.DTO.Ingredients;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Ingredients
{
    public class IngredientsRequest
    {
        public static List<IngredientsViewModel> GetAll()
        {
            try
            {
                string url = @"http://localhost:5178/api/Ingredients/GetAllIngredients";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<IngredientsViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static List<IngredientsViewModel> GetByName(string name)
        {
            try
            {
                string url = @"http://localhost:5178/api/Ingredients/GetAllIngredientsByName?name="+name;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<IngredientsViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static bool create(CrudIngredients ingredients)
        {
            try
            {
                string url = @"http://localhost:5178/api/Ingredients";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, ingredients);
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
                string url = @"http://localhost:5178/api/Ingredients?id=" + id;
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
        public static bool update(IngredientsViewModel ingredients)
        {
            try
            {
                string url = @"http://localhost:5178/api/Ingredients";
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, ingredients);
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
