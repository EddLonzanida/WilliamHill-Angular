using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using NSubstitute;
using TechChallenge.ApiHost.Api.Dashboard;
using TechChallenge.Business.Common.Dto;
using TechChallenge.Business.Requests;
using TechChallenge.Business.Responses;
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
            mediator.GetAsync(Arg.Any<RaceStatRequest>()).Returns(new RaceStatResponse(new List<RaceStat>()));

            var response = await controller.Get();

            await mediator.Received().GetAsync(Arg.Any<RaceStatRequest>());
        }
    }
}
