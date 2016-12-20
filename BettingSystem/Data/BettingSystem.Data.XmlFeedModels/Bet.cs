namespace BettingSystem.Data.XmlFeedModels
{
    using System.Collections.Generic;

    public class Bet
    {
        public Bet()
        {
            this.Odds = new HashSet<Odd>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        ICollection<Odd> Odds { get; set; }
    }
}
