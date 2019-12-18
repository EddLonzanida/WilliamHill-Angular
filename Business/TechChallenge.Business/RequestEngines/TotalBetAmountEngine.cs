using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Common.Entities.TechChallengeDb;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;
using TechChallenge.Business.Helpers;
using TechChallenge.Data.Repositories.TechChallengeDb.Contracts;

namespace TechChallenge.Business.RequestEngines
{
	[PartCreationPolicy(CreationPolicy.NonShared)]
    public class TotalBetAmountEngine : IRequestAsyncEngine<TotalBetAmountAsyncRequest, TotalBetAmountResponse>
    {
        private readonly ITechChallengeDataRepositorySoftDeleteInt<Bet> betsRepository;

        [ImportingConstructor]
        public TotalBetAmountEngine(ITechChallengeDataRepositorySoftDeleteInt<Bet> betsRepository)
        {
            this.betsRepository = betsRepository;
        }

        public async Task<TotalBetAmountResponse> GetAsync(TotalBetAmountAsyncRequest request)
        {
            var bets = await EntityFactory.GetBets(betsRepository, request);

            if (bets == null) return new TotalBetAmountResponse(new List<CustomerBetAmount>());

            var betAmounts = bets
                .GroupBy(r => new { customerId = r.CustomerId })
                .Select(g => new CustomerBetAmount
                {
                    Id = g.Key.customerId ,
                    TotalStake = g.Sum(r => r.Stake)
                })
                .OrderBy(r => r.TotalStake)
                .ThenBy(r => r.Id);

            return new TotalBetAmountResponse(betAmounts);
        }

        public void Dispose()
        {
        }
    }
}
