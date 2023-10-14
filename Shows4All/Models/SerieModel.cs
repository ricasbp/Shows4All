


namespace Shows4All.Models
{
    public class SerieModel
    {
        public int Id { get; set; }
        public string SerieName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string imageURL { get; set; }

        public SerieModel()
        {
        }

        public SerieModel(String SerieName, String Description, double Price, String Url)
        {
            this.SerieName = SerieName;
            this.Description = Description;
            this.Price = Price;
            this.imageURL = Url;
        }
    }
     
}
