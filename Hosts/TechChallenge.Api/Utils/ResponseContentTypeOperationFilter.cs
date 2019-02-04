using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace TechChallenge.Api.Utils
{
    public class ResponseContentTypeOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var requestAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerResponseContentTypeAttribute>();

            foreach (var requestAttribute in requestAttributes)
            {
                if (requestAttribute.Exclusive) operation.produces.Clear();

                operation.produces.Add(requestAttribute.ResponseType);
            }
        }
    }
}