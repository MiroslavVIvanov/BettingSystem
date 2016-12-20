namespace BettingSystem.Data.XmlFeedModels
{
    using System.Collections.Generic;

    public class Sport
    {
        public Sport()
        {
            this.Events = new HashSet<Event>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
