using Activu.KeyVault;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Desktop.Shared
{
    internal class ConfigureKeyVaultOptions : IConfigureOptions<KeyVaultOptions>
    {
        private const string KeyVaultSection = "KeyVault";

        private readonly IConfiguration Config;

        public ConfigureKeyVaultOptions(IConfiguration Config)
        {
            this.Config = Config;
        }

        public void Configure(KeyVaultOptions options)
        {
            Config.Bind(KeyVaultSection, options);
        }
    }
}
