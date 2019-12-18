using Eml.Contracts.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechChallenge.Business.Common.BaseClasses;
using TechChallenge.Infrastructure.Contracts;

namespace TechChallenge.Business.Common.Entities.TechChallengeDb
{
    public class Horse : EntitySoftDeletableIntBase, ITechChallengeDbEntity, IEntityWithParentBase<int>
    {
        [Required]
        [Display(Name = "Race")]
        public int RaceId { get; set; }

        public string Name { get; set; }

        public double Odds { get; set; }

        public virtual Race Race { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int ParentId => RaceId;
    }
}