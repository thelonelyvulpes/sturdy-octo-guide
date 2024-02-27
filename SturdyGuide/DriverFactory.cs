using Neo4j.Driver;
using Config = SturdyGuide.Config;

internal sealed class DriverFactory
{
    public static IDriver BuildDriver()
    {
        return GraphDatabase.Driver(Config.Neo4jUri, AuthTokens.Basic(Config.Neo4jUser, Config.Neo4jPassword));
    }
}