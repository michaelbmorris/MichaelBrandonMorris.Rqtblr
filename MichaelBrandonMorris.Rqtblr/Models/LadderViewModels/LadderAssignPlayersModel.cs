using System.Collections.Generic;

namespace MichaelBrandonMorris.Rqtblr.Models.LadderViewModels
{
    public class LadderAssignPlayersModel
    {
        public IList<User> Players { get; set; }
        public Ladder Ladder { get; set; }
    }
}