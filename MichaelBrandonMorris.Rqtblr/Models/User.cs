using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MichaelBrandonMorris.Rqtblr.Models
{
    public class User : IdentityUser
    {
        public ICollection<LadderPlayer> LadderPlayers { get; } =
            new List<LadderPlayer>();

        public ICollection<TeamPlayer> TeamPlayers { get; set; } =
            new List<TeamPlayer>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}