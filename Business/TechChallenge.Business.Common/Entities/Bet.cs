using System.ComponentModel.DataAnnotations;
using TechChallenge.Business.Common.BaseClasses;

namespace TechChallenge.Business.Common.Entities
{
    public class Bet : EntityBase
    {
        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Horse")]
        public int HorseId { get; set; }

        [Required]
        [Display(Name = "Race")]
        public int RaceId { get; set; }

         public double Stake { get; set; }
        //public virtual Customer Customer { get; set; }
        //public virtual Horse Horse { get; set; }
        //public virtual Race Race { get; set; }
    }
}
