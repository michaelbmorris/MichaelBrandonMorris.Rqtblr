using System.Collections.Generic;
using System.Linq;
using MichaelBrandonMorris.Rqtblr.Models.MatchViewModels;

namespace MichaelBrandonMorris.Rqtblr.Models.LadderViewModels
{
    public class LadderDisplayModel
    {
        public LadderDisplayModel()
        {
        }

        public LadderDisplayModel(Ladder ladder)
        {
            Matches = ladder.Matches.Select(x => new MatchDisplayModel(x))
                .ToList();

            Players = ladder.LadderPlayers
                .Select(x => new PlayerDisplayModel(x.Player))
                .ToList();
        }

        public IList<MatchDisplayModel> Matches { get; set; } =
            new List<MatchDisplayModel>();

        public IList<PlayerDisplayModel> Players { get; set; } =
            new List<PlayerDisplayModel>();

        public string Name { get; set; }
    }
}