using System;
using System.Linq;
using System.Threading.Tasks;
using MichaelBrandonMorris.Rqtblr.Data;
using MichaelBrandonMorris.Rqtblr.Models;
using MichaelBrandonMorris.Rqtblr.Models.LadderViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MichaelBrandonMorris.Rqtblr.Controllers
{
    public class LaddersController : Controller
    {
        public LaddersController(RqtblrDbContext db)
        {
            Db = db;
        }

        public RqtblrDbContext Db { get; }

        [HttpGet]
        public async Task<IActionResult> AssignPlayers(int id)
        {
            var ladder = await Db.Ladders.Include(x => x.LadderPlayers)
                .SingleOrDefaultAsync(x => x.Id == id);
            var players = await Db.Users.ToListAsync();

            var model = new LadderAssignPlayersModel
            {
                Ladder = ladder,
                Players = players
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignPlayers(
            int id,
            string[] playerIds)
        {
            var ladder = await Db.Ladders.Include(x => x.LadderPlayers)
                .SingleOrDefaultAsync(x => x.Id == id);

            var ladderPlayers = ladder.LadderPlayers.ToList();

            foreach (var playerId in playerIds)
            {
                if (ladderPlayers.Any(x => x.PlayerId == playerId))
                {
                    continue;
                }

                var player = await Db.FindAsync<User>(playerId);

                ladder.LadderPlayers.Add(
                    new LadderPlayer
                    {
                        Ladder = ladder,
                        Player = player
                    });
            }

            foreach (var ladderPlayer in ladderPlayers)
            {
                if (playerIds.Any(x => x == ladderPlayer.PlayerId))
                {
                    continue;
                }

                ladder.LadderPlayers.Remove(ladderPlayer);
            }

            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LadderEditModel model)
        {
            Db.Add(
                new Ladder
                {
                    Name = model.Name
                });

            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var ladder = await Db.Ladders.Include(x => x.LadderPlayers)
                .ThenInclude(x => x.Player)
                .Include(x => x.Matches).ThenInclude(x => x.TeamOne.PlayerOne)
                .Include(x => x.Matches).ThenInclude(x => x.TeamOne.PlayerTwo)
                .Include(x => x.Matches).ThenInclude(x => x.TeamTwo.PlayerOne)
                .Include(x => x.Matches).ThenInclude(x => x.TeamTwo.PlayerTwo)
                .SingleOrDefaultAsync(x => x.Id == id);

            return View(ladder);
        }

        public async Task<IActionResult> Index()
        {
            var ladders = await Db.Ladders.Include(x => x.LadderPlayers)
                .ToListAsync();
            return View(ladders);
        }

        public async Task<IActionResult> PlayGame(int id)
        {
            var ladder = await Db.Ladders.Include(x => x.LadderPlayers)
                .ThenInclude(x => x.Player)
                .Include(x => x.Matches)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (ladder.LadderPlayers.Count < 2)
            {
                return View("Error");
            }

            var random = new Random();

            var players = ladder.LadderPlayers.Select(x => x.Player)
                .OrderBy(x => random.Next())
                .Take(2)
                .ToArray();

            var match = new Match
            {
                TeamOne = new Team
                {
                    PlayerOne = players[0]
                },
                TeamTwo = new Team
                {
                    PlayerOne = players[1]
                }
            };

            ladder.Matches.Add(match);
            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}