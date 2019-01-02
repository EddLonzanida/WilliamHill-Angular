using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Eml.DataRepository.Contracts;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Common.Helpers;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;

namespace TechChallenge.Business.RequestEngines
{
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class TotalBetAmountEngine : IRequestAsyncEngine<TotalBetAmountAsyncRequest, TotalBetAmountResponse>
    {
        private readonly IDataRepositorySoftDeleteInt<Bet> betsRepository;

        [ImportingConstructor]
        public TotalBetAmountEngine(IDataRepositorySoftDeleteInt<Bet> betsRepository)
        {
            this.betsRepository = betsRepository;
        }

        public async Task<TotalBetAmountResponse> GetAsync(TotalBetAmountAsyncRequest request)
        {
            var bets = await EntityFactory.GetBets(betsRepository);

            if (bets == null) return new TotalBetAmountResponse(new List<CustomerBetAmount>());

            var betAmounts = bets
                .GroupBy(r => new { customerId = r.CustomerId })
                .Select(g => new CustomerBetAmount
                {
                    Id = g.Key.customerId,
                    Totalstake = g.Sum(r => r.Stake)
                })
                .OrderBy(r => r.Totalstake)
                .ThenBy(r => r.Id);

            return new TotalBetAmountResponse(betAmounts);
        }

        public void Dispose()
        {
        }
    }
}
