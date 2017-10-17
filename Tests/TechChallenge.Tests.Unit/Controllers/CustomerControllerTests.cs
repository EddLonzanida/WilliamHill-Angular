using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using NSubstitute;
using TechChallenge.ApiHost.Api.Customers;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;
using TechChallenge.Tests.Unit.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Unit.Controllers
{
    public class CustomerControllerTests : ControllerTestBase<CustomersController>
    {
        public CustomerControllerTests()
        {
            controller = new CustomersController(mediator)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [Fact]
        public async Task Controller_ShouldGetAllCustomers()
        {
            mediator.GetAsync(Arg.Any<CustomerRequest>()).Returns(new CustomerResponse(new List<Customer>()));

            var response = await controller.Get();

            await mediator.Received().GetAsync(Arg.Any<CustomerRequest>());
        }

        [Fact]
        public async Task Controller_ShouldGetAllBetCount()
        {
            mediator.GetAsync(Arg.Any<TotalBetCountRequest>()).Returns(new TotalBetCountResponse(new List<CustomerBetCount>()));

            var response = await controller.Bets(1);

            await mediator.Received().GetAsync(Arg.Any<TotalBetCountRequest>());
        }

        [Fact]
        public async Task Controller_ShouldGetRiskCustomers()
        {
            mediator.GetAsync(Arg.Any<RiskCustomerRequest>()).Returns(new RiskCustomerResponse(new List<RiskCustomer>()));

            var response = await controller.Risks();

            await mediator.Received().GetAsync(Arg.Any<RiskCustomerRequest>());
        }
    }
}
