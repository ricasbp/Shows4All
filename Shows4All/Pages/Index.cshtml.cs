using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4All.Data;
using Shows4All.Models;

namespace Shows4All.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public LoginModel Login { get; set; }

        //this context is our database
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            //Populate our SerieDB
            /*
            SerieModel serie1 = new SerieModel("The Shining", "Horror Movie", 2, "jack");
            SerieModel serie2 = new SerieModel("The Wolf of Wall Street", "Action", 2, "wolf");
            SerieModel serie3 = new SerieModel("Silence of the Lambs", "Action Anime", 5, "silence");
            SerieModel serie4 = new SerieModel("Ponyo", "Action Anime", 5, "ponyo");
            SerieModel serie5 = new SerieModel("Parasite", "Drama, Horror", 2, "parasite");
            SerieModel serie6 = new SerieModel("Puss in the Boots", "Animation", 7, "puss");
            SerieModel serie7 = new SerieModel("Princess Mononoke", "Action Anime", 5, "mononoke");
            SerieModel serie8 = new SerieModel("The Grave of the Fireflies", "Drama Anime", 5, "fireflies");

            _context.SerieDB.Add(serie1);
            _context.SerieDB.Add(serie2);
            _context.SerieDB.Add(serie3);
            _context.SerieDB.Add(serie4);
            _context.SerieDB.Add(serie5);
            _context.SerieDB.Add(serie6);
            _context.SerieDB.Add(serie7);
            _context.SerieDB.Add(serie8);
            _context.SaveChanges();
            */

            /*
            SerieModel serie1 = new SerieModel("Shrek 2", "Horror Movie", 2, "Shrek2");
            _context.SerieDB.Add(serie1);
            SerieModel serie2 = new SerieModel("Spider-Man into the SpiderVerse", "Action Animation", 2, "Spiderverse");
            _context.SerieDB.Add(serie2);
            _context.SaveChanges();
            */
        }
        public IActionResult OnPost()
{

//_context.ClienteDB.Add(new ClienteModel());
//_context.SaveChanges();


if (ModelState.IsValid)
{
    // Attempt to find a user with the provided username in the database
    var user = _context.ClienteDB.FirstOrDefault(u => u.Username == Login.Username);

    if (user != null && IsPasswordValid(user, Login.Password))
    {
        // Successful login

        if ((bool)user.isAdmin)
        {
            return RedirectToPage("/MainScreenAdmin", new { userID = user.Id }); // Redirect to a protected page
        }
        else
        {
            return RedirectToPage("/MainScreenClient", new { userID = user.Id }); // Redirect to a protected page
        }

    }
    else
    {
        // Invalid login, display an error message
        ModelState.AddModelError(string.Empty, "Invalid username or password.");
        return Page(); // Stay on the login page
    }
}

// If ModelState is not valid, return to the login page
return Page();
}

private bool IsPasswordValid(ClienteModel client, string password)
{
// Check if the client is null
if (client == null)
{
    return false; // Invalid client
}

// Check if the provided password matches the stored password
return client.Password.Equals(password);
}
}
}