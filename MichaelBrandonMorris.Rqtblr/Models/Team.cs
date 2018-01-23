namespace MichaelBrandonMorris.Rqtblr.Models
{
    public class Team
    {
        public int Id { get; set; }
        public virtual User PlayerOne { get; set; }
        public virtual User PlayerTwo { get; set; }
    }
}