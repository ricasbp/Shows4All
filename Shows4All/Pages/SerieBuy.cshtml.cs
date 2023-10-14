using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4All.Data;
using Shows4All.Models;

namespace Shows4All.Pages.Checkout
{
    public class SerieBuyModel : PageModel
    {

        public SerieModel SerieAtual;

        public ClienteModel ClienteAtual;

        public ClienteSeriesModel NovaClienteSeries;

        //this context is our database
        private readonly ApplicationDbContext _context;
        public SerieBuyModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int seriesId, int clientID)
        {

            this.ClienteAtual = _context.ClienteDB.FirstOrDefault(c => c.Id == clientID);
            this.SerieAtual = _context.SerieDB.FirstOrDefault(s => s.Id == seriesId);

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

            }
            this.NovaClienteSeries = new ClienteSeriesModel(this._context);

            this.NovaClienteSeries.Initialize(ClienteAtual.Id, SerieAtual.Id, SerieAtual.Price);

            // Add the new review to the database
            _context.ClienteSeriesDB.Add(NovaClienteSeries);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Review added successfully.";
            return RedirectToPage("/MainScreenClient", new { userID = clientID }); //userID é o nome da variavél na pagina MainScreenClient

        }
    }
}
