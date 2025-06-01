using System.ComponentModel.DataAnnotations;

namespace FECoffe.DTO.User
{
    public class GetInfoUser
    {
        public GetInfoUser()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
        [Required]
        public string Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }
    }
}
