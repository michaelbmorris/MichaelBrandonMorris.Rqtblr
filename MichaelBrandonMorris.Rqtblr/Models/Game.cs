namespace MichaelBrandonMorris.Rqtblr.Models
{
    public enum GameType
    {
        Singles,
        Doubles,
        Cutthroat,
        Ironman
    }

    public class Game
    {
        public int Id { get; set; }
        public int TeamOneScore { get; set; }
        public int TeamThreeScore { get; set; }
        public int TeamTwoScore { get; set; }
        public virtual Match Match { get; set; }
    }
}