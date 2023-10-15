namespace Shows4All.Models
{
    public class ClienteModel
    {
        private string v1;
        private string v2;
        private bool v3;

        public int Id { get; set; }
        public string? Username { get; set; }

        public string? Password { get; set; }

        public Boolean? isAdmin { get; set; }

        public ClienteModel(string v1, string v2, bool v3)
        {
            this.Username = v1;
            this.Password = v2;
            this.isAdmin = v3;
        }
    }

   
}
