namespace BettingSystem.Data.XmlFeedModels
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "Sport")]
    public class Sport
    {
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Event")]
        public HashSet<Event> Events { get; set; }
    }
}