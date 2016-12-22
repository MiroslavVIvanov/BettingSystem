namespace BettingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Match
    {
        private ICollection<Bet> bets;

        public Match()
        {
            this.bets = new HashSet<Bet>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(Constants.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public string MatchType { get; set; }

        public virtual ICollection<Bet> Bets
        {
            get { return this.bets; }
            set { this.bets = value; }
        }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
