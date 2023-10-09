using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4All.Data;
using Shows4All.Models;

namespace Shows4All.Pages.Checkout
{
    public class SerieInfoModel : PageModel
    {

        //this context is our database
        private readonly ApplicationDbContext _context;
        public SerieInfoModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
    }
}
