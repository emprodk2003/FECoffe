using FECoffe.DTO.User;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.User
{
    public class UserRequest
    {
        public static bool createUser(CreateUser user)
        {
            try
            {
                string url = @"http://localhost:5178/api/Account/register";
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

        public static bool changePassword(ChangePassword pass,Guid id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Role/set-password?id="+id;
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, pass);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static List<GetUser> GetUser()
        {
            try
            {
                string url = @"http://localhost:5178/api/Role/GetAllUer";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<GetUser>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static GetInfoUser GetUserByID(Guid id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Role/GetUserDetail?UserId="+id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<GetInfoUser>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static bool AddRolebyUser(UpdateUser user)
        {
            try
            {
                string url = @"http://localhost:5178/api/Role/CreateUserRole";
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

        public static List<GetRoles> GetRolesByUserID(Guid userid)
        {
            try
            {
                string url = @"http://localhost:5178/api/Role/ListRolesByUserId?userId=" + userid;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<GetRoles>>(url);
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
