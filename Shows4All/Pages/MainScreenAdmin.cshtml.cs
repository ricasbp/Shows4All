using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4All.Data;
using Shows4All.Models;

namespace Shows4All.Pages
{
    public class MainScreenAdmin : PageModel
    {
        public List<SerieModel> todasAsSeries = new List<SerieModel>();

        // UserID que vem do Login/Index.cshtml
        [BindProperty(SupportsGet = true)]
        public int userID { get; set; }

        [BindProperty]
        public ClienteModel ClienteModelAtual { get; set; }

        //this context is our database
        private readonly ApplicationDbContext _context;



        public MainScreenAdmin(ApplicationDbContext context)
        {
            _context = context;

        }

        public void OnGet()
        {
            // Retrieve ClienteModel from the database based on clienteID
            this.ClienteModelAtual = _context.ClienteDB.FirstOrDefault(c => c.Id == userID);

            this.todasAsSeries = _context.SerieDB.ToList();

        }


    }
}
