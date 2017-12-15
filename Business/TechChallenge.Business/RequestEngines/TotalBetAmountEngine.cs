using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;
using Eml.Contracts.Repositories;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Common.Helpers;

namespace TechChallenge.Business.RequestEngines
{
    public class TotalBetAmountEngine : IRequestAsyncEngine<TotalBetAmountRequest, TotalBetAmountResponse>
    {
        private readonly IDataRepositorySoftDeleteInt<Bet> betsRepository;

        [ImportingConstructor]
        public TotalBetAmountEngine(IDataRepositorySoftDeleteInt<Bet> betsRepository)
        {
            this.betsRepository = betsRepository;
        }

        public async Task<TotalBetAmountResponse> GetAsync(TotalBetAmountRequest request)
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
            betsRepository?.Dispose();
        }
    }
}
