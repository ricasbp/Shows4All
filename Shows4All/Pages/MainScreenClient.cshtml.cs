using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4All.Data;
using Shows4All.Models;

namespace Shows4All.Pages
{
    public class MainScreenClient : PageModel
    {
        public List<SerieModel> seriesDoCliente = new List<SerieModel>();

        public List<SerieModel> todasAsSeriesNaoCompradasPeloCliente = new List<SerieModel>();

        [BindProperty]
        public ClienteSeriesModel ClienteSeries { get; set; }
        [BindProperty]
        public ClienteModel ClienteModelAtual { get; set; }

        // UserID que vem do Login/Index.cshtml
        [BindProperty(SupportsGet = true)]
        public int userID { get; set; }

        //this context is our database
        private readonly ApplicationDbContext _context;

        public MainScreenClient(ApplicationDbContext context)
        {
            _context = context;

        }

        public void OnGet()
        {
            Console.WriteLine("userID =" + userID);
            System.Diagnostics.Debug.WriteLine("userID = " + userID);

            // Retrieve ClienteModel from the database based on clienteID
            this.ClienteModelAtual = _context.ClienteDB.FirstOrDefault(c => c.Id == userID);


            this.seriesDoCliente = _context.ClienteSeriesDB
                .Include(cs => cs.SerieModel) // Include the series related to the client series
                .Where(ClientSeriesModel => ClientSeriesModel.ClientModel.Id == ClienteModelAtual.Id)
                .Select(cs => cs.SerieModel) // Select the series
                .ToList(); //Output is a list

            //Ver o que se na consola temos todas as séries do Cliente;
            Console.WriteLine(seriesDoCliente);

            // Retrieve series not bought by the client
            this.todasAsSeriesNaoCompradasPeloCliente = GetSeriesNotBoughtByClient(userID);
        }

        private List<SerieModel> GetSeriesNotBoughtByClient(int userID)
        {
            // Use LINQ to query and find series not bought by the client
            var seriesNotBought = _context.SerieDB
                .Where(serie => !_context.ClienteSeriesDB
                    .Any(clienteSerie => clienteSerie.ClientModel.Id == userID && clienteSerie.SerieModel.Id == serie.Id))
                .ToList();

            return seriesNotBought;
        }

    }
}
