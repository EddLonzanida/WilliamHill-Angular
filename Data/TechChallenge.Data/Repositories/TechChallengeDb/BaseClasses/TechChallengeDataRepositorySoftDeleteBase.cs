﻿using Eml.Contracts.Entities;
using Eml.DataRepository.MsSql.BaseClasses;
using TechChallenge.Infrastructure;
using TechChallenge.Infrastructure.Contracts;

namespace TechChallenge.Data.Repositories.TechChallengeDb.BaseClasses
{
    public abstract class TechChallengeDataRepositorySoftDeleteBase<TUniqueId, T> : DataRepositoryMsSqlSoftDeleteBase<TUniqueId, T, Data.TechChallengeDb>
        where T : class, IEntityBase<TUniqueId>, IEntitySoftdeletableBase, ITechChallengeDbEntity
    {
        public override int GetIntellisenseSize()
        {
            return ApplicationSettings.IntellisenseCount;
        }

        public override string GetConnectionString()
        {
            return ConnectionStrings.TechChallengeDbKey;
        }

        public override int GetPageSize()
        {
            return ApplicationSettings.PageSize;
        }
    }
}
