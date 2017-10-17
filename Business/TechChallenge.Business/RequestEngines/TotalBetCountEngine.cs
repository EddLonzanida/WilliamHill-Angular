using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Eml.Contracts.Repositories;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Helpers;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;

namespace TechChallenge.Business.RequestEngines
{
    public class TotalBetCountEngine : IRequestAsyncEngine<TotalBetCountRequest, TotalBetCountResponse>
    {
        private readonly IDataRepositorySoftDeleteInt<Bet> betsRepository;

        [ImportingConstructor]
        public TotalBetCountEngine(IDataRepositorySoftDeleteInt<Bet> betsRepository)
        {
            this.betsRepository = betsRepository;
        }

        public async Task<TotalBetCountResponse> GetAsync(TotalBetCountRequest request)
        {
            var bets = await EntityFactory.GetBets(betsRepository);

            if (bets == null) return new TotalBetCountResponse(new List<CustomerBetCount>());

            var betCounts = bets
                .GroupBy(r => new { customerId = r.CustomerId })
                .Select(g => new CustomerBetCount
                {
                    Id = g.Key.customerId,
                    TotalBets = g.Count()
                })
                .OrderBy(r => r.TotalBets)
                .ThenBy(r => r.Id);

            if (request.CustomerId > 0)
            {
                var filteredCustomers = betCounts.ToList()
                    .Where(r => r.Id == request.CustomerId);
                return new TotalBetCountResponse(filteredCustomers);
            }
            return new TotalBetCountResponse(betCounts);
        }

        public void Dispose()
        {
            betsRepository?.Dispose();
        }
    }
}
