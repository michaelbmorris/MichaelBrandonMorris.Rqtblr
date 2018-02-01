using System;
using System.Collections.Generic;

namespace MichaelBrandonMorris.Rqtblr.Models
{
    public class Team
    {
        public Team()
        {
        }

        public Team(User player)
        {
            TeamPlayers.Add(new TeamPlayer(this, player));
        }

        public Team(ICollection<User> players)
        {
            if (players.Count > 2)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(players),
                    "The number of players on a team must not exceed two.");
            }

            foreach (var player in players)
            {
                TeamPlayers.Add(new TeamPlayer(this, player));
            }
        }

        public virtual ICollection<MatchTeam> MatchTeams { get; set; } =
            new List<MatchTeam>();

        public ICollection<TeamPlayer> TeamPlayers { get; set; } =
            new List<TeamPlayer>();

        public int Id { get; set; }
    }
}