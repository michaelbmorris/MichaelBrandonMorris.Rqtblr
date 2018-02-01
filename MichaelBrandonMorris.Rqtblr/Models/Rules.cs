using Foolproof;
using MichaelBrandonMorris.Rqtblr.Models.RulesViewModels;

namespace MichaelBrandonMorris.Rqtblr.Models
{
    public class Rules
    {
        public Rules()
        {
        }

        public Rules(RulesEditModel model)
        {
            CanTieMatch = model.CanTieMatch;
            MustWinGameByTwoPoints = model.MustWinGameByTwoPoints;
            GamesPerMatch = model.GamesPerMatch;
            GamesToWinMatch = model.GamesToWinMatch;
            Id = model.Id;
            PointsToWinGame = model.PointsToWinGame;
            PointsToWinTiebreaker = model.PointsToWinTiebreaker;
            Name = model.Name;
        }

        public bool CanTieMatch { get; set; }
        public bool MustWinGameByTwoPoints { get; set; }
        public int GamesPerMatch { get; set; }
        public int? GamesToWinMatch { get; set; }
        public int Id { get; set; }
        public int PointsToWinGame { get; set; }
        public int? PointsToWinTiebreaker { get; set; }
        public string Name { get; set; }
    }
}