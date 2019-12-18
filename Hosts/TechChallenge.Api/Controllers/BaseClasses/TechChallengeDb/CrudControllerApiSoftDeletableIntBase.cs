using Eml.Contracts.Entities;
using Eml.ControllerBase;
using Eml.Contracts.Requests;
using Eml.Contracts.Responses;
using Eml.DataRepository.MsSql.Contracts;
using Eml.Mediator.Contracts;
using TechChallenge.Infrastructure.Contracts;

namespace TechChallenge.Api.Controllers.BaseClasses.TechChallengeDb
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public abstract class CrudControllerApiSoftDeletableIntBase<T, TIndexRequest, TIndexResponse, TEditCreateRequest, TDetailsCreateResponse, TRepository>
        : CrudControllerApiSoftDeletableBase<int, T, TIndexRequest, TIndexResponse, TEditCreateRequest, TDetailsCreateResponse, Data.TechChallengeDb, TRepository>
        where T : class, IEntityBase<int>, IEntitySoftdeletableBase, ITechChallengeDbEntity
        where TIndexRequest : IIndexRequest, new()
        where TIndexResponse : ISearchResponse<T>
        where TEditCreateRequest : class, IEntityBase<int>
        where TDetailsCreateResponse : class, IEntityBase<int>
        where TRepository : IDataRepositoryMsSqlSoftDeleteBase<int, T, Data.TechChallengeDb>
    {
        protected CrudControllerApiSoftDeletableIntBase(TRepository repository)
            : base(repository)
        {
        }

        protected CrudControllerApiSoftDeletableIntBase(IMediator mediator, TRepository repository)
            : base(mediator, repository)
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
