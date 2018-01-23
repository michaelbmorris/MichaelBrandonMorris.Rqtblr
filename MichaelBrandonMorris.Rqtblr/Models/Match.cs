using System.Collections.Generic;

namespace MichaelBrandonMorris.Rqtblr.Models
{
    public class Match
    {
        public GameType GameType { get; set; }
        public IList<Game> Games { get; set; }
        public int Id { get; set; }
        public virtual Team TeamOne { get; set; }
        public virtual Team TeamThree { get; set; }
        public virtual Team TeamTwo { get; set; }
        public bool IsComplete { get; set; }
        public Ladder Ladder { get; set; }
    }
}