using System.ComponentModel.DataAnnotations;

namespace FECoffe.DTO.Auth
{
    public class AuthAdmin
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
