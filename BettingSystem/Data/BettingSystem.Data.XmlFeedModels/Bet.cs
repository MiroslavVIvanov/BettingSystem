namespace BettingSystem.Data.XmlFeedModels
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "Bet")]
    public class Bet
    {
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "IsLive")]
        public bool IsLive { get; set; }

        [XmlIgnore]
        public HashSet<Odd> OddsCollection
        {
            get { return this.Odds; }
        }

        [XmlElement(ElementName = "Odd")]
        internal HashSet<Odd> Odds { get; set; }
    }
}