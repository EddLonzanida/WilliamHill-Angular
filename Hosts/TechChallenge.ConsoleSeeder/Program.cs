using Eml.ClassFactory.Contracts;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.Extensions;
using Eml.Mef;
using System;

namespace TechChallenge.ConsoleSeeder
{
    public class Program
    {
        private const string APP_PREFIX = "TechChallenge*.dll";

        private const string DB_DIRECTORY = @".\DataBase";

        private static IClassFactory classFactory;

        static void Main(string[] args)
        {
            classFactory = Bootstrapper.Init(APP_PREFIX);

            var dbMigration = GetMainDbMigrator();

            try
            {
                Console.WriteLine("DestroyDb if any..");

                dbMigration.DestroyDb();
                dbMigration.CreateDb(DB_DIRECTORY);

                Console.WriteLine("Done. Press enter to exit...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }

        private static IMigrator GetMainDbMigrator()
        {
            return classFactory.GetMigrator(Environments.PRODUCTION);
        }
    }
}
