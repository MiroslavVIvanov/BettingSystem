namespace BettingSystem.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BettingSystem.Data;
    using BettingSystem.Data.Models;

    public static class MatchesService
    {
        public static ICollection<Match> GetMatchesInTwentyFourHours()
        {
            IRepository<Match> matchesContext = new EfGenericRepository<Match>(new BetsDbContext());

            var startPeriod = DateTime.Now;
            var endPeriod = startPeriod.AddHours(24);

            var matches = matchesContext
                .All()
                .Where(m => 
                    DateTime.Compare(m.StartDate, startPeriod) > 0 &&
                    DateTime.Compare(m.StartDate, endPeriod) < 0)
                .ToList();

            return matches;
        }
    }
}
