using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MichaelBrandonMorris.Rqtblr.Models.MatchViewModels
{
    public class MatchDisplayModel
    {
        public IList<TeamDisplayModel> Teams = new List<TeamDisplayModel>();

        public MatchDisplayModel()
        {
        }

        public MatchDisplayModel(Match match)
        {
            GameType = match.GameType;
            Id = match.Id;

            Teams = match.MatchTeams.Select(x => new TeamDisplayModel(x.Team))
                .ToList();
        }

        [Display(Name = "Game Type")]
        public GameType GameType { get; set; }

        [Display(Name = "ID")]
        public int Id { get; set; }
    }

    public class TeamDisplayModel
    {
        public TeamDisplayModel()
        {
        }

        public TeamDisplayModel(Team team)
        {
            Players =
                team.TeamPlayers.Select(x => new PlayerDisplayModel(x.Player))
                    .ToList();
        }

        public IList<PlayerDisplayModel> Players { get; set; } =
            new List<PlayerDisplayModel>();
    }

    public class PlayerDisplayModel
    {
        public PlayerDisplayModel()
        {
        }

        public PlayerDisplayModel(User player)
        {
            FirstName = player.FirstName;
            LastName = player.LastName;
        }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}