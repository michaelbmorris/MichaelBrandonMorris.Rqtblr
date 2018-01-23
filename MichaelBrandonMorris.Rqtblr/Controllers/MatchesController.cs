using System.Threading.Tasks;
using MichaelBrandonMorris.Rqtblr.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var match = await Db.Matches.Include(x => x.TeamOne.PlayerOne)
                .Include(x => x.TeamOne.PlayerTwo)
                .Include(x => x.TeamTwo.PlayerOne)
                .Include(x => x.TeamTwo.PlayerTwo)
                .Include(x => x.Ladder)
                .SingleOrDefaultAsync(x => x.Id == id);

            return View(match);
        }

        public async Task<IActionResult> Index()
        {
            var matches = await Db.Matches.ToListAsync();
            return View(matches);
        }
    }
}