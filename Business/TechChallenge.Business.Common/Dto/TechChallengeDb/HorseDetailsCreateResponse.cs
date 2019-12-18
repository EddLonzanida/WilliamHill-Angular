using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechChallenge.Business.Common.BaseClasses;
using TechChallenge.Business.Common.Entities.TechChallengeDb;

namespace TechChallenge.Business.Common.Dto.TechChallengeDb
{
    [NotMapped]
    public class HorseDetailsCreateResponse : EntityIntBase
    {
        [Required]
        [Display(Name = "Race")]
        public int RaceId { get; set; }

        public string Name { get; set; }

        public double Odds { get; set; }

        public virtual Race Race { get; set; }
    }
}
