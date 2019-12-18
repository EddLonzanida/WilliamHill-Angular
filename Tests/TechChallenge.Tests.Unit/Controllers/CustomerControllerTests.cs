using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TechChallenge.Api.Controllers;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Common.Entities.TechChallengeDb;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;
using TechChallenge.Data.Repositories.TechChallengeDb.Contracts;
using TechChallenge.Tests.Unit.BaseClasses;
using X.PagedList;
using Xunit;
 
namespace TechChallenge.Tests.Unit.Controllers
{
    public class CustomerControllerTests : ControllerTestBase<CustomerController>
    {
        protected readonly ITechChallengeDataRepositorySoftDeleteInt<Customer> repository;

        public CustomerControllerTests()
        {
            repository = Substitute.For<ITechChallengeDataRepositorySoftDeleteInt<Customer>>();

            controller = new CustomerController(mediator, repository)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [Fact]
        public async Task Controller_ShouldGetAllCustomers()
        {
            var pagedList = new PagedList<Customer>(null, 1, 10);
            repository.GetPagedListAsync(Arg.Any<int>(), Arg.Any<Expression<Func<Customer, bool>>>(),
                    Arg.Any<Func<IQueryable<Customer>, IOrderedQueryable<Customer>>>())
                .Returns(pagedList);

            await controller.Index(null);

            await repository.Received()
                .GetPagedListAsync(Arg.Any<int>(), Arg.Any<Expression<Func<Customer, bool>>>(),
                    Arg.Any<Func<IQueryable<Customer>, IOrderedQueryable<Customer>>>());
        }

        [Fact]
        public async Task Controller_ShouldGetAllBetCount()
        {
            mediator.GetAsync(Arg.Any<TotalBetCountAsyncRequest>()).Returns(new TotalBetCountResponse(new List<CustomerBetCount>()));

            await controller.GetBetCount(1);

            await mediator.Received().GetAsync(Arg.Any<TotalBetCountAsyncRequest>());
        }

        [Fact]
        public async Task Controller_ShouldGetRiskCustomers()
        {
            mediator.GetAsync(Arg.Any<RiskCustomerAsyncRequest>()).Returns(new RiskCustomerResponse(new List<RiskCustomer>()));

            await controller.GetRisk();

            await mediator.Received().GetAsync(Arg.Any<RiskCustomerAsyncRequest>());
        }

        [Fact]
        public async Task Controller_ShouldGetAllAmountsPerCustomer()
        {
            mediator.GetAsync(Arg.Any<TotalBetAmountAsyncRequest>()).Returns(new TotalBetAmountResponse(new List<CustomerBetAmount>()));

            await controller.GetBetAmount();

            await mediator.Received().GetAsync(Arg.Any<TotalBetAmountAsyncRequest>());
        }
    }
}
