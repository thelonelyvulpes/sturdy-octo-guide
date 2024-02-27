using Microsoft.SemanticKernel;
using Neo4j.Driver;

namespace SturdyGuide;

internal sealed class KernelFactory
{
    internal static Kernel BuildKernel(IDriver driver)
    {
        var builder = Kernel.CreateBuilder();
        builder.AddOpenAIChatCompletion(Config.ModelName, Config.ApiKey);
        builder.Plugins.AddFromObject(new DriverPlugin(driver));
        return builder.Build();
    }
}