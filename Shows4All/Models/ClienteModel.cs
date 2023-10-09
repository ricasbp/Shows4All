namespace Shows4All.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }

        public string? Password { get; set; }

        public Boolean? isAdmin { get; set; }

        public ClienteModel()
        {
            //this.Username = "Elson";
            //this.Password = "ola";
            //this.isAdmin = false;

        }

    }

   
}
