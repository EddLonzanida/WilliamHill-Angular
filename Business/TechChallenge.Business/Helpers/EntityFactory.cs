using Eml.DataRepository.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Data;

namespace TechChallenge.Business.Helpers
{
    public static class EntityFactory
    {
        public static async Task<List<Customer>> GetCustomers(IDataRepositoryBase<int, Customer, TechChallengeDb> repository)
        {
            var response = await repository.GetAllAsync();

            if (response == null) return await Task.FromResult(new List<Customer>());

            return response
                .OrderBy(r => r.Name)
                .ThenBy(r => r.Id)
                .ToList();
        }

        public static async Task<List<Bet>> GetBets(IDataRepositoryBase<int, Bet, TechChallengeDb> repository, TotalBetAmountAsyncRequest request)
        {
            if (request.CustomerId > 0)
            {
                return await repository.GetAsync(r => r.CustomerId == request.CustomerId);
            }

            return await repository.GetAllAsync();
        }

        public static async Task<List<Race>> GetRaces(IDataRepositoryBase<int, Race, TechChallengeDb> repository)
        {
            var response = await repository.GetAsync(r => r.Include(x => x.Horses));

            if (response == null) return await Task.FromResult(new List<Race>());

            return response
                .OrderBy(r => r.Start)
                .ThenBy(r => r.Name)
                .ToList();
        }
    }
}
