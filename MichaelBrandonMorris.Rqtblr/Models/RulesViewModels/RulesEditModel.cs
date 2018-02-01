using System.ComponentModel.DataAnnotations;

namespace MichaelBrandonMorris.Rqtblr.Models.RulesViewModels
{
    public class RulesEditModel
    {
        [Display(Name = "Match can result in a tie?")]
        public bool CanTieMatch { get; set; }

        [Display(Name = "Must win game by two points?")]
        public bool MustWinGameByTwoPoints { get; set; }

        [Display(Name = "Number of Games Per Match")]
        public int GamesPerMatch { get; set; }

        [Display(Name = "Number of Games to Win Match")]
        public int? GamesToWinMatch { get; set; }

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Number of Points to Win Game")]
        public int PointsToWinGame { get; set; }

        [Display(Name = "Number of Points to Win Tiebreaker")]
        public int? PointsToWinTiebreaker { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}