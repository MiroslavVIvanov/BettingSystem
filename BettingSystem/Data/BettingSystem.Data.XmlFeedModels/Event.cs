namespace BettingSystem.Data.XmlFeedModels
{
    using System.Collections.Generic;

    public class Event
    {
        public Event()
        {
            this.Matches = new HashSet<Match>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
