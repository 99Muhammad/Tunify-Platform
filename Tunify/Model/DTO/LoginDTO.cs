namespace Tunify.Model.DTO
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public IList<string> Roles { get; set; }
    }
}
