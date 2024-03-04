using Microsoft.SemanticKernel;
using Neo4j.Driver;

namespace SturdyGuide;

public sealed class DriverPlugin
{
    private const string driverPluginDescription = "interface to neo4j server";
    private readonly IReadOnlyList<KernelFunction> _functions;

    private DriverPlugin(IReadOnlyList<KernelFunction> functions)
    {
        _functions = functions;
    }

    public void Add(IKernelBuilderPlugins plugins)
    {
        plugins.AddFromFunctions(nameof(DriverPlugin), driverPluginDescription, _functions);
    }

    /// <summary>
    ///     Creates the plugin configured to run against a driver instance.
    /// </summary>
    /// <param name="driver">The neo4j driver.</param>
    /// <returns>a new plugin that runs against the <paramref name="driver" />.</returns>
    public static async ValueTask<DriverPlugin> FromDriverAsync(IDriver driver)
    {
        await driver.VerifyConnectivityAsync();
        var functions = await DriverKernelFunctionFactory.BuildAsync(driver);
        var plugin = new DriverPlugin(functions);
        return plugin;
    }
}