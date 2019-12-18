using Eml.Contracts.Entities;
using Eml.DataRepository.Contracts;
using Eml.ControllerBase;
using Eml.Contracts.Requests;
using Eml.Contracts.Responses;
using TechChallenge.Infrastructure.Contracts;

namespace TechChallenge.Api.Controllers.BaseClasses.TechChallengeDb
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public abstract class CrudControllerApiWithParentSoftDeletableIntBase<T, TIndexRequest, TIndexResponse, TEditCreateRequest, TDetailsCreateResponse, TRepository>
        : CrudControllerApiWithParentSoftDeletableBase<int, T, TIndexRequest, TIndexResponse, TEditCreateRequest, TDetailsCreateResponse, Data.TechChallengeDb, TRepository>
        where T : class, IEntityWithParentBase<int>, IEntitySoftdeletableBase, ITechChallengeDbEntity
        where TIndexRequest : IIndexRequest, new()
        where TIndexResponse : ISearchResponse<T>
        where TEditCreateRequest : class, IEntityBase<int>
        where TDetailsCreateResponse : class, IEntityBase<int>
        where TRepository : IDataRepositorySoftDeleteBase<int, T, Data.TechChallengeDb>
    {
        protected CrudControllerApiWithParentSoftDeletableIntBase(TRepository repository) 
            : base(repository)
        {
        }

        protected string GetCurrentUser()
        {
            return "";
        }

        protected override string GetDeletedBy()
        {
            return GetCurrentUser();
        }
    }
}
