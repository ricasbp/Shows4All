


namespace Shows4All.Models
{
    public class SerieModel
    {
        public int Id { get; set; }
        public string SerieName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        //Falta List of Ratings
        //      List of Actors
        public SerieModel()
        {
            this.SerieName = "DbTest";
            this.Description = "DbTest";
            this.Price = 200;
        }
    }
     
}
