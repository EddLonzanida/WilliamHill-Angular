using Eml.EntityBaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eml.Contracts.Entities;
using Newtonsoft.Json;

namespace TechChallenge.Business.Common.Entities
{
    public class Horse : EntityBaseSoftDeleteInt, IEntityWithParentBase<int>
    {
        [Required]
        [Display(Name = "Race")]
        public int? RaceId { get; set; }

        public string Name { get; set; }

        public double Odds { get; set; }

        public virtual Race Race { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int ParentId => RaceId ?? 0;
    }
}
