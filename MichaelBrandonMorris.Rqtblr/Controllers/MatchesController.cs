using System.Threading.Tasks;
using MichaelBrandonMorris.Rqtblr.Data;
using MichaelBrandonMorris.Rqtblr.Models.MatchViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MichaelBrandonMorris.Rqtblr.Controllers
{
    public class MatchesController : Controller
    {
        public MatchesController(RqtblrDbContext db)
        {
            Db = db;
        }

        private RqtblrDbContext Db { get; }

        public async Task<IActionResult> Details(int id)
        {
            var match = await Db.GetMatchAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            var model = new MatchDisplayModel(match);
            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            var matches = await Db.GetMatchesAsync();
            var model = new MatchListModel(matches);
            return View(model);
        }
    }
}