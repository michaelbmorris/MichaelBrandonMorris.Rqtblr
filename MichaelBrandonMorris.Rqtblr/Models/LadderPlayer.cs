namespace MichaelBrandonMorris.Rqtblr.Models
{
    public class LadderPlayer
    {
        public double Rank { get; set; }
        public int LadderId { get; set; }
        public virtual Ladder Ladder { get; set; }
        public string PlayerId { get; set; }
        public virtual User Player { get; set; }
    }
}