using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4All.Data;
using Shows4All.Models;

namespace Shows4All.Pages
{
    public class MainScreenClientModel : PageModel
    {
        public List<SerieModel> fakeSerieDB = new List<SerieModel>()
        {
            new SerieModel() {
                SerieName="Yau1",
                Description="Yau1Descp",
                Price=1.00},
            new SerieModel() {
                SerieName="Yau2",
                Description="Yau2Descp",
                Price=2.00},
            new SerieModel() {
                SerieName="Yau3",
                Description="Yau3Descp",
                Price=3.00},
            new SerieModel() {
                SerieName="Yau4",
                Description="Yau4Descp",
                Price=4.00}
        };

        [BindProperty]
        public ClienteSeriesModel ClienteSeries { get; set; }


        //this context is our database
        private readonly ApplicationDbContext _context;
        public MainScreenClientModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var clienteSeriesModel = new ClienteSeriesModel(this._context);

            var ClientId = 1;
            var SerieId = 3;

            clienteSeriesModel.Initialize(ClientId, SerieId, 2.00); // Set the properties

            _context.ClienteSeriesDB.Add(clienteSeriesModel);
            _context.SaveChanges();
        }

    }
}
