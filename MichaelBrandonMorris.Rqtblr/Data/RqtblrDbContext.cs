using System.Collections.Generic;
using System.Threading.Tasks;
using MichaelBrandonMorris.Rqtblr.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MichaelBrandonMorris.Rqtblr.Data
{
    public class RqtblrDbContext : IdentityDbContext<User>
    {
        public RqtblrDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Ladder> Ladders { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Rules> Rules { get; set; }

        public async Task<Match> GetMatchAsync(int id)
        {
            return await Matches.Include(x => x.MatchTeams)
                .ThenInclude(x => x.Team.TeamPlayers)
                .ThenInclude(x => x.Player)
                .Include(x => x.Games)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ladder> GetLadderAsync(int id)
        {
            return await Ladders.Include(x => x.LadderPlayers)
                .ThenInclude(x => x.Player)
                .Include(x => x.Matches)
                .ThenInclude(x => x.MatchTeams)
                .ThenInclude(x => x.Team.TeamPlayers)
                .ThenInclude(x => x.Player)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Ladder>> GetLaddersAsync()
        {
            return await Ladders.Include(x => x.LadderPlayers)
                .ThenInclude(x => x.Player)
                .Include(x => x.Matches)
                .ThenInclude(x => x.MatchTeams)
                .ThenInclude(x => x.Team.TeamPlayers)
                .ThenInclude(x => x.Player)
                .ToListAsync();
        }

        public async Task<IList<Match>> GetMatchesAsync()
        {
            return await Matches.Include(x => x.MatchTeams)
                .ThenInclude(x => x.Team.TeamPlayers)
                .ThenInclude(x => x.Player)
                .Include(x => x.Games)
                .ToListAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LadderPlayer>()
                .HasKey(x => new {x.LadderId, x.PlayerId});

            builder.Entity<TeamPlayer>()
                .HasKey(x => new {x.TeamId, x.PlayerId});

            builder.Entity<MatchTeam>().HasKey(x => new {x.MatchId, x.TeamId});
        }
    }
}