namespace BettingSystem.Web.Mvc.Models
{
    using System.Collections.Generic;

    public class Bet
    {
        private ICollection<Odd> odds;

        public Bet()
        {
            this.Odds = new HashSet<Odd>();
        }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public virtual ICollection<Odd> Odds
        {
            get { return this.odds; }
            set { this.odds = value; }
        }
    }
}