using System.ComponentModel.DataAnnotations;
using TechChallenge.Business.Common.BaseClasses;
using TechChallenge.Infrastructure.Contracts;

namespace TechChallenge.Business.Common.Entities.TechChallengeDb
{
    public class Bet : EntitySoftDeletableIntBase, ITechChallengeDbEntity
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
    }
}
