using FECoffe.DTO.Employee;
using FECoffe.DTO.Material;
using FECoffe.DTO.Positions;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Positions
{
    public class PositionsRequest
    {
        public static List<PositionsViewModel> GetAllPosition()
        {
            try
            {
                string url = @"http://localhost:5178/api/Positions/GetAllPositions";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<PositionsViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static List<PositionsViewModel> GetPositionByName(string name)
        {
            try
            {
                string url = @"http://localhost:5178/api/Positions/GetPositionsByName?name=" + name;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<PositionsViewModel>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool createPosition(CrudPosition position)
        {
            try
            {
                string url = @"http://localhost:5178/api/Positions";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, position);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static bool deletePosition(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Positions?id=" + id;
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
        public static bool updatePosition(PositionsViewModel positions)

        {
            try
            {
                string url = @"http://localhost:5178/api/Positions"; // Giả sử `Id` là khoá chính
                HttpClient client = new HttpClient();
                var res = client.PutAsJsonAsync(url, positions);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static PositionsViewModel GetPositionByUserId(Guid userId)
        {
            try
            {
                string url = @"http://localhost:5178/api/Positions/GetPositionsByUserId?userId=" + userId;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<PositionsViewModel>(url);
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
