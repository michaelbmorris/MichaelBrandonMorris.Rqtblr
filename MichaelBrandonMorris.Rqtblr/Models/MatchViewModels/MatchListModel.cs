using System.Collections.Generic;
using System.Linq;

namespace MichaelBrandonMorris.Rqtblr.Models.MatchViewModels
{
    public class MatchListModel
    {
        public MatchListModel()
        {
        }

        public MatchListModel(IEnumerable<Match> matches)
        {
            Matches = matches.Select(x => new MatchDisplayModel(x)).ToList();
        }

        public MatchListModel(IList<MatchDisplayModel> matches)
        {
            Matches = matches;
        }

        public IList<MatchDisplayModel> Matches { get; set; } =
            new List<MatchDisplayModel>();
    }
}