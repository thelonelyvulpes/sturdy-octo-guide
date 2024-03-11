using Microsoft.Extensions.Configuration;

namespace CreateKnowledgeGraph;

internal sealed class Config
{
    private static readonly Lazy<IConfigurationRoot> ConfigValues;

    static Config()
    {
        ConfigValues = new Lazy<IConfigurationRoot>(() =>
                new ConfigurationBuilder()
                    .AddJsonFile("./appsettings.json")
                    .Build(),
            LazyThreadSafetyMode.ExecutionAndPublication);
    }

    public static string DataCollection => ConfigValues.Value["DataCollection"] ??
                                           throw new InvalidOperationException(
                                               "'DataCollection' missing from appsettings");
}