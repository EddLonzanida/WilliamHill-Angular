using Eml.ConfigParser;

namespace TechChallenge.Infrastructure.Configurations
{
    public class TechChallengeConnectionStringParser : ConfigParserBase<string, TechChallengeConnectionStringParser>
    {
        /// <summary>
        /// DI signature: <![CDATA[IConfigParserBase<string, TechChallengeConnectionStringParser> connectionStringParser]]>.
        /// </summary>
        public TechChallengeConnectionStringParser()
        {
        }
    }
}
