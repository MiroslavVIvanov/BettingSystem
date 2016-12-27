namespace BettingSystem.Data
{
    using System.Data.Entity;
    using Models;

    public class BetsDbContext : DbContext
    {
        public BetsDbContext()
            : base("TestBettingSystemDatabase")
        {
        }

        public virtual IDbSet<Odd> Odds { get; set; }

        public virtual IDbSet<Bet> Bets { get; set; }

        public virtual IDbSet<Match> Matches { get; set; }

        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<Sport> Sports { get; set; }
    }
}
