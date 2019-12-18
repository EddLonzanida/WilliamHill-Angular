using System.Web.Http;
using System.Web.Http.Results;

namespace TechChallenge.Tests.Integration.Utils
{
    public static class ActionResultExtensions
    {
        public static TValue GetOkValue<TValue>(this IHttpActionResult controllerActionResult)
            where TValue : class
        {
            var contentResult = controllerActionResult as OkNegotiatedContentResult<TValue>;

            return contentResult?.Content;
        }

        public static TValue GetCreatedValue<TValue>(this IHttpActionResult controllerActionResult)
            where TValue : class
        {
            var contentResult = controllerActionResult as CreatedAtRouteNegotiatedContentResult<TValue>;

            return contentResult?.Content;
        }

        public static OkResult GetOkResult(this IHttpActionResult controllerActionResult)
        {
            var contentResult = controllerActionResult as OkResult;

            return contentResult;
        }

        public static NotFoundResult Get404Result(this IHttpActionResult controllerActionResult)
        {
            var contentResult = controllerActionResult as NotFoundResult;

            return contentResult;
        }

        public static int GetStatusCode<TValue>(this IHttpActionResult controllerActionResult)
            where TValue : class
        {
            if (controllerActionResult is NegotiatedContentResult<TValue> contentResult) return (int)contentResult.StatusCode;

            return -1;
        }
    }
}
