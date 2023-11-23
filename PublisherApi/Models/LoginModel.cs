namespace PublisherApi.Models
{
    public class LoginModel
    {
        public AccountToLogin AccountToLogin { get; set; }
        public AccountToRegister AccountToRegister { get; set; }
    }

    public class AccountToLogin
    {
        public string Uid { get; set; }
        public string Pwd { get; set; }
    }

    public class AccountToRegister
    {
        public string AdminAccountID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
