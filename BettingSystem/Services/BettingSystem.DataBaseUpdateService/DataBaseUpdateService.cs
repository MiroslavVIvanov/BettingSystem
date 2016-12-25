namespace BettingSystem.DataBaseUpdateService
{
    using System;
    using System.Threading;
    using BettingSystem.Data;

    public class DataBaseUpdateService
    {
        private const string BetsXmlFeedUrl = @"http://vitalbet.net/sportxml";

        public void Start()
        {
            var timer = new Timer(work =>
            {
                new XmlProcessor().InitializeDatabase(BetsXmlFeedUrl);
            });

            timer.Change(TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }
    }
}
