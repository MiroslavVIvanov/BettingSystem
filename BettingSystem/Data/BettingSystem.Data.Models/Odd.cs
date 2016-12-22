namespace BettingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Odd
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.MaxNameLength)]
        public string Name { get; set; }

        public float Value { get; set; }

        public float? SpecialBetValue { get; set; }

        public int BetId { get; set; }

        public virtual Bet Bet { get; set; }
    }
}
