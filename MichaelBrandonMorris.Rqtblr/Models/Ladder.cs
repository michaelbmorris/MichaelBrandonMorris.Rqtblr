using System.Collections.Generic;

namespace MichaelBrandonMorris.Rqtblr.Models
{
    public class Ladder
    {
        public ICollection<LadderPlayer> LadderPlayers { get; } = new List<LadderPlayer>();
        public ICollection<Match> Matches { get; set; } = new List<Match>();
        public Rules Rules { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}