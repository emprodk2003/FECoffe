namespace FECoffe.DTO.User
{
    public class GetUser
    {
        public string username {  get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

     }
}
