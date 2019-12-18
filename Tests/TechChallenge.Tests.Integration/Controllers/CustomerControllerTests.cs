using Shouldly;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TechChallenge.Api.Controllers;
using TechChallenge.Business.Common.Dto.TechChallengeDb;
using TechChallenge.Business.Common.Entities.TechChallengeDb;
using TechChallenge.Data.Repositories.TechChallengeDb.Contracts;
using TechChallenge.Tests.Integration.BaseClasses;
using TechChallenge.Tests.Integration.Utils;
using Xunit;

namespace TechChallenge.Tests.Integration.Controllers
{
    public class CustomerControllerTests : IntegrationTestDbBase
    {
        [Fact]
        public async Task CustomerController_ShouldPerformCrudOperations()
        {
            const string NAME = "IntegrationTest Name";
            const string NAME_UPDATED = "IntegrationTest Name Updated";
            const int DEFAULT_ID = default;

            //ensure no remnants of failed tests
            await EnsureNoCrudRemnants(NAME);
            await EnsureNoCrudRemnants(NAME_UPDATED);

            //CREATE
            var createCustomerRequest = new CustomerEditCreateRequest { Name = NAME };
            var controller = classFactory.GetExport<CustomerController>();
            var sutDetailsCreate = await controller.Create(createCustomerRequest);
            var insertedItem = sutDetailsCreate.GetCreatedValue<CustomerDetailsCreateResponse>();
            var insertedItemId = insertedItem.Id; //store id for future use

            insertedItemId.ShouldNotBe(DEFAULT_ID);

            //DETAILS
            sutDetailsCreate = await controller.Details(insertedItemId);

            var detailedItem = sutDetailsCreate.GetOkValue<CustomerDetailsCreateResponse>();

            detailedItem.ShouldNotBeNull();
            detailedItem.Name.ShouldBe(NAME);
            detailedItem.Id.ShouldBe(insertedItemId);

            //EDIT
            var updateCustomerRequest = new CustomerEditCreateRequest
            {
                Id = insertedItemId,
                Name = NAME_UPDATED,
            };

            sutDetailsCreate = await controller.Edit(updateCustomerRequest);

            var okItem = sutDetailsCreate.GetOkResult();

            okItem.ShouldNotBeNull();

            //SUGGESTIONS
            var sutSuggestions = await controller.Suggestions(string.Empty);
            var suggestions = sutSuggestions.GetOkValue<List<string>>();

            suggestions.ShouldNotBeNull();
            suggestions.Count.ShouldBeGreaterThan(0);

            //INDEX
            var sutIndex = await controller.Index(null);
            var pagedRows = sutIndex.GetOkValue<CustomerIndexResponse>();

            pagedRows.ShouldNotBeNull();
            pagedRows.Items.Count.ShouldBeGreaterThan(0);

            //DELETE
            var sutDelete = await controller.Delete(insertedItemId, "Integration Test");

            okItem = sutDelete.GetOkResult();
            okItem.ShouldNotBeNull();

            //Retest after Delete
            // Validate the the row has been soft deleted
            sutDetailsCreate = await controller.Details(insertedItemId);

            var deletedItem = sutDetailsCreate.Get404Result();

            deletedItem.ShouldNotBeNull();

            await EnsureNoCrudRemnants(NAME);
            await EnsureNoCrudRemnants(NAME_UPDATED);
        }

        private async Task EnsureNoCrudRemnants(string searchableText)
        {
            //ensure no remnants of failed tests
            var repository = classFactory.GetExport<ITechChallengeDataRepositorySoftDeleteInt<Customer>>();
            var context = await repository.GetDb();

            using (var connection = context.Database.Connection)
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    var sql = $"DELETE FROM Customers WHERE [Name] LIKE '%{searchableText}%';";

                    command.CommandText = sql;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
