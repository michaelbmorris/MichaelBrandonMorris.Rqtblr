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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LadderPlayer>()
                .HasKey(x => new {x.LadderId, x.PlayerId});
        }
    }
}