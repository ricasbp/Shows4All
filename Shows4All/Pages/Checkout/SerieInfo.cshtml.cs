using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4All.Data;
using Shows4All.Models;

namespace Shows4All.Pages.Checkout
{
    public class SerieInfoModel : PageModel
    {

        public SerieModel SerieAtual;

        public ClienteModel ClienteAtual;

        [BindProperty]
        public AvaliacaoModel? avaliacaoPassada { get; set; }

        [BindProperty]
        public AvaliacaoModel? novaAvaliacao { get; set; }

        public ClienteSeriesModel ClienteSeriesModel;

        //this context is our database
        private readonly ApplicationDbContext _context;


        public SerieInfoModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int seriesId, int clientID)
        {

            this.ClienteAtual = _context.ClienteDB.FirstOrDefault(c => c.Id == clientID);
            this.SerieAtual = _context.SerieDB.FirstOrDefault(s => s.Id == seriesId);

            // Use a LINQ query to find the ClientSerieModel With pricePaid and time
            this.ClienteSeriesModel = _context.ClienteSeriesDB
                .FirstOrDefault(a => a.ClientModel.Id == clientID && a.SerieModel.Id == seriesId);

            // Use a LINQ query to find the review with the specified client and series
            this.avaliacaoPassada = _context.AvaliacaoDB
                .FirstOrDefault(a => a.ClientModel.Id == clientID && a.SerieModel.Id == seriesId);

            // Now you have the review in 'avaliacaoPassada'
            if (avaliacaoPassada == null)
            {
                this.novaAvaliacao = new AvaliacaoModel(this._context);
            }

            if (SerieAtual == null)
            {
                // Handle the case where the SerieModel is not found, such as showing an error page or a message.
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            // Retrieve clientID and seriesId from the form data
            if (int.TryParse(Request.Form["clientID"], out int clientID) &&
                int.TryParse(Request.Form["seriesId"], out int seriesId))
            {
                // Now you have clientID and seriesId available for further use
                this.SerieAtual = _context.SerieDB.FirstOrDefault(s => s.Id == seriesId);
                this.ClienteAtual = _context.ClienteDB.FirstOrDefault(c => c.Id == clientID);

                // Use a LINQ query to find the ClientSerieModel With pricePaid and time
                this.ClienteSeriesModel = _context.ClienteSeriesDB
                    .FirstOrDefault(a => a.ClientModel.Id == clientID && a.SerieModel.Id == seriesId);

            }

            // Attach the review to the current series
            this.novaAvaliacao.SerieModel = SerieAtual;
            // Attach the client to the current series
            this.novaAvaliacao.ClientModel = ClienteAtual;

            // Add the new review to the database
            _context.AvaliacaoDB.Add(novaAvaliacao);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Review added successfully.";
            return RedirectToPage("/Checkout/SerieInfo", new { clientID = ClienteAtual.Id, seriesId = SerieAtual.Id}); //userID é o nome da variavél na pagina MainScreenClient

        }
    }
}
