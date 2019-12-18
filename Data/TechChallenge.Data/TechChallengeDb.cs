using System.Data.Entity;
using TechChallenge.Business.Common.Entities.TechChallengeDb;
using TechChallenge.Infrastructure;

namespace TechChallenge.Data
{
    public class TechChallengeDb : DbContext
    {
        public TechChallengeDb()
            : base(ConnectionStrings.TechChallengeDbKey)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Horse> Horses { get; set; }

        public DbSet<Race> Races { get; set; }
    }
}
