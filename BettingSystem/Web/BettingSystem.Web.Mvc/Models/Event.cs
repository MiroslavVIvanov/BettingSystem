namespace BettingSystem.Web.Mvc.Models
{
    using System.Collections.Generic;

    public class Event
    {
        private ICollection<Match> matches;

        public Event()
        {
            this.matches = new HashSet<Match>();
        }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public virtual ICollection<Match> Matches
        {
            get { return this.matches; }
            set { this.matches = value; }
        }
    }
}