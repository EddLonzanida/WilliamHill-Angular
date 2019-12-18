using TechChallenge.Infrastructure.Configurations;

namespace TechChallenge.Infrastructure
{
    /// <summary>
    /// Set in Startup.cs
    /// </summary>
    public static class ApplicationSettings
    {
		public static int IntellisenseCount { get; set; }

        public static int PageSize { get; set; }

        /// <summary>
        /// Set in Startup.cs
        /// </summary>
        public static void SetOneTime()
        {
            using (var config = new IntellisenseCountConfigParser())
            {
                IntellisenseCount = config.Value;
            }

            using (var config = new PageSizeConfigParser())
            {
                PageSize = config.Value;
            }
        }
    }
}
