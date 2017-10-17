using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eml.Contracts.Repositories;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.Business.Helpers
{
    public static class EntityFactory
    {
        public static async Task<List<Customer>> GetCustomers(IDataRepositorySoftDeleteInt<Customer> repository)
        {
            var response = await repository.GetAsync();
            if (response == null) return await Task.FromResult(new List<Customer>());
            return response
                .OrderBy(r => r.Name)
                .ThenBy(r => r.Id)
                .ToList();
        }

        public static async Task<List<Bet>> GetBets(IDataRepositorySoftDeleteInt<Bet> repository)
        {
            var response = await repository.GetAsync();
            if (response == null) return await Task.FromResult(new List<Bet>());
            return response.ToList();
        }

        public static async Task<List<Race>> GetRaces(IDataRepositorySoftDeleteInt<Race> repository)
        {
            var response = await repository.GetAsync();
            if (response == null) return await Task.FromResult(new List<Race>());

            return response
                .OrderBy(r => r.Start)
                .ThenBy(r => r.Name)
                .ToList();
        }


        //public static async Task<List<Customer>> GetCustomers(string serviceUrl, IHttpService httpService)
        //{
        //    var url = $"{serviceUrl}/GetCustomers";
        //    var aParams = new List<KeyValuePair<string, object>>
        //    {
        //        new KeyValuePair<string, object>("Name", "YourName")
        //    };
        //    var customers = await httpService.GetAsync<List<Customer>>(url, aParams);
        //    var response = customers?
        //        .OrderBy(r => r.Name)
        //        .ThenBy(r => r.Id)
        //        .ToList();
        //    return response;
        //}

        //public static async Task<List<Bet>> GetBets(string serviceUrl, IHttpService httpService)
        //{
        //    var aParams = new List<KeyValuePair<string, object>>
        //    {
        //        new KeyValuePair<string, object>("Name", "YourName")
        //    };
        //    var url = $"{serviceUrl}/GetBetsV2";
        //    var bets = await httpService.GetAsync<List<Bet>>(url, aParams);
        //    return bets ?? new List<Bet>();
        //}

        //public static async Task<List<Race>> GetRaces(string serviceUrl, IHttpService httpService)
        //{
        //    var aParams = new List<KeyValuePair<string, object>>
        //    {
        //        new KeyValuePair<string, object>("Name", "YourName")
        //    };
        //    var url = $"{serviceUrl}/GetRaces";
        //    var content = await httpService.GetAsync<List<Race>>(url, aParams);

        //    if (content == null) return new List<Race>();
        //    if (!content.Any()) return new List<Race>();

        //    var response = content
        //        .OrderBy(r => r.Start)
        //        .ThenBy(r => r.Name)
        //        .ToList();
        //    return response;
        //}
    }
}
