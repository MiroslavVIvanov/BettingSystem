namespace BettingSystem.Data.XmlFeedModels
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "Match")]
    public class Match
    {
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "StartDate")]
        public DateTime StartDate { get; set; }

        [XmlAttribute(AttributeName = "MatchType")]
        public string MatchType { get; set; }

        [XmlElement(ElementName = "Bet")]
        public HashSet<Bet> Bets { get; set; }
    }
}