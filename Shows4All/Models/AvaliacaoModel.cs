using Shows4All.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shows4All.Models
{
    public class AvaliacaoModel
    {
        public int Id { get; set; }
        public string? AvaliacaoTexto { get; set; }

        [ForeignKey("ClientID")]
        public ClienteModel? ClientModel { get; set; }

        [ForeignKey("SerieID")]
        public SerieModel? SerieModel { get; set; }


        private readonly ApplicationDbContext _context;

        public AvaliacaoModel()
        {
        }
        public AvaliacaoModel(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
