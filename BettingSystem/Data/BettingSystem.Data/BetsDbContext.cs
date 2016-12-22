namespace BettingSystem.Data
{
    using Models;
    using System.Data.Entity;

    public class BetsDbContext : DbContext
    {
        public BetsDbContext()
            :base("BettingSystemDatabase")
        {
        }

        public virtual IDbSet<Odd> Odds { get; set; }

        public virtual IDbSet<Bet> Bets { get; set; }

        public virtual IDbSet<Match> Matches { get; set; }

        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<Sport> Sports { get; set; }
    }
}
