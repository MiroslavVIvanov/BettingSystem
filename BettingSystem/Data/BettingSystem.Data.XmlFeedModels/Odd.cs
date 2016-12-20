namespace BettingSystem.Data.XmlFeedModels
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "Odd")]
    public class Odd
    {
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "Value")]
        public float Value { get; set; }

        [XmlAttribute(AttributeName = "SpecialBetValue")]
        public float? SpecialBetValue { get; set; }
    }
}