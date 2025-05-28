using FECoffe.DTO.Auth;
using FECoffe.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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

        public static List<GetUser> GetUser()
        {
            try
            {
                string url = @"http://localhost:5178/api/Account/GetAllUser";
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
    }
}
