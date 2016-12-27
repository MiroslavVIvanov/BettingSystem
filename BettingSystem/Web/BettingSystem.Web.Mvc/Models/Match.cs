namespace BettingSystem.Web.Mvc.Models
{
    using System;
    using System.Collections.Generic;

    public class Match
    {
        private ICollection<Bet> bets;

        public Match()
        {
            this.bets = new HashSet<Bet>();
        }

        public string SportName { get; set; }

        public string EventName { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string MatchType { get; set; }

        public virtual ICollection<Bet> Bets
        {
            get { return this.bets; }
            set { this.bets = value; }
        }
    }
}