using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MichaelBrandonMorris.Rqtblr.Models
{
    public class User : IdentityUser
    {
        public ICollection<LadderPlayer> LadderPlayers { get; } = new List<LadderPlayer>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}