using Microsoft.EntityFrameworkCore;
using Shows4All.Models;

namespace Shows4All.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<SerieModel> SerieDB { get; set; }

        public DbSet<ClienteModel> ClienteDB { get; set; }

        public DbSet<ClienteSeriesModel> ClienteSeriesDB { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
