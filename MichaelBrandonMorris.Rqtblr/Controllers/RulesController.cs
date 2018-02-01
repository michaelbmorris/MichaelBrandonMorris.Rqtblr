using System.Threading.Tasks;
using MichaelBrandonMorris.Rqtblr.Data;
using MichaelBrandonMorris.Rqtblr.Models;
using MichaelBrandonMorris.Rqtblr.Models.RulesViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MichaelBrandonMorris.Rqtblr.Controllers
{
    public class RulesController : Controller
    {
        public RulesController(RqtblrDbContext db)
        {
            Db = db;
        }

        public RqtblrDbContext Db { get; }

        public async Task<IActionResult> Index()
        {
            var rules = await Db.Rules.ToListAsync();
            return View(rules);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var rules = await Db.FindAsync<Rules>(id);
            return View(rules);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RulesEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var rules = new Rules(model);
            Db.Rules.Add(rules);
            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}