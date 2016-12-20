namespace BettingSystem.Data.XmlFeedModels
{
    public class Odd
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Value { get; set; }

        public float? SpecialBetValue { get; set; }
    }
}
