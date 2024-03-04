using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;

namespace SturdyGuide;

internal static class KernelFactory
{
    internal static Kernel BuildKernel(ILoggerFactory loggerFactory, params Action<IKernelBuilderPlugins>[] plugins)
    {
        var builder = Kernel.CreateBuilder();
        builder.Services.AddSingleton(loggerFactory);
        builder.AddOpenAIChatCompletion(Config.ModelName, Config.ApiKey);
        foreach (var plugin in plugins)
            plugin(builder.Plugins);
        return builder.Build();
    }
}