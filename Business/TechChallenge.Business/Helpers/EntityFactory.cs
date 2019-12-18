using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.Business.Common.Entities.TechChallengeDb;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Data.Repositories.TechChallengeDb.Contracts;

namespace TechChallenge.Business.Helpers
{
    public static class EntityFactory
    {
        public static async Task<List<Customer>> GetCustomers(ITechChallengeDataRepositorySoftDeleteInt<Customer> repository)
        {
            var response = await repository.GetAllAsync();

            if (response == null) return await Task.FromResult(new List<Customer>());

            return response
                .OrderBy(r => r.Name)
                .ThenBy(r => r.Id)
                .ToList();
        }

        public static async Task<List<Bet>> GetBets(ITechChallengeDataRepositorySoftDeleteInt<Bet> repository, TotalBetAmountAsyncRequest request)
        {
            if (request.CustomerId > 0)
            {
                return await repository.GetAsync(r => r.CustomerId == request.CustomerId);
            }

            return await repository.GetAllAsync();
        }

        public static async Task<List<Race>> GetRaces(ITechChallengeDataRepositorySoftDeleteInt<Race> repository)
        {
            Func<IQueryable<Race>, IOrderedQueryable<Race>> orderBy = race => race.OrderBy(x => x.Start).ThenBy(x => x.Name);

            var response = await repository.GetAsync(r => r.Include(x => x.Horses), orderBy, 1);

            if (response == null) return await Task.FromResult(new List<Race>());

            return response
                .ToList();
        }
    }
}
