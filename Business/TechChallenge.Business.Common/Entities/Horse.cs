using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechChallenge.Business.Common.BaseClasses;

namespace TechChallenge.Business.Common.Entities
{
    public class Horse : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //This is not recommented in real scenario.
        public override int Id { get; set; }

        [Required]
        [Display(Name = "Race")]
        public int RaceId { get; set; }

        public string Name { get; set; }
        public double Odds { get; set; }
        public virtual Race Race { get; set; }
    }
}
