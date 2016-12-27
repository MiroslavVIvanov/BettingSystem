namespace BettingSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using XmlFeedModels;

    public class XmlProcessor
    {
        private SportsCollection oldCollection;

        public void InitializeDatabase(string url)
        {
            XmlReader reader = this.Fetch(url);
            SportsCollection sports = this.Parse(reader);
            this.oldCollection = sports;
            this.CreateOrUpdateDataBase(sports);
        }

        public void UpdateDatabase(string url)
        {
            XmlReader reader = this.Fetch(url);
            SportsCollection sports = this.Parse(reader);
            SportsCollection uniqueSports = this.GetChangedEntities(sports, this.oldCollection);
            this.oldCollection = sports;
            this.CreateOrUpdateDataBase(uniqueSports);
        }

        private SportsCollection GetChangedEntities(SportsCollection newSportsCollection, SportsCollection oldSportsCollection)
        {
            // TODO: implement
            return null;
        }

        private void CreateOrUpdateDataBase(SportsCollection xmlFeedModelsCollection)
        {
            if (xmlFeedModelsCollection != null)
            {
                var context = new BetsDbContext();
                var sportsContext = new EfGenericRepository<Models.Sport>(context);
                var eventsContext = new EfGenericRepository<Models.Event>(context);
                var matchesContext = new EfGenericRepository<Models.Match>(context);
                var betsContext = new EfGenericRepository<Models.Bet>(context);
                var oddsContext = new EfGenericRepository<Models.Odd>(context);

                var allSports = new HashSet<Models.Sport>(sportsContext.All());
                var allSportEvents = new HashSet<Models.Event>(eventsContext.All());
                var allMatches = new HashSet<Models.Match>(matchesContext.All());
                var allBets = new HashSet<Models.Bet>(betsContext.All());
                var allOdds = new HashSet<Models.Odd>(oddsContext.All());

                foreach (XmlFeedModels.Sport sport in xmlFeedModelsCollection.Sports)
                {
                    var currentSport = allSports.FirstOrDefault(s => s.Id == sport.Id);

                    if (currentSport == null)
                    {
                        currentSport = new Models.Sport()
                        {
                            Id = sport.Id,
                            Name = sport.Name
                        };

                        sportsContext.Add(currentSport);
                    }

                    foreach (XmlFeedModels.Event sportEvent in sport.Events)
                    {
                        var currentEvent = allSportEvents.FirstOrDefault(e => e.Id == sportEvent.Id);

                        if (currentEvent == null)
                        {
                            currentEvent = new Models.Event()
                            {
                                Id = sportEvent.Id,
                                Name = sportEvent.Name,
                                CategoryId = sportEvent.CategoryId,
                                IsLive = sportEvent.IsLive,
                                SportId = currentSport.Id
                            };

                            eventsContext.Add(currentEvent);
                        }

                        foreach (XmlFeedModels.Match match in sportEvent.Matches)
                        {
                            var currentMatch = allMatches.FirstOrDefault(m => m.Id == match.Id);

                            if (currentMatch == null)
                            {
                                currentMatch = new Models.Match()
                                {
                                    Id = match.Id,
                                    Name = match.Name,
                                    StartDate = match.StartDate,
                                    MatchType = match.MatchType,
                                    EventId = currentEvent.Id
                                };

                                matchesContext.Add(currentMatch);
                            }

                            foreach (XmlFeedModels.Bet bet in match.Bets)
                            {
                                var currentBet = allBets.FirstOrDefault(b => b.Id == bet.Id);

                                if (currentBet == null)
                                {
                                    currentBet = new Models.Bet()
                                    {
                                        Id = bet.Id,
                                        Name = bet.Name,
                                        IsLive = bet.IsLive,
                                        MatchId = currentMatch.Id
                                    };

                                    betsContext.Add(currentBet);
                                }

                                foreach (XmlFeedModels.Odd odd in bet.OddsCollection)
                                {
                                    var currentOdd = allOdds.FirstOrDefault(o => o.Id == odd.Id);

                                    if (currentOdd == null)
                                    {
                                        currentOdd = new Models.Odd()
                                        {
                                            Id = odd.Id,
                                            Name = odd.Name,
                                            Value = odd.Value,
                                            SpecialBetValue = odd.SpecialBetValue,
                                            Bet = currentBet
                                        };

                                        oddsContext.Add(currentOdd);
                                    }
                                }
                            }

                            sportsContext.SaveChanges();
                        }
                    }
                }

                sportsContext.SaveChanges();
            }
        }

        private XmlReader Fetch(string url)
        {
            return new XmlTextReader(url);
        }

        private SportsCollection Parse(XmlReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SportsCollection));

            SportsCollection sports;

            using (reader)
            {
                sports = (SportsCollection)serializer.Deserialize(reader);
            }

            return sports;
        }
    }
}
