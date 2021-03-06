﻿using System.Threading.Tasks;
using MichaelBrandonMorris.Rqtblr.Data;
using MichaelBrandonMorris.Rqtblr.Models;
using MichaelBrandonMorris.Rqtblr.Models.PlayersViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MichaelBrandonMorris.Rqtblr.Controllers
{
    public class PlayersController : Controller
    {
        public PlayersController(RqtblrDbContext db)
        {
            Db = db;
        }

        public RqtblrDbContext Db { get; set; }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlayerEditModel model)
        {
            Db.Add(
                new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                });

            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            //var player = await Db.FindAsync<User>(id);

            var player = await Db.Users.Include(x => x.TeamPlayers)
                .ThenInclude(x => x.Team)
                .SingleOrDefaultAsync(x => id == x.Id);

            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        public async Task<IActionResult> Index()
        {
            var players = await Db.Users.ToListAsync();
            return View(players);
        }
    }
}