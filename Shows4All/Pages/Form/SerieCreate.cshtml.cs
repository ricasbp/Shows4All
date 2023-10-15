
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4All.Data;
using Shows4All.Models;
using System.Security.Cryptography.X509Certificates;

namespace Shows4All.Pages.Form
{
    public class SerieCreateModel : PageModel
    {
        [BindProperty]
        public SerieModel Serie { get; set; }

        //this context is our database
        private readonly ApplicationDbContext _context;
        public SerieCreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public RedirectToPageResult OnPost()
        {
            // Add the Serie to the context
            _context.SerieDB.Add(Serie);

            // Save the changes to the database
            _context.SaveChanges();

            // Redirect to a success page or perform other actions.
            return RedirectToPage("/MainScreenAdmin"); // Redirect to a protected
        }
     }
}
