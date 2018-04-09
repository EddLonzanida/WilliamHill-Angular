using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Eml.DataRepository.Contracts;
using NSubstitute;
using TechChallenge.ApiHost.Api.Customers;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;
using TechChallenge.Tests.Unit.BaseClasses;
using X.PagedList;
using Xunit;

namespace TechChallenge.Tests.Unit.Controllers
{
    public class CustomerControllerTests : ControllerTestBase<CustomersController>
    {
        protected readonly IDataRepositorySoftDeleteInt<Customer> repository;

        public CustomerControllerTests()
        {
            repository = Substitute.For<IDataRepositorySoftDeleteInt<Customer>>();

            controller = new CustomersController(mediator, repository)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [Fact]
        public async Task Controller_ShouldGetAllCustomers()
        {
            var pagedList = new PagedList<Customer>(null, 1, 10);
            repository.GetPagedListAsync(Arg.Any<int>(),
                    Arg.Any<Expression<Func<Customer, bool>>>(),
                    Arg.Any<Func<IQueryable<Customer>, IQueryable<Customer>>>())
                .Returns(pagedList);

            await controller.Get();

            await repository.Received()
                .GetPagedListAsync(Arg.Any<int>(),
                    Arg.Any<Expression<Func<Customer, bool>>>(),
                    Arg.Any<Func<IQueryable<Customer>, IQueryable<Customer>>>());
        }

        [Fact]
        public async Task Controller_ShouldGetAllBetCount()
        {
            mediator.GetAsync(Arg.Any<TotalBetCountRequest>()).Returns(new TotalBetCountResponse(new List<CustomerBetCount>()));

            await controller.GetBets(1);

            await mediator.Received().GetAsync(Arg.Any<TotalBetCountRequest>());
        }

        [Fact]
        public async Task Controller_ShouldGetRiskCustomers()
        {
            mediator.GetAsync(Arg.Any<RiskCustomerRequest>()).Returns(new RiskCustomerResponse(new List<RiskCustomer>()));

            await controller.GetRisks();

            await mediator.Received().GetAsync(Arg.Any<RiskCustomerRequest>());
        }
    }
}
