using System.Collections.Generic;
using Eml.Contracts.Responses;
using TechChallenge.Business.Common.Entities.TechChallengeDb;

namespace TechChallenge.Business.Common.Dto.TechChallengeDb
{
    public class HorseIndexResponse : SearchResponse<Horse>
    {
        public HorseIndexResponse(IEnumerable<Horse> items, int recordCount, int rowsPerPage) 
            : base(items, recordCount, rowsPerPage)
        {
        }
    }
}
