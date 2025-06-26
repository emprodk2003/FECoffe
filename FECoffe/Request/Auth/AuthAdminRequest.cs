using FECoffe.DTO.Auth;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Auth
{
    public class AuthAdminRequest
    {
        public static AuthenticatedResult login(AuthAdmin login)
        {
            try
            {
                string url = @"http://localhost:5178/api/Account/login";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, login);
                res.Wait();
                if (res.Result.IsSuccessStatusCode)
                {
                    var readTask = res.Result.Content.ReadFromJsonAsync<AuthenticatedResult>();
                    readTask.Wait();
                    return readTask.Result;
                }
                else
                {
                    Console.WriteLine("Đăng nhập thất bại: " + res.Result.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return null;
            }
        }
        public static bool log_out()
        {
            string url = @"http://localhost:5178/api/Account/Logout";
            HttpClient client = new HttpClient();
            var res = client.PostAsync(url,null);
            res.Wait();
            if (res.Result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
