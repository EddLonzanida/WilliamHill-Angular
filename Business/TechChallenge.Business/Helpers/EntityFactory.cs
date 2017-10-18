using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Eml.Contracts.Repositories;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.Business.Helpers
{
    public static class EntityFactory
    {
        public static async Task<List<Customer>> GetCustomers(IDataRepositorySoftDeleteInt<Customer> repository)
        {
            var response = await repository.GetAsync();
            if (response == null) return await Task.FromResult(new List<Customer>());
            return response
                .OrderBy(r => r.Name)
                .ThenBy(r => r.Id)
                .ToList();
        }

        public static async Task<List<Bet>> GetBets(IDataRepositorySoftDeleteInt<Bet> repository)
        {
            var response = await repository.GetAsync();
            if (response == null) return await Task.FromResult(new List<Bet>());
            return response.ToList();
        }

        public static async Task<List<Race>> GetRaces(IDataRepositorySoftDeleteInt<Race> repository)
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
