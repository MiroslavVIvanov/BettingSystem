namespace BettingSystem.DataBaseUpdateService
{
    using System;
    using System.Threading;
    using BettingSystem.Data;

    public static class DataBaseUpdateService
    {
        private const string BetsXmlFeedUrl = @"http://vitalbet.net/sportxml";

        public static void Start()
        {
            // initialize the database
            new XmlProcessor().InitializeDatabase(BetsXmlFeedUrl);

            // start the service after the database is filled with values
            var timer = new Timer(work =>
            {
                new XmlProcessor().UpdateDatabase(BetsXmlFeedUrl);
            });

            timer.Change(TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }
    }
}
