using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using Shows4All.Data;
using Shows4All.Models;

namespace Shows4All.Pages.Checkout
{
    public class SerieEditModel : PageModel
    {
        [BindProperty]
        public SerieModel SerieAtual { get;set; }

        public SerieModel SerieAtualEditada;


        //this context is our database
        private readonly ApplicationDbContext _context;


        public SerieEditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int seriesId)
        {

            this.SerieAtual = _context.SerieDB.FirstOrDefault(s => s.Id == seriesId);

            return Page();
        }

        public IActionResult OnPost()
        {


            // Retrieve imageURL and seriesId from the form data
            if (int.TryParse(Request.Form["seriesId"], out int seriesId) &&
                Request.Form.TryGetValue("imageURL", out StringValues imageURLValues))
            {
                // 1. Retrieve the entity you want to update from the database.
                var existingSerie = _context.SerieDB.FirstOrDefault(s => s.Id == seriesId);

                if (existingSerie == null)
                {
                    // Handle the case where the SerieModel is not found, such as showing an error page or a message.
                    return NotFound();
                }
                string imageURL = imageURLValues.FirstOrDefault();

                // 2. Update the properties of the entity with the new values.
                existingSerie.SerieName = SerieAtual.SerieName;
                existingSerie.Description = SerieAtual.Description;
                existingSerie.Price = SerieAtual.Price;
                existingSerie.imageURL = imageURL;

                // 3. Save the changes to the database.
                _context.SaveChanges();

            }
            // 4. Abrir outra vez este ViewModel
            return RedirectToPage("/MainScreenAdmin");

        }
    }
}
