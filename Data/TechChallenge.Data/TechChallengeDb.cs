using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.PerformanceData;
using System.Linq;
using Eml.DataRepository.Contracts;
using Eml.SoftDelete;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Contracts.Infrastructure;

namespace TechChallenge.Data
{
    public class TechChallengeDb : DbContext
    {
        public static int Count;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Horse> Horses { get; set; }

        public TechChallengeDb() : base(ConnectionStrings.TechChallengeKey)
        {
            Count++;
            Console.WriteLine($"Instantiating TechChallengeDb {Count}");
        }

        private bool allowIdentityInsertWhenSeeding { get; set; } = true;
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var convention = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
                SoftDeleteColumn.Key,
                (type, attributes) => attributes.Single().SoftDeleteColumnName);
            modelBuilder.Conventions.Add(convention);

            Console.WriteLine($"OnModelCreating Count: {Count}");

            if (allowIdentityInsertWhenSeeding)
            {
                modelBuilder.Properties<int>().Where(r => r.Name.Equals("Id"))
                    .Configure(r => r.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None));
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
