namespace BettingSystem.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
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

            this.CreateDataBase(sports);
        }

        public void UpdateDatabase(string url)
        {
            XmlReader reader = this.Fetch(url);
            SportsCollection sports = this.Parse(reader);

            SportsCollection uniqueSports = GetUniqueEntities(sports, this.oldCollection);
            
            this.CreateDataBase(uniqueSports);
        }

        private SportsCollection GetUniqueEntities(SportsCollection newSportsCollection, SportsCollection oldSportsCollection)
        {
            // TODO: implement
            return null;
        }


        private void CreateDataBase(SportsCollection xmlFeedModelsCollection)
        {
            if (xmlFeedModelsCollection == null)
            {
                return;
            }

            BetsDbContext context = new BetsDbContext();
            var sportsContext = new EfGenericRepository<Models.Sport>(context);
            var eventsContext = new EfGenericRepository<Models.Event>(context);
            var matchesContext = new EfGenericRepository<Models.Match>(context);
            var betsContext = new EfGenericRepository<Models.Bet>(context);

            var allSports = new HashSet<Models.Sport>(sportsContext.All());
            var allSportEvents = new HashSet<Models.Event>(eventsContext.All());
            var allMatches = new HashSet<Models.Match>(matchesContext.All());
            var allBets = new HashSet<Models.Bet>(betsContext.All());


            //var allSports = sportsContext.All();

            foreach (XmlFeedModels.Sport sport in xmlFeedModelsCollection.Sports)
            {
                //var currentSport = sportsContext.GetById(sport.Id);
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

                //var allSportEvents = eventsContext.All();

                foreach (XmlFeedModels.Event sportEvent in sport.Events)
                {
                    //var currentEvent = eventsContext.GetById(sportEvent.Id);
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

                    //var allMatches = matchesContext.All();

                    foreach (XmlFeedModels.Match match in sportEvent.Matches)
                    {
                        //var currentMatch = matchesContext.GetById(match.Id);
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

                        //var allBets = betsContext.All();

                        foreach (XmlFeedModels.Bet bet in match.Bets)
                        {
                            //var currentBet = betsContext.GetById(bet.Id);
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
                        }

                        sportsContext.SaveChanges();
                    }
                }
            }

            sportsContext.SaveChanges();
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
