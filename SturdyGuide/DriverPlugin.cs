using System.ComponentModel;
using Microsoft.SemanticKernel;
using Neo4j.Driver;
using Newtonsoft.Json;

namespace SturdyGuide;

public class DriverPlugin(IDriver driver)
{
    [KernelFunction]
    [Description("queries the neo4j database with cypher")]
    public async Task<string> QueryDb(string query, bool writeMode)
    {
        var result = await driver.ExecutableQuery(query)
            .WithConfig(new QueryConfig(writeMode ? RoutingControl.Writers : RoutingControl.Readers, "neo4j"))
            .ExecuteAsync();
        return JsonConvert.SerializeObject(result);
    }
}