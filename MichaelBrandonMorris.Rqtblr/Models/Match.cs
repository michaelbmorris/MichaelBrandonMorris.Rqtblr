using System;
using System.Collections.Generic;

namespace MichaelBrandonMorris.Rqtblr.Models
{
    public class Match
    {
        public Match()
        {
        }

        public Match(GameType gameType, ICollection<Team> teams)
        {
            GameType = gameType;

            if ((gameType == GameType.Singles ||
                 gameType == GameType.Doubles ||
                 gameType == GameType.Ironman) &&
                teams.Count != 2)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(teams), $"Game type {gameType} requires two teams.");
            }

            if (gameType == GameType.Cutthroat && teams.Count != 3)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(teams), "Game type Cutthroat requires three teams.");
            }

            foreach (var team in teams)
            {
                MatchTeams.Add(new MatchTeam(this, team));
            }
        }

        public bool IsComplete { get; set; }

        public GameType GameType { get; set; }
        public ICollection<Game> Games { get; set; } = new List<Game>();

        public ICollection<MatchTeam> MatchTeams { get; set; } =
            new List<MatchTeam>();

        public int Id { get; set; }
        public Ladder Ladder { get; set; }
    }
}