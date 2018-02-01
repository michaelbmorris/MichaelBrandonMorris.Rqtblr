namespace MichaelBrandonMorris.Rqtblr.Models
{
    public class MatchTeam
    {
        public MatchTeam()
        {
            
        }

        public MatchTeam(Match match, Team team)
        {
            Match = match;
            Team = team;
        }

        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public Match Match { get; set; }
        public Team Team { get; set; }
    }
}