using Microsoft.SemanticKernel;

namespace SturdyGuide;

internal sealed class KernelFactory
{
    internal static Kernel BuildKernel()
    {
        var builder = Kernel.CreateBuilder();
        builder.AddOpenAIChatCompletion(Config.ModelName, Config.ApiKey);
        return builder.Build();
    }
}