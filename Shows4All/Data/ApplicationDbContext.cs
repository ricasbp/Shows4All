using Microsoft.EntityFrameworkCore;
using Shows4All.Models;

namespace Shows4All.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<SerieModel> SerieModel { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
