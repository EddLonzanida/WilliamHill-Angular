using TechChallenge.Infrastructure.Configurations;

namespace TechChallenge.Infrastructure
{
    /// <summary>
    /// Set in Program.cs
    /// </summary>
    public static class ConnectionStrings
    {
        /// <summary>
        /// Should match the entry in appsettings*.json. Used in Program.cs
        /// </summary>
        public static string TechChallengeDbKey { get; } = "TechChallengeConnectionString";

        /// <summary>
        /// Set in Program.cs
        /// </summary>
        public static string TechChallengeDb { get; private set; }

        /// <summary>
        /// Set in Program.cs
        /// </summary>
        public static void SetOneTime()
        {
            using (var config = new TechChallengeConnectionStringParser())
            {
                TechChallengeDb = config.Value;
            }
        }
    }
}