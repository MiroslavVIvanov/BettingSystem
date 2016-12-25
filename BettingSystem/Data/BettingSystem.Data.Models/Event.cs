namespace BettingSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event
    {
        private ICollection<Match> matches;

        public Event()
        {
            this.matches = new HashSet<Match>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.MaxNameLength)]
        public string Name { get; set; }

        public bool IsLive { get; set; }

        public int CategoryId { get; set; }

        public virtual ICollection<Match> Matches
        {
            get { return this.matches; }
            set { this.matches = value; }
        }

        public int SportId { get; set; }

        public virtual Sport Sport { get; set; }
    }
}
