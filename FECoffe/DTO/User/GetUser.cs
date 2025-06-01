using FECoffe.DTO.Role;

namespace FECoffe.DTO.User
{
    public class GetUser
    {
        public Guid ID { get; set; }
        public string username {  get; set; }
        public string email { get; set; }
        public List<GetRoles> role { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedAtFormatted => CreateDate.ToString("dd/MM/yyyy");

    }
}
