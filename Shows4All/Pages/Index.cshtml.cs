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
            //_context.SerieModel.Add(new SerieModel());
            //_context.SaveChanges();
        }
        public IActionResult OnPost()
        {

            _context.ClientModel.Add(new ClienteModel());
            _context.SaveChanges();

            //ChatGPT Base Code Generated
            if (ModelState.IsValid)
            {
                // Attempt to find a user with the provided username in the database
                var user = _context.ClientModel.FirstOrDefault(u => u.Username == Login.Username);

                if (user != null && IsPasswordValid(user, Login.Password))
                {
                    // Successful login
                    // You can implement authentication here (e.g., setting a cookie)
                    return RedirectToPage("/MainScreenClient"); // Redirect to a protected page
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
            return client.Password == password;
        }
    }
}