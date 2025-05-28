using System.Configuration;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Windows;

namespace FECoffe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Lưu token gốc (chuỗi)
        public string RawToken { get; set; }

        // Lưu đối tượng JWT đã giải mã
        public JwtSecurityToken JwtToken { get; set; }

        // Lấy email từ token

        public string IdUser => JwtToken?.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        public string UserEmail => JwtToken?.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

        // Lấy vai trò từ token
        public string UserRole => JwtToken?.Claims.FirstOrDefault(c => c.Type == "role" || c.Type == "roles")?.Value;
    }

}
