using Microsoft.SemanticKernel;

namespace SturdyGuide;

internal sealed class KernelFactory
{
    internal static Kernel BuildKernel(params object[] plugins)
    {
        var builder = Kernel.CreateBuilder();
        builder.AddOpenAIChatCompletion(Config.ModelName, Config.ApiKey);
        foreach (var plugin in plugins) builder.Plugins.AddFromObject(plugin);
        return builder.Build();
    }
}