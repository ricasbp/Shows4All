namespace Shows4All.Models
{
    public class LoginModel
    {
        public string? Username { get; set; }

        public string? Password { get; set; }

        public LoginModel()
        {
            this.Username = "test";
            this.Password = "test";

        }

    }

   
}