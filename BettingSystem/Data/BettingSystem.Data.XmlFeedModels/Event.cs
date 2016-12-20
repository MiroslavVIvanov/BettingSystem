namespace BettingSystem.Data.XmlFeedModels
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "Event")]
    public class Event
    {
        public Event()
        {
            this.Matches = new HashSet<Match>();
        }

        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "IsLive")]
        public bool IsLive { get; set; }

        [XmlAttribute(AttributeName = "CategoryID")]
        public int CategoryId { get; set; }

        [XmlElement(ElementName = "Match")]
        public HashSet<Match> Matches { get; set; }
    }
}