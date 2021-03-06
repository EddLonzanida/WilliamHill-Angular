﻿using System.Collections.Generic;
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
    public class RiskCustomerEngine : IRequestAsyncEngine<RiskCustomerAsyncRequest, RiskCustomerResponse>
    {
        private const double RISKY_AMOUNT = 200;

        private readonly ITechChallengeDataRepositorySoftDeleteInt<Customer> customersRepository;

        private readonly ITechChallengeDataRepositorySoftDeleteInt<Bet> betsRepository;

        [ImportingConstructor]
        public RiskCustomerEngine(ITechChallengeDataRepositorySoftDeleteInt<Customer> customersRepository, ITechChallengeDataRepositorySoftDeleteInt<Bet> betsRepository)
        {
            this.customersRepository = customersRepository;
            this.betsRepository = betsRepository;
        }

        public async Task<RiskCustomerResponse> GetAsync(RiskCustomerAsyncRequest request)
        {
            var betRequest = new TotalBetAmountAsyncRequest();
            var customers = await EntityFactory.GetCustomers(customersRepository);
            var bets = await EntityFactory.GetBets(betsRepository, betRequest);

            if (bets == null) return new RiskCustomerResponse(new List<RiskCustomer>());
            if (customers == null) return new RiskCustomerResponse(new List<RiskCustomer>());

            var riskCustomers = customers
                .Select(r => new RiskCustomer
                {
                    Id = r.Id,
                    Name = r.Name,
                    Bets = GetCustomerBets(r.Id, bets)
                })
                .Where(r => r.Bets.Any())
                .OrderBy(r => r.Name);

            return new RiskCustomerResponse(riskCustomers);
        }

        private static List<Bet> GetCustomerBets(int customerId, IEnumerable<Bet> bets)
        {
            return bets
                .Where(r => r.CustomerId == customerId && r.Stake > RISKY_AMOUNT) //over $200
                .OrderBy(r => r.Stake)
                .ThenBy(r => r.RaceId)
                .ToList();
        }

        public void Dispose()
        {
        }
    }
}
