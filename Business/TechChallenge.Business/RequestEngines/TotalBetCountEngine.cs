using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Eml.DataRepository.Contracts;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;
using TechChallenge.Business.Helpers;
using TechChallenge.Data.Contracts;

namespace TechChallenge.Business.RequestEngines
{
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class TotalBetCountEngine : IRequestAsyncEngine<TotalBetCountAsyncRequest, TotalBetCountResponse>
    {
        private readonly IDataRepositorySoftDeleteInt<Bet> betsRepository;

        [ImportingConstructor]
        public TotalBetCountEngine(IDataRepositorySoftDeleteInt<Bet> betsRepository)
        {
            this.betsRepository = betsRepository;
        }

        public async Task<TotalBetCountResponse> GetAsync(TotalBetCountAsyncRequest request)
        {
            var betRequest = new TotalBetAmountAsyncRequest();
            var bets = await EntityFactory.GetBets(betsRepository, betRequest);

            if (bets == null) return new TotalBetCountResponse(new List<CustomerBetCount>());

            var betCounts = bets
                .GroupBy(r => new { customerId = r.CustomerId })
                .Select(g => new CustomerBetCount
                {
                    Id = g.Key.customerId ?? default(int),
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
        }
    }
}
