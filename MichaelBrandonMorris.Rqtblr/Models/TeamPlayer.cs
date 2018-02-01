namespace MichaelBrandonMorris.Rqtblr.Models
{
    public class TeamPlayer
    {
        public TeamPlayer()
        {
        }

        public TeamPlayer(Team team, User player)
        {
            Team = team;
            Player = player;
        }

        public int TeamId { get; set; }
        public string PlayerId { get; set; }
        public Team Team { get; set; }
        public User Player { get; set; }
    }
}