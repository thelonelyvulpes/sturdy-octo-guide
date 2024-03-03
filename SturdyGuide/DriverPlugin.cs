using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using Microsoft.SemanticKernel;
using Neo4j.Driver;

namespace SturdyGuide;

public sealed class DriverPlugin : KernelPlugin
{
    private const string driverPluginDescription = "";
    private readonly IReadOnlyList<KernelFunction> _functions;
    private readonly FrozenDictionary<string, KernelFunction> _kernelFunctionDictionary;

    private DriverPlugin(IReadOnlyList<KernelFunction> functions)
        : base(nameof(DriverPlugin), driverPluginDescription)
    {
        _functions = functions;
        _kernelFunctionDictionary = _functions.ToFrozenDictionary(x => x.Name, x => x);
    }

    public override int FunctionCount => _functions.Count;

    public override bool TryGetFunction(string name, [UnscopedRef] out KernelFunction? function)
    {
        return _kernelFunctionDictionary.TryGetValue(name, out function);
    }

    public override IEnumerator<KernelFunction> GetEnumerator()
    {
        return _functions.GetEnumerator();
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