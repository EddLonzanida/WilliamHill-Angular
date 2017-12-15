using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Eml.DataRepository;
using Eml.SoftDelete;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Contracts.Infrastructure;

namespace TechChallenge.Data
{
    public class TechChallengeDb : DbContext, IAllowIdentityInsertWhenSeeding
    {
        public bool AllowIdentityInsertWhenSeeding { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Horse> Horses { get; set; }

        public TechChallengeDb() : base(ConnectionStrings.TechChallengeKey)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var convention = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
                SoftDeleteColumn.Key,
                (type, attributes) => attributes.Single().SoftDeleteColumnName);
            modelBuilder.Conventions.Add(convention);

            if (AllowIdentityInsertWhenSeeding)
            {
                modelBuilder.Properties<int>().Where(r => r.Name.Equals("Id"))
                    .Configure(r => r.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None));
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
