namespace BettingSystem.Web.Mvc.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using DataServices;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var matches = MatchesService.GetMatchesInTwentyFourHours();

            var viewModelMatches = new HashSet<Match>();

            foreach (var match in matches)
            {
                var bets = new HashSet<Bet>();

                foreach (var bet in match.Bets)
                {
                    var newBet = new Bet()
                    {
                        Name = bet.Name,
                        IsLive = bet.IsLive
                    };

                    var odds = new HashSet<Odd>();

                    foreach (var odd in bet.Odds)
                    {
                        odds.Add(new Odd()
                        {
                            Name = odd.Name,
                            Value = odd.Value,
                            SpecialBetValue = odd.SpecialBetValue
                        });
                    }

                    newBet.Odds = odds;

                    bets.Add(newBet);
                }

                viewModelMatches.Add(new Match()
                {
                    SportName = match.Event.Sport.Name,
                    EventName = match.Event.Name,
                    Name = match.Name,
                    MatchType = match.MatchType,
                    StartDate = match.StartDate,
                    Bets = bets 
                });
            }

            return this.View(viewModelMatches);
        }
    }
}