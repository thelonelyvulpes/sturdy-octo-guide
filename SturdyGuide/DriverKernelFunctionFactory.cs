using System.Text.Json;
using Microsoft.SemanticKernel;
using Neo4j.Driver;

namespace SturdyGuide;

internal static class DriverKernelFunctionFactory
{
    public static ValueTask<IReadOnlyList<KernelFunction>> BuildAsync(IDriver driver)
    {
        var functions = new List<KernelFunction>();

        //Add basic querying.
        functions.Add(KernelFunctionFactory.CreateFromMethod(
            (string query, bool writeMode) => QueryDb(driver, query, writeMode), "queryNeo4jDatabase",
            "queries the neo4j database",
            new KernelParameterMetadata[]
                { new("query"), new("writeMode") { Description = "true if the query could modify a value" } }));

        return ValueTask.FromResult((IReadOnlyList<KernelFunction>)functions);
    }

    private static async Task<string> QueryDb(IDriver driver, string query, bool writeMode)
    {
        var result = await driver.ExecutableQuery(query)
            .WithConfig(new QueryConfig(writeMode ? RoutingControl.Writers : RoutingControl.Readers, "neo4j"))
            .ExecuteAsync();
        return JsonSerializer.Serialize(result);
    }
}