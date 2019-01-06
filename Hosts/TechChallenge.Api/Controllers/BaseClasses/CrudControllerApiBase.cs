using System.Threading.Tasks;
using Eml.Contracts.Entities;
using Eml.ControllerBase;
using Eml.DataRepository.Contracts;
using Eml.Mediator.Contracts;
using TechChallenge.Data;
using TechChallenge.Data.Contracts;
using TechChallenge.Data.Repositories;

namespace TechChallenge.Api.Controllers.BaseClasses
{
    public abstract class CrudControllerApiBase<T, TRequest> : CrudControllerApiBase<int, T, TRequest, TechChallengeDb, IDataRepositorySoftDeleteInt<T>>
        where T : class, IEntityBase<int>, IEntitySoftdeletableBase
        where TRequest : class
    {
        protected CrudControllerApiBase(IDataRepositorySoftDeleteInt<T> repository)
            : base(repository)
        {
        }

        protected CrudControllerApiBase(IMediator mediator, IDataRepositorySoftDeleteInt<T> repository)
            : base(mediator, repository)
        {
        }

        protected override async Task<T> DeleteItemAsync(TechChallengeDb db, int id, string reason)
        {
            return await repository.DeleteAsync(db, id, reason);
        }
    }
}