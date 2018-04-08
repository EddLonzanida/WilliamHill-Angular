using Eml.EntityBaseClasses;

namespace TechChallenge.Business.Common.Entities
{
    public class Customer : EntityBaseSoftDeleteInt
    {
        public string Name { get; set; }
    }
}
