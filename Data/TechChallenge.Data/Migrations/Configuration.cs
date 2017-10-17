using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.IO;
using Newtonsoft.Json;
using TechChallenge.Business.Common.Entities;

namespace TechChallenge.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TechChallengeDb>
    {
        private const string JSON_SOURCES = @"Migrations\JsonSources";
        private readonly string racesPath;
        private readonly string betsPath;
        private readonly string customersPath;

        public Configuration()
        {
            var isEnabled = false; //Disable if running in Release Mode
#if DEBUG
            isEnabled = true;
#endif
            AutomaticMigrationsEnabled = isEnabled;
            AutomaticMigrationDataLossAllowed = isEnabled;

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            racesPath = $@"{baseDirectory}\{JSON_SOURCES}\races.json";
            betsPath = $@"{baseDirectory}\{JSON_SOURCES}\bets.json";
            customersPath = $@"{baseDirectory}\{JSON_SOURCES}\customers.json";
        }

        protected override void Seed(TechChallengeDb context)
        {
            DoSeed(context);
        }

        private void DoSeed(TechChallengeDb context)
        {
            Console.WriteLine("====== Seed start..");

            var racesStub = JsonConvert.DeserializeObject<List<Race>>(File.ReadAllText(racesPath));
            var betStub = JsonConvert.DeserializeObject<List<Bet>>(File.ReadAllText(betsPath));
            var customerStub = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(customersPath));

            racesStub.ForEach(r =>
            {
                context.Races.AddOrUpdate(item => item.Id, r);
            });
            DoSave(context, "Races");

            betStub.ForEach(r =>
            {
                context.Bets.AddOrUpdate(item => item.Id, r);
            });
            DoSave(context, "Bets");

            customerStub.ForEach(r =>
            {
                context.Customers.AddOrUpdate(item => item.Id, r);
            });
        }

        private static void DoSave(DbContext context, string EntityName)
        {
            try
            {
                Console.WriteLine("Saving.. {0}", EntityName);
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        var error = string.Format("===Entity: {2}    Property: {0}       Error: {1}", validationError.PropertyName, validationError.ErrorMessage, EntityName);
                        System.Console.WriteLine(error);
                        throw new Exception(error);
                    }
                }
            }
        }

    }
}
