
using FECoffe.DTO.Material;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Material
{
    public class MaterialRequest
    {
        public static bool createMaterial(CrudMaterial data)
        {
            try
            {
                string url = @"http://localhost:5178/api/Materials";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, data);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static List<CrudMaterial> GetMaterial()
        {
            try
            {
                string url = @"http://localhost:5178/api/Materials/GetAllCategory";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudMaterial>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool updateMaterial(CrudMaterial data)
        {
            try
            {
                string url = @"http://localhost:5178/api/Materials"; // Giả sử `Id` là khoá chính
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, data);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
        public static bool deleteMaterial(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Materials?id=" + id;
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
