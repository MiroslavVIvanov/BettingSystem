namespace BettingSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        private ICollection<Odd> odds;

        public Bet()
        {
            this.odds = new HashSet<Odd>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public virtual ICollection<Odd> Odds
        {
            get { return this.odds; }
            set { this.odds = value; }
        }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }
    }
}
