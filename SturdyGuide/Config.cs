using Microsoft.Extensions.Configuration;

namespace SturdyGuide;

internal sealed class Config
{
    private static readonly Lazy<IConfigurationRoot> ConfigValues;

    static Config()
    {
        ConfigValues = new Lazy<IConfigurationRoot>(() =>
        {
            var cb = new ConfigurationBuilder();
            cb.AddUserSecrets<Config>();
            return cb.Build();
        }, LazyThreadSafetyMode.ExecutionAndPublication);
    }

    public static string ApiKey => ConfigValues.Value["OAI:ApiKey"] ??
                                   throw new InvalidOperationException("secret for api key not loaded");
}