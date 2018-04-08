﻿using System.Collections.Generic;
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
using Xunit;

namespace TechChallenge.Tests.Unit.Controllers
{
    public class CustomerControllerTests : ControllerTestBase<CustomersController>
    {
        protected readonly IDataRepositorySoftDeleteInt<Customer> repository;

        public CustomerControllerTests()
        {
            repository = Substitute.For<IDataRepositorySoftDeleteInt<Customer>>();

            controller = new CustomersController(mediator,repository)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [Fact]
        public async Task Controller_ShouldGetAllCustomers()
        {
            mediator.GetAsync(Arg.Any<CustomerRequest>()).Returns(new CustomerResponse(new List<Customer>()));

            await controller.Get();

            await mediator.Received().GetAsync(Arg.Any<CustomerRequest>());
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
