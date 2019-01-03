using NSubstitute;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TechChallenge.Api.Controllers;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Common.Requests;
using TechChallenge.Business.Common.Responses;
using TechChallenge.Tests.Unit.BaseClasses;
using Xunit;

namespace TechChallenge.Tests.Unit.Controllers
{
    public class DashboardControllerTests : ControllerTestBase<DashboardController>
    {
        public DashboardControllerTests()
        {
            controller = new DashboardController(mediator)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [Fact]
        public async Task Controller_ShouldGetAllCustomers()
        {
            mediator.GetAsync(Arg.Any<RaceStatAsyncRequest>()).Returns(new RaceStatResponse(new List<RaceStat>()));

            await controller.Index();

            await mediator.Received().GetAsync(Arg.Any<RaceStatAsyncRequest>());
        }
    }
}
