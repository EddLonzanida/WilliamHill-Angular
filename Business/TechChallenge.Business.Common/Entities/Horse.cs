using Eml.EntityBaseClasses;
using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Business.Common.Entities
{
    public class Horse : EntityBaseSoftDeleteInt
    {
        [Required]
        [Display(Name = "Race")]
        public int RaceId { get; set; }

        public string Name { get; set; }

        public double Odds { get; set; }

        public virtual Race Race { get; set; }
    }
}
