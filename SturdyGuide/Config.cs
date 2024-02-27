using Microsoft.Extensions.Configuration;

namespace SturdyGuide;

internal sealed class Config
{
    private static readonly Lazy<IConfigurationRoot> ConfigValues;

    static Config()
    {
        ConfigValues = new Lazy<IConfigurationRoot>(() =>
                new ConfigurationBuilder()
                    .AddUserSecrets<Config>()
                    .AddJsonFile("./appsettings.json")
                    .Build(),
            LazyThreadSafetyMode.ExecutionAndPublication);
    }

    public static string ApiKey => ConfigValues.Value["OAI:ApiKey"] ??
                                   throw new InvalidOperationException("secret for api key not loaded");

    public static string ModelName => ConfigValues.Value["Model"] ??
                                      throw new InvalidOperationException("'Model' missing from appsettings");
}