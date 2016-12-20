﻿namespace BettingSystem.Data.XmlFeedModels
{
    using System;
    using System.Collections.Generic;

    public class Match
    {
        public Match()
        {
            this.Bets = new HashSet<Bet>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string MatchType { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
