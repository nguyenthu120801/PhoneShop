namespace WebMVC.Entity
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public bool IsBlocked { get; set; }
    }
}
