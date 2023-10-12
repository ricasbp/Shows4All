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

        [BindProperty]
        public ClienteSeriesModel ClienteSeries { get; set; }


        public int clienteAtualID = 1;
        public ClienteModel ClienteModelAtual { get; set; }


        //this context is our database
        private readonly ApplicationDbContext _context;
        public MainScreenClient(ApplicationDbContext context)
        {
            _context = context;

            // Retrieve ClienteModel from the database based on clienteID
            this.ClienteModelAtual = _context.ClienteDB.FirstOrDefault(c => c.Id == clienteAtualID);


            this.seriesDoCliente = _context.ClienteSeriesDB
                .Include(cs => cs.SerieModel) // Include the series related to the client series
                .Where(ClientSeriesModel => ClientSeriesModel.ClientModel.Id == ClienteModelAtual.Id)
                .Select(cs => cs.SerieModel) // Select the series
                .ToList(); //Output is a list

            //Ver o que se na consola temos todas as séries do Cliente;
            Console.WriteLine(seriesDoCliente);



        }

        public void OnGet()
        {
            //Example of Client Buying a new Serie
            // clienteSeriesModel = new ClienteSeriesModel(this._context);

            //var ClientId = 1;
            //var SerieId = 10;

            //clienteSeriesModel.Initialize(ClientId, SerieId, 2.00);

            //_context.ClienteSeriesDB.Add(clienteSeriesModel);
            //_context.SaveChanges();
        }

    }
}
