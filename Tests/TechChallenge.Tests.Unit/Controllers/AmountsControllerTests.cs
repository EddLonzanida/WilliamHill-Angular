using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using NSubstitute;
using Shouldly;
using TechChallenge.ApiHost.Api.Amounts;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;
using TechChallenge.Tests.Unit.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Unit.Controllers
{
    public class AmountsControllerTests: ControllerTestBase<AmountsController>
    {
        public AmountsControllerTests()
        {
            controller = new AmountsController(mediator)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [Fact]
        public async Task Controller_ShouldReturnGrandTotalBetAmount()
        {
            mediator.GetAsync(Arg.Any<TotalBetAmountRequest>()).Returns(totalBetAmountResponseStub);

            var response = await controller.GetTotal();

            await mediator.Received().GetAsync(Arg.Any<TotalBetAmountRequest>());
            var contentResult = response as OkNegotiatedContentResult<double>;
            contentResult.Content.ShouldBe(6060);
        }

        [Fact]
        public async Task Controller_ShouldGetAllAmountsPerCustomer()
        {
            mediator.GetAsync(Arg.Any<TotalBetAmountRequest>()).Returns(new TotalBetAmountResponse(new List<CustomerBetAmount>()));

            await controller.Index();

            await mediator.Received().GetAsync(Arg.Any<TotalBetAmountRequest>());
        }
    }
}
