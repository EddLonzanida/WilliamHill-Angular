using NSubstitute;
using Shouldly;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TechChallenge.ApiHost.Controllers;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;
using TechChallenge.Tests.Unit.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Unit.Controllers
{
    public class AmountsControllerTests : ControllerTestBase<AmountsController>
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
            mediator.GetAsync(Arg.Any<TotalBetAmountAsyncRequest>()).Returns(totalBetAmountResponseStub);

            var response = await controller.GetTotal();

            await mediator.Received().GetAsync(Arg.Any<TotalBetAmountAsyncRequest>());
            var contentResult = response as OkNegotiatedContentResult<double>;
            contentResult.Content.ShouldBe(6060);
        }

        [Fact]
        public async Task Controller_ShouldGetAllAmountsPerCustomer()
        {
            mediator.GetAsync(Arg.Any<TotalBetAmountAsyncRequest>()).Returns(new TotalBetAmountResponse(new List<CustomerBetAmount>()));

            await controller.Index();

            await mediator.Received().GetAsync(Arg.Any<TotalBetAmountAsyncRequest>());
        }
    }
}
