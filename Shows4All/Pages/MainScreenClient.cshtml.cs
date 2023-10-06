using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4All.Models;

namespace Shows4All.Pages
{
    public class MainScreenClientModel : PageModel
    {
        public List<SerieModel> fakeSerieDB = new List<SerieModel>()
        {
            new SerieModel() {
                SerieName="Yau1",
                Description="Yau1Descp",
                Price=1.00},
            new SerieModel() {
                SerieName="Yau2",
                Description="Yau2Descp",
                Price=2.00},
            new SerieModel() {
                SerieName="Yau3",
                Description="Yau3Descp",
                Price=3.00},
            new SerieModel() {
                SerieName="Yau4",
                Description="Yau4Descp",
                Price=4.00}
        };
        public void OnGet()
        {
        }
    }
}
