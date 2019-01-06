using Eml.Contracts.Entities;
using Eml.ControllerBase;
using Eml.Mediator.Contracts;
using System.Threading.Tasks;
using TechChallenge.Data;
using TechChallenge.Data.Contracts;

namespace TechChallenge.Api.Controllers.BaseClasses
{
    public abstract class CrudControllerApiWithParentBase<T, TRequest> : CrudControllerApiWithParentBase<int, T, TRequest, TechChallengeDb, IDataRepositorySoftDeleteInt<T>>
        where T : class, IEntityWithParentBase<int>, IEntitySoftdeletableBase
        where TRequest : class
    {
        protected CrudControllerApiWithParentBase(IDataRepositorySoftDeleteInt<T> repository) : base(repository)
        {
        }

        protected CrudControllerApiWithParentBase(IMediator mediator, IDataRepositorySoftDeleteInt<T> repository) : base(mediator, repository)
        {
        }

        protected override async Task<T> DeleteItemAsync(TechChallengeDb db, int id, string reason)
        {
            return await repository.DeleteAsync(db, id, reason);
        }
    }
}