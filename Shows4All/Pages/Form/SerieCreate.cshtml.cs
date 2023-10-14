
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
        
        public void OnGet()
        {
            
        }
    }
}
