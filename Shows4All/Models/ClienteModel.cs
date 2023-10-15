namespace Shows4All.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool? isAdmin { get; set; }


        public ClienteModel()
        {
        }

        public ClienteModel(string Username, string Password, bool isAdmin)
        {
            this.Username = Username;
            this.Password = Password;
            this.isAdmin = isAdmin;
        }
    }

   
}
