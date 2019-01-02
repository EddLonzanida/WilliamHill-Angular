using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eml.Contracts.Entities;
using Eml.EntityBaseClasses;
using Eml.SoftDelete;
using Newtonsoft.Json;

namespace TechChallenge.Business.Common.Entities.BaseClasses
{
    [Serializable]
    [SoftDelete(SoftDeleteColumn.Name)]
    public abstract class EntityBase : EntityBaseSoftDeleteInt
    {
        //[Key]
        //[Column(Order = 1)]
        //public virtual int Id { get; set; }

        //[JsonIgnore]
        //[Display(Name = "DateDeleted")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? DateDeleted { get; set; }

        //[JsonIgnore]
        //[Display(Name = "Reason for deleting:")]
        //[DataType(DataType.MultilineText)]
        //public string DeletionReason { get; set; }
    }
}
