using FECoffe.DTO.Role;
using FECoffe.DTO.User;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Role
{
    public class RoleRequest
    {

        public static bool createRole(CreateRole role)
        {
            try
            {
                string url = @"http://localhost:5178/api/Role/CreateRole";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, role);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
        public static List<GetListRole> GetRoles()
        {
            try
            {
                string url = @"http://localhost:5178/api/Role/GetAllRole";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<GetListRole>>(url);
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
