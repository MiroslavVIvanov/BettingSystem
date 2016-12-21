namespace BettingSystem.Data.XmlFeedModels
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "XmlSports")]
    public class SportsCollection
    {
        [XmlAttribute(AttributeName = "CreateDate")]
        public DateTime CreateDate { get; set; }

        [XmlElement(ElementName = "Sport")]
        public HashSet<Sport> Sports { get; set; }
    }
}
