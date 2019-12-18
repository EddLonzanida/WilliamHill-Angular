using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Infrastructure
{
    public static class Constants
    {
        /// <summary>
        /// Used in MEF DI, Swagger, Integration test, Unit tests
        /// </summary>
        public const string ApplicationId = "TechChallenge";

        /// <summary>
        /// Default value is "Development". Set in Program.cs
        /// </summary>
        public static string CurrentEnvironment = "Development";
    }

    /// Database id for DbMigratorExportAttribute.
    public class DbNames
    {
        public const string TechChallenge = "TechChallenge";
    }
}
